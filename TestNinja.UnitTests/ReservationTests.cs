using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnTrue()
        {
            // Arrange
            var reservation = new Reservation();
            var user = new User
            {
                IsAdmin = true
            };
            // Act
            var testFunction = reservation.CanBeCancelledBy(user);
            var testFunction2 = reservation.CanBeCancelledBy(new User { IsAdmin=true });
            // Assert
            Assert.IsTrue(testFunction);
            Assert.IsTrue(testFunction2);
        }
        [TestMethod]
        public void CanBeCancelledBy_UserMadeByItself_ReturnTrue()
        {
            // Arrange
            var user = new User{ IsAdmin = false };
            var reservation = new Reservation { MadeBy = user };
            // Act
            var testFunction = reservation.CanBeCancelledBy(user);
            // Assert
            Assert.IsTrue(testFunction);
        }

        [TestMethod]
        public void CanBeCancelledBy_UserIsNotAdminUserIsNotMadeByItself_ReturnFalse()
        {
            // Arrange
            var user = new User { IsAdmin = false };
            var reservation = new Reservation { MadeBy = null };
            // Act
            var testFunction = reservation.CanBeCancelledBy(user);
            // Assert
            Assert.IsFalse(testFunction);
        }
    }
}
