using Dal.Lists;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Lists
{
    public class clsCategoriaListBL
    {
        #region Constructor
        public clsCategoriaListBL()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Devuelve lo que devuelve el método getDepartaments() de la capa dal
        /// Descripcion: En este metodo incluiremos las reglas de negocio
        /// </summary>
        /// <returns>List<clsDepartament> La lista con todos los departamentos que devuelve el método getDepartaments() de la capa dal </returns>
        public List<clsCategoria> getCategorias()
        {

            return new clsCategoriaListDal().getCategorias();


        }

        #endregion

    }
}
