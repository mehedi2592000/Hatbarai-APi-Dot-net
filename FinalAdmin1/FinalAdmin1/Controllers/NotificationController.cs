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
    public class NotificationController : ApiController
    {
        [Route("api/notification/GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAllMessage()
        {
            return Request.CreateResponse(HttpStatusCode.OK, NotificationServices.GetAllNotification());
        }

        [Route("api/notification/GetAllindex/{id}")]
        [HttpGet]
        public HttpResponseMessage GetindexAllMessage(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, NotificationServices.GetindexNotification(id));
        }

        [Route("api/notification/EditNotification")]
        [HttpPost]
        public HttpResponseMessage EditMessage(NotificationModel m)
        {
            var data = NotificationServices.EditMessage(m);
            return Request.CreateResponse(data ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/notification/AddNotification")]
        [HttpPost]
        public HttpResponseMessage AddMessage(NotificationModel m)
        {
            var data = NotificationServices.AddedMessage(m);
            return Request.CreateResponse(data ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }
        [Route("api/notification/DeleteNotification/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteMessage(int id)
        {
            var data = NotificationServices.DeleteMeesga(id);
            return Request.CreateResponse(data ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/notification/FindAll")]
        [HttpGet]
        public HttpResponseMessage FindMessage()
        {
            return Request.CreateResponse(HttpStatusCode.OK, NotificationServices.FindNotification());
        }
    }
}
