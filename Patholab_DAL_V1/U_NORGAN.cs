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
    
    public partial class U_NORGAN
    {
        public U_NORGAN()
        {
            this.U_NORGAN1 = new HashSet<U_NORGAN>();
        }
    
        public long U_NORGAN_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string VERSION { get; set; }
        public Nullable<long> GROUP_ID { get; set; }
        public Nullable<long> PARENT_VERSION_ID { get; set; }
    
        public virtual LIMS_GROUP LIMS_GROUP { get; set; }
        public virtual ICollection<U_NORGAN> U_NORGAN1 { get; set; }
        public virtual U_NORGAN U_NORGAN2 { get; set; }
        public virtual U_NORGAN_USER U_NORGAN_USER { get; set; }
    }
}
