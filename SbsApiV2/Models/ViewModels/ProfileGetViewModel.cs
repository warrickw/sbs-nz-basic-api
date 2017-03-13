using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models.ViewModels
{
    public class ProfileGetViewModel
    {
        public ProfileGetViewModel(ProfileResponse model)
        {
            FirstName = model.Customer.FirstName;
            LastName = model.Customer.LastName;
            PreferredName = model.Customer.LastName;
            MemberId = model.Customer.Number;
        }

        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
    }
}
