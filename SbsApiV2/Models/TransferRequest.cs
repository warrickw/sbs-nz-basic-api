using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models
{
    public class FromAccountDetails
    {
        public object AccountTransactionSearchUri { get; set; }
        public object UpcomingPayments { get; set; }
        public object AccountTransactionListResponseDocument { get; set; }
        public string AccountUri { get; set; }
        public object AdditionalText { get; set; }
        public string Balance { get; set; }
        public string AvailableFunds { get; set; }
        public int Icon { get; set; }
        public int Id { get; set; }
        public bool AllowsDeposit { get; set; }
        public bool AllowsWithdrawal { get; set; }
        public bool FullAuthority { get; set; }
        public bool InternalAuthorityOnly { get; set; } = true;
        public string Name { get; set; }
        public string Number { get; set; }
        public string CustomerNumber { get; set; }
        public string AccountPartnersUri { get; set; }
        public bool IsInvestmentAccount { get; set; }
        public bool PaperStatementsSupressed { get; set; }
        public bool ChequeBookEnabled { get; set; }
        public bool DepositBookEnabled { get; set; }
        public bool AvailableForSmsAlerts { get; set; }
        public readonly string DocumentType = "AccountDetail";
    }

    public class ToAccountDetails
    {
        public object AccountTransactionSearchUri { get; set; }
        public object UpcomingPayments { get; set; }
        public object AccountTransactionListResponseDocument { get; set; }
        public string AccountUri { get; set; }
        public object AdditionalText { get; set; }
        public string Balance { get; set; }
        public string AvailableFunds { get; set; }
        public int Icon { get; set; }
        public int Id { get; set; }
        public bool AllowsDeposit { get; set; }
        public bool AllowsWithdrawal { get; set; }
        public bool FullAuthority { get; set; }
        public bool InternalAuthorityOnly { get; set; } = true;
        public string Name { get; set; }
        public string Number { get; set; }
        public string CustomerNumber { get; set; }
        public string AccountPartnersUri { get; set; }
        public bool IsInvestmentAccount { get; set; }
        public bool PaperStatementsSupressed { get; set; }
        public bool ChequeBookEnabled { get; set; }
        public bool DepositBookEnabled { get; set; }
        public bool AvailableForSmsAlerts { get; set; }
        public readonly string DocumentType = "AccountDetail";
    }

    public class ToDetails
    {
        public string Particulars { get; set; }
        public string Code { get; set; }
        public string References { get; set; }
    }

    public class TransferRequest
    {
        public readonly string DocumentType = "MoveMoneyToAccount";
        public string Amount { get; set; }
        public int FromAccount { get; set; }
        public FromAccountDetails fromAccountDetails { get; set; }
        public string FromDetails { get; set; }
        public bool SaveAsPayee { get; set; } = false;
        public bool isRecurring { get; set; } = false;
        public object ScheduleDetails { get; set; } = null;
        public int ToAccount { get; set; }
        public int PayeeId { get; set; }
        public int OrganisationId { get; set; }
        public string PaymentType { get; set; } = "PersonalAccountTransfer";
        public ToAccountDetails toAccountDetails { get; set; }
        public string ToAccountName { get; set; }
        public string ToAccountNumber { get; set; }
        public ToDetails ToDetails { get; set; }
        public string TransferDate { get; set; }
        public bool sameDesc { get; set; }
    }
}
