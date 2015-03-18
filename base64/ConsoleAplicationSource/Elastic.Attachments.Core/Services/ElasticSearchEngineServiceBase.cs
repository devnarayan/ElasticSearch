// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElasticSearchEngineServiceBase.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Base class for working with ElasticSearch
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.Services
{
    using System;
    using System.Configuration;

    using Elastic.Attachments.Core.Models;
    using Elastic.Attachments.Core.SearchEngines;

    using Elasticsearch.Net.Connection;

    using Nest;

    /// <summary>
    /// Base class for working with ElasticSearch
    /// </summary>
    public abstract class ElasticSearchEngineServiceBase
    {
        private ElasticClient elasticClient;

        /// <summary>
        /// ElasticClient
        /// </summary>
        protected ElasticClient ElasticClient
        {
            get
            {
                if (this.elasticClient == null)
                {

                    var setting =
                        new ConnectionSettings(
                            new Uri(string.Format("http://{0}", ConfigurationManager.AppSettings["searchengine-host"])));
                    setting.PluralizeTypeNames(); 
#if TRACE
                    setting.EnableTrace();
#endif
                    //Basic Auth          
                    var connection = ConfigurationManager.AppSettings["searchengine-basic-auth"] != null
                                     && Convert.ToBoolean(ConfigurationManager.AppSettings["searchengine-basic-auth"])
                                         ? new BasicAuthHttpConnection(
                                               setting,
                                               ConfigurationManager.AppSettings["searchengine-user"],
                                               ConfigurationManager.AppSettings["searchengine-password"])
                                         : new HttpConnection(setting);

                    setting.MapDefaultTypeIndices(d => d.Add(typeof(Doc), ConfigurationManager.AppSettings["searchengine-indexname"]));
                    setting.MapDefaultTypeIndices(d => d.Add(typeof(BaseDoc), ConfigurationManager.AppSettings["searchengine-indexname"]));
                    setting.MapDefaultTypeIndices(d => d.Add(typeof(Email), ConfigurationManager.AppSettings["searchengine-indexname"]));

                    this.elasticClient = new ElasticClient(setting, connection);
                }

                return this.elasticClient;
            }
        }
    }
}