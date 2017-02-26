using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models
{
    /// <summary>
    /// The model used for transfering money
    /// </summary>
    public class TransferModel
    {
        /// <summary>
        /// The account id to transfer money from
        /// </summary>
        [Required]
        public int FromAccount { get; set; }

        /// <summary>
        /// The account id to transfer money to
        /// </summary>
        [Required]
        public int ToAccount { get; set; }

        /// <summary>
        /// The amount to transfer, in cents
        /// </summary>
        [Required]
        public long Amount { get; set; }

        [StringLength(12)]
        public string Particulars { get; set; }

        [StringLength(12)]
        public string Code { get; set; }

        [StringLength(12)]
        public string Reference { get; set; }

        [StringLength(12)]
        public string Details { get; set; }

        /// <summary>
        /// Use the same details on my statement (doesn't seem to do much)
        /// </summary>
        public bool UseSameDetails { get; set; } = false;
    }
}
