using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dal.Connection;


namespace Dal.Handler
{
    public class clsHandlerContabilidadDal
    {

        public clsHandlerContabilidadDal()
        {

        }


   
    /// <summary>
    /// Precondiciones: El atributo image del parametro clsPerson en caso de no ser nulo, debe ser una url válida de una imagen
    /// Postcondiciones: Si se puede realizar correctamente la inserción, la persona se insertara en la base de datos
    /// Descripcion: Este metodo usa sentencias de sql para insertar la persona
    /// </summary>
    /// <param name="clsPerson"> La persona que queremos insertar en la base de datos</param>
    /// <returns>int Las filas afectadas</returns>
    public int insertContabilidad(clsContabilidad clsContabilidad)
    {

        SqlCommand sqlCommand = new SqlCommand();
        SqlConnection sqlConnection = null;
        clsMyConnection clsMyConnection = new clsMyConnection();
        int rowsAffected;


        sqlCommand.Parameters.Add("@fecha", System.Data.SqlDbType.DateTime).Value = clsContabilidad.fecha;
        sqlCommand.Parameters.Add("@recaudacionDada", System.Data.SqlDbType.Float).Value = clsContabilidad.recaudacionDada;
        sqlCommand.Parameters.Add("@recaudacionReal", System.Data.SqlDbType.Float).Value = clsContabilidad.recaudacionReal;




        try
        {
            sqlConnection = clsMyConnection.getConnection();
            sqlCommand.CommandText = "INSERT INTO contabilidad VALUES (@fecha, @recaudacionDada, @recaudacionReal)";
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



    }
}
