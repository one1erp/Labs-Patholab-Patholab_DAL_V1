using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Patholab_DAL_V1.Logic
{
    internal class OperatorLogic
    {

        public static List<OPERATOR> GetOperatorsByRole(Entities context, string roleName)
        {
            var lr = context.LIMS_ROLE.FirstOrDefault(x => x.NAME == roleName);
            if (lr != null)
            {
                return lr.OPERATORs1.ToList();
            }
            return null;
        }
        public static OPERATOR GetOperatorByIdIncludeRole(Entities context, double operatorId)
        {


            var q = (from item in context.OPERATORs.Include("LIMS_ROLES") where item.OPERATOR_ID == operatorId select item).SingleOrDefault();
    
            return q;
        }
        public static IQueryable<OPERATOR> GetOperatorsByGroup(Entities context, long groupIde)
        {


            var q = from item in context.OPERATOR_GROUP where groupIde == item.GROUP_ID select item.OPERATOR;
            return q;
        }
    }
}