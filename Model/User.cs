using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test3_Bank.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength (100)]
        public String Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        public virtual Account Account { get; set; }
    }
}
