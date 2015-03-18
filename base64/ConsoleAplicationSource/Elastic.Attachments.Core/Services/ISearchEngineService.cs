// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearchEngineService.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Inreface search engine
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.Services
{
    using System.Threading.Tasks;

    using Elastic.Attachments.Core.Models;

    /// <summary>
    /// Inreface search engine
    /// </summary>
    public interface ISearchEngineService
    {
        /// <summary>
        /// Index doc (load file in search engine)
        /// </summary>
        /// <param name="doc">Document</param>
        /// <returns></returns>
        Task<bool> IndexAsync(BaseDoc doc);

        /// <summary>
        /// Index doc (load file in search engine) 
        /// </summary>
        /// <param name="doc">Document</param>
        bool Index(BaseDoc doc);
    }
}