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
    public class OrphansController : ApiController
    {
        [Route("api/orphan/Allorphanchild")]
        [HttpGet]
        public HttpResponseMessage AllOrphanList()
        {
            return Request.CreateResponse(HttpStatusCode.OK, OrphanService.GetAllOrphan());
        }

        [Route("api/orphan/Allorphanlist/{id}")]
        [HttpGet]
        public HttpResponseMessage idListOrphan(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, OrphanService.GetAllOrphan(id));
        }

        [Route("api/orphan/EditOrphan")]
        [HttpPost]
        public HttpResponseMessage EditOrphan(OrphanModel e)
        {
            return Request.CreateResponse(OrphanService.EditOrphan(e) ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/orphan/AddOrphan")]
        [HttpPost]
        public HttpResponseMessage AddOrphan(OrphanModel e)
        {
            bool suceff = OrphanService.AddOrphan(e);
            return Request.CreateResponse(suceff ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/orphan/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteOrphan(int id)
        {
            bool sucess = OrphanService.DeleteOrphan(id);
            return Request.CreateResponse(sucess ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/orphan/Findbyname/{name}")]
        [HttpGet]
        public HttpResponseMessage FindStudent(string name)
        {
            return Request.CreateResponse(HttpStatusCode.OK, OrphanService.SearchnameOrphan(name));
        }

        [Route("api/orphan/totalOrphan")]
        [HttpGet]
        public HttpResponseMessage TotalOrphan()
        {
            return Request.CreateResponse(HttpStatusCode.OK, OrphanService.TotalOrphan());
        }
    }
}
