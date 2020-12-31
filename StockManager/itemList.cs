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


        public void loadFile(string fileName)
        {
            try
            {

                var path = Path.Combine(Directory.GetCurrentDirectory(), "\\test.txt");
                string filepath = @"C:\Users\NA infini\source\repos\StockManager\test.txt";
                string[] lines = File.ReadAllLines(path);
                string[] types = lines[0].Replace(" ", "").Split(',');
                string[] names = lines[1].Replace(" ", "").Split(',');
                if (names.Length != types.Length)
                {
                    return;
                    //something is wrong with save file number of fields doesnt match
                }
                foreach (string itemName in names)
                {
                    Type myType = Type.GetType(types[Array.FindIndex(names, x => x.Contains(itemName))]);
                    nameOfField.Add(itemName);
                    typeOfField.Add(myType);
                }
                for (int i = 2; i < lines.Length; i++)
                {
                    item tempItem = new item();
                    string[] itemValues = lines[i].Replace(" ", "").Split(',');
                    for(int j = 0; j < itemValues.Length; j++)
                    {
                        if (types[j] == "string")
                        {
                            tempItem.addField(itemValues[j]);
                        }else if(types[j] == "int")
                        {
                            tempItem.addField(Int32.Parse(itemValues[j]));
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
        public void saveFile(string name)
        {

        }
    }

}
