using System;
using System.Collections.Generic;
using System.Text;

namespace Fiszki_projekt
{
    interface EngineInterface
    {
        public string setCurrentWordinFirstLanguage();

        void setLanguagesForLeaning(int firstLanguageName, int secondLanguageName, int numberOfWordtoLearn);

        void wordsForRepetitions(int firstLanguageName, int secondLanguageName, int numberOfWordtoLearn);

        public string getCurrentWordInSecondLanguage();

        public string getCurrentWordinFirstLanguage();
    }
}
