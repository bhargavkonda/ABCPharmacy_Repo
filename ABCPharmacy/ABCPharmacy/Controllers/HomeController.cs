using ABCPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCPharmacy.Controllers
{
    public class HomeController : Controller
    {
        ABCPharmacyClient _client;
        public HomeController()
        {
            _client = new ABCPharmacyClient();
        }
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ErrorModel model = new ErrorModel { ErrorMessage = ex.Message };
                return View("Error", model);
            }

        }

        public ActionResult Search(MedicineModel medicine)
        {
            try
            {
                var result = _client.GetMedicines(medicine.Input);

                if (result != null && result.Count > 0)
                {
                    medicine.Result = result;
                }
                else
                {
                    medicine.MedicineResultCount = 0;
                }

                return View("Index", medicine);
            }
            catch (Exception ex)
            {
                ErrorModel model = new ErrorModel { ErrorMessage = ex.Message };
                return View("Error", model);
            }
        }

        public ActionResult AddMedicineView()
        {
            try
            {
                return View("AddMedicine");
            }
            catch (Exception ex)
            {
                ErrorModel model = new ErrorModel { ErrorMessage = ex.Message };
                return View("Error", model);
            }
        }

        public ActionResult AddMedicine(MedicineModel medicine)
        {
            try
            {
                var result = _client.AddMedicine(medicine.Input);

                if (result != null && result.Count > 0)
                {
                    medicine.Result = result;
                }
                else
                {
                    medicine.MedicineResultCount = 0;
                }

                return View("Index", medicine);
            }
            catch (Exception ex)
            {
                ErrorModel model = new ErrorModel { ErrorMessage = ex.Message };
                return View("Error", model);
            }
        }

        public ActionResult UpdateMedicineView()
        {
            try
            {
                return View("UpdateMedicine");
            }
            catch (Exception ex)
            {
                ErrorModel model = new ErrorModel { ErrorMessage = ex.Message };
                return View("Error", model);
            }
        }

    }
}