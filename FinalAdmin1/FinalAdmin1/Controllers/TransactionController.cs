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
    public class TransactionController : ApiController
    {
        [Route("api/transaction/GetAllTransaction")]
        [HttpGet]
        public HttpResponseMessage GetAllTransaction()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionServices.GetAllTransction());
        }

        [Route("api/transaction/GetTransaction/{id}")]
        [HttpGet]
        public HttpResponseMessage GetindexTransacti(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionServices.GetindexTransction(id));
        }

        [Route("api/transaction/Add")]
        [HttpPost]
        public HttpResponseMessage AddAdmintoAdminTransaction(TransactionModel t)
        {
            bool data = TransactionServices.AddAdminTranscationtoAdmin(t);
            return Request.CreateResponse(data ? HttpStatusCode.OK: HttpStatusCode.BadRequest);
        }

        [Route("api/transaction/Delete/{id}")]
        [HttpGet]
        public HttpResponseMessage DeleteAnyTransaction(int id)
        {
            bool data = TransactionServices.DeleteTranscation(id);
            return Request.CreateResponse(data ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/transaction/Edit")]
        [HttpPost]
        public HttpResponseMessage EditTable(TransactionModel t)
        {
            bool data = TransactionServices.EditTransaction(t);
            return Request.CreateResponse(data ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/transation/RequestAgencyPandin")]
        [HttpGet]
        public HttpResponseMessage RequestAgencyPandinList()
        {

            return Request.CreateResponse(HttpStatusCode.OK, TransactionServices.RequesttoAgencyPeople());
        }
        [Route("api/transation/AccaptedRequestAgencyPandin")]
        [HttpPost]
        public HttpResponseMessage AccaptedRequestAgencyPandinEdit(TransactionModel t)
        {
            bool data = TransactionServices.RequestExaccapted(t);
            return Request.CreateResponse(data ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [Route("api/transaction/usertoAdminmoneyList")]
        [HttpGet]
        public HttpResponseMessage GetusertoadminList()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionServices.GetUsertoAdminmoneyList());
        }

        [Route("api/transation/TotalusertoadminModeney")]
        [HttpGet]
        public HttpResponseMessage TotalusertoadminMo()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionServices.TotalusertoadminModeney());
        }

        


        [Route("api/transation/TotaluserModeney")]
        [HttpGet]
        public HttpResponseMessage HightuserMoneye()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionServices.HightuserMoney());
        }

        [Route("api/transaction/VolunteertoAdminmoneyList")]
        [HttpGet]
        public HttpResponseMessage GetvolunteertoAdminmoneyLista()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionServices.GetvolunteertoAdminmoneyList());
        }

        [Route("api/transation/TotalVolunteertoadminModeney")]
        [HttpGet]
        public HttpResponseMessage TotalvolunteertoadminMoneye()
        {
            return Request.CreateResponse(HttpStatusCode.OK, TransactionServices.TotalvolunteertoadminMoney());
        }
    }
}
