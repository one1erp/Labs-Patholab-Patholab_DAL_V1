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
    
    public partial class U_RESULT_DESC_USER
    {
        public long U_RESULT_DESC_ID { get; set; }
        public string U_BOLD { get; set; }
        public string U_FONT_COLOR { get; set; }
        public string U_FREE_TEXT_TEMPLATE { get; set; }
        public Nullable<decimal> U_HEIGHT { get; set; }
        public string U_LABEL { get; set; }
        public Nullable<decimal> U_LETTER_ORDER { get; set; }
        public string U_MANDATORY { get; set; }
        public string U_MANDATORY_VALUE { get; set; }
        public string U_NEEDS_REVIEW { get; set; }
        public string U_READ_ONLY { get; set; }
        public string U_RTL { get; set; }
        public string U_PRINT_FAX { get; set; }
        public Nullable<decimal> U_ORDER { get; set; }
        public string U_PHRASE_LIST { get; set; }
        public Nullable<decimal> U_RENK { get; set; }
        public Nullable<long> U_RESULT_TEMPLATE_ID { get; set; }
        public string U_TEMPLATE_NAME { get; set; }
        public string U_TYPE { get; set; }
        public string U_VISIBLE { get; set; }
        public Nullable<decimal> U_WIDTH { get; set; }
    
        public virtual U_RESULT_DESC U_RESULT_DESC { get; set; }
    }
}
