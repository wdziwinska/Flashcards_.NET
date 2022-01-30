using System;
using System.Collections.Generic;
using System.Text;

namespace Fiszki_projekt
{
    interface Initializer
    {
        void setLanguagesForLeaning(int firstLanguageName, int secondLanguageName, int numberOfWordtoLearn);

        void wordsForRepetitions(int firstLanguageName, int secondLanguageName, int numberOfWordtoLearn);
    }
}
