using Patholab_DAL_V1.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patholab_DAL_V1.Logic
{
    public class SampleMsgLogic
    {

        internal static string ValidateSampleMsg(U_SAMPLE_MSG_USER item)
        {
            string errors = "";
            if (!item.U_CLINIC_ID.HasValue)
            {
                errors += "No Clinic;";
            }

            if (!item.U_REFERRING_PHYSICIAN.HasValue)
            {
                errors += "Missing Referring Physician;";
            }
            if (!item.U_IMPLEMENTING_PHYSICIAN.HasValue)
            {
                errors += "Missing Executing Physician;";
            }
            if (!item.U_CLIENT_ID.HasValue)
            {
                errors += "Missing Patient;";
            }
            if (item.U_ORDER == null)
            {
                errors += "Missing Order;";
            }
            else
            {
                if (!item.U_ORDER.U_ORDER_USER.U_PARTS_ID.HasValue)
                {
                    errors += "Missing Part";
                }
                if (!item.U_ORDER.U_ORDER_USER.U_CUSTOMER.HasValue)
                {
                    errors += "Missing Customer";
                }
            }




            return errors;
        }
    }
}
