using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Fiszki_projekt
{
    interface PhrasesDBInterface
    {
        //public List<Tuple<int,string, string>> getWord(int phraseId, int firstLanguageId, int secondLangueId);

        public List<(int,string,string)> getWord(int phraseId, int firstLanguageId, int secondLangueId, int numberOfWordsToLearn, SqlConnection SqlCon);
        public int getRecordsCount();
    }
}
