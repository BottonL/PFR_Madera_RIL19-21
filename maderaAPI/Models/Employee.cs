using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace maderaAPI.Models
{
    public class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("lastname", TypeName = "varchar(50)")]
        public string Lastname { get; set; }

        [Required]
        [Column("firstname", TypeName = "varchar(35)")]
        public string Firstname { get; set; }

        [Required]
        [Column("mail", TypeName = "varchar(200)")]
        public string Mail { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }

        [Required]
        [Column("phone", TypeName = "varchar(12)")]
        public string Phone { get; set; }

        [Column("role")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        #region Navigation Properties
        public virtual Role Role { get; set; }
        #endregion
    }
}
