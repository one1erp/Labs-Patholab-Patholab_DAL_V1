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
    
    public partial class OPERATOR
    {
        public OPERATOR()
        {
            this.ALIQUOTs = new HashSet<ALIQUOT>();
            this.ALIQUOTs1 = new HashSet<ALIQUOT>();
            this.ALIQUOTs2 = new HashSet<ALIQUOT>();
            this.ALIQUOTs3 = new HashSet<ALIQUOT>();
            this.ALIQUOTs4 = new HashSet<ALIQUOT>();
            this.ALIQUOT_USER = new HashSet<ALIQUOT_USER>();
            this.INSPECTION_LOG = new HashSet<INSPECTION_LOG>();
            this.U_CONTAINER_USER = new HashSet<U_CONTAINER_USER>();
            this.U_PRICE_LIST_USER = new HashSet<U_PRICE_LIST_USER>();
            this.SDGs = new HashSet<SDG>();
            this.SDG_USER = new HashSet<SDG_USER>();
            this.U_SPECIAL_INSPECTION_USER = new HashSet<U_SPECIAL_INSPECTION_USER>();
            this.U_SPECIAL_INSPECTION_USER1 = new HashSet<U_SPECIAL_INSPECTION_USER>();
            this.OPERATOR_GROUP = new HashSet<OPERATOR_GROUP>();
            this.RESULTs = new HashSet<RESULT>();
            this.RESULTs1 = new HashSet<RESULT>();
            this.RESULTs2 = new HashSet<RESULT>();
            this.RESULTs3 = new HashSet<RESULT>();
            this.SAMPLEs = new HashSet<SAMPLE>();
            this.SAMPLEs1 = new HashSet<SAMPLE>();
            this.SAMPLEs2 = new HashSet<SAMPLE>();
            this.SAMPLEs3 = new HashSet<SAMPLE>();
            this.SAMPLEs4 = new HashSet<SAMPLE>();
            this.SAMPLEs5 = new HashSet<SAMPLE>();
            this.SDGs1 = new HashSet<SDG>();
            this.SDGs2 = new HashSet<SDG>();
            this.SDGs3 = new HashSet<SDG>();
            this.TESTs = new HashSet<TEST>();
            this.TESTs1 = new HashSet<TEST>();
            this.TESTs2 = new HashSet<TEST>();
            this.TESTs3 = new HashSet<TEST>();
            this.LIMS_ROLE1 = new HashSet<LIMS_ROLE>();
            this.WORKSTATIONs = new HashSet<WORKSTATION>();
            this.U_LABORANT_WORK_USER = new HashSet<U_LABORANT_WORK_USER>();
            this.U_ALL_BARCODE_SCAN_USER = new HashSet<U_ALL_BARCODE_SCAN_USER>();
            this.U_EXTRA_REQUEST_USER = new HashSet<U_EXTRA_REQUEST_USER>();
            this.SDG_USER1 = new HashSet<SDG_USER>();
        }
    
        public long OPERATOR_ID { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<long> ROLE_ID { get; set; }
        public string NAME { get; set; }
        public string ALLOW_LOGIN { get; set; }
        public string JOB_TITLE { get; set; }
        public string QUALIFICATIONS { get; set; }
        public Nullable<long> DATABASE_ID { get; set; }
        public string DATABASE_NAME { get; set; }
        public string FULL_NAME { get; set; }
        public Nullable<long> PROFILE_ID { get; set; }
    
        public virtual ICollection<ALIQUOT> ALIQUOTs { get; set; }
        public virtual ICollection<ALIQUOT> ALIQUOTs1 { get; set; }
        public virtual ICollection<ALIQUOT> ALIQUOTs2 { get; set; }
        public virtual ICollection<ALIQUOT> ALIQUOTs3 { get; set; }
        public virtual ICollection<ALIQUOT> ALIQUOTs4 { get; set; }
        public virtual ICollection<ALIQUOT_USER> ALIQUOT_USER { get; set; }
        public virtual ICollection<INSPECTION_LOG> INSPECTION_LOG { get; set; }
        public virtual LIMS_ROLE LIMS_ROLE { get; set; }
        public virtual ICollection<U_CONTAINER_USER> U_CONTAINER_USER { get; set; }
        public virtual ICollection<U_PRICE_LIST_USER> U_PRICE_LIST_USER { get; set; }
        public virtual ICollection<SDG> SDGs { get; set; }
        public virtual ICollection<SDG_USER> SDG_USER { get; set; }
        public virtual ICollection<U_SPECIAL_INSPECTION_USER> U_SPECIAL_INSPECTION_USER { get; set; }
        public virtual ICollection<U_SPECIAL_INSPECTION_USER> U_SPECIAL_INSPECTION_USER1 { get; set; }
        public virtual ICollection<OPERATOR_GROUP> OPERATOR_GROUP { get; set; }
        public virtual ICollection<RESULT> RESULTs { get; set; }
        public virtual ICollection<RESULT> RESULTs1 { get; set; }
        public virtual ICollection<RESULT> RESULTs2 { get; set; }
        public virtual ICollection<RESULT> RESULTs3 { get; set; }
        public virtual ICollection<SAMPLE> SAMPLEs { get; set; }
        public virtual ICollection<SAMPLE> SAMPLEs1 { get; set; }
        public virtual ICollection<SAMPLE> SAMPLEs2 { get; set; }
        public virtual ICollection<SAMPLE> SAMPLEs3 { get; set; }
        public virtual ICollection<SAMPLE> SAMPLEs4 { get; set; }
        public virtual ICollection<SAMPLE> SAMPLEs5 { get; set; }
        public virtual ICollection<SDG> SDGs1 { get; set; }
        public virtual ICollection<SDG> SDGs2 { get; set; }
        public virtual ICollection<SDG> SDGs3 { get; set; }
        public virtual ICollection<TEST> TESTs { get; set; }
        public virtual ICollection<TEST> TESTs1 { get; set; }
        public virtual ICollection<TEST> TESTs2 { get; set; }
        public virtual ICollection<TEST> TESTs3 { get; set; }
        public virtual ICollection<LIMS_ROLE> LIMS_ROLE1 { get; set; }
        public virtual ICollection<WORKSTATION> WORKSTATIONs { get; set; }
        public virtual ICollection<U_LABORANT_WORK_USER> U_LABORANT_WORK_USER { get; set; }
        public virtual ICollection<U_ALL_BARCODE_SCAN_USER> U_ALL_BARCODE_SCAN_USER { get; set; }
        public virtual OPERATOR_USER OPERATOR_USER { get; set; }
        public virtual ICollection<U_EXTRA_REQUEST_USER> U_EXTRA_REQUEST_USER { get; set; }
        public virtual ICollection<SDG_USER> SDG_USER1 { get; set; }
    }
}