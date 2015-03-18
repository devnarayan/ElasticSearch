// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElasticAttachmentsModule.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Autofac module
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core
{
    using Autofac;

    using Elastic.Attachments.Core.Services;

    /// <summary>
    /// Autofac module
    /// </summary>
    public class ElasticAttachmentsModule : Module
    {
        /// <summary>
        /// The builder of dependencies
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ElasticAzureAttachmentsIndexer>()
                      .As<IAttachmentsIndexer>()
                      .SingleInstance();

            builder.RegisterType<ElasticSearchEngineService>()
                      .As<ISearchEngineService>()
                      .InstancePerDependency();

            builder.RegisterType<AzureBlobStorageService>()
                            .As<IStorageService>()
                            .InstancePerDependency();

            builder.RegisterType<ConverterObjectsStrategy>()
                .As<IConverterObjectsStrategy>()
                .InstancePerDependency();
        }
    }
}
