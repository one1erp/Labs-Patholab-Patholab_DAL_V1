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
    
    public partial class SDG_USER
    {
        public long SDG_ID { get; set; }
        public string U_CLINIC_CODE { get; set; }
        public string U_CONSULT { get; set; }
        public string U_ISQC { get; set; }
        public string U_ISCONSULT { get; set; }
        public string U_ISPOSITIVE { get; set; }
        public Nullable<System.DateTime> U_LAST_UPDATE { get; set; }
        public string U_MALIGNANT { get; set; }
        public Nullable<decimal> U_NBR_OF_SAMPLES { get; set; }
        public Nullable<long> U_PATHOLOG { get; set; }
        public Nullable<long> U_PATIENT { get; set; }
        public Nullable<decimal> U_PRIORITY { get; set; }
        public string U_PREGNANCY { get; set; }
        public Nullable<System.DateTime> U_PREGNANCY_DATE { get; set; }
        public Nullable<System.DateTime> U_REFERRAL_DATE { get; set; }
        public Nullable<long> U_REFERRING_PHYSICIAN { get; set; }
        public string U_REPORTED { get; set; }
        public Nullable<System.DateTime> U_REQUEST_DATE { get; set; }
        public string U_REVISION_CAUSE { get; set; }
        public Nullable<decimal> U_SLIDE_NBR { get; set; }
        public string U_SNOMED { get; set; }
        public string U_SNOMED_T { get; set; }
        public string U_STORED { get; set; }
        public string U_SUSPENSION_CAUSE { get; set; }
        public Nullable<decimal> U_WEEK_NBR { get; set; }
        public Nullable<long> U_IMPLEMENTING_PHYSICIAN { get; set; }
        public Nullable<long> U_IMPLEMENTING_CLINIC { get; set; }
        public Nullable<long> U_COLLECTION_STATION { get; set; }
        public string U_QC { get; set; }
        public string U_IS_QC { get; set; }
        public string U_ATFILENM { get; set; }
        public Nullable<decimal> U_MACASE { get; set; }
        public string U_PATHOLAB_NUMBER { get; set; }
        public Nullable<decimal> U_HOSPITAL_NUMBER { get; set; }
        public string U_NO_OBLIGATION { get; set; }
        public Nullable<long> U_CONTAINER_ID { get; set; }
        public Nullable<decimal> U_AGE_AT_ARRIVAL { get; set; }
        public string U_RECEIVE_QC { get; set; }
        public Nullable<long> U_REFERRAL_PHYSICIAN_CLINI { get; set; }
        public string U_PASSPORT { get; set; }
        public Nullable<long> U_ORDER_ID { get; set; }
        public string U_ACCORD_NUMBER { get; set; }
        public string U_PDF_PATH { get; set; }
        public Nullable<System.DateTime> U_FAX_EMAIL_SENT_ON { get; set; }
        public string U_IS_LAST_UPDATE { get; set; }
        public string U_IS_THINPREP { get; set; }
        public string U_CALCULATE_DEBIT { get; set; }
        public string U_TUMOR_SIZE { get; set; }
        public Nullable<System.DateTime> U_CANCELD_ON { get; set; }
        public Nullable<long> U_CANCELD_BY { get; set; }
        public string U_AUTHORIZE_STATUS { get; set; }
        public string U_CONSULT_DESC { get; set; }
        public Nullable<System.DateTime> U_BACK_FROM_PATHOLOG { get; set; }
    
        public virtual CLIENT CLIENT { get; set; }
        public virtual OPERATOR PATHOLOG { get; set; }
        public virtual SDG SDG { get; set; }
        public virtual U_CLINIC U_CLINIC { get; set; }
        public virtual U_CONTAINER U_CONTAINER { get; set; }
        public virtual U_CLINIC IMPLEMENTING_CLINIC { get; set; }
        public virtual SUPPLIER IMPLEMENTING_PHYSICIAN { get; set; }
        public virtual U_ORDER U_ORDER { get; set; }
        public virtual U_CLINIC REFERRAL_PHYSICIAN_CLINIC { get; set; }
        public virtual SUPPLIER REFERRING_PHYSIC { get; set; }
        public virtual OPERATOR OPERATOR { get; set; }
    }
}