using RestaurantModels;
using RestaurantUI;
using Xunit;

namespace TestProject
{
    public class UnitTestingUI
    {
        [Fact]
        public void LoginAccountTest()
        {
            UserAcc newUser = new UserAcc();
            newUser.Username = "jello";
            newUser.Password = "jello123";

            Assert.Equal(newUser.Username, "jello");
            Assert.Equal(newUser.Password, "jello123");
        }
        [Fact]
        public void SearchRestaurantsTest()
        {
            Restaurant resName = new Restaurant();
            resName.RestaurantID = 1;
            resName.RestaurantName = "All 'Merican";
            resName.City = "";
            resName.State = "TX";
            resName.ZipCode = 75001;

            Assert.Equal(resName.RestaurantID, 1);
            Assert.Equal(resName.RestaurantName, "All 'Merican");
            Assert.Equal(resName.State, "TX");
            Assert.Equal(resName.ZipCode, 75001);
            Assert.True(resName.ZipCode == 75001);
            Assert.Empty(resName.City);
        }
        [Fact]
        public void CheckReviewsTest()
        {
            Feedback rateName = new Feedback();
            rateName.Username = "pops";
            rateName.RestaurantName = "All 'American";
            rateName.Review = "";
            rateName.Rating = 5;

            Assert.Equal(rateName.Username, "pops");
            Assert.True(rateName.Rating == 5);
            Assert.Empty((string)rateName.Review);
            Assert.False(rateName.RestaurantName != "All 'American");
        }
    }
}
