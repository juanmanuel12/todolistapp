using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BodegaRopaFuncionesGenerales;

namespace TodoListApp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            General.Conexion.BaseDeDatos = "bodega";
            General.Conexion.Usuario = "sysprogsropa";
            General.Conexion.Password = "8a4b0941b40d417c877babbca3a84dec";
            General.Conexion.TipoServer = TipoServer.Postgres;
            //General.Conexion.Servidor = "10.44.157.104";
            //General.Conexion.Servidor = "10.44.172.221";
            General.Conexion.Servidor = "10.28.114.110";
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ListarTodoList());
        }
    }
}
