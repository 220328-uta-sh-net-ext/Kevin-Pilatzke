using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBL
{
    public interface IAccountLogic
    {
        CreateAcc AddUser(CreateAcc ca);
    }
}
