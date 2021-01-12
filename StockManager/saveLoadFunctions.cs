using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace StockManager
{
    class saveLoadFunctions
    {
        public string language;

        #region file access


        //write to save.txt file to save user perfrences
        public void writeToFile(string directory,string time,string fileName,string content)
        {
            
            try
            {
                File.WriteAllText(Path.Combine(directory, time+fileName + ".txt"), content);
            }
            catch (DirectoryNotFoundException)
            {
                createDirectory(directory);
                File.WriteAllText(Path.Combine(directory, time+fileName + ".txt"), content);
            }
            
        }

        //read user prefernce from file
        public void readFromFile()
        {


        }

        //create directory when it doesnt exist
        private void createDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
        }


        #endregion


        #region sort files on save/close(also related methods)
        //remove extra files up on user exiting application
        public void sortFiles(string directory)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(directory);
            List<long> times = new List<long>();
            Dictionary<string, long> filesToKeep = new Dictionary<string, long>();
            foreach (FileInfo file in di.GetFiles()) 
            {
                string fileName = file.Name.Replace("-", "").Replace(".txt", "").Substring(6);
                try
                {
                    long timeFromName = long.Parse(file.Name.Replace("-", "").Substring(0, 5));
                    long timeInDic;
                    if (filesToKeep.TryGetValue(fileName, out timeInDic))
                    {
                        if (timeInDic < timeFromName)
                        {
                            filesToKeep[fileName] = timeFromName;
                            file.Delete();
                        }
                    }
                    else
                    {
                        filesToKeep.Add(fileName, timeFromName);
                    }
                }
                catch (FormatException)
                {
                    throw new FormatException("format wrong");
                }
            }
        }

        //sort out saves in a day by hours minutes
        public void sortSavedTxt(string directory)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(directory);
            Dictionary<string, List<string>> filesToSave = new Dictionary<string, List<string>>();
            
            foreach (FileInfo file in di.GetFiles())
            {
                List<string> tempList = new List<string>();
                string nameOfFile = Regex.Replace(file.Name.Replace(".txt", "").Replace("-", ""), @"[\d-]", string.Empty);
                try
                {
                    long timeFromFile = long.Parse(file.Name.Replace("-", "").Substring(0, 5));
                    if (filesToSave.TryGetValue(nameOfFile, out tempList))
                    {
                        tempList.Add(file.Name.Substring(0,8));
                        if (tempList.Count > 50)
                        {
                            tempList.Sort();
                            tempList.RemoveRange(0, tempList.Count - 50);
                        }
                    }
                    else
                    {
                        tempList = new List<string>();
                        tempList.Add(file.Name.Substring(0, 8));
                        filesToSave.Add(nameOfFile, tempList);
                    }
                }
                catch (FormatException)
                {

                }
                
            }
            List<string> templil = new List<string>();
            foreach (string name in filesToSave.Keys)
            {
                List<string> templia = new List<string>();
                if (filesToSave.TryGetValue(name, out templia))
                {
                    foreach (string time in templia)
                    {
                        string tempStr = time + name + ".txt";
                        templil.Add(tempStr);
                    }
                }
            }
            foreach (FileInfo file in di.GetFiles())
            {
                if (!templil.Contains(file.Name))
                {
                    file.Delete();
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

            if (tempList.Count > 5)
            {
                tempList.Sort();
                tempList.RemoveRange(0, tempList.Count - 5);
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

        //return a string of the last directory of the given one
        public string findLatestDirc(string directory)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(directory);
            string lastDir = di.GetDirectories()[0].Name;
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    long tempLong = long.Parse(dir.Name.Replace("-", ""));
                    if (tempLong > long.Parse(lastDir.Replace("-", "")))
                    {
                        lastDir = dir.Name;
                    }
                }
                catch (FormatException)
                {
                    throw new FormatException("format wrong");
                }

            }
            return lastDir+"\\";
        }

        //return a string of the last txt file of the gien directory
        public string findLastTxt(string directory)
        {
            string lastTxt;
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(directory);
                lastTxt = di.GetFiles()[0].Name;
                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        long tempLong = long.Parse(file.Name.ToString().Replace("-", "").Substring(0,5));
                        if(tempLong>long.Parse(lastTxt.Replace("-", "").Substring(0, 5)))
                        {
                            lastTxt = file.Name;
                        }
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("format wrong");
                    }

                }
                return lastTxt;
            }
            catch (ArgumentException)
            {
                return "";
            }
            
            
            
            
        }

        #endregion


        #region setting access


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


        #endregion
    }
}
