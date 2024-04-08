using Patholab_DAL_V1.Enums;
using Patholab_DAL_V1.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patholab_DAL_V1.Logic
{
    public class ExtraRequestLogic
    {



         const string Add_Slide = "Add Slide";
         const string Extra_Material = "Extra Material";
         const string Send_to_Consultant = "Send to Consultant";
         const string Rescan = "Rescan";
         const string Repainting = "Repainting";
         const string Pap_Dilution = "Pap_Dilution";
         const string Cell_Block = "Cell_Block";



        public static string GetEntityType(string entityName)
        {



            int dots = 0;
            foreach (char c in entityName)
            {
                if (c == '.')
                    dots++;
            }
            string entityType;
            if (dots == 0) entityType = "Sdg";
            else if (dots == 1) entityType = "Sample";
            else if (dots == 2) entityType = "Block";
            else entityType = "Slide";


            return entityType;



        }

        internal static string GetReason(ExtraRequestType exRequestType)
        {
            switch (exRequestType)
            {
                case ExtraRequestType.I:
                    return Add_Slide;

                case ExtraRequestType.H:
                    return Add_Slide;

                case ExtraRequestType.S:
                    return Rescan;

                case ExtraRequestType.M:
                    return Extra_Material;

                case ExtraRequestType.R:
                    return Repainting;

                case ExtraRequestType.O:
                    return Add_Slide;

                case ExtraRequestType.T:
                    return Send_to_Consultant;

                case ExtraRequestType.P:
                    return Pap_Dilution;

                case ExtraRequestType.C:
                    return Cell_Block;
                default:
                    return "";
            }
        }
    }
}
