using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models
{
    /// <summary>
    /// The model returned in response to a transfer
    /// </summary>
    public class TransferResponse
    {
        public string Amount { get; set; }
        public int FromAccount { get; set; }
        public ToDetails ToDetails { get; set; }
        public string FromDetails { get; set; }
        public int PayeeId { get; set; }
        public int OrganisationId { get; set; }
        public int PaymentId { get; set; }
        public bool SaveAsPayee { get; set; }
        public object ScheduleDetails { get; set; }
        public int ToAccount { get; set; }
        public string ToAccountName { get; set; }
        public string ToAccountNumber { get; set; }
        public string TransferDate { get; set; }
        public string PaymentType { get; set; }
        public string PaymentCustomerNumber { get; set; }
        public string PaymentReceiptUri { get; set; }
        public string DocumentType { get; set; }
    }
}
