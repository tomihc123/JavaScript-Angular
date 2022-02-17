using Dal.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Handler
{
    public class clsHandlerPlantaDal
    {

        #region  Constructor
        public clsHandlerPlantaDal()
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// Precondiciones: El atributo image del parametro clsPerson en caso de no ser nulo, debe ser una url válida de una imagen
        /// Postcondiciones: Si se puede realizar correctamente la inserción, la persona se insertara en la base de datos
        /// Descripcion: Este metodo usa sentencias de sql para insertar la persona
        /// </summary>
        /// <param name="clsPerson"> La persona que queremos insertar en la base de datos</param>
        /// <returns>int Las filas afectadas</returns>
        public int insertPlanta(clsPlanta clsPlanta)
        {

            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            int rowsAffected;


            sqlCommand.Parameters.Add("@nombrePlanta", System.Data.SqlDbType.VarChar).Value = clsPlanta.nombrePlanta;
            sqlCommand.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar).Value = clsPlanta.descripcion;
            sqlCommand.Parameters.Add("@precio", System.Data.SqlDbType.Float).Value = clsPlanta.precio;
            sqlCommand.Parameters.Add("@idCategoria", System.Data.SqlDbType.Int).Value = clsPlanta.idCategoria;


            try
            {
                sqlConnection = clsMyConnection.getConnection();
                sqlCommand.CommandText = "INSERT INTO plantas VALUES (@nombrePlanta, @descripcion, @precio, @idCategoria)";
                sqlCommand.Connection = sqlConnection;
                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                clsMyConnection.closeConnection(ref sqlConnection);
            }

            return rowsAffected;

        } 


        /// <summary>
        /// Precondiciones: El atributo image del parametro clsPerson en caso de no ser nulo, debe ser una url válida de una imagen
        /// Postcondiciones: Si se puede realizar correctamente la actualización, la persona se actualizara en la base de datos
        /// Descripcion: Este metodo usa sentencias de sql para actualizar la persona
        /// </summary>
        /// <param name="clsPerson"> La persona que queremos actualizar en la base de datos</param>
        /// <returns>int Las filas afectadas</returns>
        public int updatePlanta(clsPlanta clsPlanta)
        {

            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            int rowsAffected;

            try
            {
                sqlConnection = clsMyConnection.getConnection();

                sqlCommand.Parameters.Add("@idPlanta", System.Data.SqlDbType.VarChar).Value = clsPlanta.idPlanta;
                sqlCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = clsPlanta.nombrePlanta;
   


                sqlCommand.CommandText = "UPDATE plantas SET nombrePlanta = @nombre WHERE idPlanta = @idPlanta";
                sqlCommand.Connection = sqlConnection;
                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                clsMyConnection.closeConnection(ref sqlConnection);
            }

            return rowsAffected;


        }


        /// <summary>
        /// Precondiciones: La id debe existir en la base de datos
        /// Postcondiciones: Si se puede realizar correctamente la eliminación, la persona cuya id es la pasado por parámetro se eliminara en la base de datos
        /// Descripcion: Este metodo usa sentencias de sql para eliminar la persona
        /// </summary>
        /// <param name="id">La id de la persona que queremos eliminar</param>
        /// <returns>int Las filas afectadas</returns>
        /// 
        public int deletePlanta(int id)
        {

            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            int rowsAffected;

            try
            {
                sqlConnection = clsMyConnection.getConnection();
                sqlCommand.Parameters.Add("@idPlanta", System.Data.SqlDbType.VarChar).Value = id;
                sqlCommand.CommandText = "DELETE  FROM plantas WHERE idPlanta = @idPlanta ";
                sqlCommand.Connection = sqlConnection;
                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                clsMyConnection.closeConnection(ref sqlConnection);
            }

            return rowsAffected;


        }

        #endregion

    }


}
