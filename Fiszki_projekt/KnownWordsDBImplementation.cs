using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

// 1 - Polski
// 2 - Angielski
// 3 - Niemiecki
// 4 - Rosyjski
// 5 - Wloski
// 6 - Francuski


namespace Fiszki_projekt
{
    internal class KnownWordsDBImplementation : KnownWordsDBInterface
    {
        public void storeKnownWord(int phraseId, int firstLanguageId, int secondLanguageId, string phraseInFirstLanguage, string phraseInSecondLanguage)
        {
            var csv = new StringBuilder();
            string pId = phraseId.ToString();
            string fId = firstLanguageId.ToString();
            string sId = secondLanguageId.ToString();
            bool isInDB = false; // wpierw trzeba sprawdzic czy dana fraza jest w bazie, zeby wiedziec czy dopisac jezyk, czy cala fraze
                                 // nie mozna uzyc funkcji isWordKnown poniewaz jeden z jezykow jest nowy

            int counter = -1;
            // jezeli slowko jest znane w obu jezykach to nic nie dopisuj
            string[] values = {""};
            if (isWordKnown(phraseId, firstLanguageId, secondLanguageId))
            {
                return;
            }

            using (var reader = new StreamReader(@"knownWordsDatabase.csv"))
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
                int pom = Int32.Parse(values[0])-1;
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
                    csv.Append(values[i]+";");
                } 
                List<string> lines = File.ReadAllLines("knownWordsDatabase.csv").ToList();
              //  System.Diagnostics.Debug.WriteLine("Id frazy: " + pom);
                lines.RemoveAt(counter);
                lines.Insert(counter,csv.ToString());
                lines.Sort();
                File.WriteAllLines("knownWordsDatabase.csv", lines.ToArray());

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
                File.AppendAllText("knownWordsDatabase.csv", csv.ToString());

            }
        }

        public bool isWordKnown(int phraseId, int firstLanguageId, int secondLanguageId)
        {
            using (var reader = new StreamReader(@"knownWordsDatabase.csv"))
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

    }
}
