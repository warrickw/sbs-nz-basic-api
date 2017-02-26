using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbsApiV2.Models
{
    /// <summary>
    /// A class for storing all the sbs encryption and session information
    /// </summary>
    public class AuthenticationTokenContainer
    {
        /// <summary>
        /// Construct an authentication token container from values
        /// </summary>
        /// <param name="token"></param>
        /// <param name="keyStrengtheningIterations"></param>
        /// <param name="username"></param>
        public AuthenticationTokenContainer(string token, int keyStrengtheningIterations, string username)
        {
            this.Token = token;
            this.KeyStrentheningIterations = keyStrengtheningIterations;
            this.Username = username;
        }

        public AuthenticationTokenContainer()
        {

        }

        public string Token { get; set; }
        public int KeyStrentheningIterations { get; set; }
        public string Username { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public bool HasExpired {
            get
            {
                return ExpiresAt < DateTime.UtcNow;
            }
        }

        // JOOB session cookies
        public string CookieHeader { get; set; }
        public string UserId { get; set; }

        public SbsEncryption CreateEncryption()
        {
            return new SbsEncryption(Token, KeyStrentheningIterations, Username);
        }

        /// <summary>
        /// Serialize this authentication token container into a base64 string
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this)));
        }

        /// <summary>
        /// Create this object from a serialized string version of it
        /// </summary>
        /// <param name="serializedString"></param>
        /// <returns></returns>
        public static AuthenticationTokenContainer Parse(string serializedString) {
            string jsonString = Encoding.UTF8.GetString(Convert.FromBase64String(serializedString));
            return JsonConvert.DeserializeObject<AuthenticationTokenContainer>(jsonString);
        }
    }
}
