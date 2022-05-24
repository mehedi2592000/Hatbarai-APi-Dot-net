using Business_Entity_Layer.DataModel;
using Business_Logic_Layer.Services;
using FinalAdmin1.Auth;
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
    public class UserController : ApiController
    {
        [CustomAuth]
        [Route("api/user/list")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserServices.GetallUser());
        }

        [Route("api/user/list/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserServices.GetUser(id));
        }

        [Route("api/user/edit")]
        [HttpPost]
        public HttpResponseMessage EditUser(UserModel e)
        {
            return Request.CreateResponse(UserServices.EditUser(e) ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/user/add")]
        [HttpPost]
        public HttpResponseMessage AddUser(UserModel e)
        {
            bool sucess = UserServices.Adduser(e);
            return Request.CreateResponse(sucess ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/user/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Deleteuser(int id)
        {
            bool sucess = UserServices.Deleteuser(id);
            return Request.CreateResponse(sucess ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }
        /*
        [Route("api/user/email")]
        [HttpGet]
        public HttpResponseMessage Checkmail(string email)
        {
            bool 
        }
        */

        [Route("api/user/UserList")]
        [HttpGet]
        public HttpResponseMessage UserList()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserServices.GetAlluse());
        }
        [Route("api/user/volunteerList")]
        [HttpGet]
        public HttpResponseMessage VolunteerList()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserServices.GetAllVolunteer());
        }
        [Route("api/user/agencyList")]
        [HttpGet]
        public HttpResponseMessage AgencyList()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserServices.GetAllAgency());
        }

        [Route("api/user/numofvolunteer")]
        [HttpGet]
        public HttpResponseMessage numvolunteer()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserServices.TotalVolunteer());
        }
        [Route("api/user/numofAgency")]
        [HttpGet]
        public HttpResponseMessage numAgency()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserServices.TotalAgency());
        }
        [Route("api/user/numofUser")]
        [HttpGet]
        public HttpResponseMessage numUser()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserServices.TotalUser());
        }
        
        [Route("api/user/Totalmoneyadmin")]
        [HttpGet]
        public HttpResponseMessage Totalmoneyadmine()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserServices.Totalmoneyadmin());
        }
    }
}
