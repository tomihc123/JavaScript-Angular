using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class clsCategoria
    {

        #region Properties
        public int id { get; set; }
        public string name { get; set; }
        #endregion

        #region Constructors
        public clsCategoria()
        {

        }

        public clsCategoria(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        #endregion 


    }
}
