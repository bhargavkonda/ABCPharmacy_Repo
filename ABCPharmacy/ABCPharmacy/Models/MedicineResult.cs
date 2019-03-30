using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCPharmacy.Models
{
    public class MedicineResult
    {
        public int MedicineId { get; set; }

        public string FullName { get; set; }

        public string Brand { get; set; }

        public Double Price { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string Notes { get; set; }



    }
}