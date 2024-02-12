using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Entity
{
    //یوزری که فرست نیم و لست نیم دارد
    public class UserApp : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
