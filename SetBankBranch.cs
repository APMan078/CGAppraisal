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
    
    public partial class SetBankBranch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SetBankBranch()
        {
            this.TxnAppraisals = new HashSet<TxnAppraisal>();
        }
    
        public int Id { get; set; }
        public Nullable<int> BankId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> DateEncoded { get; set; }
    
        public virtual SetBank SetBank { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TxnAppraisal> TxnAppraisals { get; set; }
    }
}