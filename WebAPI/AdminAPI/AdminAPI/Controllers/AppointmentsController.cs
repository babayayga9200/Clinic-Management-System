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
    public class AppointmentsController : ApiController
    {
        private Context db = new Context();

        // GET: api/Appointments 
        //Roles = Admin:1, Doctor:2, Patient:3
        [Authorize(Roles = "1,2,3")]
        public HttpResponseMessage Getappointments()
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var id = dbContext.appointments.ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, id);

                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        //Roles = Admin:1, Doctor:2, Patient:3
        [HttpGet]
        [Authorize(Roles = "1,2,3")]
        [Route("api/Appointments/GetAppointmentById/{id}")]
        public HttpResponseMessage GetAppointmentById(int id)
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var entity = dbContext.appointments.Where(c => c.PatientID == id).ToList();
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Appointment list not available");
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
        [HttpGet]
        [Authorize(Roles = "1,2,3")]
        [Route("api/Appointments/GetPatientNotificationById/{id}")]
        public HttpResponseMessage GetPatientNotificationById(int id)
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var entity = dbContext.appointments.Where(c => c.PatientID == id).ToList();
                    if (entity == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, entity);
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
        [Route("api/Appointments/GetTotalIncome")]
        [Authorize(Roles = "1")]
        public HttpResponseMessage GetTotalIncome()
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var id = dbContext.bills.Sum(c=>c.Amount);
                    Hashtable entity = new Hashtable();
                    entity.Add("Count", id);
                    return Request.CreateResponse(HttpStatusCode.OK, entity);

                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }


        //Roles = Admin:1, Doctor:2, Patient:3
        [Route("api/Appointments/PostAppointment")]
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(Appointment))]
        public HttpResponseMessage PostAppointment(AppointmentViewModel Appoin)
        {

            try
            {
                using (Context db = new Context())
                {
                    Appointment Appoint = new Appointment()
                    {

                        DoctorID = Appoin.DoctorID,
                        PatientID = Appoin.PatientID,
                        Date = Appoin.Date,
                        Appointment_Status = 0,
                        Bill_Amount = null,
                        Bill_Status = null,
                        DoctorNotification = 1,
                        PatientNotification = 0,
                        
                        DoctorName = db.doctors.Where(d => d.DoctorID == Appoin.DoctorID).Select(d => d.Name).FirstOrDefault()
                    };
                    db.appointments.Add(Appoint);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);

                }
            }

            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }


        // DELETE: api/Appointments/5
        //Roles = Admin:1, Doctor:2, Patient:3
        [ResponseType(typeof(Appointment))]
        [Authorize(Roles = "1,2,3")]
        public IHttpActionResult DeleteAppointment(int id)
        {
            Appointment appointment = db.appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            db.appointments.Remove(appointment);
            db.SaveChanges();

            return Ok(appointment);
        }

        //Roles = Admin:1, Doctor:2, Patient:3
        [HttpGet]
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(Appointment))]
        [Route("api/Appointments/GetUnAcceptedAppointments")]
        public HttpResponseMessage GetUnAcceptedAppointments()
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    DateTime date = DateTime.Today;
                    var id = dbContext.appointments.Where(a => a.Appointment_Status == 0 && DbFunctions.TruncateTime(a.Date) == date).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, id);

                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }



        // GET: api/Appointments
        //Roles = Admin:1, Doctor:2, Patient:3
        [HttpGet]
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(Appointment))]
        [Route("api/Appointments/GetAcceptedAppointments")]
        public HttpResponseMessage GetAcceptedAppointments()
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    var id = dbContext.appointments.Where(a => a.Appointment_Status == 1).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, id);

                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        //Roles = Admin:1, Doctor:2, Patient:3
        [HttpPut]
        [Authorize(Roles = "1,2,3")]
        [ResponseType(typeof(Appointment))]
        [Route("api/Appointments/putAcceptedAppointment/{id}")]
        public HttpResponseMessage putAcceptedAppointment(int id)
        {
            try
            {
                using (Context dbContext = new Context())
                {
                    Appointment status = dbContext.appointments.Where(a => a.AppointID == id).FirstOrDefault();

                    status.Appointment_Status = 1;
                    status.PatientNotification = 1;
                    dbContext.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        //Roles = Admin:1, Doctor:2, Patient:3
        [HttpDelete]
        [Authorize(Roles = "1,2,3")]
        [Route("api/Appointments/DeleteAppointmentById/{id}")]
        public HttpResponseMessage DeleteAppointmentById(int id)
        {
            try
            {
                using (Context dbContext = new Context())
                {

                    var appointment = dbContext.appointments.Where(d => d.AppointID == id).FirstOrDefault();

                    dbContext.appointments.Remove(appointment);

                    dbContext.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, appointment);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }


    }
}