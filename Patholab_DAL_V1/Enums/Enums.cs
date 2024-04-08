using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patholab_DAL_V1.Enums
{

        
    public enum SdgType
    {
       None, Histology,Cytology,Pap
    }

    //public enum EntityType
    //{
    //    Sdg,
    //    Sample,
    //    Block,
    //    Slide
    //}

    public enum ExtraRequestType
    {
        I, // אימונוהיסטוכימיה
        H, // היסטוכימיה
        S, // סריקה חוזרת
        M, // חומר נוסף
        R, // צביעה חוזרת
        O, // בקשה אחרת
        T ,// התייעצות
        C,
        P
    }

}
