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
    
    public partial class INSPECTION_PLAN
    {
        public INSPECTION_PLAN()
        {
            this.ALIQUOTs = new HashSet<ALIQUOT>();
            this.INSPECTION_ENTRY = new HashSet<INSPECTION_ENTRY>();
            this.INSPECTION_PLAN1 = new HashSet<INSPECTION_PLAN>();
            this.RESULTs = new HashSet<RESULT>();
            this.SAMPLEs = new HashSet<SAMPLE>();
            this.SDGs = new HashSet<SDG>();
            this.TESTs = new HashSet<TEST>();
            this.RESULT_TEMPLATE = new HashSet<RESULT_TEMPLATE>();
        }
    
        public long INSPECTION_PLAN_ID { get; set; }
        public Nullable<long> GROUP_ID { get; set; }
        public string NAME { get; set; }
        public string VERSION { get; set; }
        public string DESCRIPTION { get; set; }
        public string VERSION_STATUS { get; set; }
        public Nullable<long> PARENT_VERSION_ID { get; set; }
    
        public virtual ICollection<ALIQUOT> ALIQUOTs { get; set; }
        public virtual ICollection<INSPECTION_ENTRY> INSPECTION_ENTRY { get; set; }
        public virtual LIMS_GROUP LIMS_GROUP { get; set; }
        public virtual ICollection<INSPECTION_PLAN> INSPECTION_PLAN1 { get; set; }
        public virtual INSPECTION_PLAN INSPECTION_PLAN2 { get; set; }
        public virtual ICollection<RESULT> RESULTs { get; set; }
        public virtual ICollection<SAMPLE> SAMPLEs { get; set; }
        public virtual ICollection<SDG> SDGs { get; set; }
        public virtual ICollection<TEST> TESTs { get; set; }
        public virtual ICollection<RESULT_TEMPLATE> RESULT_TEMPLATE { get; set; }
    }
}