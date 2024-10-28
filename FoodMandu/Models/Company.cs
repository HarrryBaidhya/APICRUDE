using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodMandu.Models
{
    public class Company : CommonResponse
    {
        public int LayoutId { get; set; }
        public string Banner { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Layout { get; set; }
        public object Item { get; set; }
    }





}