using Infrastructur.Contexts;
using Infrastructur.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Repositories
{
    internal class CompanyRepository : Repo<CompanyEntity>
    {
        public CompanyRepository(DataContext context) : base(context)
        {
        }
    }
}
