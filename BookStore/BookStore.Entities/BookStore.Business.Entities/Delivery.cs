//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStore.Business.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Delivery
    {
        public Delivery()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public string Warehouse { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
