using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCPharmacy.Models
{
    public class MedicineInput
    {
        public string FullName { get; set; }

        public string Brand { get; set; }

        public DateTime ExpiryDate { get; set; }

        public Decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Notes { get; set; }
    }
}