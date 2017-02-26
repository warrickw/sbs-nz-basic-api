using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models
{
    public class AccountResponseInnerAccount
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
        public bool InternalAuthorityOnly { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string CustomerNumber { get; set; }
        public string AccountPartnersUri { get; set; }
        public bool IsInvestmentAccount { get; set; }
        public bool PaperStatementsSupressed { get; set; }
        public bool ChequeBookEnabled { get; set; }
        public bool DepositBookEnabled { get; set; }
        public bool AvailableForSmsAlerts { get; set; }
        public string DocumentType { get; set; }
    }

    public class AccountResponse
    {
        public List<AccountResponseInnerAccount> Accounts { get; set; }
        public string DocumentType { get; set; }
    }
}
