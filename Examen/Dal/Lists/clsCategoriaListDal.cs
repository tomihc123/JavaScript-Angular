using Dal.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Lists
{
    public class clsCategoriaListDal
    {

        #region Constructor
        public clsCategoriaListDal()
        {

        }
        #endregion


        #region Methods

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Tiene que devolver todas las categorias
        /// Devuelve las categorias de la bd
        /// </summary>
        /// <returns>List<clsCategoria> Un listado con todas las categorias de la base de datos</returns>
        public List<clsCategoria> getCategorias()
        {

            List<clsCategoria> listCategorias = new List<clsCategoria>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsCategoria clsCategoria;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;



            try
            {
                connection = clsMyConnection.getConnection();
                command.CommandText = "Select * FROM categorias";
                command.Connection = connection;
                reader = command.ExecuteReader();


                //If there are rows in the reader
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        clsCategoria = new clsCategoria();

                        clsCategoria.id = (int)reader["idCategoria"];

                        clsCategoria.name = (string)reader["nombreCategoria"];


                        listCategorias.Add(clsCategoria);
                    }
                }


                clsMyConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }


            return listCategorias;

        }

        #endregion

    }
}
