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
    
    public partial class U_PRICE_LIST
    {
        public U_PRICE_LIST()
        {
            this.U_CUSTOMER_USER = new HashSet<U_CUSTOMER_USER>();
            this.U_PRICE_LIST1 = new HashSet<U_PRICE_LIST>();
        }
    
        public long U_PRICE_LIST_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string VERSION { get; set; }
        public string VERSION_STATUS { get; set; }
        public Nullable<long> GROUP_ID { get; set; }
        public Nullable<long> PARENT_VERSION_ID { get; set; }
    
        public virtual LIMS_GROUP LIMS_GROUP { get; set; }
        public virtual ICollection<U_CUSTOMER_USER> U_CUSTOMER_USER { get; set; }
        public virtual ICollection<U_PRICE_LIST> U_PRICE_LIST1 { get; set; }
        public virtual U_PRICE_LIST U_PRICE_LIST2 { get; set; }
        public virtual U_PRICE_LIST_USER U_PRICE_LIST_USER { get; set; }
    }
}
