using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace StockManager
{
    class itemList
    {
        #region instance,set get methods


        List<string> valveOfField = new List<string>();
        List<double> valueOfField = new List<double>();
        List<string> nameOfField = new List<string>();
        List<ArrayList> items = new List<ArrayList>();


        public itemList() { }
        public List<string> getName()
        {
            return nameOfField;
        }
        public List<ArrayList> getItems()
        {
            return items;
        }
        public List<string> getValve()
        {
            return valveOfField;
        }
        public List<double> getValue()
        {
            return valueOfField;
        }
        public void addName(string valve,double value,string name)
        {
            if (nameOfField.Contains(name))
            {
                throw new DuplicateNameException(defaultLanguage.sameName);
            }
            else
            {
                nameOfField.Add(name);
                valveOfField.Add(valve);
                valueOfField.Add(value);
            }
            

        }
        public void set(int fieldIndex, int itemIndex, double tempDou)
        {
            items[itemIndex][fieldIndex] = tempDou;
        }
        public void set(int fieldIndex, int itemIndex, string tempStr)
        {
            items[itemIndex][fieldIndex] = tempStr;
        }



        #endregion


        #region item list edits
        //remove a field based on its name
        public void removeName(string name)
        {
            if (!nameOfField.Contains(name))
            {
                throw new ArgumentNullException("ItemDoesntExist");
            }
            else
            {
                foreach (ArrayList tempItem in items)
                {
                    tempItem.RemoveAt(nameOfField.IndexOf(name));
                }
                valveOfField.RemoveAt(nameOfField.IndexOf(name));
                valueOfField.RemoveAt(nameOfField.IndexOf(name));
                nameOfField.Remove(name);
            }
            
        }
        //remove a field based on its index
        public void removeFieldAt(int index)
        { 
            foreach (ArrayList tempItem in items)
            {
                tempItem.RemoveAt(index);
            }
            try
            {
                nameOfField.RemoveAt(index);
                valveOfField.RemoveAt(index);
                valueOfField.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
                


        }
        //remove item form list by id
        public void removeItemAt(int id)
        {
            int toRemove = 0;
            foreach(ArrayList item in items)
            {
                if ((int)item[item.Count - 1] != id)
                {
                    toRemove++;
                }
                else
                {
                    break;
                }
            }
            items.RemoveAt(toRemove);
        }

        //add item to the end of the list
        public void addItem(ArrayList value)
        {
            items.Add(value);
        }

        //spaws the positon of any two names. also for all items
        public void swap(int index1,int index2)
        {
            double tempvalue = valueOfField[index1];
            valueOfField[index1] = valueOfField[index2];
            valueOfField[index2] = tempvalue;

            string tempvalve = valveOfField[index1];
            valveOfField[index1] = valveOfField[index2];
            valveOfField[index2] = tempvalve;

            string tempName = nameOfField[index1];
            nameOfField[index1] = nameOfField[index2];
            nameOfField[index2] = tempName;

            foreach(ArrayList itemInList in items)
            {
                object tempObj = itemInList[index1];
                itemInList[index1] = itemInList[index2];
                itemInList[index2] = tempObj;
            }
            
        }

        //load from txt file to itemlist
        public void loadFile(string fileName)
        {
            try
            {
                
                string[] lines = File.ReadAllLines(fileName);
                string[] valves = lines[0].Replace(" ", "").Split(',');
                string[] names = lines[1].Replace(" ", "").Split(',');
                //loading into types and names
                foreach (string valve in valves)
                {
                    valveOfField.Add(valve[0].ToString());
                    valueOfField.Add(Convert.ToDouble(valve.Substring(1)));
                }
                foreach(string name in names)
                {
                    nameOfField.Add(name);
                }
                //loading items aiwth their fields then into list
                for (int i = 2; i < lines.Length; i++)
                {
                    ArrayList tempItem = new ArrayList();
                    string[] itemValues = lines[i].Split(',');
                    for(int j = 0; j < itemValues.Length; j++)
                    {
                        tempItem.Add(itemValues[j]);
                    }
                    tempItem.Add(i-2);
                    items.Add(tempItem);
                }
            }catch(FileNotFoundException)
            {
                Console.WriteLine("file not found");
                return;
            }catch(DirectoryNotFoundException)
            {
                Console.WriteLine("directory not found");
            }catch(IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException(defaultLanguage.invalidFormat);
            }
            catch (FormatException)
            {
                Console.WriteLine("wrong format");
            }
        }

        #endregion

        //simple method to turn itemlist into a stin
        public string toString()
        {
            try
            {
                string result = "";
                for(int i = 0; i < valueOfField.Count; i++)
                {
                    result = result + valveOfField[i]+valueOfField[i].ToString() + ",";
                }
                result = result.Remove(result.Length - 1);
                result += "\n";
                foreach (string nameOfItem in nameOfField)
                {
                    result = result + nameOfItem + ",";
                }
                result = result.Remove(result.Length - 1);
                result += "\n";
                foreach (ArrayList idItem in items)
                {
                    for(int i = 0; i < nameOfField.Count; i++)
                    {
                        result = result + idItem[i].ToString() + ",";
                    }
                    result = result.Remove(result.Length - 1);
                    result += "\n";
                }
                
                return result;

            }
            catch (Exception e)
            {
                return "something went wrong" + e.ToString();
            }
            
        }
    }

}
