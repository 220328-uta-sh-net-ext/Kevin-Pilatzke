using RestaurantModels;

namespace UnitTesting
{
    public class ModelTesting
    {
        [Fact]
        public void ReviewSection()
        {
            Feedback newReview = new Feedback()
            {
                Review = "Food was good but a bit greasy. Service was ok, though food got out quickly at least. Would likely go back if I am in the area again.",
                Username = "phi",
                RestaurantName = "All 'Merican",
                Rating = 4.0m
            };
            Assert.Equal("phi", newReview.Username);
            Assert.False(newReview.Rating == 5.0m);
            Assert.True(newReview.RestaurantName == "All 'Merican");
            Assert.NotNull(newReview.Review);
        }
        [Fact]
        public void UserSection()
        {
            UserAcc newUser = new UserAcc()
            {
                Username = "phi",
                Password = "hotdogs",
                Access = "Basic"
            };
            Assert.True(newUser.Password == "hotdogs");
            Assert.False(newUser.Access == "admin");
            Assert.NotNull(newUser.Username);
        }
        [Fact]
        public void RestaurantSection()
        {
            Restaurant newRestaurant = new Restaurant()
            {
                RestaurantID = 1,
                RestaurantName = "All 'Mericna",
                State = "TX",
                City = "Dallas",
                ZipCode = 75001
            };
            Assert.Contains("all", "All 'Merican");
            Assert.DoesNotContain("toast", "All 'Merican");
            Assert.True(newRestaurant.ZipCode == 75001);
            Assert.NotNull(newRestaurant.RestaurantName);
            Assert.False(newRestaurant.City != "Kansas");
        }
    }
}