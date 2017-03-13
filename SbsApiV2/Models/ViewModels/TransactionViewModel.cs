using SbsApiV2.Models.AccountGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models.ViewModels
{
    public class TransactionViewModel
    {
        public TransactionViewModel(ItemList model)
        {
            Amount = SbsCurrencyUtilities.Parse(model.Amount);
            Balance = SbsCurrencyUtilities.Parse(model.Balance);
            Organization = model.Organisation;
            PayeeName = model.Payee?.PayeeName;
            ToAccountNumber = model.ToAccountNumber;
            Description = model.TransactionDescription;
            Timestamp = TimeZoneInfo.ConvertTime(DateTime.Parse(model.TransactionTimestampNZ), TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time"), TimeZoneInfo.FindSystemTimeZoneById("UTC"));
            IsUpcomingPayment = model.IsUpcomingPayment;
            ToAccount = model.ToAccount;
            FromAccount = model.FromAccount;
            ToDetails_Particulars =  string.IsNullOrWhiteSpace(model.ToDetails?.Particulars) ? null : model.ToDetails.Particulars;
            ToDetails_Code = string.IsNullOrWhiteSpace(model.ToDetails?.Code) ? null : model.ToDetails.Code;
            ToDetails_References = string.IsNullOrWhiteSpace(model.ToDetails?.References) ? null : model.ToDetails.References;
            FromDetails = model.FromDetails;
        }

        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public object Organization { get; set; }
        public string PayeeName { get; set; }
        public string ToAccountNumber { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; } // TODO convert from ns
        public bool IsUpcomingPayment { get; set; }
        public int ToAccount { get; set; }
        public int FromAccount { get; set; }
        public string ToDetails_Particulars { get; set; }
        public string ToDetails_Code { get; set; }
        public string ToDetails_References { get; set; }
        public string FromDetails { get; set; }
    }
}