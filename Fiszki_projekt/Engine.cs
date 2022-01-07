using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace Fiszki_projekt
{
    public class Engine : LearningProcessManager, WordClassifier, WordGetter, Initializer, WordSetter
    {
        
        PhrasesDBImplementation PhrasesDBImplementationObject = new PhrasesDBImplementation();
        public List<(string, string)> phrases;

        public Engine()
        {
           phrases = PhrasesDBImplementationObject.getWord(1, 1, 2);
        }

        public string setCurrentWordinFirstLanguage()
        {
            if (phrases.Count > 0)
            {
                return phrases.ElementAt(0).Item1;
            }
            return "//Koniec cwiczenia//";
        }
        public string getCurrentWordinFirstLanguage()
        {
            if (phrases.Count > 0)
            {
                return phrases.ElementAt(0).Item1;
            }
            return "//Koniec cwiczenia//";
        }

        public string getCurrentWordInSecondLanguage()
        {

            if (phrases.Count > 0)
            {
                return phrases.ElementAt(0).Item2;
            }
            return "//Koniec cwiczenia//";
        }

        

       


    }
}
