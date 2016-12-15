using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloWorld.Models
{
    public class Webpage
    {
        public int WebPageID { get; set; }

        public string URLAddress { get; set; }

        public string Comment { get; set; }
    }
}