using System;
using System.Collections.Generic;
using System.Text;

namespace Fiszki_projekt
{
    interface EngineInterface
    {
        public string setCurrentWordinFirstLanguage();

        public string getCurrentWordInSecondLanguage();

        public string getCurrentWordinFirstLanguage();

        public void storeKnownWord();

        public void storeUnknownWord();

        void setLanguagesForLeaning(int firstLanguageName, int secondLanguageName, int numberOfWordtoLearn);

        void wordsForRepetitions(int firstLanguageName, int secondLanguageName, int numberOfWordtoLearn);

        public void removeKnownWordsFromPhrases(int numberOfWordsToLearn);
    }
}
