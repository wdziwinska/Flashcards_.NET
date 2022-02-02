using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Fiszki_projekt
{
    interface RepetitionsDBInterface
    {
        // void storeUnknownWord(int phraseId, int firstLanguageId, int secondLanguageId, string phraseInFirstLanguage, string phraseInSecondLanguage);
        //public List<(int, string, string)> getWordsForRepetition(int firstLanguageId, int secondLanguageId, int numberOfWordsToLearn);
        // bool isWordAddedToRepetitions(int phraseId, int firstLanguageId, int secondLanguageId);
        //void removeWord(int phraseId, int firstLanguageId, int secondLanguageId);
        void storeUnknownWord(int phraseId, int firstLanguageId, int secondLanguageId, string phraseInFirstLanguage, string phraseInSecondLanguage,SqlConnection sqlCon);
  
        public List<(int, string, string)> getWordsForRepetition(int firstLanguageId, int secondLanguageId, int numberOfWordsToLearn,SqlConnection sqlCon);


        void removeWord(int phraseId, int firstLanguageId, int secondLanguageId,SqlConnection sqlCon);

        bool isWordAddedToRepetitions(int phraseId, int firstLanguageId, int secondLanguageId,SqlConnection sqlCon);
        string languageIdToName(int languageId);
    }
}
