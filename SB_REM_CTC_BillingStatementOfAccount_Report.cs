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
    
    public partial class SB_REM_CTC_BillingStatementOfAccount_Report
    {
        public int id { get; set; }
        public string transmittalbatch { get; set; }
        public Nullable<System.DateTime> billingdate { get; set; }
        public string BankName { get; set; }
        public string PresentAddress { get; set; }
        public string PreparedByName { get; set; }
        public string ApprovedByName { get; set; }
        public string CheckedByName { get; set; }
        public Nullable<int> NoOfAccounts { get; set; }
        public Nullable<decimal> ActualRDFee { get; set; }
    }
}
