using System;
using System.Collections.Generic;
using System.Text;

namespace Fiszki_projekt
{
    interface KnownWordsDBInterface
    {
        void storeKnownWorld (int phraseId,int firstLanguageId, int secondLanguageId, string phraseInFirstLanguage, string phraseInSecondLanguage);
    }
}
