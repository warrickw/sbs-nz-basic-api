using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models
{
    /// <summary>
    /// Device information model, which is passed inside the create session request
    /// </summary>
    public class DeviceInformation
    {
        public DeviceInformation(string additionalInformation, int deviceModel, string deviceType, string deviceId, string oSVersion, string joobMobileClient, string joobMobileClientVersion, string applicationVersion)
        {
            AdditionalInformation = additionalInformation;
            DeviceModel = deviceModel;
            DeviceType = deviceType;
            DeviceId = deviceId;
            OSVersion = oSVersion;
            JoobMobileClient = joobMobileClient;
            JoobMobileClientVersion = joobMobileClientVersion;
            ApplicationVersion = applicationVersion;
        }

        /// <summary>
        /// Create a default device information object filled out with some lame data
        /// </summary>
        public DeviceInformation()
        {

        }

        public string AdditionalInformation { get; set; } = "Chome buddy.";
        public int DeviceModel { get; set; } = -1;
        public string DeviceType { get; set; } = "Chrome";
        public string DeviceId { get; set; } = Guid.NewGuid().ToString();
        public string OSVersion { get; set; } = "Chrome";
        public string JoobMobileClient { get; set; } = "JavaScript";
        public string JoobMobileClientVersion { get; set; } = "4.1.0.0";
        public string ApplicationVersion { get; set; } = "4.1.0.0";
    }

    /// <summary>
    /// Create session request json model
    /// </summary>
    public class CreateSessionRequest
    {
        public CreateSessionRequest(string username, string userToken, DeviceInformation deviceInformation)
        {
            Username = username;
            UserToken = userToken;
            DeviceInformation = deviceInformation;
        }

        public string Username { get; set; }
        public string UserToken { get; set; }
        public DeviceInformation DeviceInformation { get; set; }
        public readonly string DocumentType = "SessionCreationDocument";
    }
}
 