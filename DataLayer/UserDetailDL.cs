using Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserDetailDL:BasicMethods<UserDetail>
    {
        public UserDetailDL(DBModel DbContextScope) : base(DbContextScope)
        {
           
        }

        

    }
}
