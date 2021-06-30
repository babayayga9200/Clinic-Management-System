using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AdminAPI.Models;
using AdminAPI.ViewModels;

namespace AdminAPI.Controllers
{
    public class BillsController : ApiController
    {

        //Roles = Admin:1, Doctor:2, Patient:3
        [Authorize(Roles = "1,2,3")]
        [Route("api/Bills/GetBillDetails_usingPatientID/{id}")]
        public HttpResponseMessage GetBillDetails_usingPatientID(int id)  
        {
            try
            {
                using (Context db = new Context())
                {
                    var entity = db.bills.Where(z => z.PatientId == id).ToList();
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Bill History");
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);

            }
        }

        //Roles = Admin:1, Doctor:2, Patient:3
        [Route("api/Bills")]
        [HttpGet]
        [Authorize(Roles = "1,2,3")]
        public HttpResponseMessage Getbills()
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    DateTime date = DateTime.Today;
                    var id = dbContext.bills.Where(a => DbFunctions.TruncateTime(a.Date) == date).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, id);

                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        //Roles = Admin:1, Doctor:2, Patient:3
        [Authorize(Roles = "1,2,3")]
        public IHttpActionResult PostBill(BillViewModel bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                using (Context dbContext = new Context())
                {
                    Bill b = new Bill()
                    {
                        Date = bill.Date,
                        PatientName = bill.PatientName,
                        PatientId = dbContext.patients.Where(p => p.Name.Equals(bill.PatientName)).Select(p => p.PatientID).FirstOrDefault(),
                        DoctorName = bill.DoctorName,
                        PurposeOfVisit = bill.PurposeOfVisit,
                        Prescripton = bill.Prescription,
                        Amount = bill.Amount
                    };


                    dbContext.bills.Add(b);
                    dbContext.SaveChanges();

                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        
    }
}