using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patholab_DAL_V1
{
    public partial class PHRASE_HEADER
    {
        public Dictionary<string, string> PhraseEntriesDictonary
        {

            get
            {
                Dictionary<string, string> phraseEntriesDic = new Dictionary<string, string>();
                
                foreach (PHRASE_ENTRY entry in this.PHRASE_ENTRY)
                {
                    phraseEntriesDic.Add(entry.PHRASE_NAME, entry.PHRASE_DESCRIPTION);
                }
                return phraseEntriesDic;

            }
        }

    }
}