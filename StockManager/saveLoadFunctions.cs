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

        public void writeToFile(string directory,string fileName,string content)
        {
            
            try
            {
                File.WriteAllText(Path.Combine(directory, fileName), content);
            }
            catch (DirectoryNotFoundException)
            {
                createDirectory(directory);
                File.WriteAllText(Path.Combine(directory, fileName), content);
            }
            
        }

        private void createDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
        }
        
        

        //remove extra files up on user exiting application
        public void sortFiles(string directory)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(directory);
            List<long> tempList = new List<long>();
            foreach (FileInfo file in di.GetFiles()) 
            {
                try
                {
                    tempList.Add(long.Parse(file.Name.ToString().Replace("-", "").Replace(".txt", "")));
                }
                catch(FormatException)
                {
                    throw new FormatException("format wrong");
                }
                
            }
            tempList.Sort();
            foreach(FileInfo file in di.GetFiles())
            {
                if (tempList.Count > 0)
                {
                    if (!file.Name.ToString().Replace("-", "").Replace(".txt", "").Equals(tempList[tempList.Count - 1].ToString()))
                    {
                        file.Delete();
                    }
                }
                
            }
        }


        //sort out saves in a day by hours minutes
        public void sortSavedTxt(string directory)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(directory);
            List<long> tempList = new List<long>();
            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    tempList.Add(long.Parse(file.Name.ToString().Replace("-", "").Replace(".txt", "")));
                }
                catch (FormatException)
                {
                    throw new FormatException("format wrong");
                }

            }
            
            if (tempList.Count > 50)
            {
                tempList.Sort();
                tempList.RemoveRange(tempList.Count - 51, 50);
                foreach (FileInfo file in di.GetFiles())
                {
                    
                    foreach (long tempLong in tempList)
                    {
                        if (file.Name.ToString().Replace("-", "").Replace(".txt", "").Equals(tempLong.ToString()))
                        {
                            file.Delete();
                            break;
                        }
                    }


                }
            }
            
            
        }

        //sort out directory of days, keep only 30 days of data
        public void sortDirectory(string directory)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(directory);
            List<long> tempList = new List<long>();
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    tempList.Add(long.Parse(dir.Name.ToString().Replace("-", "").Replace("_", "")));
                }
                catch (FormatException)
                {
                    throw new FormatException("format wrong");
                }

            }

            if (tempList.Count > 30)
            {
                tempList.Sort();
                tempList.RemoveRange(tempList.Count - 31, 30);
                foreach (DirectoryInfo dir in di.GetDirectories())
                {

                    foreach (long tempLong in tempList)
                    {
                        if (dir.Name.ToString().Replace("-", "").Replace("_", "").Equals(tempLong.ToString()))
                        {
                            foreach (FileInfo file in dir.GetFiles())
                            {
                                file.Delete();
                            }
                            dir.Delete();
                            break;
                        }
                    }

                }
            }
        }

        public string findLatestDirc(string directory)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(directory);
            List<long> tempList = new List<long>();
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    tempList.Add(long.Parse(dir.Name.ToString().Replace("-", "").Replace("_", "")));
                }
                catch (FormatException)
                {
                    throw new FormatException("format wrong");
                }

            }

            if (tempList.Count >= 1)
            {
                tempList.Sort();
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    if (dir.Name.ToString().Replace("-", "").Replace("_", "").Equals(tempList[tempList.Count-1].ToString()))
                    {
                        if (dir.GetFiles().Length >= 1)
                        {
                            return directory +"\\" +dir.Name.ToString();
                        }
                        
                    }

                }
            }
            return "";
        }
        public string findLastTxt(string directory)
        {
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(directory);
                List<long> tempList = new List<long>();
                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        tempList.Add(long.Parse(file.Name.ToString().Replace("-", "").Replace(".txt", "")));
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("format wrong");
                    }

                }
                if (tempList.Count >= 1)
                {
                    tempList.Sort();
                    foreach (FileInfo file in di.GetFiles())
                    {

                        if (file.Name.ToString().Replace("-", "").Replace(".txt", "").Equals(tempList[tempList.Count - 1].ToString()))
                        {
                            return directory + "\\" + file.Name.ToString();
                        }


                    }
                }
                return "";
            }
            catch (ArgumentException)
            {

            }
            return "";
            
            
            
        }

        //read user prefernce from file
        public void readFromFile()
        {


        }

        //turn all settings to string
        private string settingsToString()
        {
            string result = "";
            result = result + language + "\n";

            return result;

        }

        //turn all string in file to settings

        private void StringToSettings()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\" + "save.txt");
                language = lines[0];
            }
            catch(Exception)
            {
                language = "english";
            }
            
            
        }
    }
}
