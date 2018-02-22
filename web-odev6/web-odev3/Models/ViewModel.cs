using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_odev3.Models;
using System.Data;
using System.Data.Entity;
using System.Net;

namespace web_odev3.Models
{
    public class ViewModel
    {
        public List<Yorum1> ListY { get; set; }
        public List<Haber> ListH { get; set; }
        public List<Users1> ListU { get; set; }
        public Haber TargetId { get; set; } 
        public Yorum1 yorum1 { get; set; }
        public Users1 user1 { get; set; }
        public Haber haber { get; set; }

        public ViewModel()
        {
            this.ListY = new List<Yorum1>();
        }
    }
}