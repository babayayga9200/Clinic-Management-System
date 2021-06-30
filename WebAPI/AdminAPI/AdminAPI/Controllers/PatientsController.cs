using System;
using System.Collections;
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
    public class PatientsController : ApiController
    {
        private Context db = new Context();

        //Roles = Admin:1, Doctor:2, Patient:3
        // GET: api/Patients
        [Authorize(Roles = "1,2,3")]
        public HttpResponseMessage GetPatients()
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var entity = dbContext.patients.ToList();
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient's list not available");
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpGet]
        [Authorize(Roles = "1,2,3")]
        [Route("api/Patients/GetPatientById/{id}")]
        public HttpResponseMessage GetPatientById(int id)
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var entity = dbContext.patients.Where(c=>c.PatientID==id).ToList();
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient's list not available");
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

       

        [HttpGet]
        [Authorize(Roles = "1,2,3")]
        [Route("api/Patients/GetPatientCount")]
        public IHttpActionResult GetPatientCount()
        {
            try
            {
                using (Context dbContext = new Context())
                {

                    var entity = dbContext.patients.Count();
                    Hashtable i = new Hashtable();
                    i.Add("Count", entity);

                    return Ok(i);
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

       

        [ResponseType(typeof(Patient))]
        [AllowAnonymous]
        public HttpResponseMessage PostPatient(AddPatientViewModel home)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                using (Context dbContext = new Context())
                {
                    

                    LoginTable lt = new LoginTable()
                    {
                        Password = home.Password,
                        Email = home.Email,
                        Type = 3
                    };

                    Patient d = new Patient()
                    {
                        Name = home.Name,
                        Phone = home.Phone,
                        Address = home.Address,
                        BirthDate = home.BirthDate,
                        LoginId = lt.LoginId,
                        LoginTable = lt,
                        Email = home.Email


                    };
                    dbContext.patients.Add(d);
                    dbContext.SaveChanges();


                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }

        }

        [HttpDelete]
        [Authorize(Roles = "1,2,3")]
        [Route("api/Patients/DeletePatientById/{id}")]
        public HttpResponseMessage DeletePatientById(int id)
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var patient = dbContext.patients.Where(d => d.PatientID == id).FirstOrDefault();
                    var appointment = dbContext.appointments.Where(d => d.PatientID == id).ToList();
                    var login = dbContext.loginTables.Where(d => d.LoginId == patient.LoginId).FirstOrDefault();
                    if (patient == null || login==null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    dbContext.patients.Remove(patient);
                    dbContext.loginTables.Remove(login);
                    foreach (var app in appointment)
                    {
                        dbContext.appointments.Remove(app);
                    }
                    dbContext.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, patient);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        
    }
}