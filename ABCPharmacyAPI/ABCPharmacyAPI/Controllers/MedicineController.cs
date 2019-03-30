using ABCPharmacyAPI.Interfaces;
using ABCPharmacyAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ABCPharmacyAPI.Controllers
{
    public class MedicineController : ApiController
    {

        public MedicineController()
        {

        }
        IABCPharamacyProcessor _processor;
        public MedicineController(IABCPharamacyProcessor processor)
        {
            _processor = processor;
        }
        // GET: api/Medicines
        public List<Medicine> GetMedicines()
        {
            return _processor.GetMedicines();
        }

        // GET: api/Medicines/5
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult GetMedicine(int id)
        {
            Medicine medicine = _processor.GetMedicine(id);
            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }

        [Route("api/Medicine/SearchMedicine")]
        [HttpPost]
        public HttpResponseMessage SearchMedicine([FromBody]Medicine value)
        {
            List<Medicine> medicine = _processor.SearchMedicines(value);
            if (medicine == null)
            {
                return null;
            }
            return Request.CreateResponse(HttpStatusCode.OK, medicine);
        }

        // PUT: api/Medicines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicine(int id, Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicine.MedicineId)
            {
                return BadRequest();
            }

            try
            {
                _processor.UpdateMedicine(medicine);
            }
            catch (Exception)
            {
                if (id > 0 && !_processor.MedicineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Medicines
        [Route("api/Medicine/AddMedicine")]
        [ResponseType(typeof(Medicine))]
        [HttpPost]

        public IHttpActionResult AddMedicine(Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _processor.AddMedicine(medicine);
            }
            catch (Exception)
            {
                if (_processor.MedicineExists(medicine.MedicineId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = medicine.MedicineId}, medicine);
        }

        // DELETE: api/Medicines/5
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult DeleteMedicine(int id)
        {
            Medicine medicine = _processor.GetMedicine(id);
            try
            {
                if (medicine == null)
                {
                    return NotFound();
                }

                _processor.DeleteMedicine(medicine);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(medicine);
        }
    }
}
