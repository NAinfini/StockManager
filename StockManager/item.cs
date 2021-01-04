using System;
using System.Collections;

namespace StockManager
{
    class item
    {

        public ArrayList allFields { get; }

        public item()
        {
            allFields = new ArrayList();
        }
        public ArrayList getAllFields()
        {
            return allFields;
        }
        public string addField(int value)
        {
            try
            {
                allFields.Add(value);
                return "added";
            }catch(Exception e)
            {
                return "something went wrong " + e.ToString();
            }
        }
        public string addField(string value)
        {
            try
            {
                allFields.Add(value);
                return "added";
            }
            catch (Exception e)
            {
                return "something went wrong " + e.ToString();
            }
        }
        public string addField(double value)
        {
            try
            {
                allFields.Add(value);
                return "added";
            }
            catch (Exception e)
            {
                return "something went wrong " + e.ToString();
            }
        }
        public string removeField(int index)
        {
            try
            {
                allFields.RemoveAt(index);
                return "removed";
            }catch(Exception e)
            {
                return "something went wrong " + e.ToString();
            }
        }
        public string removeField(string value)
        {
            try
            {
                allFields.Remove(value);
                return "removed";
            }
            catch (Exception e)
            {
                return "something went wrong " + e.ToString();
            }
        }


        public void set(int index, int value)
        {
            allFields[index] = value;
        }
        public void set(int index, string value)
        {
            allFields[index] = value;
        }
        public void set(int index, double value)
        {
            allFields[index] = value;
        }


        public void swap(int index1,int index2)
        {
            Object tempObj = allFields[index1];
            allFields[index1] = allFields[index2];
            allFields[index2] = tempObj;
        }
        public string toString()
        {
            string result = "";
            foreach(object value in allFields)
            {
                result = result + value.ToString() + ",";
            }
            result = result.Remove(result.Length - 1);
            return result;
        }

        public Boolean equal(item other)
        {
            for(int i=0;i < allFields.Count; i++)
            {
                if (!this.allFields[i].ToString().Equals(other.allFields[i].ToString()) )
                {
                    return false;
                }
            }
            return true;

        }
    }

}
