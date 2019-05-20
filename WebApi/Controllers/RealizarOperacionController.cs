using Cube_Summation.Services.Interfaces;
using Cube_Summation.Services.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Operacion")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RealizarOperacionController : ApiController
    {
        private readonly IOperacion _Ioperacion = new SOperacion();

        [HttpPost, Route("GetResult")]
        public HttpResponseMessage ObtenerResultado(Operacion operacion)
        {
            try
            {
                List<string> _result = _Ioperacion.Realizar(p_texto: operacion.operacion);
                var _anonymousType = new { result = _result };
                return Request.CreateResponse(HttpStatusCode.OK, _anonymousType);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet, Route("ok")]
        public HttpResponseMessage OK()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "(Y)");
        }
    }
}
