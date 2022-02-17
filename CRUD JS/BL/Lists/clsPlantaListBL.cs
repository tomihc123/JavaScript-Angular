using Dal.Handler;
using Dal.Lists;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Lists
{
    public class clsPlantaListBL
    {

        #region Constructor
        public clsPlantaListBL()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Devuelve lo que devuelve el metodo getPersons() de la capa dal
        /// Descripcion: En este metodo incluiremos las reglas de negocio
        /// </summary>
        /// <returns>List<clsPerson> Las lista de personas que devuelve el metodo getPersons() de la capa dal</returns>
        public clsPlanta getPlanta(int id)
        {

            return new clsPlantaListDal().getPlanta(id);

        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Devuelve lo que devuelve el metodo getPerson(int id) de la capa dal
        /// Descripcion: En este metodo incluiremos las reglas de negocio
        /// </summary>
        /// <param name="id">La id de la persona que queremos obtener</param>
        /// <returns>clsPerson La persona que devuelve el metodo getPerson(int id) de la capa dal</returns>
        public List<clsPlanta> getPlantasByCategorias (int id)
        {
            return new clsPlantaListDal().getPlantasByCategorias(id);
        }
        #endregion


        public List<clsPlanta> getPlantas()
        {
            return new clsPlantaListDal().getPlantas();
        }


    }
}
