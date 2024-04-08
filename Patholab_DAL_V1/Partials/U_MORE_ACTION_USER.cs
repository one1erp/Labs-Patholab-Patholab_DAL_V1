using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patholab_DAL_V1.Logic;

namespace Patholab_DAL_V1
{
    public partial class U_MORE_ACTION_USER
    {

    
        
        public string StatusHistory
        {
            get
            {
                if (string.IsNullOrEmpty(U_STATUS))return "";
                        
                return U_STATUS.Replace ( ",", Environment.NewLine );
                
            }
        }



    }
}
