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
    public partial class ListarTodoList : Form
    {
        private TodoListRepository _todoListoRepository;
        public ListarTodoList()
        {
            InitializeComponent();
            _todoListoRepository = new TodoListRepository();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarTarea frm = new AgregarTarea();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarTodoList eliminar = new EliminarTodoList();
            eliminar.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModificarTarea modificar = new ModificarTarea();
            modificar.ShowDialog();
        }

        private void ListarTodoList_Load(object sender, EventArgs e)
        {
            List<TodoList> lstTodoList = _todoListoRepository.obtenerTodaslasTareas();
            dgvTodasLasTareas.DataSource = lstTodoList;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
    }
}
