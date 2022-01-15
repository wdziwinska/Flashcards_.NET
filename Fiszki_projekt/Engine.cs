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
        KnownWordsDBImplementation KnownWordsDBImplementationObject = new KnownWordsDBImplementation();
        public List<(string, string)> phrases;

        private int firstLanguageId = 4; // te zmienne powinne byc przypisane przez gui
        private int secondLanguageId = 3;


        public Engine()
        {
           phrases = PhrasesDBImplementationObject.getWord(1, firstLanguageId, secondLanguageId);
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

        public void storeKnownWords()
        {
            KnownWordsDBImplementationObject.storeKnownWorld(1,firstLanguageId,secondLanguageId,getCurrentWordinFirstLanguage(),getCurrentWordInSecondLanguage());
        }
        

       


    }
}
