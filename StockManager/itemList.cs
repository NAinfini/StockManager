using System;
using System.Collections.Generic;
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
        public string addName(Type type, string name)
        {
            if (nameOfField.Count != 0)
            {
                if (nameOfField.Contains(name))
                {
                    return "name exists";
                }
            }
            typeOfField.Add(type);
            nameOfField.Add(name);
            return "added";

        }
        public string removeName(string name)
        {
            if (!nameOfField.Contains(name))
            {
                return "name of field doesnt exist";
            }
            typeOfField.RemoveAt(nameOfField.IndexOf(name));
            nameOfField.Remove(name);
            return "removed";
        }
        public void addItem(item value)
        {
            items.Add(value);
        }

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
                foreach(string type in types)
                {
                    typeOfField.Add(Type.GetType(type));
                }
                foreach (string itemName in names)
                {
                    nameOfField.Add(itemName);
                }
                for (int i = 2; i < lines.Length; i++)
                {
                    item tempItem = new item();
                    string[] itemValues = lines[i].Replace(" ", "").Split(',');
                    for(int j = 0; j < itemValues.Length; j++)
                    {
                        if (types[j].Equals("System.String"))
                        {
                            tempItem.addField(itemValues[j]);
                        }else if(types[j].Equals("System.Int32"))
                        {
                            tempItem.addField(Int32.Parse(itemValues[j]));
                        }else if (types[j].Equals("System.Double"))
                        {
                            tempItem.addField(Convert.ToDouble(itemValues[j]));
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
            }
            
        }

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
