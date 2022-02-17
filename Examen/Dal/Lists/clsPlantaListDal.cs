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


        /// <summary>
        /// Precondiciones: La id debe existir en la base de datos
        /// Postcondiciones: Devolvera una lista de plantas cuya idCategoria es la id pasada por parametro
        /// Descripcion: Usa sentencias sql para obtener los resultados
        /// </summary>
        /// <param name="id">La id de la categoria</param>
        /// <returns>List<clsPerson>List<clsPlanta> la lista con las plantas</returns>
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

    }
}

