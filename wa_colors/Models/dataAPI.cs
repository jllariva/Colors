using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Xml;
using System.Xml.Serialization;

namespace wa_colors.Models
{
    public class API
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<data> data { get; set; }
        public Support support { get; set; }
    }

    public class data
    {
        public string id { get; set; }
        public string name { get; set; }
        public string year { get; set; }
        public string color { get; set; }
        public string pantone_value { get; set; }
        public string nombre { get; set; }
        public string año { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class viewData
    {
        public string year { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string pantone { get; set; }
    }
}