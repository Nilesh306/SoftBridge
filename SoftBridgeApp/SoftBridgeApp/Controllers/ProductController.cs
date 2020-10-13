using SoftBridgeApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SoftBridgeApp.Controllers
{
    public class ProductController : Controller
    {
        private string Errorlog = @"D:\Nilesh\APISoftbridge\Error\ErrorLogText.txt";
        // GET: Product
      /// <summary>
      /// Fetch all the Product data From API
      /// </summary>
      /// <returns>List of all Product</returns>
        #region Add New Product
        public ActionResult AddNewProduct()
        {
            IEnumerable<Product> prodlist=null;
            try
            {
                
                HttpResponseMessage Response = GlobalVariable.Webapiclient.GetAsync("Product").Result;
                prodlist = Response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Errorlog, true);
                sw.WriteLine(System.DateTime.Now.ToString() + " SoftBridgeApp.Controllers - " + ex.ToString());
                sw.Flush();
                sw.Close();
            }
            return View(prodlist);
        }
        #endregion
        /// <summary>
        /// Saves data to the Database by calling API
        /// </summary>
       /// <returns>Json result success/failed</returns>
        #region Save Data
        public ActionResult SaveData(Product pmd,HttpPostedFileBase imgfile)
        {
            Random r = new Random();
            int random = r.Next();
            var result = "";
           

            try
            {
                string filename = Path.GetFileNameWithoutExtension(imgfile.FileName);
                string extension = Path.GetExtension(imgfile.FileName);
                filename = filename + random + extension;
                pmd.ImageURL = "~/Image/" + filename;

                if (pmd.Name != null && pmd.Description != null && pmd.Price != 0 && pmd.ImageURL != null)
            {
                
                    filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                    imgfile.SaveAs(filename);
                 


                    HttpResponseMessage response = GlobalVariable.Webapiclient.PostAsJsonAsync("Product", pmd).Result;
                    result = "Sucessfully Added";
                }
                else
                {
                    result = "Failed! Field value is not Appropriate...";
                }
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Errorlog, true);
                sw.WriteLine(System.DateTime.Now.ToString() + " SoftBridgeApp.Controllers - " + ex.ToString());
                sw.Flush();
                sw.Close();
                result = "Failed! Field value is not Appropriate...";
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        #endregion

       


       /// <summary>
       /// Delete Product based on ID
       /// </summary>
       /// <param name="id"></param>
       /// <returns>Redirect to Main page</returns>
        #region DeleteProduct
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.Webapiclient.DeleteAsync("Product/" + id.ToString()).Result;
          
            return RedirectToAction("AddNewProduct");
        }
        #endregion

        /// <summary>
        /// Get the selected full Product details 
        /// </summary>
        /// <param name="id"></param>
        /// <returns> </returns>
        #region DetailsProduct
        public ActionResult DetailsProduct(int id = 0)
        {
            Product prodlist = null;
            try
            {
                if (id == 0)
                {
                    prodlist = new Product();
                }
                else
                {
                    HttpResponseMessage response = GlobalVariable.Webapiclient.GetAsync("Product/" + id.ToString()).Result;
                  prodlist=response.Content.ReadAsAsync<Product>().Result;

                }
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Errorlog, true);
                sw.WriteLine(System.DateTime.Now.ToString() + " SoftBridgeApp.Controllers - " + ex.ToString());
                sw.Flush();
                sw.Close();
            }
            return View(prodlist);
        }
        #endregion

    }


}