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
    [EnableCors("*","*","*")]
    public class AuthController : ApiController
    {
        [Route("api/logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            if(token!=null)
            {
                var rs=AuthServices.Logout(token);
                if(rs)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.OK, "sucess full");
                }
                
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "soryy");
        }
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Auth(UserModel user)
        {
            var data = AuthServices.Auth(user);
            if(data!=null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "user the pro");
        }
    }
}
