using NUnit.Framework;

namespace TestSamurai.NUnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_Admin_ReturnsTrue()
        {
            var reservation = new Reservation();
            var admin = new User { IsAdmin = true };

            var canBeCancelledByAdmin = reservation.CanBeCancelledBy(admin);

            Assert.That(canBeCancelledByAdmin, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_MakerUser_ReturnsTrue()
        {
            var reservation = new Reservation();
            var user = new User { IsAdmin = true };

            reservation.MadeBy = user;

            var canBeCancelledByMakerUser = reservation.CanBeCancelledBy(user);

            Assert.That(canBeCancelledByMakerUser, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_RegularUser_ReturnsFalse()
        {
            var reservation = new Reservation();
            var user = new User { IsAdmin = false };

            var canBeCancelledByRegularUser = reservation.CanBeCancelledBy(user);

            Assert.That(canBeCancelledByRegularUser, Is.False);
        }
    }
}
