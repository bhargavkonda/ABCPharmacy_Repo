using System;
using System.Collections.Generic;
using NUnit.Framework;
using ABCPharmacyAPI.Models;
using NSubstitute;
using ABCPharmacyAPI.Interfaces;
using ABCPharmacyAPI.Processor;
using ABCPharmacyAPI.Controllers;
using Assert = NUnit.Framework.Assert;

namespace ABCPharmacyAPI.Tests.Controllers
{
    /// <summary>
    /// Summary description for MedicineTest
    /// </summary>
    [TestFixture]
    public class MedicineControllerTest
    {
        
        [Test]
        public void GetMedicine_ReturnsMedicines()
        {
            // Arrange
            object model;
            var _mockRepo = Substitute.For<IABCPharamacyRepository>();
            IABCPharamacyProcessor _processor = new ABCPharmacyProcessor(_mockRepo);



            List<Medicine> mockResult = new List<Medicine>()
            {
                new Medicine()
                {
                    MedicineId = 1,
                    Full_Name  = "Crosine",
                    Brand = "Cipla",
                    Price = 10.00M,
                    Quantity = 100,
                    Expiry_Date = DateTime.Now.AddDays(100),
                    Notes = "No Notes"
                    
                }
            };

            _mockRepo.GetMedicines().Returns(mockResult);
            MedicineController controller = new MedicineController(_processor);


            // Act
            var result = controller.GetMedicines();

            

            // Assert
            Assert.IsNotNull(result);

            Assert.Greater(result.Count, 0);
        }
    }
}
