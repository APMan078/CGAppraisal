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
    
    public partial class SB_LTO_MonthlyQuantityReport
    {
        public int id { get; set; }
        public string accountname { get; set; }
        public Nullable<int> bankid { get; set; }
        public string BankName { get; set; }
        public Nullable<int> ltoagencyid { get; set; }
        public string ltoagencyname { get; set; }
        public decimal servicefee { get; set; }
        public Nullable<System.DateTime> daterecieved { get; set; }
    }
}
