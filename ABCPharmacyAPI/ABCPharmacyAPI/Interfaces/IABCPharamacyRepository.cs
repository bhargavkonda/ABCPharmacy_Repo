using ABCPharmacyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCPharmacyAPI.Interfaces
{
    public interface IABCPharamacyRepository
    {
        List<Medicine> GetMedicines();

        Medicine GetMedicine(int medicineId);

        List<Medicine> SearchMedicines(Medicine medicine);

        bool MedicineExists(int medicineId);

        void UpdateMedicine(Medicine Medicine);

        void AddMedicine(Medicine Medicine);

        void DeleteMedicine(Medicine Medicine);
    }
}
