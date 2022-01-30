using System;
using System.Collections.Generic;
using System.Text;

namespace Fiszki_projekt
{
    interface RepetitionsDBInterface
    {
        void storeUnknownWord(int phraseId, int firstLanguageId, int secondLanguageId, string phraseInFirstLanguage, string phraseInSecondLanguage);
        public List<(int, string, string)> getWordsForRepetition(int firstLanguageId, int secondLanguageId, int numberOfWordsToLearn);

        void removeWord(int phraseId,int firstLanguageId,int secondLanguageId);

        bool isWordAddedToRepetitions(int phraseId, int firstLanguageId, int secondLanguageId);
    }
}
