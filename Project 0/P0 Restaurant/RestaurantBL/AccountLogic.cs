using ResturantDL;
using ResturantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBL
{
    public class AccountLogic : IAccountLogic
    {
        readonly IRepo repo;
        public AccountLogic(IRepo repo)
        {
            this.repo = repo;
        }

        public CreateAcc AddUser(CreateAcc ca)
        {
          
        }
    }
}
