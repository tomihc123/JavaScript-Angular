using Dal.Handler;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Handler
{
    public class clsHandlerContabilidadBL
    {


        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: LLamara a la funcion updatePerson(clsPerson person) de la capa dal
        /// Descripcion: En este metodo se incluirán las reglas de negocios
        /// </summary>
        /// <param name="person">La persona que pasamos la funcion updatePerson(clsPerson person) de la capa dal</param>
        /// <returns>int el numero de filas afectadas que devuelve el metodo updatePerson(clsPerson person) de la capa dal</returns>
        public int isnertContabilidad(clsContabilidad clsContabilidad)
        {
            return new clsHandlerContabilidadDal().insertContabilidad(clsContabilidad);
        }


    }
}
