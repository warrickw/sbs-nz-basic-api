using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models
{
    /// <summary>
    /// The response model returned for the one time login request
    /// </summary>
    public class OneTimeLoginResponse
    {
        public string Token { get; set; }
        public bool JoobMobileEncryption { get; set; }
        public int KeyStrengtheningIterations { get; set; }
        public bool DisablePersistentEncryptionKey { get; set; }
    }
}
