using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Entities
{
    internal class PhoneNumberEntity
    {
        [Key]
        public int Id { get; set; }

        public string WorkPhone { get; set; } = null!;

        public string MobilePhone { get; set; } = null!;

    }
}
