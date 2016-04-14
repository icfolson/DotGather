using DotGather.GatherContent.Objects;
using DotGather.GatherContent.Service;
using DotGather.Interfaces;
using DotGather.Test.TestUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotGather.Test.Tests.Service
{
    public class GatherContentServiceTest
    {
        #region Global Test Variables

        private GatherContentService service = new GatherContentService();
        private DateTime now = DateTime.Now;

        #endregion

        #region Positive Unit Tests
        [Fact]
        [Trait("ObjectValueComparison", "GetMeTest()>")]
        public void GetMeTest()
        {            
            //Arrange
            User actual = new User();
            User expected = ExpectedValuesLibrary.GetMeTestJsonData;
            
            //Act
            actual = (User)service.GetMe();

            //Assert
            Assert.True(ObjectValueComparison.AreEqual(expected, actual));
        }

        [Fact]
        [Trait("ObjectValueComparison", "GetAccountsTest()")]
        public void GetAccountsTest()
        {
            //Arrange
            Accounts actual = new Accounts();
            Accounts expected = ExpectedValuesLibrary.GetAccountsTestJsonData;

            //Act
            actual = service.GetAccounts();

            //Assert
            Assert.True(ObjectValueComparison.AreEqual<Accounts>(expected, actual));
        }

        [Fact]
        [Trait("ObjectValueComparison", "GetProjectsTest()")]
        public void GetProjectsTest()
        {
            //Arrange
            Project actual = new Project();
            Project expected = ExpectedValuesLibrary.GetProjectsTestJsonData.First(x => x.Id == ExpectedValuesLibrary.SampleProjectId);

            //Act
            actual = service.GetProjects(ExpectedValuesLibrary.SampleAccountId).First(x => x.Id == ExpectedValuesLibrary.SampleProjectId);

            //Assert
            Assert.True(ObjectValueComparison.AreEqual(expected, actual));
        }

        [Fact]
        [Trait("ObjectValueComparison", "GetProjectTest()")]
        public void GetProjectTest()
        {
            //Arrange
            Project actual = new Project();
            Project expected = ExpectedValuesLibrary.GetProjectsTestJsonData.First(x => x.Id == ExpectedValuesLibrary.SampleProjectId);

            //Act
            actual = (Project)service.GetProject(ExpectedValuesLibrary.SampleProjectId);

            //Assert
            Assert.True(ObjectValueComparison.AreEqual(expected, actual));
        }

        [Fact]
        [Trait("Equal", "CreateProjectTest()")]
        public void CreateProjectTest()
        {
            //Arrange
            string actual;
            string expected = "CreateProjectTestName" + DateTime.Now;

            //Act
            service.CreateProject(ExpectedValuesLibrary.SampleAccountId, expected);
            actual = service.GetProjects(ExpectedValuesLibrary.SampleAccountId).First(x => x.Name == expected).Name;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("ObjectValueComparison", "GetStatusesTest()")]
        public void GetStatusesTest()
        {
            //Arrange
            Statuses actual = new Statuses();
            Statuses expected = ExpectedValuesLibrary.GetStatusesTestJsonData;

            //Act
            actual = service.GetStatuses(ExpectedValuesLibrary.SampleProjectId);

            //Assert
            Assert.True(ObjectValueComparison.AreEqual<Statuses>(actual, expected));
        }

        [Fact]
        [Trait("ObjectValueComparison", "GetStatusTest()")]
        public void GetStatusTest()
        {
            //Arrange
            Status actual = new Status();
            Status expected = ExpectedValuesLibrary.GetStatusesTestJsonData.First(x => x.Id == ExpectedValuesLibrary.SampleStatusId);

            //Act
            actual = (Status)service.GetStatus(ExpectedValuesLibrary.SampleProjectId, ExpectedValuesLibrary.SampleStatusId);

            //Assert
            Assert.True(ObjectValueComparison.AreEqual(actual, expected));
        }

        [Fact]
        [Trait("ObjectValueComparison", "GetItemTest()")]
        public void GetItemTest()
        {
            //Arrange
            Page actual = new Page();
            Page expected = ExpectedValuesLibrary.GetItemTestJsonData;

            //Act
            actual = (Page)service.GetItem(ExpectedValuesLibrary.SampleItemId);

            //Assert
            Assert.True(ObjectValueComparison.AreEqual(actual, expected));
        }

        [Fact]
        [Trait("ObjectValueComparison", "GetFilesForItemTest()")]
        public void GetFilesForItemTest()
        {
            //Arrange
            GatherFiles actual = new GatherFiles();
            GatherFiles expected = ExpectedValuesLibrary.GetFilesForItemTestJsonData;

            //Act
            actual = service.GetFilesForItem(ExpectedValuesLibrary.SampleItemId);

            //Assert
            Assert.True(ObjectValueComparison.AreEqual(actual, expected));
        }

        [Fact]
        public void GetTemplateTest()
        {
            //Arrange
            Template actual = new Template();
            Template expected = ExpectedValuesLibrary.GetTemplatesTestJsonData[0];

            //Act
            actual = (Template)service.GetTemplate(ExpectedValuesLibrary.SampleTemplateId);

            //Assert
            Assert.True(ObjectValueComparison.AreEqual(actual, expected));

        }

        [Fact]
        public void GetTemplatesTest()
        {
            //Arrange
            Templates actual = new Templates();
            Templates expected = ExpectedValuesLibrary.GetTemplatesTestJsonData;

            //Act
            actual = service.GetTemplates(ExpectedValuesLibrary.SampleProjectId);

            //Assert
            Assert.True(ObjectValueComparison.AreEqual(actual, expected));

        }

        [Fact]
        public void ChooseStatusTest()
        {
            //Arrange
            Status actual = new Status();
            Random randNum = new Random();
            var index = randNum.Next(0, 4);
            Status expected = ExpectedValuesLibrary.GetStatusesTestJsonData[index];

            //Act
            service.ChooseStatus(ExpectedValuesLibrary.SampleItemId, expected.Id);
            actual = service.GetItem(ExpectedValuesLibrary.SampleItemId).Status;

            //Assert
            Assert.True(ObjectValueComparison.AreEqual(actual, expected));

        }

        [Fact]
        public void SaveItemTest()
        {
            //Arrange
            string actual = "";
            string expected = "";
            var config = ExpectedValuesLibrary.SampleConfigJsonData;
            var uniqueName = "SaveItemConfigTest " + DateTime.Now;
            config.First().Label = uniqueName;
            expected = uniqueName;
            //Act
            service.SaveItem(ExpectedValuesLibrary.SamplePostItemId, config);
            actual = service.GetItem(ExpectedValuesLibrary.SamplePostItemId).ContentSections.First().Label;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CreateItemTest()
        {
            //Arrange
            string actual = "";
            var uniqueName = "CreateItemTest " + DateTime.Now;
            Page expected = new Page
            {
                ProjectId = ExpectedValuesLibrary.SamplePostProjectID,
                Name = uniqueName,
                ContentSections = ExpectedValuesLibrary.SampleConfigJsonData
            };

            //Act
            service.CreateItem(expected);
            actual = service.GetItems(ExpectedValuesLibrary.SamplePostProjectID).Where(x => x.Name == uniqueName).First().Name;

            //Assert
            Assert.Equal(actual, expected.Name);
        }

        [Fact]
        public void ApplyTemplateTest()
        {
            //Arrange
            int actual, expected;
            Template expectedTemplate = new Template();
            var templates = new Templates();
            Random rand = new Random();
            //Act
            templates = service.GetTemplates(ExpectedValuesLibrary.SamplePostProjectID);
            expectedTemplate = templates[rand.Next(0, templates.Count)];
            expected = expectedTemplate.Id;
            service.ApplyTemplate(ExpectedValuesLibrary.SamplePostItemId, expectedTemplate.Id);
            actual = service.GetItem(ExpectedValuesLibrary.SamplePostItemId).TemplateId.GetValueOrDefault();

            //Assert
            Assert.True(ObjectValueComparison.AreEqual(actual, expected));
        }
        #endregion

        #region Negative Unit Tests

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [Trait("ArgumentNullException ", "GetProjects(int accountId)")]
        public void GetProjects_ThrowsErrorWhenAccountIsZeroOrLess(int accountId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.GetProjects(accountId));

            //Assert
            Assert.True(expectedException.Message.Contains("Project ID cannot be less than or equal to zero."));
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [Trait("ArgumentNullException", "GetProject(int projectId)")]
        public void GetProject_ThrowsErrorWhenProjectIsZeroOrLess(int projectId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.GetProject(projectId));

            //Assert
            Assert.True(expectedException.Message.Contains("Project ID cannot be less than or equal to zero."));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [Trait("ArgumentNullException", "GetStatuses(int projectId)")]
        public void GetStatuses_ThrowsErrorWhenProjectIsZeroOrLess(int projectId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.GetStatuses(projectId));

            //Assert
            Assert.True(expectedException.Message.Contains("Project ID cannot be less than or equal to zero."));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(-1, -1)]
        [Trait("ArgumentNullException", "GetStatus(int projectId, int statusId)")]
        public void GetStatus_ThrowsErrorWhenProjectOrStatusIsZeroOrLess(int projectId, int statusId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.GetStatus(projectId, statusId));

            //Assert

            Assert.True(projectId <= 0  ? 
                 expectedException.Message.Contains("Project ID cannot be less than or equal to zero.")
                 : expectedException.Message.Contains("Status ID cannot be less than or equal to zero."));
          
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [Trait("ArgumentNullException", "GetItems(int projectId)")]
        public void GetItems_ThrowsErrorWhenProjectIsZeroOrLess(int projectId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.GetItems(projectId));

            //Assert
            Assert.True(expectedException.Message.Contains("Project ID cannot be less than or equal to zero."));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [Trait("ArgumentNullException", "GetItem(int itemId)")]
        public void GetItem_ThrowsErrorWhenItemIsZeroOrLess(int itemId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.GetItem(itemId));

            //Assert
            Assert.True(expectedException.Message.Contains("Item ID cannot be less than or equal to zero."));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [Trait("ArgumentNullException", "GetFilesForItem(int itemId)")]
        public void GetFilesForItem_ThrowsErrorWhenItemIsZeroOrLess(int itemId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.GetFilesForItem(itemId));

            //Assert
            Assert.True(expectedException.Message.Contains("Item ID cannot be less than or equal to zero."));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [Trait("ArgumentNullException", "GetTemplates(int projectId)")]
        public void GetTemplates_ThrowsErrorWhenProjectIsZeroOrLess(int projectId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.GetTemplates(projectId));

            //Assert
            Assert.True(expectedException.Message.Contains("Project ID cannot be less than or equal to zero."));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(null)]
        [Trait("ArgumentNullException", "GetTemplate(int templateId)")]
        public void GetTemplate_ThrowsErrorWhenTemplateIsZeroOrLess(int templateId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.GetTemplate(templateId));

            //Assert
            Assert.True(expectedException.Message.Contains("Template ID cannot be less than or equal to zero."));
        }

        [Theory]
        [InlineData(0 , null)]
        [InlineData(-1 , "")]
        [InlineData(0 , " ")]
        [InlineData(1, " ")]
        [InlineData(1, "")]
        [InlineData(1, null)]
        [Trait("ArgumentNullException", "CreateProject(int accountId , string name)")]
        public void CreateProject_ThrowsErrorWhenAccountIdOrNameIsZeroOrLessOrEmpty(int accountId , string name)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.CreateProject(accountId, name));

            //Assert
            Assert.True(accountId <= 0 ?
              expectedException.Message.Contains("Account ID cannot be less than or equal to zero.")
              : expectedException.Message.Contains("Project name cannot be empty."));
            }

        [Theory, MemberData("PageData")]
        [Trait("ArgumentNullException", "CreateItem(Page page)")]
        public void CreateItem_ThrowsErrorWhenPageNameIsBlankOrProjectIsZeroOrLess(string pageName, int projectId)
        {
            //Arrange
            Page newPage = new Page();
            newPage.Name = pageName;
            newPage.ProjectId = projectId;

            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.CreateItem(newPage));

            //Assert
            Assert.True(expectedException.Message.Contains("The Page being created cannot have a blank name or a project ID less than or equal to 0"));
        }

        // Data for CreateItem_ThrowsErrorWhenPageNameIsBlankOrProjectIsZeroOrLess
        public static IEnumerable<object[]> PageData
        {
            get
            {
                // Data to populate the Page Class in the test 
                return new[]
                {
                new object[] { null, 0 },
                new object[] { "", -1 },
                new object[] { " ", null },
                new object[] { "test", 0 },
                new object[] { "test", -1 },
                new object[] { "test", null }
            };
            }
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [Trait("ArgumentNullException", "SaveItem(int itemId)")]
        public void SaveItem_ThrowsErrorWhenItemIsZeroOrLess(int itemId)
        {
            //Arrange
            var section = typeof(IEnumerable<ISection>) as IEnumerable<ISection>;

            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.SaveItem(itemId , section));

            //Assert
            Assert.True(expectedException.Message.Contains("Item ID cannot be less than or equal to zero."));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        [InlineData(1, 0)]
        [InlineData(1, -1)]
        [Trait("ArgumentNullException", "ApplyTemplate(int itemId , int templateId)")]
        public void ApplyTemplate_ThrowsErrorWhenItemOrTemplateIsZeroOrLess(int itemId , int templateId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.ApplyTemplate(itemId , templateId));

            //Assert
            Assert.True(itemId <= 0 ?
                expectedException.Message.Contains("Item ID cannot be less than or equal to zero.")
                : expectedException.Message.Contains("Template ID cannot be less than or equal to zero."));
            }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        [InlineData(1, 0)]
        [InlineData(1, -1)]
        [Trait("ArgumentNullException", "ChooseStatus(int itemId , int statusId)")]
        public void ChooseStatus_ThrowsErrorWhenItemOrStatusIsZeroOrLess(int itemId , int statusId)
        {
            //Arrange
            ArgumentNullException expectedException;

            //Act
            expectedException = Assert.Throws<ArgumentNullException>(() => service.ChooseStatus(itemId , statusId));

            //Assert
            Assert.True(itemId <= 0 ?
                expectedException.Message.Contains("Item ID cannot be less than or equal to zero.")
                : expectedException.Message.Contains("Status ID cannot be less than or equal to zero."));
            }

        [Fact]
        [Trait("InvalidOperationException", "PostRequest()")]
        public void PostRequest_ThrowsErrorWhenMethodNotFound()
        {
            //Arrange
            InvalidOperationException expectedException;
            service.RequestPath = "/DoesNotExist";

            //Act
            expectedException = Assert.Throws<InvalidOperationException>(() => service.PostRequest());

            //Assert
            Assert.True(expectedException.Message.Contains("The request you made doesn't exist."));
        }

        #endregion
    }
}
