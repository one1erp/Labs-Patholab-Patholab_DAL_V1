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
    
    public partial class U_ORDER
    {
        public U_ORDER()
        {
            this.SDG_USER = new HashSet<SDG_USER>();
            this.U_DEBIT_USER = new HashSet<U_DEBIT_USER>();
            this.U_ORDER1 = new HashSet<U_ORDER>();
            this.U_SAMPLE_MSG_USER = new HashSet<U_SAMPLE_MSG_USER>();
        }
    
        public long U_ORDER_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string VERSION { get; set; }
        public string VERSION_STATUS { get; set; }
        public Nullable<long> GROUP_ID { get; set; }
        public Nullable<long> PARENT_VERSION_ID { get; set; }
        public Nullable<long> TEMPLATE_ID { get; set; }
        public Nullable<long> WORKFLOW_NODE_ID { get; set; }
        public string EVENTS { get; set; }
    
        public virtual LIMS_GROUP LIMS_GROUP { get; set; }
        public virtual ICollection<SDG_USER> SDG_USER { get; set; }
        public virtual ICollection<U_DEBIT_USER> U_DEBIT_USER { get; set; }
        public virtual ICollection<U_ORDER> U_ORDER1 { get; set; }
        public virtual U_ORDER U_ORDER2 { get; set; }
        public virtual WORKFLOW_NODE WORKFLOW_NODE { get; set; }
        public virtual U_ORDER_USER U_ORDER_USER { get; set; }
        public virtual ICollection<U_SAMPLE_MSG_USER> U_SAMPLE_MSG_USER { get; set; }
    }
}
