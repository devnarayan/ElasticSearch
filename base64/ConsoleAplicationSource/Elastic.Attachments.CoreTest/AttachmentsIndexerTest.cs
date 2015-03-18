using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elastic.Attachments.CoreTest
{
    using System.Threading.Tasks;

    using Autofac;

    using Elastic.Attachments.Core;
    using Elastic.Attachments.Core.Services;
    using Elastic.Attachments.IOC;

    [TestClass]
    public class AttachmentsIndexerTest
    {
        /// <summary>
        /// The initialize test.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            CoreInitializer.Initialize(Dependencies);
        }

        private void Dependencies(ContainerBuilder builder)
        {
            // register indexer module
            builder.RegisterModule(new ElasticAttachmentsModule());
        }

        [TestMethod]
        public void IndexTest()
        {
            var indexer = ServiceLocator.Resolve<IAttachmentsIndexer>();
            var result = indexer.Index("/demo2/demo2/1/1/190/emailAttachments/mymicrosExportSpec109.doc");
            Assert.IsTrue(result);

        }
        [TestMethod]
        public async Task IndexAsyncTest()
        {
            var indexer = ServiceLocator.Resolve<IAttachmentsIndexer>();
            var result = indexer.Index("/demo2/demo2/1/1/500/emailAttachments/All%20Store%20List%20071613.xlsx");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IndexTest2()
        {
            var indexer = ServiceLocator.Resolve<IAttachmentsIndexer>();
            var result = indexer.Index("/demo2/demo2/1/1/2173/emailAttachments/image001.jpg");
            Assert.IsTrue(result);

        }
        [TestMethod]
        public async Task IndexAsyncTest2()
        {
            var indexer = ServiceLocator.Resolve<IAttachmentsIndexer>();
            var result = indexer.Index("/demo2/demo2/1/1/11984/emailAttachments/image005.png");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IndexTest3()
        {
            var indexer = ServiceLocator.Resolve<IAttachmentsIndexer>();
            var result = indexer.Index("/demo2/demo2/1/1/94/emailAttachments/Updated%20MICROS-IT%20Manager%20Job%20Description_August2013.docx");
            Assert.IsTrue(result);

        }
        [TestMethod]
        public async Task IndexAsyncTest3()
        {
            var indexer = ServiceLocator.Resolve<IAttachmentsIndexer>();
            var result = indexer.Index("/demo2/demo2/1/1/94/emailAttachments/Updated%20MICROS-IT%20Manager%20Job%20Description_August2013.txt");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IndexTest4()
        {
            var indexer = ServiceLocator.Resolve<IAttachmentsIndexer>();
            var result = indexer.Index("/demo2/demo2/1/1/99/emailAttachments/Sample%20SOW%20Template.pdf");
            Assert.IsTrue(result);

        }
        [TestMethod]
        public async Task IndexAsyncTest4()
        {
            var indexer = ServiceLocator.Resolve<IAttachmentsIndexer>();
            var result = indexer.Index("/demo2/demo2/1/1/2649/emailAttachments/ATT00014.htm");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public async Task IndexAsyncTest5()
        {
            var indexer = ServiceLocator.Resolve<IAttachmentsIndexer>();
            var result = indexer.Index("/demo2/demo2/1/1/2173/emailAttachments/test.tif");
            Assert.IsTrue(result);
        }

    }
}
