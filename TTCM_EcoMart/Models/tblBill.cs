//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TTCM_EcoMart.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblBill()
        {
            this.tblBill_details = new HashSet<tblBill_details>();
        }
    
        public string Bill_ID { get; set; }
        public string Account_ID { get; set; }
        public string Payment_ID { get; set; }
        public System.DateTime PurchasedDate { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<byte> Bill_status { get; set; }
    
        public virtual tblAccount tblAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBill_details> tblBill_details { get; set; }
        public virtual tblPayment tblPayment { get; set; }
    }
}