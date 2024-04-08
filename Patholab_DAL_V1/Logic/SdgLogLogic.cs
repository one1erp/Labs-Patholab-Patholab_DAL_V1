using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patholab_DAL_V1.Logic
{
    internal class SdgLogLogic
    {
        internal static bool InsertToSdgLog(Entities context, long SdgId, string applicationCode, long sessionId, string Description)
        {
            try
            {
               
                SDG_LOG newLogEntry = new SDG_LOG
                {
                    SDG_ID = SdgId,
                    TIME = DateTime.Now,
                    APPLICATION_CODE = applicationCode,
                    SESSION_ID = sessionId,
                    DESCRIPTION = Description,
                };
                context.SaveChanges();
                Repository.Add(context, newLogEntry);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
