using RestaurantModels;

namespace RestaurantAPI.JWTRepo
{
    public interface IJWTRepo
    {
        //Task<Tokens> Auth(UserAcc user);
        Tokens AuthUser(UserAcc user);
    }
}
