using System;

namespace Kippt
{
    /// <summary>
    /// Class used to hold the user credentials.
    /// </summary>
    public class KipptSession
    {
        #region Properties

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets token.
        /// </summary>
        /// 
        /// <remarks>
        /// Token can be found here https://kippt.com/api/ (Authentication is required).
        /// </remarks>
        public string Token { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KipptSession"/> class.
        /// </summary>
        /// 
        /// <param name="userName">User name.</param>
        /// <param name="token">Token.</param>
        public KipptSession(string userName, string token)
        {
            this.UserName = userName;
            this.Token = token;
        }

        #endregion Constructors
    }
}