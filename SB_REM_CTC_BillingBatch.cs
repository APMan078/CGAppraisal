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
    
    public partial class SB_REM_CTC_BillingBatch
    {
        public int id { get; set; }
        public string billingid { get; set; }
        public Nullable<int> bankid { get; set; }
        public Nullable<System.DateTime> billingdate { get; set; }
        public string contactpersonid { get; set; }
        public Nullable<int> preparedbyid { get; set; }
        public Nullable<int> checkedbyid { get; set; }
        public Nullable<int> approvedbyid { get; set; }
        public Nullable<int> approvalstatusid { get; set; }
        public Nullable<System.DateTime> dateencoded { get; set; }
        public Nullable<int> encodedbyid { get; set; }
        public Nullable<int> billingnumber { get; set; }
    }
}