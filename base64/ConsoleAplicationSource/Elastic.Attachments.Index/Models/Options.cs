// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Options.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Command line arguments
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Index.Models
{
    using CommandLine;

    /// <summary>
    /// Command line arguments
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Local path of file
        /// </summary>
        [Option('u', "url", Required = false, HelpText = "Input local path file.")]
        public string File { get; set; }

        /// <summary>
        /// Conatainer name
        /// </summary>
        [Option('c', "container", Required = false, HelpText = "Input container name.")]
        public string Conatainer { get; set; }
    }
}