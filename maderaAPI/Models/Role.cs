using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace maderaAPI.Models
{
    public class Role
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title", TypeName = "varchar(25)")]
        public string Title { get; set; }

        [InverseProperty("Role")]
        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}
