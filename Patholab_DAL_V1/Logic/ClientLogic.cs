using Patholab_DAL_V1.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patholab_DAL_V1.Logic
{
    public class ClientLogic
    {
        public static CLIENT    AddClient(Entities context, string _identity, DateTime? _birthDate,
            string ispassport, string FirstName, string lastName, string gender)
        {
            bool isPassportorTZ = ispassport == "T";

            FixIdentity(_identity, isPassportorTZ);

            if (isPassportorTZ == false)//Is T.Z
            {

                bool validId = RunFunction.Run_CheckId(context, _identity);
                if (!validId)
                {
                    throw new Exception("Identity is not valid");
                }
            }

            CLIENT clnt = new CLIENT();
            clnt.CLIENT_USER = new CLIENT_USER();
            clnt.NAME = _identity;

            var clientId = RunFunction.GetNewId(context, "SQ_CLIENT");

            clnt.CLIENT_ID = (long)clientId;
            clnt.CLIENT_USER.CLIENT_ID = (long)clientId;
            clnt.VERSION = "1";
            clnt.VERSION_STATUS = "A";

            clnt.CLIENT_USER.U_FIRST_NAME = FirstName;

            clnt.CLIENT_USER.U_LAST_NAME = lastName;

            clnt.CLIENT_USER.U_DATE_OF_BIRTH = _birthDate;

            clnt.CLIENT_USER.U_PASSPORT = ispassport;

            clnt.CLIENT_USER.U_GENDER = gender;

            context.CLIENTs.Add(clnt);

            return clnt;
        }



        static string FixIdentity(string cn, bool isPassport)
        {
            if (isPassport)
            {
                return cn;
            }
            else //T.Z
            {
                var cn0 = cn;
                while (cn0.Length < 9)
                {
                    cn0 = "0" + cn0;
                }
                return cn0;
            }

        }
    }
}
