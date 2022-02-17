using BL.Handler;
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
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<clsPlanta> Get()
        {
            return new clsPlantaListBL().getPlantas();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public clsPlanta Get(int id)
        {
            return new clsPlantaListBL().getPlanta(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] clsPlanta clsPlanta)
        {

            IActionResult result = null;
            int numeroFilasAfectadas = 0;

            try
            {
                numeroFilasAfectadas = new clsHandlerPlantaBL().insertPlanta(clsPlanta);
            }
            catch (HttpResponseException e)
            {
                result = BadRequest();
            }
            if (numeroFilasAfectadas == 0)
            {
                result = NoContent();
            }
            else
            {
                result = Ok();
            }
            return result;

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] clsPlanta clsPlanta)
        {

            IActionResult result = null;
            int numeroFilasAfectadas = 0;

            try
            {
                numeroFilasAfectadas = new clsHandlerPlantaBL().updatePlanta(clsPlanta);
            }
            catch (HttpResponseException e)
            {
                result = BadRequest();
            }
            if (numeroFilasAfectadas == 0)
            {
                result = NoContent();
            }
            else
            {
                result = Ok();
            }
            return result;

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            IActionResult result = null;
            int numeroFilasAfectadas = 0;

            try
            {
                numeroFilasAfectadas = new clsHandlerPlantaBL().deletePlanta(id);
            }
            catch (HttpResponseException e)
            {
                result = BadRequest();
            }
            if (numeroFilasAfectadas == 0)
            {
                result = NoContent();
            }
            else
            {
                result = Ok();
            }
            return result;
        }
    }
}
