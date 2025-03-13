﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobPortal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JobPortalDBEntities : DbContext
    {
        public JobPortalDBEntities()
            : base("name=JobPortalDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company_Table> Company_Table { get; set; }
        public virtual DbSet<Job_Table> Job_Table { get; set; }
        public virtual DbSet<Login_Table> Login_Table { get; set; }
        public virtual DbSet<User_Table> User_Table { get; set; }
        public virtual DbSet<JobApply_Table> JobApply_Table { get; set; }
    
        public virtual ObjectResult<Nullable<int>> sp_CountLogId(string una, string pwd)
        {
            var unaParameter = una != null ?
                new ObjectParameter("una", una) :
                new ObjectParameter("una", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_CountLogId", unaParameter, pwdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_GetRegId(string una, string pwd)
        {
            var unaParameter = una != null ?
                new ObjectParameter("una", una) :
                new ObjectParameter("una", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_GetRegId", unaParameter, pwdParameter);
        }
    
        public virtual ObjectResult<string> sp_GetType(string una, string pwd)
        {
            var unaParameter = una != null ?
                new ObjectParameter("una", una) :
                new ObjectParameter("una", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("sp_GetType", unaParameter, pwdParameter);
        }
    
        public virtual int sp_InsertCompany(Nullable<int> cid, string name, string addr, string phn, string em, string web, string img)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var addrParameter = addr != null ?
                new ObjectParameter("addr", addr) :
                new ObjectParameter("addr", typeof(string));
    
            var phnParameter = phn != null ?
                new ObjectParameter("phn", phn) :
                new ObjectParameter("phn", typeof(string));
    
            var emParameter = em != null ?
                new ObjectParameter("em", em) :
                new ObjectParameter("em", typeof(string));
    
            var webParameter = web != null ?
                new ObjectParameter("web", web) :
                new ObjectParameter("web", typeof(string));
    
            var imgParameter = img != null ?
                new ObjectParameter("img", img) :
                new ObjectParameter("img", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertCompany", cidParameter, nameParameter, addrParameter, phnParameter, emParameter, webParameter, imgParameter);
        }
    
        public virtual int sp_InsertLogin(Nullable<int> regId, string uname, string pwd, string type)
        {
            var regIdParameter = regId.HasValue ?
                new ObjectParameter("regId", regId) :
                new ObjectParameter("regId", typeof(int));
    
            var unameParameter = uname != null ?
                new ObjectParameter("uname", uname) :
                new ObjectParameter("uname", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertLogin", regIdParameter, unameParameter, pwdParameter, typeParameter);
        }
    
        public virtual int sp_InsertUser(Nullable<int> uid, string name, Nullable<int> age, string addr, string phn, string em, string gen, string qual, Nullable<int> exp, string sk, string loc, string img)
        {
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("age", age) :
                new ObjectParameter("age", typeof(int));
    
            var addrParameter = addr != null ?
                new ObjectParameter("addr", addr) :
                new ObjectParameter("addr", typeof(string));
    
            var phnParameter = phn != null ?
                new ObjectParameter("phn", phn) :
                new ObjectParameter("phn", typeof(string));
    
            var emParameter = em != null ?
                new ObjectParameter("em", em) :
                new ObjectParameter("em", typeof(string));
    
            var genParameter = gen != null ?
                new ObjectParameter("gen", gen) :
                new ObjectParameter("gen", typeof(string));
    
            var qualParameter = qual != null ?
                new ObjectParameter("qual", qual) :
                new ObjectParameter("qual", typeof(string));
    
            var expParameter = exp.HasValue ?
                new ObjectParameter("exp", exp) :
                new ObjectParameter("exp", typeof(int));
    
            var skParameter = sk != null ?
                new ObjectParameter("sk", sk) :
                new ObjectParameter("sk", typeof(string));
    
            var locParameter = loc != null ?
                new ObjectParameter("loc", loc) :
                new ObjectParameter("loc", typeof(string));
    
            var imgParameter = img != null ?
                new ObjectParameter("img", img) :
                new ObjectParameter("img", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertUser", uidParameter, nameParameter, ageParameter, addrParameter, phnParameter, emParameter, genParameter, qualParameter, expParameter, skParameter, locParameter, imgParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_MaxRegId()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_MaxRegId");
        }
    
        public virtual ObjectResult<sp_selectJobs_Result> sp_selectJobs(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_selectJobs_Result>("sp_selectJobs", cidParameter);
        }
    
        public virtual int sp_createJob(Nullable<int> cid, string title, string desc, Nullable<int> sal, string loc, Nullable<int> exp, string sk, string type, Nullable<int> vac, string status, Nullable<System.DateTime> std, Nullable<System.DateTime> end)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var descParameter = desc != null ?
                new ObjectParameter("desc", desc) :
                new ObjectParameter("desc", typeof(string));
    
            var salParameter = sal.HasValue ?
                new ObjectParameter("sal", sal) :
                new ObjectParameter("sal", typeof(int));
    
            var locParameter = loc != null ?
                new ObjectParameter("loc", loc) :
                new ObjectParameter("loc", typeof(string));
    
            var expParameter = exp.HasValue ?
                new ObjectParameter("exp", exp) :
                new ObjectParameter("exp", typeof(int));
    
            var skParameter = sk != null ?
                new ObjectParameter("sk", sk) :
                new ObjectParameter("sk", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var vacParameter = vac.HasValue ?
                new ObjectParameter("vac", vac) :
                new ObjectParameter("vac", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(string));
    
            var stdParameter = std.HasValue ?
                new ObjectParameter("std", std) :
                new ObjectParameter("std", typeof(System.DateTime));
    
            var endParameter = end.HasValue ?
                new ObjectParameter("end", end) :
                new ObjectParameter("end", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_createJob", cidParameter, titleParameter, descParameter, salParameter, locParameter, expParameter, skParameter, typeParameter, vacParameter, statusParameter, stdParameter, endParameter);
        }
    
        public virtual int sp_updateJob(Nullable<int> id, Nullable<int> cid, Nullable<int> vac, string status)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            var vacParameter = vac.HasValue ?
                new ObjectParameter("vac", vac) :
                new ObjectParameter("vac", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_updateJob", idParameter, cidParameter, vacParameter, statusParameter);
        }
    
        public virtual ObjectResult<sp_getJob_Result> sp_getJob(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getJob_Result>("sp_getJob", idParameter);
        }
    
        public virtual ObjectResult<sp_getJobDetails_Result> sp_getJobDetails(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_getJobDetails_Result>("sp_getJobDetails", idParameter);
        }
    
        public virtual int sp_JobSearch(string query)
        {
            var queryParameter = query != null ?
                new ObjectParameter("query", query) :
                new ObjectParameter("query", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_JobSearch", queryParameter);
        }
    
        public virtual int sp_archiveJob(Nullable<int> id, Nullable<int> uid, string status)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var statusParameter = status != null ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_archiveJob", idParameter, uidParameter, statusParameter);
        }
    
        public virtual int sp_applycv(Nullable<int> uid, Nullable<int> cid, Nullable<int> jid, string res, string datenow, string status)
        {
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            var jidParameter = jid.HasValue ?
                new ObjectParameter("jid", jid) :
                new ObjectParameter("jid", typeof(int));
    
            var resParameter = res != null ?
                new ObjectParameter("res", res) :
                new ObjectParameter("res", typeof(string));
    
            var datenowParameter = datenow != null ?
                new ObjectParameter("datenow", datenow) :
                new ObjectParameter("datenow", typeof(string));
    
            var statusParameter = status != null ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_applycv", uidParameter, cidParameter, jidParameter, resParameter, datenowParameter, statusParameter);
        }
    
        public virtual ObjectResult<sp_selectArchivedJobs_Result> sp_selectArchivedJobs(Nullable<int> cid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_selectArchivedJobs_Result>("sp_selectArchivedJobs", cidParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_alreadyApplied(Nullable<int> cid, Nullable<int> jid, Nullable<int> uid)
        {
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            var jidParameter = jid.HasValue ?
                new ObjectParameter("jid", jid) :
                new ObjectParameter("jid", typeof(int));
    
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_alreadyApplied", cidParameter, jidParameter, uidParameter);
        }
    
        public virtual int sp_updateCv(Nullable<int> uid, Nullable<int> cid, Nullable<int> jid, string res, string datenow)
        {
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var cidParameter = cid.HasValue ?
                new ObjectParameter("cid", cid) :
                new ObjectParameter("cid", typeof(int));
    
            var jidParameter = jid.HasValue ?
                new ObjectParameter("jid", jid) :
                new ObjectParameter("jid", typeof(int));
    
            var resParameter = res != null ?
                new ObjectParameter("res", res) :
                new ObjectParameter("res", typeof(string));
    
            var datenowParameter = datenow != null ?
                new ObjectParameter("datenow", datenow) :
                new ObjectParameter("datenow", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_updateCv", uidParameter, cidParameter, jidParameter, resParameter, datenowParameter);
        }
    }
}
