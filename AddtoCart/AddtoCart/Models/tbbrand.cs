//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AddtoCart.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbbrand
    {
        public tbbrand()
        {
            this.tbproducts = new HashSet<tbproduct>();
        }
    
        public int id { get; set; }
        public string b_name { get; set; }
    
        public virtual ICollection<tbproduct> tbproducts { get; set; }
    }
}
