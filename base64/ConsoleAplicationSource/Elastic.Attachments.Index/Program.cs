// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Program of indexing
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Index
{
    using System;

    using Autofac;

    using Elastic.Attachments.Core;
    using Elastic.Attachments.Core.Services;
    using Elastic.Attachments.Index.Models;
    using Elastic.Attachments.IOC;

    /// <summary>
    /// Program of indexing
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArgumentsStrict(args, options))
            {
                CoreInitializer.Initialize(Dependencies);
                using (var lifetime = ServiceLocator.GetContainer().BeginLifetimeScope())
                {
                    var module = lifetime.Resolve<IAttachmentsIndexer>();

                    if (!string.IsNullOrWhiteSpace(options.File)) 
                        module.Index(options.File);
                    else if (!string.IsNullOrWhiteSpace(options.Conatainer)) 
                        module.IndexFromContainer(options.Conatainer);
                    else 
                        module.IndexFromContainer();
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// The register dependencies.
        /// </summary>
        /// <param name="builder">
        /// The IOC container builder.
        /// </param>
        private static void Dependencies(ContainerBuilder builder)
        {
            // register indexer module
            builder.RegisterModule(new ElasticAttachmentsModule());
        }
    }
}
