using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO;

namespace Fiszki_projekt
{
    internal class PhrasesDBImplementation : PhrasesDBInterface
    {
        public int getRecordsCount()
        {
            throw new NotImplementedException();
        }



       public List<(int,string,string)> getWord(int phraseId, int firstLanguageId, int secondLanguageId, int numberOfWordsToLearn)
        {
        
            using (var reader = new StreamReader(@"BazaSlowek.csv"))
            {
                reader.ReadLine();
                int licznik = 0;
                var retList = new List<(int,string,string)>();
                while (!reader.EndOfStream && licznik<numberOfWordsToLearn)
                //while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(";");
                    System.Diagnostics.Debug.WriteLine("Slowo: " + values[firstLanguageId] + ", tlumaczenie: " + values[secondLanguageId]);
                    (int,string,string) tuple = (Int32.Parse(values[0]), values[firstLanguageId], values[secondLanguageId]);
                    retList.Add(tuple);
                    licznik++; 
                }
                reader.Close();
                return retList;
            }

        }
    }
}
