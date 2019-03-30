using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCPharmacy.Models
{
    public class MedicineModel
    {
        public MedicineInput Input { get; set; }

        public List<MedicineResult> Result { get; set; }

        public int MedicineResultCount = -1;

    }
}