using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TodoListApp.Model
{
    public class TodoList
    {
        public int idTarea { get; set; }
        public String Titulo { get; set; }
        public String Descripcion { get; set; }
        public String Fecha { get; set; }
        public String status { get; set; }
    }
}
