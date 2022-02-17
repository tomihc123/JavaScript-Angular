using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class clsPlanta
    {

        #region Properties 
        public int idPlanta { get; set; }
        public string nombrePlanta { get; set; }
        public string descripcion { get; set; }
        [Required]
        [DisplayName("Precio")]
        public double precio { get; set; }
        public int idCategoria { get; set; }
        #endregion

        #region Constructors 
        //Constructor por defecto
        public clsPlanta()
        {
        }

        //Constructor con parametros
        public clsPlanta(string nombrePlanta, string descripcion, double precio, int idCategoria)
        {
            this.nombrePlanta = nombrePlanta;
            this.descripcion = descripcion;
            this.precio = precio;
            this.idCategoria = idCategoria;

        }


        public clsPlanta(clsPlanta clsPlanta)
        {
            this.nombrePlanta = clsPlanta.nombrePlanta;
            this.descripcion = clsPlanta.descripcion;
            this.precio = clsPlanta.precio;
            this.idCategoria = clsPlanta.idCategoria;

        }


        //Constructor con parametros
        public clsPlanta(int id, string name, string descripcion, int idcategoria, double precio)
        {
            this.idPlanta = id;
            this.nombrePlanta = name;
            this.descripcion = descripcion;
            this.precio = precio;
            this.idCategoria = idcategoria;
        }
        #endregion


        public clsPlanta(int id, double precio)
        {
            this.idPlanta = id;
            this.precio = precio;
        }

    }
}
