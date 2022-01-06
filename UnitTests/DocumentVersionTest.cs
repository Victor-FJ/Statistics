using DataAccess.DocumentVersions;
using DataAccess.Statistics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class DocumentVersionTest
    {
        private readonly Mock<IDocumentVersionDataAccess> _documentVersionDataAccess = new Mock<IDocumentVersionDataAccess>();

        [TestMethod]
        public void AverageNumberOfCompaniesInTheSameGroupTest()
        {
            //Arrange
            var filter = new DateFilter();

            List<DocumentVersionType> typesOfDocumentVersions = new List<DocumentVersionType>
            {
                new DocumentVersionType(),
                new DocumentVersionType(){ QuestionnaireSkipped = true, FilePdfId = Guid.NewGuid() },
                new DocumentVersionType(){ QuestionnaireSkipped = true, FilePdfId = Guid.NewGuid() },
                new DocumentVersionType(){ QuestionnaireSkipped = true, FilePdfId = Guid.Empty },
                new DocumentVersionType(){ QuestionnaireSkipped = true, Url = "Test"},
                new DocumentVersionType(){ Answers = new List<CC.Core.DocumentVersion.DocumentVersionAnswerItemEntity>
                {
                    new CC.Core.DocumentVersion.DocumentVersionAnswerItemEntity()
                }
                }
            };

            _documentVersionDataAccess.Setup(x => x.SplitBetweenTheTypeOfDocumentsInPercentage(filter)).Returns(typesOfDocumentVersions);
            var documentVersionService = new DocumentVersionService(_documentVersionDataAccess.Object);

            //Act
            NumberStatistics<DocumentVersionTypePercentage> result = documentVersionService.SplitBetweenTheTypeOfDocumentsInPercentage(filter);

            //Assert
            double expectedAnswersPercentage = 0.25;
            double expectedUrlPercentage = 0.25;
            double expectedFilePercentage = 0.5;

            Assert.AreEqual(expectedAnswersPercentage, result.Result.Questionnarie);
            Assert.AreEqual(expectedUrlPercentage, result.Result.ExternalLink);
            Assert.AreEqual(expectedFilePercentage, result.Result.FileUpload);
        }
    }
}
