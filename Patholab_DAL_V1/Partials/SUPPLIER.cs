using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patholab_DAL_V1
{
    public partial class SUPPLIER
    {
        public override string ToString()
        {

            if (this.SUPPLIER_USER.U_FIRST_NAME == null)
            {
                return this.SUPPLIER_USER.U_LAST_NAME;
            }
            else
            {
                return this.SUPPLIER_USER.U_FIRST_NAME + " " + this.SUPPLIER_USER.U_LAST_NAME;
            }
        }
    }
}
