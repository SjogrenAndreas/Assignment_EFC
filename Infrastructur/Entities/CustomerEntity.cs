using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int PhoneNumberId { get; set; }
        public PhoneNumberEntity PhoneNumber { get; set; } = null!;

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!;

        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; } = null!;

        public int RoleId { get; set; }
        public RoleEntity Role { get; set; } = null!;


    }
}
