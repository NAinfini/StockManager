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
        List<Type> typeOfField = new List<Type>();
        List<string> nameOfField = new List<string>();
        List<item> items = new List<item>();



        public itemList() { }
        public List<Type> getType()
        {
            return typeOfField;
        }
        public List<string> getName()
        {
            return nameOfField;
        }
        public List<item> getItems()
        {
            return items;
        }
        public void addName(Type type, string name)
        {
            if (nameOfField.Count != 0)
            {
                if (nameOfField.Contains(name))
                {
                    throw new DuplicateNameException(defaultLanguage.sameName);
                }
            }
            typeOfField.Add(type);
            nameOfField.Add(name);

        }

        //remove an item based on its name
        public void removeName(string name)
        {
            if (!nameOfField.Contains(name))
            {
                throw new ArgumentNullException("ItemDoesntExist");
            }
            foreach (item tempItem in items)
            {
                tempItem.removeField(nameOfField.IndexOf(name));
            }
            typeOfField.RemoveAt(nameOfField.IndexOf(name));
            nameOfField.Remove(name);
        }

        //add item to the end of the list
        public void addItem(item value)
        {
            items.Add(value);
        }


        //spaws the positon of any two names. also for all items
        public void swap(int index1,int index2)
        {
            Type tempType = typeOfField[index1];
            typeOfField[index1] = typeOfField[index2];
            typeOfField[index2] = tempType;
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
                string[] types = lines[0].Replace(" ", "").Split(',');
                string[] names = lines[1].Replace(" ", "").Split(',');
                if (names.Length != types.Length)
                {
                    return;
                    //something is wrong with save file number of fields doesnt match
                }
                //loading into types and names
                for(int i = 0; i < types.Length;i++)
                {
                    typeOfField.Add(Type.GetType(types[i]));
                    nameOfField.Add(names[i]);
                }
                //loading items aiwth their fields then into list
                for (int i = 2; i < lines.Length; i++)
                {
                    item tempItem = new item();
                    string[] itemValues = lines[i].Replace(" ", "").Split(',');
                    for(int j = 0; j < itemValues.Length; j++)
                    {
                        dynamic value3 = Convert.ChangeType(itemValues[j], Type.GetType(types[j]));
                        tempItem.addField(value3);
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
            }
            
        }


        //simple method to turn itemlist into a stin
        public string toString()
        {
            try
            {
                string result = "";

                foreach(Type temp in typeOfField)
                {
                    result = result + temp.ToString() + ",";
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
