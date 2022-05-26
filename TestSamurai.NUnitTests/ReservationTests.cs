using NUnit.Framework;

namespace TestSamurai.NUnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        private Reservation _reservation;

        [SetUp]
        public void SetUp() => _reservation = new Reservation();

        [Test]
        public void CanBeCancelledBy_Admin_ReturnsTrue()
        {
            var admin = new User { IsAdmin = true };

            var canBeCancelledByAdmin = _reservation.CanBeCancelledBy(admin);

            Assert.That(canBeCancelledByAdmin, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_MakerUser_ReturnsTrue()
        {
            var user = new User { IsAdmin = true };

            _reservation.MadeBy = user;

            var canBeCancelledByMakerUser = _reservation.CanBeCancelledBy(user);

            Assert.That(canBeCancelledByMakerUser, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_RegularUser_ReturnsFalse()
        {
            var user = new User { IsAdmin = false };

            var canBeCancelledByRegularUser = _reservation.CanBeCancelledBy(user);

            Assert.That(canBeCancelledByRegularUser, Is.False);
        }
    }

    public class ReservationTestsUsingTestCases
    {
        private Reservation _reservation;

        [SetUp]
        public void SetUp() => _reservation = new Reservation();

        [Test]
        [TestCase(true, true, true)]
        [TestCase(true, false, true)]
        [TestCase(false, true, true)]
        [TestCase(false, false, false)]
        public void CanBeCancelledByUser(bool isAdmin, bool isMaker, bool expectedResult)
        {
            var user = new User { IsAdmin = isAdmin };
            if (isMaker)
                _reservation.MadeBy = user;
            else
                _reservation.MadeBy = new User();

            var canBeCancelledByUser = _reservation.CanBeCancelledBy(user);

            Assert.That(canBeCancelledByUser, Is.EqualTo(expectedResult));
        }
    }
}
