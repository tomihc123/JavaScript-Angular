using Dal.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Lists
{
    public class clsPlantaListDal
    {
        #region Constructor
        public clsPlantaListDal()
        {

        }
        #endregion


        #region Methods
        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Que la persona devuelta tenga la misma id que el parametro
        /// Descripcion: Este metodo te devuelve de la base de datos la persona cuyo id coincide con el parámetro que pasamos al metodo
        /// </summary>
        /// <param name="id">La id de la persona que queremos obtener</param>
        /// <returns>Type: clsPerson La persona de la base de datos</returns>
        public clsPlanta getPlanta(int id)
        {


            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPlanta clsPlanta = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;

            try
            {
                //Obtenemos la conexion
                connection = clsMyConnection.getConnection();
                command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                command.CommandText = "Select * FROM plantas WHERE idPlanta = @ID";
                command.Connection = connection;
                reader = command.ExecuteReader();


                //Si hay filas
                if (reader.HasRows)
                {
                    //Mientras se pueda leer
                    while (reader.Read())
                    {

                        clsPlanta = new clsPlanta();

                        clsPlanta.idPlanta = (int)reader["idPlanta"];

                        clsPlanta.nombrePlanta = (string)reader["nombrePlanta"];

                        //En realidad nunca van a ser nulos porque hacemos las validaciones en el cliente, pero por si acaso
                        if (reader["descripcion"] != DBNull.Value)
                        {
                            clsPlanta.descripcion = (string)reader["descripcion"];
                        }

                        if (reader["precio"] == System.DBNull.Value)
                        {
                            clsPlanta.precio = 0;
                        }
                        else
                        {
                            clsPlanta.precio = (double)reader["precio"]; ;

                        }

                        if (reader["idCategoria"] != DBNull.Value)
                        {
                            clsPlanta.idCategoria = (int)reader["idCategoria"];
                        }

                    }
                }


                clsMyConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }

            return clsPlanta;

        }


       

        /// <summary>
        /// Precondiciones: La id debe existir en la base de datos
        /// Postcondiciones: Devolvera una lista de personas cuyo departamento es la id pasada por parametro
        /// Descripcion: Usa sentencias sql para obtener los resultados
        /// </summary>
        /// <param name="id">La id del departamento</param>
        /// <returns>List<clsPerson> la lista de personas</returns>
        public List<clsPlanta> getPlantasByCategorias(int id)
        {

            List<clsPlanta> clsPlantas = new List<clsPlanta>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPlanta clsPlanta;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;



            try
            {
                connection = clsMyConnection.getConnection();
                command.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id;
                command.CommandText = "Select * FROM plantas WHERE idCategoria = @ID";
                command.Connection = connection;
                reader = command.ExecuteReader();


                //Si hay filas
                if (reader.HasRows)
                {
                    //Mientras se pueda leer
                    while (reader.Read())
                    {
                        clsPlanta = new clsPlanta();

                        clsPlanta.idPlanta = (int)reader["idPlanta"];

                        clsPlanta.nombrePlanta = (string)reader["nombrePlanta"];

                        //En realidad nunca van a ser nulos porque hacemos las validaciones en el cliente, pero por si acaso
                        if (reader["descripcion"] != DBNull.Value)
                        {
                            clsPlanta.descripcion = (string)reader["descripcion"];
                        }

                        if (reader["precio"] == System.DBNull.Value)
                        {
                            clsPlanta.precio = 0;
                        } else
                        {
                            clsPlanta.precio = (double)reader["precio"]; ;

                        }

                        if (reader["idCategoria"] != DBNull.Value)
                        {
                            clsPlanta.idCategoria = (int)reader["idCategoria"];
                        }

                        clsPlantas.Add(clsPlanta);

                    }
                }


                clsMyConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }


            return clsPlantas;
        }



        /// <summary>
        /// Precondiciones: La id debe existir en la base de datos
        /// Postcondiciones: Devolvera una lista de personas cuyo departamento es la id pasada por parametro
        /// Descripcion: Usa sentencias sql para obtener los resultados
        /// </summary>
        /// <param name="id">La id del departamento</param>
        /// <returns>List<clsPerson> la lista de personas</returns>
        public List<clsPlanta> getPlantas()
        {

            List<clsPlanta> clsPlantas = new List<clsPlanta>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPlanta clsPlanta;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;



            try
            {
                connection = clsMyConnection.getConnection();
                command.CommandText = "Select * FROM plantas";
                command.Connection = connection;
                reader = command.ExecuteReader();


                //Si hay filas
                if (reader.HasRows)
                {
                    //Mientras se pueda leer
                    while (reader.Read())
                    {
                        clsPlanta = new clsPlanta();

                        clsPlanta.idPlanta = (int)reader["idPlanta"];

                        clsPlanta.nombrePlanta = (string)reader["nombrePlanta"];

                        //En realidad nunca van a ser nulos porque hacemos las validaciones en el cliente, pero por si acaso
                        if (reader["descripcion"] != DBNull.Value)
                        {
                            clsPlanta.descripcion = (string)reader["descripcion"];
                        }

                        if (reader["precio"] == System.DBNull.Value)
                        {
                            clsPlanta.precio = 0;
                        }
                        else
                        {
                            clsPlanta.precio = (double)reader["precio"]; ;

                        }

                        if (reader["idCategoria"] != DBNull.Value)
                        {
                            clsPlanta.idCategoria = (int)reader["idCategoria"];
                        }

                        clsPlantas.Add(clsPlanta);

                    }
                }


                clsMyConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }


            return clsPlantas;
        }


        #endregion
    }
}

