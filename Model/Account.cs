using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test3_Bank.Model;

namespace Test3_Bank
{
    public  class Account
    {
        [Key]
        [Column("Account Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double Balance { get; set; }
        
    }
}
