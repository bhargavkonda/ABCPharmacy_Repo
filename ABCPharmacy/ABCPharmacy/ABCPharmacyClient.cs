using ABCPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace ABCPharmacy
{
    public class ABCPharmacyClient
    {

        public List<MedicineResult> GetMedicines(MedicineInput medicineInput)
        {
            HttpClient _client = new HttpClient();
            StringContent content = null;

            List<MedicineResult> result = new List<MedicineResult>();

            try
            {

                _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


                content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(medicineInput), Encoding.UTF8, "application/json");

                HttpResponseMessage response = _client.PostAsync(new Uri("http://localhost:2555/api/medicine/SearchMedicine"), content).Result;


                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MedicineResult>>(response.Content.ReadAsStringAsync().Result);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<MedicineResult> AddMedicine(MedicineInput medicineInput)
        {
            HttpClient _client = new HttpClient();
            StringContent content = null;

            List<MedicineResult> result = new List<MedicineResult>();

            try
            {

                _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


                content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(medicineInput), Encoding.UTF8, "application/json");

                HttpResponseMessage response = _client.PostAsync(new Uri("http://localhost:2555/api/medicine/AddMedicine"), content).Result;


                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MedicineResult>>(response.Content.ReadAsStringAsync().Result);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}