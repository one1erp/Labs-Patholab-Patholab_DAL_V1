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
    
    public partial class ALIQUOT_USER
    {
        public long ALIQUOT_ID { get; set; }
        public string U_ALIQUOT_FIX { get; set; }
        public string U_ALIQUOT_REMARK { get; set; }
        public string U_ALIQUOT_STATION { get; set; }
        public string U_ARCHIVE { get; set; }
        public string U_COLOR_TYPE { get; set; }
        public string U_DECAL { get; set; }
        public string U_EXPRESS { get; set; }
        public string U_FORMATTED_COLOR { get; set; }
        public string U_FROZEN { get; set; }
        public string U_GLASS_TYPE { get; set; }
        public string U_IS_CELL_BLOCK { get; set; }
        public Nullable<decimal> U_LAST_ENTRANCE { get; set; }
        public Nullable<long> U_LAST_LABORANT { get; set; }
        public Nullable<long> U_LAST_MICROTOM { get; set; }
        public string U_LOCATION { get; set; }
        public string U_NUM_OF_TISSUES { get; set; }
        public string U_OLD_ALIQUOT_STATION { get; set; }
        public string U_OVERNIGHT { get; set; }
        public string U_SETTING_UP { get; set; }
        public string U_AUTOTEC { get; set; }
        public string U_BLOCK_NAME { get; set; }
        public Nullable<long> U_LAST_MICROTOME { get; set; }
        public Nullable<System.DateTime> U_PRINTED_ON { get; set; }
        public string U_PRINTER_COL { get; set; }
        public string U_BASKET { get; set; }
        public Nullable<System.DateTime> U_SEND_TO_PATHOLOG_ON { get; set; }
        public Nullable<System.DateTime> U_BACK_FROM_PATHOLOG_ON { get; set; }
        public string U_PATHOLAB_ALIQUOT_NAME { get; set; }
        public Nullable<System.DateTime> U_CANCELED_ON { get; set; }
        public string U_CALCULATE_DEBIT { get; set; }
        public Nullable<long> U_DEBIT_ID { get; set; }
        public string U_EXTERNAL_LAB_NUM { get; set; }
        public string U_AGREE_TYPE { get; set; }
        public string U_HISTOKINT_BATCH { get; set; }
        public string U_SCANNED { get; set; }
        public Nullable<System.DateTime> U_SCANNED_ON { get; set; }
        public Nullable<System.DateTime> U_CUT_ON { get; set; }
    
        public virtual ALIQUOT ALIQUOT { get; set; }
        public virtual OPERATOR OPERATOR { get; set; }
        public virtual WORKSTATION WORKSTATION { get; set; }
        public virtual WORKSTATION WORKSTATION1 { get; set; }
        public virtual U_DEBIT U_DEBIT { get; set; }
    }
}