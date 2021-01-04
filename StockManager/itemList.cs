using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace StockManager
{
    class itemList
    {

        List<string> valveOfField = new List<string>();
        List<double> valueOfField = new List<double>();
        List<string> nameOfField = new List<string>();
        List<item> items = new List<item>();



        public itemList() { }
        public List<string> getName()
        {
            return nameOfField;
        }
        public List<item> getItems()
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

        //remove an item based on its name
        public void removeName(string name)
        {
            if (!nameOfField.Contains(name))
            {
                throw new ArgumentNullException("ItemDoesntExist");
            }
            else
            {
                foreach (item tempItem in items)
                {
                    tempItem.removeField(nameOfField.IndexOf(name));
                }
                nameOfField.Remove(name);
                valveOfField.RemoveAt(nameOfField.IndexOf(name));
            }
            
        }

        //add item to the end of the list
        public void addItem(item value)
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

            foreach(item itemInList in items)
            {
                itemInList.swap(index1, index2);
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
                    item tempItem = new item();
                    string[] itemValues = lines[i].Replace(" ", "").Split(',');
                    for(int j = 0; j < itemValues.Length; j++)
                    {
                        try
                        {
                            double value3 = Convert.ToDouble(itemValues[j]);
                            tempItem.addField(value3);
                        }
                        catch (FormatException e)
                        {
                            tempItem.addField(itemValues[j]);
                        }
                    }
                    items.Add(tempItem);
                }
            }catch(FileNotFoundException e)
            {
                Console.WriteLine("file not found");
                return;
            }catch(DirectoryNotFoundException e)
            {
                Console.WriteLine("directory not found");
            }catch(IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException(defaultLanguage.invalidFormat);
            }
            
        }


        public void removeItem(item toRemove)
        {
            
            for (int i =0;i<items.Count;i++)
            {
                if (items[i].equal(toRemove))
                {
                    items.RemoveAt(i);
                    return;
                }
            }
            throw new ArgumentNullException(defaultLanguage.itemNull);
        }

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
                foreach (item idItem in items)
                {
                    result = result + idItem.toString() + "\n";
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
