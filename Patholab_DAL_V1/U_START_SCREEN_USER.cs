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
    
    public partial class U_START_SCREEN_USER
    {
        public long U_START_SCREEN_ID { get; set; }
        public string U_CUSTUMER_NAME { get; set; }
        public Nullable<long> U_CUSTOMER_CODE { get; set; }
        public string U_RECEIVE_QC { get; set; }
        public string U_PART_TYPE { get; set; }
        public string U_PART_CODE { get; set; }
        public string U_RECEIVE_NUMBER { get; set; }
        public string U_CUSTOMER { get; set; }
        public string U_CLINIC { get; set; }
        public string U_SECOND_CUSTOMER { get; set; }
        public string U_EXTERNAL_REFERENCE { get; set; }
        public string U_HOSPITAL_NUMBER { get; set; }
        public string U_NO_OBLIGATION { get; set; }
        public string U_IN_ADVANCE { get; set; }
        public string U_URGENT { get; set; }
        public string U_DATE_ARRIVAL { get; set; }
        public string U_IMPLEMENTING_PHYSICIAN { get; set; }
        public string U_REFERRAL_PHYSICIAN { get; set; }
        public string U_REFERRAL_CLINIC { get; set; }
        public string U_PASSPORT_Y_N { get; set; }
        public string U_C_NAME { get; set; }
        public string U_LAST_NAME { get; set; }
        public string U_FIRST_NAME { get; set; }
        public string U_DATE_OF_BIRTH { get; set; }
        public string U_AGE_AT_ARRIVAL { get; set; }
        public string U_SEX { get; set; }
        public string U_PHONE { get; set; }
        public string U_REMARKS { get; set; }
        public string U_SUSPENSION_CAUSE { get; set; }
        public string U_REQUEST_DATE { get; set; }
        public string U_SAMPLE_NBR { get; set; }
        public string U_MARK_AS { get; set; }
        public string U_ORGAN_CODE { get; set; }
        public string U_ALIQUOT_NBR { get; set; }
        public string U_PRINT_COLOMN { get; set; }
        public string U_PRINT { get; set; }
        public string U_PATHOLOG { get; set; }
        public string U_OK { get; set; }
        public string U_CANCEL { get; set; }
        public string U_SAMPLE_TYPE { get; set; }
        public string U_COLOR { get; set; }
        public string U_VOLUME { get; set; }
        public string U_NEXT_STEP { get; set; }
        public string U_SLIDE_QNTY { get; set; }
        public string U_STAIN { get; set; }
        public string U_SMEAR { get; set; }
        public string U_LBC { get; set; }
        public string U_HPV { get; set; }
        public string U_ACCORD_NUMBER { get; set; }
        public Nullable<long> U_CLINIC_CODE { get; set; }
        public string U_PREV_LAST_NAME { get; set; }
        public string U_ASSUTA_NUMBER { get; set; }
    
        public virtual U_CLINIC U_CLINIC1 { get; set; }
        public virtual U_CUSTOMER U_CUSTOMER1 { get; set; }
        public virtual U_START_SCREEN U_START_SCREEN { get; set; }
    }
}
