//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class TxnAppraisalPaymentDetail
    {
        public int TxnAppraisalId { get; set; }
        public Nullable<int> RowNo { get; set; }
        public string PaymentDetails { get; set; }
        public Nullable<decimal> Amount { get; set; }
    
        public virtual TxnAppraisal TxnAppraisal { get; set; }
    }
}
