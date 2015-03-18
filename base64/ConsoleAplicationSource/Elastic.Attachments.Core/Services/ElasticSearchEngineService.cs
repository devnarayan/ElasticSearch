// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElasticSearchEngineService.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Search engine ElasticSearch
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.Services
{
    using System;
    using System.Threading.Tasks;

    using Elastic.Attachments.Core.Models;

    using Nest;

    /// <summary>
    /// Search engine ElasticSearch
    /// </summary>
    public class ElasticSearchEngineService : ElasticSearchEngineServiceBase, ISearchEngineService
    {
        /// <summary>
        /// Index doc (load file in search engine)
        /// </summary>
        /// <param name="doc">Document</param>
        /// <returns></returns>
        public async Task<bool> IndexAsync(BaseDoc doc)
        {
            var index = await ElasticClient.IndexAsync(doc, descriptor => descriptor.Type(doc.Kind));
            Console.WriteLine("Index created = {0}, _id = {1}", index.Created, index.Id);
            return index.IsValid;
        }

        /// <summary>
        /// Index doc (load file in search engine) 
        /// </summary>
        /// <param name="doc">Document</param>
        public bool Index(BaseDoc doc)
        {
            var index = ElasticClient.Index(doc, descriptor => descriptor.Type(doc.Kind));
            Console.WriteLine("Index created = {0}, _id = {1}", index.Created, index.Id);
            return index.IsValid;
        }
    }
}
