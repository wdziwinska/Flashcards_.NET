using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fiszki_projekt
{
    internal class RepetitionsDBImplementation : RepetitionsDBInterface
    {
       

        public List<(int, string, string)> getWordsForRepetition(int firstLanguageId, int secondLanguageId)
        {
            (int, string, string) tuple = (0, "", "");
            using (var reader = new StreamReader(@"wordsForRepetition.csv"))
            {
              //  reader.ReadLine();
                //int licznik = 0;
                var retList = new List<(int, string, string)>();
                //while (!reader.EndOfStream && licznik<10)
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(";");
                    // System.Diagnostics.Debug.WriteLine("Slowo: " + values[firstLanguageId] + ", tlumaczenie: " + values[secondLanguageId]);
                    if (isWordAddedToRepetitions(Int32.Parse(values[0]),firstLanguageId, secondLanguageId))
                    {
                        tuple = (Int32.Parse(values[0]), values[firstLanguageId], values[secondLanguageId]);
                        retList.Add(tuple);
                    }
                    //licznik++; 
                }
                reader.Close();
                return retList;
            }
        }

        public bool isWordAddedToRepetitions(int phraseId, int firstLanguageId, int secondLanguageId)
        {
            using (var reader = new StreamReader(@"wordsForRepetition.csv"))
            {
                //reader.ReadLine(); ta linijka musi byc gdy bedzie poprawny naglowek
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(";");
                    if (Int32.Parse(values[0]) == phraseId) // jezeli jest to id
                    {
                        // oba musza byc nie puste, zeby to slowo bylo uznane za zrozumiane
                        if (values[firstLanguageId] != "" && values[secondLanguageId] != "")
                        {
                            //   System.Diagnostics.Debug.WriteLine("Slowo: " + values[firstLanguageId] + ", tlumaczenie: " + values[secondLanguageId]);
                            return true;
                        }

                    }

                }
                reader.Close();
                return false;
            }
        }

        public void removeWord(int phraseId, int firstLanguageId, int secondLanguageId)
        {
            var csv = new StringBuilder();
            string pId = phraseId.ToString();
            string fId = firstLanguageId.ToString();
            string sId = secondLanguageId.ToString();
            string[] values = { "" };
            int counter = -1;
            bool shouldIWriteBack = false;
            // jezeli nie ma slowa to wracaj
            if (!isWordAddedToRepetitions(phraseId, firstLanguageId, secondLanguageId))
            {
                return;
            }

            using (var reader = new StreamReader(@"wordsForRepetition.csv"))
            {
                //reader.ReadLine(); ta linijka musi byc gdy bedzie poprawny naglowek
                reader.DiscardBufferedData();
                reader.BaseStream.Position = 0;
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    values = lines.Split(";");
                    counter++;
                    if (Int32.Parse(values[0]) == phraseId) // jezeli jest to id to sie zapisuja sie linia do values
                    {
                        break;
                    }
                }
                reader.Close();
            }
            int pom = Int32.Parse(values[0]) - 1;
            // usuwam slowa ktore zaznaczylem ze umiem

            values[firstLanguageId] = "";
            values[secondLanguageId] = "";

            for (int i=1; i<values.Length; i++)
            {
                // jezeli ktoras wartosc nie jest pusta, oznacza to, ze sa tam slowa ktorych nie umiem wiec trzeba to wpisac z powrotem
                if (values[i] != "")
                {
                    shouldIWriteBack= true;
                }
            }

            for (int i = 0; i < values.Length; i++)
            {
                csv.Append(values[i] + ";");
            }

            List<string> lines2 = File.ReadAllLines("wordsForRepetition.csv").ToList();
          //  System.Diagnostics.Debug.WriteLine("Id frazy: " + pom);
            lines2.RemoveAt(counter);

            if (shouldIWriteBack)
            {
                lines2.Insert(counter, csv.ToString());
            }
           
            File.WriteAllLines("wordsForRepetition.csv", lines2.ToArray());
        }

        public void storeUnknownWord(int phraseId, int firstLanguageId, int secondLanguageId, string phraseInFirstLanguage, string phraseInSecondLanguage)
        {
            var csv = new StringBuilder();
            string pId = phraseId.ToString();
            string fId = firstLanguageId.ToString();
            string sId = secondLanguageId.ToString();
            bool isInDB = false; // wpierw trzeba sprawdzic czy dana fraza jest w bazie, zeby wiedziec czy dopisac jezyk, czy cala fraze
                                 // nie mozna uzyc funkcji isWordKnown poniewaz jeden z jezykow jest nowy

            int counter = -1;
            // jezeli slowko jest znane w obu jezykach to nic nie dopisuj
            string[] values = { "" };
            if (isWordAddedToRepetitions(phraseId, firstLanguageId, secondLanguageId))
            {
                return;
            }

            using (var reader = new StreamReader(@"wordsForRepetition.csv"))
            {
                //reader.ReadLine(); ta linijka musi byc gdy bedzie poprawny naglowek
                reader.DiscardBufferedData();
                reader.BaseStream.Position = 0;
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    values = lines.Split(";");
                    counter++;
                    if (Int32.Parse(values[0]) == phraseId) // jezeli jest to id
                    {
                        isInDB = true;
                        break;
                    }
                }
                reader.Close();

            }

            if (isInDB) // jezeli id jest w bazie, to trzeba dopisac jedno z jezykow
            {
                int pom = Int32.Parse(values[0]) - 1;
                if (values[firstLanguageId] == "")
                {
                    values[firstLanguageId] = phraseInFirstLanguage;
                }
                if (values[secondLanguageId] == "")
                {
                    values[secondLanguageId] = phraseInSecondLanguage;
                }
                for (int i = 0; i < values.Length; i++)
                {
                    csv.Append(values[i] + ";");
                }
                List<string> lines = File.ReadAllLines("wordsForRepetition.csv").ToList();
                //  System.Diagnostics.Debug.WriteLine("Id frazy: " + pom);
                lines.RemoveAt(counter);
                lines.Insert(counter, csv.ToString());
                File.WriteAllLines("wordsForRepetition.csv", lines.ToArray());

            }
            else // jezel nie jest w bazie to trzeba dopisac cala fraze
            {
                csv.Append(pId + ";");
                for (int i = 1; i <= 6; i++)
                {
                    if (firstLanguageId == i)
                    {
                        csv.Append(phraseInFirstLanguage + ";");
                    }
                    else if (secondLanguageId == i)
                    {
                        csv.Append(phraseInSecondLanguage + ";");
                    }
                    else
                    {
                        csv.Append(";");
                    }
                }
                csv.Append("\n");
                File.AppendAllText("wordsForRepetition.csv", csv.ToString());

            }
        }
    }
}
