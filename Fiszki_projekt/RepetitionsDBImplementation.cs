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
            using (var reader = new StreamReader(@"BazaSlowek.csv"))
            {
                reader.ReadLine();
                //int licznik = 0;
                var retList = new List<(int, string, string)>();
                //while (!reader.EndOfStream && licznik<10)
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(";");
                    // System.Diagnostics.Debug.WriteLine("Slowo: " + values[firstLanguageId] + ", tlumaczenie: " + values[secondLanguageId]);
                    (int, string, string) tuple = (Int32.Parse(values[0]), values[firstLanguageId], values[secondLanguageId]);
                    retList.Add(tuple);
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
                    if (Int32.Parse(values[0]) == phraseId) // jezeli jest to id to sie zapisuja sie linia do values
                    {
                        break;
                    }
                }
                reader.Close();
            }
            int pom = Int32.Parse(values[0]) - 1;
            values[firstLanguageId] = "";
            values[secondLanguageId] = "";

            for (int i = 0; i < values.Length; i++)
            {
                csv.Append(values[i] + ";");
            }

            List<string> lines2 = File.ReadAllLines("wordsForRepetition.csv").ToList();
            //  System.Diagnostics.Debug.WriteLine("Id frazy: " + pom);
            lines2.RemoveAt(pom);
            lines2.Insert(pom, csv.ToString());
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
                lines.RemoveAt(pom);
                lines.Insert(pom, csv.ToString());
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
