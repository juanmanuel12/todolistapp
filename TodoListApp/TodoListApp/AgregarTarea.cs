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
    public partial class AgregarTarea : Form
    {
        public List<TodoList> lstTodoList;
        private TodoListRepository _todolistRepository;
        public AgregarTarea()
        {
            InitializeComponent();
            lstTodoList = new List<TodoList>();
            _todolistRepository = new TodoListRepository();
        }


        public void Limpiar()
        {
            txt_titulo.Text = "";
            txt_descripcion.Text = "";
        
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txt_titulo.Text == "")
            {
                errorProviderAgregar.SetError(txt_titulo, "Debe Ingresar Titulo");
                txt_titulo.Focus();
                return;
            }


            if (txt_descripcion.Text == "")
            {
                errorProviderAgregar.SetError(txt_descripcion, "Debe Ingresar Descripcion");
                txt_descripcion.Focus();
                return;
            }



            TodoList todoList = new TodoList();
            todoList.Titulo = txt_titulo.Text;
            todoList.Descripcion = txt_descripcion.Text;
            todoList.status = "Activo";
            todoList.Fecha = DateTime.Now.ToString("dd/MMMM/yy");
            _todolistRepository.AgregarNuevaTarea(todoList);

            if (_todolistRepository.actualizarid(todoList))
            {
                MessageBox.Show("Registro se Elimino  con éxito");
            }
            else
            {
                MessageBox.Show("Registro No se Elimino  con éxito");
            }

            Limpiar();
        }

        public void SoloCaracter(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsControl(e.KeyChar))
                {
                    e.Handled = false;

                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo Acepta Caracter", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (FormatException)
            {

            }
        }


        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txt_titulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloCaracter(e);
        }

        private void txt_descripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
           // SoloCaracter(e);
        }

        private void AgregarTarea_Load(object sender, EventArgs e)
        {

        }
    }
}
