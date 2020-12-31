using System;
using System.Collections;

namespace StockManager
{
    class item
    {

        ArrayList allFields = new ArrayList();

        public item(){}
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
        public string removeField(int value)
        {
            try
            {
                allFields.Remove(value);
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
    }

}
