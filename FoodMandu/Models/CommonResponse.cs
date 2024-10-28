using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodMandu.Models
{
    public class CommonResponse
    {
        private string _Message = string.Empty;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

      
        private int _ReponseCode = 0;
        public int ReponseCode
        {
            get { return _ReponseCode; }
            set { _ReponseCode = value; }
        }


        //status
        private bool _status = false;
        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }


        public object Item { get; set; }
    }
}