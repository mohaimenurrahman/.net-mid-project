//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace midproject.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class currentBill
    {
        public string buildingCode { get; set; }
        public string flatNumber { get; set; }
        public string unit { get; set; }
        public string dstart { get; set; }
        public string dend { get; set; }
        public string unitAmount { get; set; }
        public string totalAmount { get; set; }
    
        public virtual buildingDetail buildingDetail { get; set; }
    }
}
