// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasicAuthHttpConnection.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   HttpConnection with basic auth usage
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.SearchEngines
{
    using System;
    using System.Globalization;
    using System.Text;

    using Elasticsearch.Net.Connection;
    using Elasticsearch.Net.Connection.Configuration;

    /// <summary>
    /// HttpConnection with basic auth usage
    /// </summary>
    public sealed class BasicAuthHttpConnection : HttpConnection
    {
        /// <summary>
        /// Password
        /// </summary>
        private readonly string _password;

        /// <summary>
        /// Username
        /// </summary>
        private readonly string _userName;

        /// <summary>
        /// constructor with username + password for the basic auth
        /// </summary>
        /// <param name="settings">Connection settings</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        public BasicAuthHttpConnection(IConnectionConfigurationValues settings, string username, string password) : base(settings)
        {
            this._userName = username;
            this._password = password;
        }


        /// <summary>
        /// Creation of web request
        /// </summary>
        /// <param name="uri">Url-address</param>
        /// <param name="method">Method</param>
        /// <param name="data">Data</param>
        /// <param name="requestSpecificConfig">Settings</param>
        /// <returns>Web-request</returns>
        protected override System.Net.HttpWebRequest CreateWebRequest(Uri uri, string method, byte[] data, IRequestConfiguration requestSpecificConfig)
        {
            var request = base.CreateWebRequest(uri, method, data, requestSpecificConfig);
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", this._userName, this._password)));
            return request;
        }

        /// <summary>
        /// Creation of web request
        /// </summary>
        /// <param name="uri">Url-address</param>
        /// <param name="method">Method</param>
        /// <param name="data">Data</param>
        /// <param name="requestSpecificConfig">Settings</param>
        /// <returns>Web-request</returns>
        protected override System.Net.HttpWebRequest CreateHttpWebRequest(Uri uri, string method, byte[] data, IRequestConfiguration requestSpecificConfig)
        {
            var request = base.CreateHttpWebRequest(uri, method, data, requestSpecificConfig);
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format(CultureInfo.InvariantCulture, "{0}:{1}", this._userName, this._password)));
            return request;
        }
    }
}