using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class clsContabilidad
    {

        public DateTime fecha { get; set; }
        public double recaudacionDada { get; set; }
         public double recaudacionReal { get; set; }

        public clsContabilidad(DateTime fecha, double recaudacionDada, double recaudacionReal)
        {
            this.fecha = fecha;
            this.recaudacionDada = recaudacionDada;
            this.recaudacionReal = recaudacionReal;

        }



}
}
