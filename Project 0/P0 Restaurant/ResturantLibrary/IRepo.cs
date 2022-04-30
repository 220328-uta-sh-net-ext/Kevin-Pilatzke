using ResturantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantDL
{
    public interface IRepo
    {
        UserAcc AddUser(UserAcc user);
        Restaurant AddRestaurant(Restaurant restaurant);
        Feedback AddFeedback(Feedback feedback);    
    }
}
