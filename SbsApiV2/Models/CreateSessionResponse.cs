using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models
{
    public class CreateSessionResponse
    {
        public string SessionId { get; set; }
        public string ExpiryTime { get; set; }
        public string SessionCreationTime { get; set; }
        public string ApplicationId { get; set; }
        public string EnvironmentId { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public string User { get; set; }
        public bool PayloadEncrypted { get; set; }
        public string DeviceId { get; set; }

        // JOOB cookies are patched in here
        public string CookieHeader { get; set; }
    }
}
