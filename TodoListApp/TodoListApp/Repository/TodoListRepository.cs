using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BodegaRopaFuncionesGenerales;
using TodoListApp.Model;

namespace TodoListApp.Repository
{
    public class TodoListRepository
    {
        #region Objetos de Conexiones
        private clsConexion_Odbc odbcConexion;
        private clsLeerGenerico odbcLector;
        private clsGrabarError odbcError;

        #endregion

        public bool AgregarNuevaTarea(TodoList todoList)
        {
            string sSql = "";
            bool bRegresa = false;
            odbcConexion = new clsConexion_Odbc(General.Conexion);
            odbcLector = new clsLeerGenerico(ref odbcConexion);
            odbcError = new clsGrabarError();

            try
            {
                if (odbcConexion.Abrir())
                {
                    sSql = String.Format("insert into TodoList (titulo,descripcion,status,fecha ) values ('{0}','{1}','{2}','{3}')", todoList.Titulo, todoList.Descripcion, todoList.status, todoList.Fecha);

                    if (odbcLector.Exec(sSql))
                    {
                        bRegresa = true;
                    }
                    else
                    {
                        bRegresa = false;
                    }
                }

            }
            catch (Exception e)
            {
                General.msjError("Ocurrio un error al ejecutar la consulta" + e.ToString());
            }
            finally
            {
                odbcConexion.Cerrar();
            }


            return bRegresa;
        }

        public List<TodoList> obtenerTodaslasTareas()
        {
            List<TodoList> lst = new List<TodoList>();
            string sSql = "";
            
            odbcConexion = new clsConexion_Odbc(General.Conexion);
            odbcLector = new clsLeerGenerico(ref odbcConexion);
            odbcError = new clsGrabarError();


            try
            {
                if (odbcConexion.Abrir())
                {
                    sSql = String.Format("select id_todolist,titulo,descripcion,status,fecha from TodoList");
                    if (odbcLector.Exec(sSql))
                    {
                        while (odbcLector.Leer())
                        {
                            lst.Add(new TodoList()
                            {
                                idTarea = odbcLector.CampoInt("id_todolist"),
                                Titulo = odbcLector.Campo("titulo"),
                                Descripcion = odbcLector.Campo("descripcion"),
                                status = odbcLector.Campo("status"),
                                Fecha = odbcLector.Campo("fecha")
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                General.msjError("Ocurrio un error al ejecutar la consulta" + e.ToString());
            }
            finally
            {
                odbcConexion.Cerrar();
            }

            return lst;
        }

        public TodoList buscarPorId(int id)
        {
            TodoList todolist = new TodoList();
            string sSql = "";

            odbcConexion = new clsConexion_Odbc(General.Conexion);
            odbcLector = new clsLeerGenerico(ref odbcConexion);
            odbcError = new clsGrabarError();
            try
            {
                if (odbcConexion.Abrir())
                {
                    sSql = String.Format("select id_todolist,titulo,descripcion,fecha,status from TodoList where id_todolist = {0}",id);
                    if (odbcLector.Exec(sSql))
                    {
                        if (odbcLector.Leer())
                        {
                            todolist.idTarea = odbcLector.CampoInt("id_todolist");
                            todolist.Titulo = odbcLector.Campo("titulo");
                            todolist.Descripcion = odbcLector.Campo("descripcion");
                            todolist.Fecha = odbcLector.Campo("fecha");
                            todolist.status = odbcLector.Campo("status");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                General.msjError("Ocurrio un error al ejecutar la consulta" + e.ToString());
            }
            finally
            {
                odbcConexion.Cerrar();
            }


            return todolist;
        }


        public bool eliminarporId(int d)
        {
            bool bRegresa = false;
           
            string sSql = "";

            odbcConexion = new clsConexion_Odbc(General.Conexion);
            odbcLector = new clsLeerGenerico(ref odbcConexion);
            odbcError = new clsGrabarError();
            try
            {
                if(odbcConexion.Abrir())
                {
                    sSql = String.Format("delete  from TodoList where id_todolist={0}",d);
                    if (odbcLector.Exec(sSql)) 
                    {
                        if (odbcLector.Leer())
                        {
                            bRegresa = true;
                        }
                        else 
                        {
                            bRegresa = false;
                        }
                    
                    }

                }

            }
            catch (Exception e)
            {
                General.msjError("Ocurrio un error al ejecutar la consulta" + e.ToString());
            }

            finally
            {
                odbcConexion.Cerrar();
            }
            return bRegresa;

        }




        public bool actualizarid(TodoList todoLista) 
        {      
            string sSql = "";
            bool bRegresa = false;
         
            odbcConexion = new clsConexion_Odbc(General.Conexion);
            odbcLector = new clsLeerGenerico(ref odbcConexion);
            odbcError = new clsGrabarError();

            try
            {
                if (odbcConexion.Abrir())
                {
                    sSql = String.Format("update TodoList set titulo='{0}' , descripcion='{1}' , fecha='{2}' , status='{3}' where id_todolist={4} ",todoLista.Titulo, todoLista.Descripcion,todoLista.Fecha,todoLista.status,todoLista.idTarea);
                    if (odbcLector.Exec(sSql))
                    {
                        bRegresa = true;
                    }
                    else
                    {
                        bRegresa = false;
                    }

                }

            }
            catch (Exception e)
            {
                General.msjError("Ocurrio un error al ejecutar la consulta" + e.ToString());
            }

            finally
            {
                odbcConexion.Cerrar();
            }
            return bRegresa;

        
        }
       
    }
}
