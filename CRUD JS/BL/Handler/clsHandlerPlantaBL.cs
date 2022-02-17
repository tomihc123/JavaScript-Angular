using Dal.Handler;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Handler
{
    public class clsHandlerPlantaBL
    {

        #region Constructor
        public clsHandlerPlantaBL()
        {

        }
        #endregion


        #region Methods
        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: LLamara a la funcion updatePerson(clsPerson person) de la capa dal
        /// Descripcion: En este metodo se incluirán las reglas de negocios
        /// </summary>
        /// <param name="person">La persona que pasamos la funcion updatePerson(clsPerson person) de la capa dal</param>
        /// <returns>int el numero de filas afectadas que devuelve el metodo updatePerson(clsPerson person) de la capa dal</returns>
        public int updatePlanta(clsPlanta clsPlanta)
        {
            return new clsHandlerPlantaDal().updatePlanta(clsPlanta);
        }

        
        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: LLamara a la funcion insertPerson(clsPerson person) de la capa dal
        /// Descripcion: En este metodo se incluirán las reglas de negocios
        /// </summary>
        /// <param name="person">La persona que pasamos la funcion insertPerson(clsPerson person) de la capa dal</param>
        /// <returns>int el numero de filas afectadas que devuelve el metodo insertPerson(clsPerson person) de la capa dal</returns>
        public int insertPlanta(clsPlanta clsPlanta)
        {
            return new clsHandlerPlantaDal().insertPlanta(clsPlanta);
        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: LLamara a la funcion deletePerson(int id) de la capa dal
        /// Descripcion: En este metodo se incluirán las reglas de negocios
        /// </summary>
        /// <param name="id">La id que pasamos a la funcion deletePerson(int id) de la capa dal</param>
        /// <returns>int el numero de filas afectadas que devuelve el metodo deletePerson(int id) de la capa dal</returns>
        public int deletePlanta(int id)
        {

            return new clsHandlerPlantaDal().deletePlanta(id);

        } 

        #endregion

    }
}
