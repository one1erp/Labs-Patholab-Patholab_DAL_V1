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
    
    public partial class U_SPECIAL_INSPECTION
    {
        public U_SPECIAL_INSPECTION()
        {
            this.U_SPECIAL_INSPECTION1 = new HashSet<U_SPECIAL_INSPECTION>();
        }
    
        public long U_SPECIAL_INSPECTION_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string VERSION { get; set; }
        public string VERSION_STATUS { get; set; }
        public Nullable<long> GROUP_ID { get; set; }
        public Nullable<long> PARENT_VERSION_ID { get; set; }
    
        public virtual LIMS_GROUP LIMS_GROUP { get; set; }
        public virtual ICollection<U_SPECIAL_INSPECTION> U_SPECIAL_INSPECTION1 { get; set; }
        public virtual U_SPECIAL_INSPECTION U_SPECIAL_INSPECTION2 { get; set; }
        public virtual U_SPECIAL_INSPECTION_USER U_SPECIAL_INSPECTION_USER { get; set; }
    }
}