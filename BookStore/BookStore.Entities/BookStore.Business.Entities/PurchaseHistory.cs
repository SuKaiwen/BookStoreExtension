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
    
    public partial class PurchaseHistory
    {
        public int Id { get; set; }
        public Nullable<bool> Rating { get; set; }
        public System.DateTime RatingDate { get; set; }
    
        public virtual Media Media { get; set; }
        public virtual User Users { get; set; }
    }
}