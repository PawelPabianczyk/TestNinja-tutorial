using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests {
    [TestFixture]
    public class ReservationTests {
        private Reservation _reservation;

        [SetUp]
        public void SetUp() {
            _reservation = new Reservation();
        }


        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue() {

            //Act
            var result = _reservation.CanBeCancelledBy(new User {IsAdmin = true });

            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdmin_ReturnsTrue() {

            //Arrange
            var user = new User { IsAdmin = false };
            _reservation.MadeBy = user;

            //Act
            var result = _reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_UserIsNotAdmin_ReturnsFalse() {

            //Arrange
            var user = new User { IsAdmin = false };
            _reservation.MadeBy = user;

            //Act
            var result = _reservation.CanBeCancelledBy(new User { IsAdmin = false });

            //Assert
            Assert.IsFalse(result);
        }
    }
}
