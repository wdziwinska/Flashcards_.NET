using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace Fiszki_projekt
{
    public class Engine : LearningProcessManager, WordClassifier, WordGetter, Initializer, WordSetter
    {
        
        PhrasesDBImplementation phrasesDBImplementationObject = new PhrasesDBImplementation();
        KnownWordsDBImplementation knownWordsDBImplementationObject = new KnownWordsDBImplementation();
        RepetitionsDBImplementation repetitionsDBImplementationObject = new RepetitionsDBImplementation();
        public List<(int,string, string)> phrases;

        public int firstLanguageId; // te zmienne powinne byc przypisane przez gui
        public int secondLanguageId;


        public Engine()
        {
        }

        public string setCurrentWordinFirstLanguage()
        {
            if (phrases.Count > 0)
            {
                return phrases.ElementAt(0).Item2;
            }
            return "//Congratulations!//";
        }
        public string getCurrentWordinFirstLanguage()
        {
            if (phrases.Count > 0)
            {
                return phrases.ElementAt(0).Item2;
            }
            return "//Congratulations!//";
        }

        public string getCurrentWordInSecondLanguage()
        {

            if (phrases.Count > 0)
            {
                return phrases.ElementAt(0).Item3;
            }
            return "//Congratulations!//";
        }

        public void storeKnownWord()
        {
            // jezeli slowko nie jest zapisane to je zapisz
            if (phrases.Count > 0)
            {
                knownWordsDBImplementationObject.storeKnownWord(phrases.ElementAt(0).Item1, firstLanguageId, secondLanguageId, getCurrentWordinFirstLanguage(), getCurrentWordInSecondLanguage());
                repetitionsDBImplementationObject.removeWord(phrases.ElementAt(0).Item1, firstLanguageId, secondLanguageId);
            }
        }
       
        public void storeUnknownWord()
        {       
            if (phrases.Count > 0) // rozbite na dwa if, bo jak zrobie w jednym && to nie dziala
            {
                if (!knownWordsDBImplementationObject.isWordKnown(phrases.ElementAt(0).Item1, firstLanguageId, secondLanguageId))
                {
                    repetitionsDBImplementationObject.storeUnknownWord(phrases.ElementAt(0).Item1, firstLanguageId, secondLanguageId, getCurrentWordinFirstLanguage(), getCurrentWordInSecondLanguage());
                }
            } 
        }

        public void setLanguagesForLeaning(int firstLanguageId, int secondLanguageId, int numberOfWordsToLearn)
        {
            phrases = phrasesDBImplementationObject.getWord(1, firstLanguageId, secondLanguageId, numberOfWordsToLearn);
        }

        public void wordsForRepetitions(int firstLanguageId, int secondLanguageId, int numberOfWordsToLearn)
        {
            phrases = repetitionsDBImplementationObject.getWordsForRepetition(firstLanguageId, secondLanguageId, numberOfWordsToLearn);
            System.Diagnostics.Debug.WriteLine(phrases);
        }

        public void removeKnownWordsFromPhrases(int numberOfWordsToLearn)
        {   
            phrases.RemoveAll(i => knownWordsDBImplementationObject.isWordKnown(i.Item1, firstLanguageId, secondLanguageId));
            int i =phrases.Count-1;
            while (phrases.Count > numberOfWordsToLearn)
            {
                phrases.RemoveAt(i);
                i--;
            }
        }
    }
}
