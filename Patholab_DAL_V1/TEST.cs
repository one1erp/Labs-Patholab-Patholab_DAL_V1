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
    
    public partial class TEST
    {
        public TEST()
        {
            this.RESULTs = new HashSet<RESULT>();
        }
    
        public long TEST_ID { get; set; }
        public Nullable<long> ALIQUOT_ID { get; set; }
        public Nullable<decimal> REPLICATE_NUMBER { get; set; }
        public Nullable<long> GROUP_ID { get; set; }
        public Nullable<long> OPERATOR_ID { get; set; }
        public Nullable<long> LOCATION_ID { get; set; }
        public Nullable<long> INSTRUMENT_ID { get; set; }
        public Nullable<decimal> PRIORITY { get; set; }
        public Nullable<System.DateTime> DATE_RESULTS_REQUIRED { get; set; }
        public Nullable<System.DateTime> EXPECTED_ON { get; set; }
        public string CONCLUSION { get; set; }
        public Nullable<long> WORKFLOW_NODE_ID { get; set; }
        public Nullable<long> TEST_TEMPLATE_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string STATUS { get; set; }
        public string OLD_STATUS { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<System.DateTime> COMPLETED_ON { get; set; }
        public Nullable<System.DateTime> AUTHORISED_ON { get; set; }
        public string EVENTS { get; set; }
        public string NEEDS_REVIEW { get; set; }
        public Nullable<long> INSPECTION_PLAN_ID { get; set; }
        public string HAS_NOTES { get; set; }
        public string HAS_AUDITS { get; set; }
        public Nullable<System.DateTime> STARTED_ON { get; set; }
        public Nullable<long> CREATED_BY { get; set; }
        public Nullable<long> COMPLETED_BY { get; set; }
        public Nullable<long> AUTHORISED_BY { get; set; }
        public Nullable<long> PLATE_ID { get; set; }
    
        public virtual ALIQUOT ALIQUOT { get; set; }
        public virtual INSPECTION_PLAN INSPECTION_PLAN { get; set; }
        public virtual LIMS_GROUP LIMS_GROUP { get; set; }
        public virtual LOCATION LOCATION { get; set; }
        public virtual OPERATOR OPERATOR { get; set; }
        public virtual OPERATOR OPERATOR1 { get; set; }
        public virtual OPERATOR OPERATOR2 { get; set; }
        public virtual OPERATOR OPERATOR3 { get; set; }
        public virtual ICollection<RESULT> RESULTs { get; set; }
        public virtual TEST_USER TEST_USER { get; set; }
        public virtual WORKFLOW_NODE WORKFLOW_NODE { get; set; }
    }
}