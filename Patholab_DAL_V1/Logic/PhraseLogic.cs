using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Patholab_DAL_V1.Logic
{
    public class PhraseLogic
    {
        public static PHRASE_HEADER GetPhraseByName(Entities context, string phraseName)
        {

            //var p = context.PHRASE_HEADER.Include("PHRASE_ENTRY").FirstOrDefault(x => x.NAME == phraseName);

            var p = context.PHRASE_HEADER.FirstOrDefault(x => x.NAME == phraseName);
            return p;


        }
        public static PHRASE_HEADER GetPhraseByID(Entities context, long PHRASE_ID)
        {

            var p = context.PHRASE_HEADER.FirstOrDefault(x => x.PHRASE_ID == PHRASE_ID);
            return p;


        }
        public static IQueryable<PHRASE_ENTRY> GetPhraseEntries(Entities context, string phraseName)
        {


            var q = from item in context.PHRASE_ENTRY where item.PHRASE_HEADER.NAME == phraseName orderby item.ORDER_NUMBER select item;
            return q;


        }
        public static IQueryable<PHRASE_ENTRY> GetPhraseEntriesNew(Entities context, string phraseName)
        {


            var q = from ph in context.PHRASE_HEADER
                    join pe in context.PHRASE_ENTRY
                        on ph.PHRASE_ID equals pe.PHRASE_ID
                    where ph.NAME == phraseName
                    orderby pe.ORDER_NUMBER
                    select pe;

            return q;


        }
    }
}