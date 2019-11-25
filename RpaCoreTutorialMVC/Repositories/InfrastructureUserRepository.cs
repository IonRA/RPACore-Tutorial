using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpaCoreTutorialMVC.Repositories
{
    public class UserRepository
    {
        private IUserDataContext _userDataContext;

        public UserRepository(IUserDataContext userDataContext)
        {
            this._userDataContext = userDataContext;
        }

        static UserRepository()
        {
            Users = n
        }
    }
}
