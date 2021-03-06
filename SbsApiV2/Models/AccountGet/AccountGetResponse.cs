﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SbsApiV2.Models.AccountGet
{

    public class ToDetails
    {

        [JsonProperty("Particulars")]
        public string Particulars { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }

        [JsonProperty("References")]
        public string References { get; set; }

        [JsonProperty("DescriptionTitles")]
        public List<string> DescriptionTitles { get; set; }

        [JsonProperty("DescriptionElements")]
        public List<string> DescriptionElements { get; set; }
    }

    public class ItemListPayee
    {
        public int BadgeColour { get; set; }
        public string BadgeName { get; set; }
        public string PayeeName { get; set; }
        public string PayeeAltName { get; set; }
        public int PayeeId { get; set; }
        public int OrganisationId { get; set; }
        public bool IsIrdOrganisation { get; set; }
        public string PayeeUri { get; set; }
        public string DocumentType { get; set; }
    }

    public class ItemList
    {

        [JsonProperty("SerialNumber")]
        public int SerialNumber { get; set; }

        [JsonProperty("ActionList")]
        public object ActionList { get; set; }

        [JsonProperty("Amount")]
        public string Amount { get; set; }

        [JsonProperty("Balance")]
        public string Balance { get; set; }

        [JsonProperty("GroupingLabel")]
        public string GroupingLabel { get; set; }

        [JsonProperty("Organisation")]
        public object Organisation { get; set; }

        [JsonProperty("Payee")]
        public ItemListPayee Payee { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("RecurringScheduleDetailsResponse")]
        public object RecurringScheduleDetailsResponse { get; set; }

        [JsonProperty("ToAccountNumber")]
        public string ToAccountNumber { get; set; }

        [JsonProperty("ToReference")]
        public string ToReference { get; set; }

        [JsonProperty("ThirdPartyAccount")]
        public string ThirdPartyAccount { get; set; }

        [JsonProperty("ThirdPartyReference")]
        public string ThirdPartyReference { get; set; }

        [JsonProperty("ThumbnailReference")]
        public object ThumbnailReference { get; set; }

        [JsonProperty("TransactionDescription")]
        public string TransactionDescription { get; set; }

        [JsonProperty("TransactionOwnerBadgeColor")]
        public int TransactionOwnerBadgeColor { get; set; }

        [JsonProperty("TransactionOwnerDescription")]
        public string TransactionOwnerDescription { get; set; }

        [JsonProperty("TransactionTimestampNZ")]
        public string TransactionTimestampNZ { get; set; }

        [JsonProperty("PaymentCustomerNumber")]
        public string PaymentCustomerNumber { get; set; }

        [JsonProperty("PaymentUri")]
        public string PaymentUri { get; set; }

        [JsonProperty("PaymentId")]
        public int PaymentId { get; set; }

        [JsonProperty("CreatedByName")]
        public string CreatedByName { get; set; }

        [JsonProperty("CreatedByBadgeColor")]
        public int CreatedByBadgeColor { get; set; }

        [JsonProperty("IsUpcomingPayment")]
        public bool IsUpcomingPayment { get; set; }

        [JsonProperty("AllowViewDetails")]
        public bool AllowViewDetails { get; set; }

        [JsonProperty("CanBeEdited")]
        public bool CanBeEdited { get; set; }

        [JsonProperty("ToAccount")]
        public int ToAccount { get; set; }

        [JsonProperty("FromAccount")]
        public int FromAccount { get; set; }

        [JsonProperty("PaymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("ToDetails")]
        public ToDetails ToDetails { get; set; }

        [JsonProperty("FromDetails")]
        public string FromDetails { get; set; }

        [JsonProperty("DocumentType")]
        public string DocumentType { get; set; }
    }

    public class AllChunkParameter
    {

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }
    }

    public class AccountTransactionListResponseDocument
    {

        [JsonProperty("ItemList")]
        public List<ItemList> ItemList { get; set; }

        [JsonProperty("ChunkNumber")]
        public int ChunkNumber { get; set; }

        [JsonProperty("HasMoreTransactions")]
        public bool HasMoreTransactions { get; set; }

        [JsonProperty("AllChunkParameters")]
        public List<AllChunkParameter> AllChunkParameters { get; set; }

        [JsonProperty("DocumentType")]
        public string DocumentType { get; set; }
    }

    public class Account
    {

        [JsonProperty("AccountTransactionSearchUri")]
        public string AccountTransactionSearchUri { get; set; }

        [JsonProperty("UpcomingPayments")]
        public List<object> UpcomingPayments { get; set; }

        [JsonProperty("AccountTransactionListResponseDocument")]
        public AccountTransactionListResponseDocument AccountTransactionListResponseDocument { get; set; }

        [JsonProperty("AccountUri")]
        public string AccountUri { get; set; }

        [JsonProperty("AdditionalText")]
        public object AdditionalText { get; set; }

        [JsonProperty("Balance")]
        public string Balance { get; set; }

        [JsonProperty("AvailableFunds")]
        public string AvailableFunds { get; set; }

        [JsonProperty("Icon")]
        public int Icon { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("AllowsDeposit")]
        public bool AllowsDeposit { get; set; }

        [JsonProperty("AllowsWithdrawal")]
        public bool AllowsWithdrawal { get; set; }

        [JsonProperty("FullAuthority")]
        public bool FullAuthority { get; set; }

        [JsonProperty("publicAuthorityOnly")]
        public bool publicAuthorityOnly { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Number")]
        public string Number { get; set; }

        [JsonProperty("CustomerNumber")]
        public string CustomerNumber { get; set; }

        [JsonProperty("AccountPartnersUri")]
        public string AccountPartnersUri { get; set; }

        [JsonProperty("IsInvestmentAccount")]
        public bool IsInvestmentAccount { get; set; }

        [JsonProperty("PaperStatementsSupressed")]
        public bool PaperStatementsSupressed { get; set; }

        [JsonProperty("ChequeBookEnabled")]
        public bool ChequeBookEnabled { get; set; }

        [JsonProperty("DepositBookEnabled")]
        public bool DepositBookEnabled { get; set; }

        [JsonProperty("AvailableForSmsAlerts")]
        public bool AvailableForSmsAlerts { get; set; }

        [JsonProperty("DocumentType")]
        public string DocumentType { get; set; }
    }

    public class AccountGetResponse
    {

        [JsonProperty("Account")]
        public Account Account { get; set; }

        [JsonProperty("AccountPrintAndExportTemplateUri")]
        public string AccountPrintAndExportTemplateUri { get; set; }

        [JsonProperty("AccountPrintAndExportUri")]
        public string AccountPrintAndExportUri { get; set; }

        [JsonProperty("AccountSettingsUri")]
        public string AccountSettingsUri { get; set; }

        [JsonProperty("AccountStatementsUri")]
        public string AccountStatementsUri { get; set; }

        [JsonProperty("MoveMoneyToUri")]
        public string MoveMoneyToUri { get; set; }

        [JsonProperty("DocumentType")]
        public string DocumentType { get; set; }
    }

}
