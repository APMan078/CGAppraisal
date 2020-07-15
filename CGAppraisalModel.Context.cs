﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CG_AppraisalEntities : DbContext
    {
        public CG_AppraisalEntities()
            : base("name=CG_AppraisalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SetAccess> SetAccesses { get; set; }
        public virtual DbSet<SetBank> SetBanks { get; set; }
        public virtual DbSet<SetBankBranch> SetBankBranches { get; set; }
        public virtual DbSet<SetPaymentDetail> SetPaymentDetails { get; set; }
        public virtual DbSet<SetUser> SetUsers { get; set; }
        public virtual DbSet<TxnAppraisal> TxnAppraisals { get; set; }
    
        public virtual ObjectResult<BankBranchLoad_Result> BankBranchLoad(Nullable<int> id, string keyword, Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateto)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var keywordParameter = keyword != null ?
                new ObjectParameter("keyword", keyword) :
                new ObjectParameter("keyword", typeof(string));
    
            var dateFromParameter = dateFrom.HasValue ?
                new ObjectParameter("dateFrom", dateFrom) :
                new ObjectParameter("dateFrom", typeof(System.DateTime));
    
            var datetoParameter = dateto.HasValue ?
                new ObjectParameter("dateto", dateto) :
                new ObjectParameter("dateto", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BankBranchLoad_Result>("BankBranchLoad", idParameter, keywordParameter, dateFromParameter, datetoParameter);
        }
    
        public virtual int BankBranchSaveUpdate(Nullable<bool> isEdit, Nullable<int> id, Nullable<int> bankId, string name, string accountNo, Nullable<bool> isActive)
        {
            var isEditParameter = isEdit.HasValue ?
                new ObjectParameter("isEdit", isEdit) :
                new ObjectParameter("isEdit", typeof(bool));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var bankIdParameter = bankId.HasValue ?
                new ObjectParameter("bankId", bankId) :
                new ObjectParameter("bankId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var accountNoParameter = accountNo != null ?
                new ObjectParameter("accountNo", accountNo) :
                new ObjectParameter("accountNo", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("isActive", isActive) :
                new ObjectParameter("isActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BankBranchSaveUpdate", isEditParameter, idParameter, bankIdParameter, nameParameter, accountNoParameter, isActiveParameter);
        }
    
        public virtual ObjectResult<BankLoad_Result> BankLoad(Nullable<int> id, string keyword, Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateto)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var keywordParameter = keyword != null ?
                new ObjectParameter("keyword", keyword) :
                new ObjectParameter("keyword", typeof(string));
    
            var dateFromParameter = dateFrom.HasValue ?
                new ObjectParameter("dateFrom", dateFrom) :
                new ObjectParameter("dateFrom", typeof(System.DateTime));
    
            var datetoParameter = dateto.HasValue ?
                new ObjectParameter("dateto", dateto) :
                new ObjectParameter("dateto", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BankLoad_Result>("BankLoad", idParameter, keywordParameter, dateFromParameter, datetoParameter);
        }
    
        public virtual int BankSaveUpdate(Nullable<bool> isEdit, Nullable<int> id, string name, Nullable<bool> isActive)
        {
            var isEditParameter = isEdit.HasValue ?
                new ObjectParameter("isEdit", isEdit) :
                new ObjectParameter("isEdit", typeof(bool));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("isActive", isActive) :
                new ObjectParameter("isActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BankSaveUpdate", isEditParameter, idParameter, nameParameter, isActiveParameter);
        }
    
        public virtual ObjectResult<PaymentDetailsLoad_Result> PaymentDetailsLoad(Nullable<int> id, string keyword, Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateto)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var keywordParameter = keyword != null ?
                new ObjectParameter("keyword", keyword) :
                new ObjectParameter("keyword", typeof(string));
    
            var dateFromParameter = dateFrom.HasValue ?
                new ObjectParameter("dateFrom", dateFrom) :
                new ObjectParameter("dateFrom", typeof(System.DateTime));
    
            var datetoParameter = dateto.HasValue ?
                new ObjectParameter("dateto", dateto) :
                new ObjectParameter("dateto", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PaymentDetailsLoad_Result>("PaymentDetailsLoad", idParameter, keywordParameter, dateFromParameter, datetoParameter);
        }
    
        public virtual int PaymentDetailsSaveUpdate(Nullable<bool> isEdit, Nullable<int> id, string name, Nullable<decimal> defaultPayment, Nullable<bool> isActive)
        {
            var isEditParameter = isEdit.HasValue ?
                new ObjectParameter("isEdit", isEdit) :
                new ObjectParameter("isEdit", typeof(bool));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var defaultPaymentParameter = defaultPayment.HasValue ?
                new ObjectParameter("defaultPayment", defaultPayment) :
                new ObjectParameter("defaultPayment", typeof(decimal));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("isActive", isActive) :
                new ObjectParameter("isActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PaymentDetailsSaveUpdate", isEditParameter, idParameter, nameParameter, defaultPaymentParameter, isActiveParameter);
        }
    
        public virtual int SaveUpdateUser(Nullable<bool> isEdit, Nullable<int> id, string firstName, string lastName, string middleName, Nullable<int> accessId, string username, string password, Nullable<bool> isActive)
        {
            var isEditParameter = isEdit.HasValue ?
                new ObjectParameter("IsEdit", isEdit) :
                new ObjectParameter("IsEdit", typeof(bool));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var middleNameParameter = middleName != null ?
                new ObjectParameter("MiddleName", middleName) :
                new ObjectParameter("MiddleName", typeof(string));
    
            var accessIdParameter = accessId.HasValue ?
                new ObjectParameter("AccessId", accessId) :
                new ObjectParameter("AccessId", typeof(int));
    
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveUpdateUser", isEditParameter, idParameter, firstNameParameter, lastNameParameter, middleNameParameter, accessIdParameter, usernameParameter, passwordParameter, isActiveParameter);
        }
    
        public virtual ObjectResult<UserLogin_Result> UserLogin(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserLogin_Result>("UserLogin", userNameParameter, passwordParameter);
        }
    }
}
