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
    
    public partial class U_CONTAINER_MSG_USER
    {
        public long U_CONTAINER_MSG_ID { get; set; }
        public Nullable<decimal> U_CONTAINER_NBR { get; set; }
        public string U_STATUS { get; set; }
        public string U_SENDER { get; set; }
        public string U_MSG_NAME { get; set; }
        public string U_PATH { get; set; }
        public Nullable<long> U_CLINIC_ID { get; set; }
        public string U_ERRORS { get; set; }
        public Nullable<System.DateTime> U_CREATED_ON { get; set; }
        public Nullable<System.DateTime> U_PACKED_ON { get; set; }
        public string U_RECEIVING_STATUS { get; set; }
        public string U_DRIVER_NAME { get; set; }
        public Nullable<System.DateTime> U_MSG_DATE { get; set; }
    
        public virtual U_CLINIC U_CLINIC { get; set; }
        public virtual U_CONTAINER_MSG U_CONTAINER_MSG { get; set; }
    }
}
