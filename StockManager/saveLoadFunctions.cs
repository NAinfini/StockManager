using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockManager
{
    class saveLoadFunctions
    {
        public string language;


        //write to save.txt file to save user perfrences


        public void writeToFile()
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "save.txt", setToString());
        }

        //read user prefernce from file

        public void readFromFile()
        {


        }

        //turn all settings to string

        private string setToString()
        {
            string result = "";
            result = result + language + "\n";

            return result;

        }

        //turn all string in file to settings

        private void StringToSet()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\" + "save.txt");
                language = lines[0];
            }
            catch(Exception e)
            {
                language = "english";
            }
            
            
        }
    }
}
