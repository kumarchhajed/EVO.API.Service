using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EVO.API.Service.Models;
using System.Collections.Generic;
using EVO.API.Service.Controllers;
using Moq;
using EVO.API.Service.Interfaces;
using System.Web.Http.Results;
using System.Web.Http;
using System.Net;

namespace EVO.API.Service.Tests
{
    [TestClass]
    public class ContantInfoControllerTest
    {

        [TestMethod]
        public void GetAllContacts_Test()
        {
            var repositoryMockObject = new Mock<IContactInfoRepository>();
            repositoryMockObject.Setup(service => service.GetAll()).Returns(GetTestContacts());

            var controller = new ContactInfoController(repositoryMockObject.Object);
            IHttpActionResult actionResult = controller.Get();
            var okRes = actionResult as OkNegotiatedContentResult<List<ContactInformation>>;
            Assert.IsNotNull(okRes);
            Assert.IsNotNull(okRes.Content);
            Assert.AreEqual(1, okRes.Content[0].ID);
        }

        [TestMethod]
        public void PutContact_Test()
        {
            var repositoryMockObject = new Mock<IContactInfoRepository>();
            var controller = new ContactInfoController(repositoryMockObject.Object);

            IHttpActionResult actionResult = controller.Put(1,GetTestContacts()[0]);
            var contentResult = actionResult as NegotiatedContentResult<ContactInformation>;
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.ID);
        }

        [TestMethod]
        public void PostContact_Test()
        {
            var repositoryMockObject = new Mock<IContactInfoRepository>();
            var controller = new ContactInfoController(repositoryMockObject.Object);

            IHttpActionResult actionResult = controller.Post(GetTestContacts()[1]);
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void DeleteContact_Test()
        {
            var repositoryMockObject = new Mock<IContactInfoRepository>();
            var controller = new ContactInfoController(repositoryMockObject.Object);

            IHttpActionResult actionResult = controller.Delete(1);
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        private List<ContactInformation> GetTestContacts()
        {
            var testContacts = new List<ContactInformation>();
            testContacts.Add(new ContactInformation { ID = 1, FirstName = "FirstDemo1", LastName = "LastDemo1", Email = "kumar1@gmail.com", Status = true});
            testContacts.Add(new ContactInformation { ID = 2, FirstName = "FirstDemo2", LastName = "LastDemo2", Email = "kumar2@gmail.com", Status = true });
            testContacts.Add(new ContactInformation { ID = 3, FirstName = "FirstDemo3", LastName = "LastDemo3", Email = "kumar3@gmail.com", Status = true });
            testContacts.Add(new ContactInformation { ID = 4, FirstName = "FirstDemo4", LastName = "LastDemo4", Email = "kumar4@gmail.com", Status = true });

            return testContacts;
        }
    }
}
