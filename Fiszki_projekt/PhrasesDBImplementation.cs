using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO;

namespace Fiszki_projekt
{
    internal class PhrasesDBImplementation
    {
        public int getRecordsCount()
        {
            throw new NotImplementedException();
        }



       public List<(string,string)> getWord(int phraseId, int firstLanguageId, int secondLangueId)
        {
            // <1,pies,dog> ---- <2,kot,cat> ------ <3,kiedy,when>
            using (var reader = new StreamReader(@"BazaSlowek.csv"))
            {
                reader.ReadLine();
                //int licznik = 0;
                var retList = new List<(string,string)>();
                //while (!reader.EndOfStream && licznik<10)
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(";");
                    //System.Diagnostics.Debug.WriteLine("Slowo: " + values[firstLanguageId] + ", tlumaczenie: " + values[secondLangueId]);
                    (string,string) tuple = (values[firstLanguageId], values[secondLangueId]);
                    retList.Add(tuple);
                    //licznik++; 
                }
                reader.Close();
                return retList;
            }

        }
    }
}
