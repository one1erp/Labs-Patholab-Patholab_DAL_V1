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
    
    public partial class U_CONTAINER_USER
    {
        public long U_CONTAINER_ID { get; set; }
        public string U_RECEIVE_NUMBER { get; set; }
        public Nullable<System.DateTime> U_RECEIVED_ON { get; set; }
        public Nullable<System.DateTime> U_SEND_ON { get; set; }
        public Nullable<long> U_CLINIC { get; set; }
        public Nullable<decimal> U_NUMBER_OF_ORDERS { get; set; }
        public Nullable<decimal> U_NUMBER_OF_SAMPLES { get; set; }
        public Nullable<long> U_CREATE_BY { get; set; }
        public string U_STATUS { get; set; }
        public Nullable<System.DateTime> U_FAX_SEND_ON { get; set; }
        public Nullable<decimal> U_CONTEINER_ID { get; set; }
        public Nullable<decimal> U_BIG_QNT { get; set; }
        public Nullable<decimal> U_URGENT_QNT { get; set; }
        public string U_REQUESTS { get; set; }
        public string U_DRIVER_NAME { get; set; }
        public string U_DRIVER_ID { get; set; }
        public string U_SAMPLE_TYPE { get; set; }
    
        public virtual OPERATOR OPERATOR { get; set; }
        public virtual U_CLINIC U_CLINIC1 { get; set; }
        public virtual U_CONTAINER U_CONTAINER { get; set; }
    }
}