//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZaghiniAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class posts
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string image { get; set; }
        public System.DateTime postdate { get; set; }
        public bool active { get; set; }
        public bool onlyregistercanread { get; set; }
        public int iduser { get; set; }
        public int idtag { get; set; }
    
        public virtual tags tags { get; set; }
        public virtual users users { get; set; }
    }
}