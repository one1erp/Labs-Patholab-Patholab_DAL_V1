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
    
    public partial class PHRASE_HEADER
    {
        public PHRASE_HEADER()
        {
            this.PHRASE_ENTRY = new HashSet<PHRASE_ENTRY>();
            this.PHRASE_HEADER1 = new HashSet<PHRASE_HEADER>();
            this.U_REPORT_PARAMS_USER = new HashSet<U_REPORT_PARAMS_USER>();
            this.RESULT_TEMPLATE = new HashSet<RESULT_TEMPLATE>();
        }
    
        public long PHRASE_ID { get; set; }
        public Nullable<long> GROUP_ID { get; set; }
        public string NAME { get; set; }
        public string VERSION { get; set; }
        public string DESCRIPTION { get; set; }
        public string VERSION_STATUS { get; set; }
        public Nullable<long> PARENT_VERSION_ID { get; set; }
    
        public virtual LIMS_GROUP LIMS_GROUP { get; set; }
        public virtual ICollection<PHRASE_ENTRY> PHRASE_ENTRY { get; set; }
        public virtual ICollection<PHRASE_HEADER> PHRASE_HEADER1 { get; set; }
        public virtual PHRASE_HEADER PHRASE_HEADER2 { get; set; }
        public virtual ICollection<U_REPORT_PARAMS_USER> U_REPORT_PARAMS_USER { get; set; }
        public virtual ICollection<RESULT_TEMPLATE> RESULT_TEMPLATE { get; set; }
    }
}
