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
        private SdgType _sdgType;



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
                            break;

                        case "C":
                            return SdgType.Cytology;
                            break;

                        case "P":
                            return SdgType.Pap;
                            break;
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
