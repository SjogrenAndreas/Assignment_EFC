using Infrastructur.Contexts;
using Infrastructur.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Repositories
{
    internal class PhoneNumberRepository : Repo<PhoneNumberEntity>
    {
        public PhoneNumberRepository(DataContext context) : base(context)
        {
        }
    }
}
