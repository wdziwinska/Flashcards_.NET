using System;
using System.Collections.Generic;
using System.Text;

namespace Fiszki_projekt
{
    interface PhrasesDBInterface
    {
        public List<Tuple<int,String, String>> getWord(int phraseId, int firstLanguageId, int secondLangueId);
        public int getRecordsCount();
    }
}
