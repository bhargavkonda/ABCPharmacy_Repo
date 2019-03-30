using ABCPharmacyAPI.Interfaces;
using ABCPharmacyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ABCPharmacyAPI.Repository
{
    public class ABCPharamacyRepository : IABCPharamacyRepository
    {

        private ABCPharmacyEntities db;

        public ABCPharamacyRepository()
        {
            db = new ABCPharmacyEntities();
        }

        public void AddMedicine(Medicine medicine)
        {
            try
            {
                db.Medicines.Add(medicine);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMedicine(Medicine medicine)
        {
            try
            {
                db.Medicines.Remove(medicine);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Medicine GetMedicine(int medicineId)
        {
            return db.Medicines.Find(medicineId);
        }

        public List<Medicine> GetMedicines()
        {
            return db.Medicines.ToList();
        }

        public List<Medicine> SearchMedicines(Medicine medicine)
        {
            List<Medicine> medicinesList = new List<Medicine>();
            var resultList = db.Medicines.ToList();

            foreach (var result in resultList)
            {
                if (result.Brand.Trim() == medicine.Brand.Trim() || result.Full_Name == medicine.Full_Name || result.Expiry_Date == medicine.Expiry_Date)
                    medicinesList.Add(result);
            }
            return medicinesList;
        }


        public bool MedicineExists(int medicineId)
        {
            return db.Medicines.Count(e => e.MedicineId == medicineId) > 0;
        }

        public void UpdateMedicine(Medicine medicine)
        {
            try
            {
                db.Entry(medicine).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}