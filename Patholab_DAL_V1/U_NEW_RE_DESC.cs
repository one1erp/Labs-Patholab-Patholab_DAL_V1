//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Patholab_DAL_V1
{
    using System;
    using System.Collections.Generic;
    
    public partial class U_NEW_RE_DESC
    {
        public U_NEW_RE_DESC()
        {
            this.U_NEW_RE_DESC1 = new HashSet<U_NEW_RE_DESC>();
        }
    
        public long U_NEW_RE_DESC_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string VERSION { get; set; }
        public string VERSION_STATUS { get; set; }
        public Nullable<long> GROUP_ID { get; set; }
        public Nullable<long> PARENT_VERSION_ID { get; set; }
    
        public virtual LIMS_GROUP LIMS_GROUP { get; set; }
        public virtual ICollection<U_NEW_RE_DESC> U_NEW_RE_DESC1 { get; set; }
        public virtual U_NEW_RE_DESC U_NEW_RE_DESC2 { get; set; }
        public virtual U_NEW_RE_DESC_USER U_NEW_RE_DESC_USER { get; set; }
    }
}