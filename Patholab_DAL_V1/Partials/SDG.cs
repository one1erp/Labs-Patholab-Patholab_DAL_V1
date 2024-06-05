using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Patholab_Common;
using Patholab_DAL_V1.Enums;

namespace Patholab_DAL_V1
{
    public partial class SDG
    {
        // private string _sdgType;
#pragma warning disable CS0169 // The field 'SDG._sdgType' is never used
        private SdgType _sdgType;
#pragma warning restore CS0169 // The field 'SDG._sdgType' is never used



        public SdgType SdgType
        {
            get
            {
                try
                {   


                    string fl = this.NAME[0].ToString();
                    switch (fl)
                    {
                        case "B":
                            return SdgType.Histology;
#pragma warning disable CS0162 // Unreachable code detected
                            break;
#pragma warning restore CS0162 // Unreachable code detected

                        case "C":
                            return SdgType.Cytology;
#pragma warning disable CS0162 // Unreachable code detected
                            break;
#pragma warning restore CS0162 // Unreachable code detected

                        case "P":
                            return SdgType.Pap;
#pragma warning disable CS0162 // Unreachable code detected
                            break;
#pragma warning restore CS0162 // Unreachable code detected
                        default:
                            return SdgType.None;
                    }
                }
                catch (Exception e)
                {

                       Logger.WriteLogFile(e); 
                    return SdgType.None;
                }
            }

        }
   
    }
}
