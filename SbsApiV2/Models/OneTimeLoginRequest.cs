using System;

namespace SbsApiV2.Models
{
    /// <summary>
    /// One time login request post model, used to initiate a login
    /// </summary>
    public class OneTimeLoginRequest
    {
        public OneTimeLoginRequest(string username, string deviceId, string deviceType)
        {
            Username = username;
            DeviceId = deviceId;
            DeviceType = deviceType;
        }

        public readonly string DocumentType = "OneTimeLoginTokenRequestDocument";
        public string Username { get; set; }
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
    }
}
