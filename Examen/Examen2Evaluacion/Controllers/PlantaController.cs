using BL.Lists;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examen2Evaluacion.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PlantaController : ControllerBase
    {

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IEnumerable<clsPlanta> Get(int id)
        {
            return new clsPlantaListBL().getPlantasByCategorias(id);
        }

        
    }
}
