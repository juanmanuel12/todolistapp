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
    public partial class ModificarTarea : Form
    {
        public List<TodoList> lstTodoList;
        private TodoListRepository _todolistRepository;
        public ModificarTarea()
        {
            InitializeComponent();
            lstTodoList = new List<TodoList>();
            _todolistRepository = new TodoListRepository();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblid_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            TodoList todoList = _todolistRepository.buscarPorId(id);

            txtTitulo.Text = todoList.Titulo;
            txtDescripcion.Text = todoList.Descripcion;
            txtFecha.Text = todoList.Fecha;
            txtStatus.Text = todoList.status;
            txtid.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "")
            {

                errorProviderModificar.SetError(txtTitulo, "Se debe ingresar Titulo");
                txtTitulo.Focus();
                    return;
            }

            if (txtFecha.Text == "")
            {

                errorProviderModificar.SetError(txtFecha, "Se debe ingresar Fecha");
                txtFecha.Focus();
                return;
            
            }

            if (txtStatus.Text == "")
            { 
            
                errorProviderModificar.SetError(txtStatus,"Se debe ingresar Status");
                
                txtStatus.Focus();
                return;       
            }

            if (txtDescripcion.Text == "")
            {

                errorProviderModificar.SetError(txtDescripcion, "Se debe ingresar Descripcion");
                txtStatus.Focus();
                return;
            }
            
            TodoList todoList = new TodoList();
           
            todoList.Titulo = txtTitulo.Text;
            todoList.Descripcion = txtDescripcion.Text;
            todoList.Fecha = txtFecha.Text;
            todoList.status = txtStatus.Text;
            todoList.idTarea = int.Parse(txtid.Text);
            if (_todolistRepository.actualizarid(todoList))
            {
                MessageBox.Show("Registro Actualizado con éxito");
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el registro");
            }

          
            Limpiar();
        }

        public void Limpiar()
        {
            txtTitulo.Text = "";
            txtDescripcion.Text = "";
            txtFecha.Text = "";
            txtStatus.Text = "";
            txtid.Text = "";
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

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
