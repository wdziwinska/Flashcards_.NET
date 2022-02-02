using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Fiszki_projekt
{
    internal class RepetitionsDBImplementation : RepetitionsDBInterface
    {



        /*public List<(int, string, string)> getWordsForRepetition(int firstLanguageId, int secondLanguageId, int numberOfWordsToLearn)
        {
            (int, string, string) tuple = (0, "", "");
            using (var reader = new StreamReader(@"wordsForRepetition.csv"))
            {
              //  reader.ReadLine();
                int licznik = 0;
                var retList = new List<(int, string, string)>();
                while (!reader.EndOfStream && licznik< numberOfWordsToLearn)
                //while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(";");
                    // System.Diagnostics.Debug.WriteLine("Slowo: " + values[firstLanguageId] + ", tlumaczenie: " + values[secondLanguageId]);
                    if (isWordAddedToRepetitions(Int32.Parse(values[0]),firstLanguageId, secondLanguageId))
                    {
                        tuple = (Int32.Parse(values[0]), values[firstLanguageId], values[secondLanguageId]);
                        retList.Add(tuple);
                    }
                    licznik++; 
                }
                reader.Close();
                return retList;
            }
        }*/

        /*  public bool isWordAddedToRepetitions(int phraseId, int firstLanguageId, int secondLanguageId)
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
          }*/

        /* public void removeWord(int phraseId, int firstLanguageId, int secondLanguageId)
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
         }*/


        /* public void storeUnknownWord(int phraseId, int firstLanguageId, int secondLanguageId, string phraseInFirstLanguage, string phraseInSecondLanguage)
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
         }*/
        public string languageIdToName(int languageId)
        {
            switch (languageId)
            {
                case 1:
                    return "Polish";
                    break;
                case 2:
                    return "English";
                    break;
                case 3:
                    return "German";
                    break;
                case 4:
                    return "Russian";
                    break;
                case 5:
                    return "Italian";
                    break;
                case 6:
                    return "French";
                    break;
                default:
                    return "error";
            }

        }

        public List<(int, string, string)> getWordsForRepetition(int firstLanguageId, int secondLanguageId, int numberOfWordsToLearn,SqlConnection sqlCon)
        {
            var retList = new List<(int, string, string)>();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;

            sql = "Select * FROM dbo.wordsForRepetition";
            command = new SqlCommand(sql, sqlCon);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                //Output = Output + dataReader.GetValue(firstLanguageId) + " - " + dataReader.GetValue(secondLanguageId) + "\n";
                (int, string, string) tuple = ((int)dataReader.GetValue(0), (string)dataReader.GetValue(firstLanguageId), (string)dataReader.GetValue(secondLanguageId));
                retList.Add(tuple);
            }
            dataReader.Close();
            return retList;
        }

        public bool isWordAddedToRepetitions(int phraseId, int firstLanguageId, int secondLanguageId, SqlConnection sqlCon)
        {
            SqlCommand command;
            SqlDataReader dataReader;
            String sql;
            sql = "Select * FROM dbo.wordsForRepetition";
            command = new SqlCommand(sql, sqlCon);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if ((int)dataReader.GetValue(0) == phraseId)
                {
                    if ((string)dataReader.GetValue(firstLanguageId) != "" && (string)dataReader.GetValue(secondLanguageId) != "")
                    {
                       // System.Diagnostics.Debug.WriteLine("Slowo: " + (string)dataReader.GetValue(firstLanguageId) + ", tlumaczenie: " + (string)dataReader.GetValue(secondLanguageId));
                        return true;
                    }
                }

            }
            dataReader.Close();

            return false;
        }

        public void removeWord(int phraseId, int firstLanguageId, int secondLanguageId, SqlConnection sqlCon)
        {
            if (!isWordAddedToRepetitions(phraseId, firstLanguageId, secondLanguageId,sqlCon))
            {
                return;
            }
            SqlCommand command;
            SqlCommand command2;
            SqlDataReader dataReader;
            string firstLanguage = languageIdToName(firstLanguageId);
            string secondLanguage = languageIdToName(secondLanguageId);
            String sql;
            sql = String.Format("UPDATE dbo.wordsForRepetition SET {0} = '' WHERE phraseId = {1}", firstLanguage,phraseId);
            command = new SqlCommand(sql, sqlCon);
            command.ExecuteNonQuery();
            sql = String.Format("UPDATE dbo.wordsForRepetition SET {0} = '' WHERE phraseId = {1}", secondLanguage, phraseId);
            command2 = new SqlCommand(sql, sqlCon);
            command2.ExecuteNonQuery();
        }


        public void storeUnknownWord(int phraseId, int firstLanguageId, int secondLanguageId, string phraseInFirstLanguage, string phraseInSecondLanguage, SqlConnection sqlCon)
        {
            bool isInDB = false;
            int counter = 0;
            string firstLanguage = languageIdToName(firstLanguageId);
            string secondLanguage = languageIdToName(secondLanguageId);

            if (isWordAddedToRepetitions(phraseId, firstLanguageId, secondLanguageId, sqlCon))
            {
                return;
            }
            SqlCommand command;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql;

            sql = "Select * FROM dbo.wordsForRepetition";
            command = new SqlCommand(sql, sqlCon);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                counter++;
                if (phraseId == (int)dataReader.GetValue(0))
                {
                    isInDB = true;
                    break;
                }
            }
            dataReader.Close();

            if (isInDB)
            {
                sql = String.Format("UPDATE dbo.wordsForRepetition SET {0} = N'{1}' WHERE phraseId = {2}", firstLanguage, phraseInFirstLanguage, phraseId);
                SqlCommand command2 = new SqlCommand(sql, sqlCon);
                command2.ExecuteNonQuery();
                sql = String.Format("UPDATE dbo.wordsForRepetition SET {0} = N'{1}' WHERE phraseId = {2}", secondLanguage, phraseInSecondLanguage, phraseId);
                SqlCommand command3 = new SqlCommand(sql, sqlCon);
                command3.ExecuteNonQuery();
            }
            else
            {
                sql = String.Format("INSERT INTO dbo.wordsForRepetition (phraseID,{0},{1}) VALUES ({2},N'{3}',N'{4}')", firstLanguage, secondLanguage, phraseId, phraseInFirstLanguage, phraseInSecondLanguage);
                SqlCommand command4 = new SqlCommand(sql, sqlCon);
               // System.Diagnostics.Debug.WriteLine(sql);
                command4.ExecuteNonQuery();
            }
        }
    }
}
