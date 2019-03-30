using ABCPharmacyAPI.Models;
using System.Collections.Generic;

namespace ABCPharmacyAPI.Interfaces
{
    public interface IABCPharamacyProcessor
    {
        List<Medicine> GetMedicines();

        Medicine GetMedicine(int id);

        List<Medicine> SearchMedicines(Medicine medicine);

        void UpdateMedicine(Medicine medicine);

        bool MedicineExists(int id);

        void AddMedicine(Medicine medicine);

        void DeleteMedicine(Medicine medicine);
    }
}
