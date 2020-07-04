using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PMId { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        [RegularExpression(@"[a-zA-Z \-']{1,50}",
         ErrorMessage = "Only upper/lower alpha characters, spaces, hyphens, or apostrophes are allowed.")]
        public string CardOwnerName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [RegularExpression(@"[a-zA-Z0-9 ']{1,100}",
         ErrorMessage = "Only upper/lower alpha characters or numbers are allowed.")]
        public string CardOwnerStreet { get; set; }

        [Required]
        [Column(TypeName = "varchar(9)")]
        [RegularExpression(@"([0-9]{5}(-[0-9]{4})?)",
         ErrorMessage = "Only numbers are allowed.")]
        public string CardOwnerZip { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        [RegularExpression(@"[0-9]{13,16}",
         ErrorMessage = "Only numbers are allowed.")]
        public string CardNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        [RegularExpression(@"[0-9]{2}\/[0-9]{2}",
         ErrorMessage = "Please enter in MM/YY.")]
        public string ExpirationDate { get; set; }

        [Required]
        [Column(TypeName = "varchar(3)")]
        [RegularExpression(@"[0-9]{3}",
         ErrorMessage = "Only numbers are allowed.")]
        public string CVV { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [RegularExpression(@"([0-9]+)\.?[0-9][0-9]",
         ErrorMessage = "Only numbers are allowed.")]
        public string TransactionAmount { get; set; }
    }
}
