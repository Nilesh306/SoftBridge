using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftBridgeApp.Controllers;
using SoftBridgeApp.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SoftBridgeApplication.Test
{
    [TestClass]
    public class UnitTest1
    {
        ProductController controller = new ProductController();

        [TestMethod]
        public void GetProducts()
        {
            
                var result = controller.AddNewProduct() as ViewResult;
                var data = (IEnumerable<Product>)result.ViewData.Model;
                Assert.AreEqual(1, data.Count());
                Assert.IsNotNull(result);
          
        }
        [TestMethod]
        public void GetProductsbyID()
        {
            int productid = 1;
            var result = controller.DetailsProduct(productid) as ViewResult;
         
            Assert.IsNotNull(result.Model);
         

        }
        [TestMethod]
        public void GetProductsbyIDNotPresent()
        {
            int productid = 25;
            var result = controller.DetailsProduct(productid) as ViewResult;
            
           
            Assert.IsNull(result.Model);

        }

        [TestMethod]
    
        public void PostProductData()
        {

            Product pmd = new Product
            {
                Name = "Apple",
                Description = "Eat Apple Every Day",
                Price = 377.87m,

            };


            HttpPostedFileBase imgfile = null;

            var result = controller.SaveData(pmd,imgfile) as JsonResult;
  
         
            Assert.AreEqual("Failed! Field value is not Appropriate...", result.Data);
        }

        [TestMethod]
        public void GetdeletebyID()
        {
            var result = (RedirectToRouteResult)controller.Delete(4);
            Assert.AreEqual("AddNewProduct", result.RouteValues["action"]);
        }

     

    }
}
