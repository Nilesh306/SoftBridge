using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Softbridge_API.Controllers;
using Softbridge_API.Models;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Linq;
using Moq;

namespace SoftbridgeApi.Test
{
    [TestClass]
    public class UnitTest1
    {
                
            ProductController controller = new ProductController();
        
        [TestMethod]
        public void GetAllProductsTest()
        {  
           
            
           var data = controller.GetProducts();
            int count = data.Count();
         
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetSpecificProduct()
        {
          
            var response = controller.GetProduct(1);
            var contentResult = response as OkNegotiatedContentResult<SoftBridgeProduct>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.ProductID);
        }
        [TestMethod]
        public void GetReturnsNotFound()
        {
           
           var controller = new ProductController();

            IHttpActionResult actionResult = controller.GetProduct(20);

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
        [Ignore]
        public void DeleteProductbyid()
        {
          
            var response = controller.DeleteProduct(2);
            var contentResult = response as OkNegotiatedContentResult<SoftBridgeProduct>;

            Assert.IsNotNull(contentResult);
         
           // Assert.AreEqual(16, contentResult.Content.ProductID);
        }
        [TestMethod]
        public void PostMethodSetsLocationHeader()
        {
            
            IHttpActionResult actionResult = controller.PostProduct(new SoftBridgeProduct { Name = "BOOKS", Description="EDUCATION",Price=350.90m, ImageURL= @"C:\Users\NILESH SINGH BHATI\Desktop\Chiko-Photos\IMG20191012205918.jpg" });
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<SoftBridgeProduct>;

           
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(2, createdResult.RouteValues["id"]);
        }
    }
}
