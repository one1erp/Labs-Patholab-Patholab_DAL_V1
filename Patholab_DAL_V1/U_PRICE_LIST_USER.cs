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
    
    public partial class U_PRICE_LIST_USER
    {
        public long U_PRICE_LIST_ID { get; set; }
        public Nullable<long> U_PART_ID { get; set; }
        public Nullable<decimal> U_PART_PRICE { get; set; }
        public Nullable<System.DateTime> U_EFCT_FROM_DATE { get; set; }
        public Nullable<System.DateTime> U_UPDATE_ON { get; set; }
        public Nullable<long> U_UPDATE_BY { get; set; }
        public string U_PRICE_LIST_NAME { get; set; }
        public Nullable<decimal> U_PART_PRICE_URGENT { get; set; }
    
        public virtual OPERATOR OPERATOR { get; set; }
        public virtual U_PARTS U_PARTS { get; set; }
        public virtual U_PRICE_LIST U_PRICE_LIST { get; set; }
    }
}
