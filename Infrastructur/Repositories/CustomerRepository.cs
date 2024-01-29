using Infrastructur.Contexts;
using Infrastructur.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Repositories
{
    public class CustomerRepository : Repo<CustomerEntity>
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }
    }
}
