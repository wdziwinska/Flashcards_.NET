using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Data.SqlClient;
using System.Windows;

namespace Fiszki_projekt
{
    public class Engine : EngineInterface
    {
        
        PhrasesDBImplementation phrasesDBImplementationObject = new PhrasesDBImplementation();
        KnownWordsDBImplementation knownWordsDBImplementationObject = new KnownWordsDBImplementation();
        RepetitionsDBImplementation repetitionsDBImplementationObject = new RepetitionsDBImplementation();
        public List<(int,string, string)> phrases;

        public int firstLanguageId; // te zmienne powinne byc przypisane przez gui
        public int secondLanguageId;
        public SqlConnection sqlCon;


        public Engine()
        {
            sqlCon = new SqlConnection(@"Data Source = DESKTOP-VPA9T48; Initial Catalog=flashcardsDatabase; Integrated Security=True; MultipleActiveResultSets=true;");
        }

        public string setCurrentWordinFirstLanguage()
        {
            if (phrases.Count > 0)
            {
                return phrases.ElementAt(0).Item2;
            }
            return "//Congratulation!//";
        }
        public string getCurrentWordinFirstLanguage()
        {
            if (phrases.Count > 0)
            {
                return phrases.ElementAt(0).Item2;
            }
            return "//Congratulation!//";
        }

        public string getCurrentWordInSecondLanguage()
        {
            if (phrases.Count > 0)
            {
                return phrases.ElementAt(0).Item3;
            }
            return "//Congratulation!//";
        }

        public void storeKnownWord()
        {
            // jezeli slowko nie jest zapisane to je zapisz
            if (phrases.Count > 0)
            {
                knownWordsDBImplementationObject.storeKnownWord(phrases.ElementAt(0).Item1, firstLanguageId, secondLanguageId, getCurrentWordinFirstLanguage(), getCurrentWordInSecondLanguage(),sqlCon);
                repetitionsDBImplementationObject.removeWord(phrases.ElementAt(0).Item1, firstLanguageId, secondLanguageId,sqlCon);
            }
        }
       
        public void storeUnknownWord()
        {       
            if (phrases.Count > 0) // rozbite na dwa if, bo jak zrobie w jednym && to nie dziala
            {
                if (!knownWordsDBImplementationObject.isWordKnown(phrases.ElementAt(0).Item1, firstLanguageId, secondLanguageId,sqlCon))
                {
                    repetitionsDBImplementationObject.storeUnknownWord(phrases.ElementAt(0).Item1, firstLanguageId, secondLanguageId, getCurrentWordinFirstLanguage(), getCurrentWordInSecondLanguage(),sqlCon);
                }
            } 
        }

        public void setLanguagesForLeaning(int firstLanguageId, int secondLanguageId, int numberOfWordsToLearn)
        {
            phrases = phrasesDBImplementationObject.getWord(1, firstLanguageId, secondLanguageId, numberOfWordsToLearn, sqlCon);
        }

        public void wordsForRepetitions(int firstLanguageId, int secondLanguageId, int numberOfWordsToLearn)
        {
            phrases = repetitionsDBImplementationObject.getWordsForRepetition(firstLanguageId, secondLanguageId, numberOfWordsToLearn,sqlCon);
            System.Diagnostics.Debug.WriteLine(phrases);
        }

        public void removeKnownWordsFromPhrases(int numberOfWordsToLearn)
        {   
            phrases.RemoveAll(i => knownWordsDBImplementationObject.isWordKnown(i.Item1, firstLanguageId, secondLanguageId,sqlCon));
            int i =phrases.Count-1;
            while (phrases.Count > numberOfWordsToLearn)
            {
                phrases.RemoveAt(i);
                i--;
            }
        }

        public void connectToDatabase()
        {
            
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                    System.Diagnostics.Debug.WriteLine("Opened");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           /* finally
            {
                sqlCon.Close();
            }*/
        }

       /* public void readFromDatabase()
        {
            SqlCommand command;
            SqlDataReader dataReader2;
            String sql, Output = "";

            sql = "Select * FROM dbo.phrasesBase";
            command = new SqlCommand(sql, sqlCon);
            dataReader2 = command.ExecuteReader();
            while (dataReader2.Read())
            {
                Output = Output + dataReader2.GetValue(firstLanguageId) + " - " + dataReader2.GetValue(secondLanguageId) + "\n";
            }
            MessageBox.Show(Output);
            dataReader2.Close();
        }*/
    }
}
