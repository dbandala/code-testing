using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class CustomerControllerTests
    {

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            // Not found object
            Assert.That(result, Is.TypeOf<NotFound>());
            // Not found object or one of its derivatives
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {

            var controller = new CustomerController();

            var result = controller.GetCustomer(4);

            // Ok object
            Assert.That(result, Is.TypeOf<Ok>());
            // Ok object or one of its derivatives
            Assert.That(result, Is.InstanceOf<Ok>());

        }
    }
}
