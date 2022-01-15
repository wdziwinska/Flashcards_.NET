using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fiszki_projekt
{
    internal class KnownWordsDBImplementation : KnownWordsDBInterface
    {
        public void storeKnownWorld(int phraseId, int firstLanguageId, int secondLanguageId, string phraseInFirstLanguage, string phraseInSecondLanguage)
        {
            var csv = new StringBuilder();
            var pId = phraseId.ToString();
            var fId = firstLanguageId.ToString();
            var sId = secondLanguageId.ToString();
            var newLine = string.Format("{0},{1},{2}\n", pId, phraseInFirstLanguage, phraseInSecondLanguage);
            csv.Append(newLine);
            File.AppendAllText("knownWordsDatabase.csv", csv.ToString());
        }
    }
}
