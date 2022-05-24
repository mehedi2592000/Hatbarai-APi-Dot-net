using Business_Entity_Layer.DataModel;
using Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FinalAdmin1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AgencyController : ApiController
    {
        [Route("api/agency/AllAgency")]
        [HttpGet]
        public HttpResponseMessage AllAgency()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AgencyServices.GetAllAgency());
        }

        [Route("api/agency/intAgency/{id}")]
        [HttpGet]
        public HttpResponseMessage intAgency(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AgencyServices.GetAgency(id));
        }

        [Route("api/agency/EditAgency")]
        [HttpPost]
        public HttpResponseMessage EditAgency(AgencyModel e)
        {
            bool sucess = AgencyServices.EditAgency(e);

            return Request.CreateResponse(sucess ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/agency/AddAgency")]
        [HttpPost]
        public HttpResponseMessage AddAgency(AgencyModel e)
        {
            bool sucess = AgencyServices.AddAgency(e);
            return Request.CreateResponse(sucess ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/agency/DeleteAgency/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteAgency(int id)
        {
            bool sucess = AgencyServices.DeleteAgency(id);
            return Request.CreateResponse(sucess ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/agency/serachAgency/{name}")]
        [HttpGet]
        public HttpResponseMessage SearchAgency(string name)
        {
            return Request.CreateResponse(HttpStatusCode.OK, AgencyServices.FindAgency(name));
        }

       /* [Route("api/agency/TotalmoneyAgency")]
        [HttpGet]
        public HttpResponseMessage TotalMoney()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AgencyServices.AgencyTotalmoney());
        }

        [Route("api/agency/MaxmoneyAgency")]
        [HttpGet]
        public HttpResponseMessage MaxMoney()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AgencyServices.AgencyMaxmoney());
        }
       */

    }
}
