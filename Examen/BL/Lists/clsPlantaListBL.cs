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
        /// Postcondiciones: Devuelve lo que devuelve el metodo getPlantasByCategorias(int id) de la capa dal
        /// Descripcion: En este metodo incluiremos las reglas de negocio
        /// </summary>
        /// <param name="id">La id de la categoria</param>
        /// <returns>clsPerson La lista que devuelve el metodo getPlantasByCategorias(int id) de la capa dal</returns>
        public List<clsPlanta> getPlantasByCategorias (int id)
        {
            return new clsPlantaListDal().getPlantasByCategorias(id);
        }
        #endregion


    }
}
