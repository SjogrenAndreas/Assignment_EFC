using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Entities
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        public string StreetName { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string City { get; set; } = null!;
      
    }
}
