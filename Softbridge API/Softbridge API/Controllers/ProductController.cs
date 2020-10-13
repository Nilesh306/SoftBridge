using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Softbridge_API.Models;
using System.IO;
using System.Configuration;

namespace Softbridge_API.Controllers
{
    public class ProductController : ApiController
    {
        private SnowBridgeDatabaseEntities db = new SnowBridgeDatabaseEntities();
        private string Errorlog = @"D:\Nilesh\APISoftbridge\Error\ErrorLogText.txt";
        // GET: api/Product
        #region GetProducts
        public IQueryable<SoftBridgeProduct> GetProducts()
        {
            IQueryable<SoftBridgeProduct> result=null;

            try {

                result = db.SoftBridgeProducts;
                }
            catch (Exception ex)
                {
                StreamWriter sw = new StreamWriter(Errorlog, true);
                sw.WriteLine(System.DateTime.Now.ToString() + " Softbridge_API.Controllers - " + ex.ToString());
                sw.Flush();
                sw.Close();
                 }
            return result ;
        }
        #endregion

        #region GetProduct
        // GET: api/Product/5
        [ResponseType(typeof(SoftBridgeProduct))]
        public IHttpActionResult GetProduct(int id)
        {
            SoftBridgeProduct product = null;
            try
            {
                product = db.SoftBridgeProducts.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Errorlog, true);
                sw.WriteLine(System.DateTime.Now.ToString() + " Softbridge_API.Controllers - " + ex.ToString());
                sw.Flush();
                sw.Close();
            }

            return Ok(product);
        }

        #endregion

        #region commented
        /*
                // PUT: api/Product/5
                [ResponseType(typeof(void))]
                public IHttpActionResult PutProduct(decimal id, SoftBridgeProducts product)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    if (id != product.ProductID)
                    {
                        return BadRequest();
                    }

                    db.Entry(product).State = EntityState.Modified;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductExists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return StatusCode(HttpStatusCode.NoContent);
                }
        */
        #endregion

        #region Post Product
        // POST: api/Product
        [ResponseType(typeof(SoftBridgeProduct))]
        public IHttpActionResult PostProduct(SoftBridgeProduct product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.SoftBridgeProducts.Add(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Errorlog, true);
                sw.WriteLine(System.DateTime.Now.ToString() + " Softbridge_API.Controllers - " + ex.ToString());
                sw.Flush();
                sw.Close();
            }
            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }
        #endregion

        #region Delete Product
        // DELETE: api/Product/5
        [ResponseType(typeof(SoftBridgeProduct))]
        public IHttpActionResult DeleteProduct(int id)
        {
            SoftBridgeProduct product = null;
            try
            {
                product = db.SoftBridgeProducts.Find(id);
                if (product == null)
                {
                    return NotFound();
                }

                db.SoftBridgeProducts.Remove(product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter(Errorlog, true);
                sw.WriteLine(System.DateTime.Now.ToString() + " Softbridge_API.Controllers - " + ex.ToString());
                sw.Flush();
                sw.Close();
            }
            return Ok(product);
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
        #region Productexists
        private bool ProductExists(int id)
        {
            return db.SoftBridgeProducts.Count(e => e.ProductID == id) > 0;
        }
        #endregion
    }
}