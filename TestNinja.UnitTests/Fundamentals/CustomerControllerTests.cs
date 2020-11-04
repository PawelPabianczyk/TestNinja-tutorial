using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests {

    [TestFixture]
    class CustomerControllerTests {

        [Test]
        public void GetCustomer_WhenIdIsZero_ReturnNotFound() {

            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());
        }

        [Test]
        public void GetCustomer_WhenIdIsNotZero_ReturnOk() {

            var controller = new CustomerController();

            var result = controller.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());
        }
    }
}