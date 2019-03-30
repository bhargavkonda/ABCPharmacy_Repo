using ABCPharmacyAPI.Interfaces;
using ABCPharmacyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABCPharmacyAPI.Processor
{
    public class ABCPharmacyProcessor : IABCPharamacyProcessor
    {
        IABCPharamacyRepository _repo;
        public ABCPharmacyProcessor(IABCPharamacyRepository repository)
        {
            _repo = repository;
        }
        public void AddMedicine(Medicine medicine)
        {
            try
            {
                if (medicine != null)
                {
                    _repo.AddMedicine(medicine);
                }
                else
                    throw new ArgumentNullException();
            }

            catch (ArgumentNullException)
            {
                throw;
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
                _repo.DeleteMedicine(medicine);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Medicine GetMedicine(int medicineId)
        {
            if (medicineId > 0)
                return _repo.GetMedicine(medicineId);
            else
                return null;
        }

        public List<Medicine> GetMedicines()
        {
            return _repo.GetMedicines();
        }

        public List<Medicine> SearchMedicines(Medicine medicine)
        {
            return _repo.SearchMedicines(medicine);
        }

        public bool MedicineExists(int medicineId)
        {
            return _repo.MedicineExists(medicineId);
        }

        public void UpdateMedicine(Medicine medicine)
        {
            try
            {
                if (medicine != null)
                {
                    _repo.UpdateMedicine(medicine);
                }
                else
                    throw new ArgumentNullException();
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}