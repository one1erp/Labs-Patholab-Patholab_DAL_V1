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
    
    public partial class HISTOLOGY_BLOCK_LIST
    {
        public long SDG_ID { get; set; }
        public long ALIQUOT_ID { get; set; }
        public string ALIQ_NAME { get; set; }
        public string U_BASKET { get; set; }
        public string PRIORITY { get; set; }
        public string ALIQUOT_STATION { get; set; }
        public Nullable<System.DateTime> MACRO_DATE { get; set; }
        public string LABWORKERHEBREW_NAME { get; set; }
        public Nullable<System.DateTime> RECEIVED_ON { get; set; }
        public string U_PATHOLAB_NUMBER { get; set; }
        public string HISTOKINT { get; set; }
        public string ORGAN { get; set; }
    }
}
