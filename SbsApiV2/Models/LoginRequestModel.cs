using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models
{
    public class UserTokenRequestVersionModel
    {
        public int GeneralAccountViewRequest { get; set; } = 1;
        public int AccountDetailRequest { get; set; } = 1;
        public int AccountListRequest { get; set; } = 1;
        public int TransactionListRequest { get; set; } = 1;
        public int ChangePasswordRequest { get; set; } = 1;
        public int CustomerProfileRequest { get; set; } = 1;
        public int StopPaperStatementRequest { get; set; } = 1;
        public int ImageListRequest { get; set; } = 1;
        public int ImageRequest { get; set; } = 1;
        public int PayeeRequest { get; set; } = 1;
        public int RegPayeeRequest { get; set; } = 1;
        public int RegPayeeListRequest { get; set; } = 1;
        public int PayeeHistoryRequest { get; set; } = 1;
        public int SuspendAccessRequest { get; set; } = 1;
        public int PaymentRequest { get; set; } = 1;
        public int PaymentSaveRequest { get; set; } = 1;
        public int PaymentListRequest { get; set; } = 1;
        public int Update2FaStatusRequest { get; set; } = 1;
        public int CreateIRDPaymentRequest { get; set; } = 1;
        public int RenameAccountRequest { get; set; } = 1;
        public int SaveQuickTransferSettingsRequest { get; set; } = 1;
        public int IrdTaxTypesRequest { get; set; } = 1;
        public int ReschedulePaymentRequest { get; set; } = 1;
        public int AcceptTermsRequest { get; set; } = 1;
        public int SendSecureMessageRequest { get; set; } = 1;
        public int GetSecureMessageRequest { get; set; } = 1;
        public int GetSmcThreadList { get; set; } = 1;
        public int GetSmcThreadMessages { get; set; } = 1;
        public int GetSecureMsgTopicList { get; set; } = 1;
        public int SetSecureMsgRead { get; set; } = 1;
        public int GetAccountStatementList { get; set; } = 1;
        public int InvestmentSummaryRequest { get; set; } = 1;
        public int AccountPartnersRequest { get; set; } = 1;
        public int CustomerConfigurationUpdate { get; set; } = 1;
        public int PaymentHistoryRequest { get; set; } = 1;
        public int IrdPayeeRequest { get; set; } = 1;
        public int OrderChequeBookRequest { get; set; } = 1;
        public int OrderDepositBookRequest { get; set; } = 1;
        public int OrderPaperStatementRequest { get; set; } = 1;
        public int GetAlertDefinitions { get; set; } = 1;
        public int SetAlertsForAccounts { get; set; } = 1;
        public int GetAlertsForAccounts { get; set; } = 1;
        public int LogoutRequest { get; set; } = 1;
    }

    /// <summary>
    /// User token model used when authenticating a session
    /// </summary>
    public class LoginRequestModel
    {
        public LoginRequestModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public readonly string DataType = "SBSAuthenticationUserToken";
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserTokenRequestVersionModel RequestVersion { get; set; } = new UserTokenRequestVersionModel();
    }
}