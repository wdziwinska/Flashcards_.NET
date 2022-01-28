using System;
using System.Collections.Generic;
using System.Text;

namespace Fiszki_projekt
{
    interface Initializer
    {
        void setLanguagesForLeaning(String firstLanguageName, String secondLanguageName);

        void setNumberOfWordsToLearn();
    }
}
