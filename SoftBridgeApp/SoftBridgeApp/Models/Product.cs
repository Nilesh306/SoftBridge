using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoftBridgeApp.Models
{
    public class Product
    {

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        /*
        public decimal ProductID { get; set; }
      //  [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        

        */
    }
    
}