using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSamurai.MSUnitTests;

[TestClass]
public class ReservationTests
{
    [TestMethod]
    public void CanBeCancelledBy_Admin_ReturnsTrue()
    {
        //Arrange
        var reservation = new Reservation();
        var admin = new User { IsAdmin = true };

        //Act
        var canBeCancelledByAdmin = reservation.CanBeCancelledBy(admin);

        //Assert
        Assert.IsTrue(canBeCancelledByAdmin);
    }

    [TestMethod]
    public void CanBeCancelledBy_MakerUser_ReturnsTrue()
    {
        //Arrange
        var reservation = new Reservation();
        var user = new User { IsAdmin = true };

        reservation.MadeBy = user;

        //Act
        var canBeCancelledByMakerUser = reservation.CanBeCancelledBy(user);

        //Assert
        Assert.IsTrue(canBeCancelledByMakerUser);
    }

    [TestMethod]
    public void CanBeCancelledBy_RegularUser_ReturnsFalse()
    {
        //Arrange
        var reservation = new Reservation();
        var user = new User { IsAdmin = false };

        //Act
        var canBeCancelledByRegularUser = reservation.CanBeCancelledBy(user);

        //Assert
        Assert.IsFalse(canBeCancelledByRegularUser);
    }
}
