using Patholab_DAL_V1.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patholab_DAL_V1.Logic
{
    public class SdgLogic
    {
        public static string GeneratePatholabNumber(Entities context, SDG_USER newSDg)
        {
            //In case of SDG already exists
            try
            {
                var Departmen = newSDg.SDG.NAME[0];
                U_CUSTOMER cust = newSDg.U_ORDER.U_ORDER_USER.U_CUSTOMER1;


                decimal val = RunFunction.Run_PATHOLAB_SYNTAX(context, cust.U_CUSTOMER_ID, Departmen.ToString());


                string signs = "";
                switch (Departmen)
                {

                    case 'B':
                        signs = cust.U_CUSTOMER_USER.U_LETTER_B;
                        break;
                    case 'C':
                        signs = cust.U_CUSTOMER_USER.U_LETTER_C;
                        break;
                    case 'P':
                        signs = cust.U_CUSTOMER_USER.U_LETTER_P;
                        break;
                    default:
                        signs = "";
                        break;

                }

                string Digits = val.ToString();
                const int numOfDigits = 5;
                while (Digits.Length < numOfDigits)
                {
                    Digits = "0" + Digits;
                }
                var today = DateTime.Now.Date;

                var year = today.ToString("yy");
                string syntax = signs + Digits + "/" + year;
                return syntax;
            }
            catch (Exception ex)
            {
                return "0";
            }

        }



        internal static SDG_DETAILS Get_SDG_DETAILS(Entities context, long sdgId)
        {
            string sql = " SELECT * FROM lims.sdg_details where sdg_id=" + sdgId;
            var aa = context.Database.SqlQuery<SDG_DETAILS>(sql);
            return aa.FirstOrDefault();
        }

        internal static SDG_DETAILS Get_SDG_DETAILS(Entities context, string name)
        {
            string sql = " SELECT * FROM lims.sdg_details where sdg_name='" + name + "'";
            var res = context.Database.SqlQuery<SDG_DETAILS>(sql);
            if (res.Count() < 1)
            {
                sql = " SELECT * FROM lims.sdg_details where patholab_number='" + name + "'";
                res = context.Database.SqlQuery<SDG_DETAILS>(sql);

            }
            if (res.Count() < 1 && name.Length > 10)//by sample or aliquopt
            {
                sql = " SELECT * FROM lims.sdg_details where sdg_name='" + name.Substring(0, 10) + "'";
                res = context.Database.SqlQuery<SDG_DETAILS>(sql);
                if (res.Count() < 1)
                {
                    sql = " SELECT * FROM lims.sdg_details where patholab_number='" + name.Substring(0, 10) + "'";
                    res = context.Database.SqlQuery<SDG_DETAILS>(sql);

                }
            }
            return res.FirstOrDefault();
        }

        internal static List<SDG_RESULTS> Get_SDG_RESULTS(Entities context, long sdgId)
        {
            string sql = " SELECT * FROM lims.SDG_RESULTS where sdg_id=" + sdgId;
            var aa = context.Database.SqlQuery<SDG_RESULTS>(sql);
            return aa.ToList();
        }

        internal static List<SDG_RESULTS> Get_SDG_RESULTS(Entities context, string name)
        {
            string sql = " SELECT * FROM lims.SDG_RESULTS where SDG_NAME='" + name + "'";
            var res = context.Database.SqlQuery<SDG_RESULTS>(sql);
            return res.ToList();
        }



    }
}
