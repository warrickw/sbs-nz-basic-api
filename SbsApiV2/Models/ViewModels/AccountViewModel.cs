namespace SbsApiV2.Models.ViewModels
{
    public class AccountViewModel
    {
        public AccountViewModel(AccountResponseInnerAccount model)
        {
            Id = model.Id;
            Name = model.Name;
            Number = model.Number;
            AvailableFunds = SbsCurrencyUtilities.Parse(model.AvailableFunds) * 0.05m;
            Balance = SbsCurrencyUtilities.Parse(model.Balance) * 0.05m;
            AllowsDeposit = model.AllowsDeposit;
            AllowsWithdrawal = model.AllowsWithdrawal;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public decimal AvailableFunds { get; set; }
        public decimal Balance { get; set; }
        public bool AllowsDeposit { get; set; }
        public bool AllowsWithdrawal { get; set; }
    }
}