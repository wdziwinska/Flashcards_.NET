using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// 1 - Polski
// 2 - Angielski
// 3 - Niemiecki
// 4 - Rosyjski
// 5 - Wloski
// 6 - Francuski


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
            // var newLine = string.Format("{0};{1};{2}", pId, phraseInFirstLanguage, phraseInSecondLanguage);
            // csv.Append(newLine);
            // csv.Append("testwubwub\n");
            csv.Append(pId + ";");
           /* if (firstLanguageId == 1)
            {
                csv.Append(phraseInFirstLanguage+";");
            }
            else if (secondLanguageId == 1)
            {
                csv.Append(phraseInSecondLanguage+";");
            }
            else
            {
                csv.Append(";");
            }*/
            for (int i = 1; i <= 6; i++)
            {
                if (firstLanguageId == i)
                {
                    csv.Append(phraseInFirstLanguage + ";");
                }
                else if (secondLanguageId == i)
                {
                    csv.Append(phraseInSecondLanguage + ";");
                }
                else
                {
                    csv.Append(";");
                }
            }


            csv.Append("\n");
            File.AppendAllText("knownWordsDatabase.csv", csv.ToString());
        }
    }
}
