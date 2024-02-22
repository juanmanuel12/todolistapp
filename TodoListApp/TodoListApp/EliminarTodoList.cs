using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TodoListApp.Model;
using TodoListApp.Repository;

namespace TodoListApp
{
    public partial class EliminarTodoList : Form
    {

        public List<TodoList> lstTodoList;
        private TodoListRepository _todolistRepository;
        public EliminarTodoList()
        {
            InitializeComponent();
            lstTodoList = new List<TodoList>();
            _todolistRepository = new TodoListRepository();
        
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool BuscarId(int id)
        {
            bool bandera = true;

            _todolistRepository.buscarPorId(id);

          
            //foreach (TodoList todl in lstTodoList) 
            //{
            //    if (todl.idTarea == id) 
            //    {
            //        bandera = false;
            //        break;
            //    } 
            
            //}
            return bandera;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void EliminarTodoList_Load(object sender, EventArgs e)
        {

        }

        public void  Limpiar()
        
        {
            txt_id.Text = "";
            txtTitulo.Text = "";
            txtDescripcion.Text = "";


        }



        private void button1_Click(object sender, EventArgs e)
        {

            if (txt_id.Text == "") 
            {
                errorProviderEliminar.SetError(txt_id, "Se debe Ingresar ID");
                txt_id.Focus();
                return;
            
            }
            
            int id = int.Parse(txt_id.Text);
            TodoList todoList =   _todolistRepository.buscarPorId(id);

            txtTitulo.Text = todoList.Titulo;
            txtDescripcion.Text = todoList.Descripcion;
            txt_id.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "")
            {
                errorProviderEliminar.SetError(txt_id, "Se debe Ingresar ID");
                txt_id.Focus();
                return;

            }


            int id = int.Parse(txt_id.Text);
            TodoList todolistaelim = new TodoList();

           
           

            txt_id.Enabled = false;
            _todolistRepository.eliminarporId(id);

            if (_todolistRepository.actualizarid(todolistaelim))
            {
                MessageBox.Show("Registro se Elimino  con éxito");
            }
            else
            {
                MessageBox.Show("Registro No se Elimino  con éxito");
            }



            Limpiar();

        }

        public void SoloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo Acepta Numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (FormatException)
            {

            }
        }
        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }
    }
}
