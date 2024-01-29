using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Entities
{
    public class RoleEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Role {  get; set; } = null!;

    }
}
