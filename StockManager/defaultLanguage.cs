using System;
using System.Collections.Generic;
using System.Text;

namespace StockManager
{

    public class defaultLanguage
    {
        //Global
        public static readonly string confirmBtn = "Confirm";


        //file read
        public static readonly string noFileOpened = "Please open a file first";

        //Item form
        public static readonly string ItemsBtn = "Item";
        public static readonly string searchItemBtn = "search Item";
        public static readonly string settingsBtn = "Settings";
        public static readonly string helpBtn = "Help";

        public static readonly string addItemBtn = "Add item";
        public static readonly string addFieldBtn = "Add field";
        public static readonly string saveBtn = "Save";
        public static readonly string openFileBtn = "Open";
        //dialog stuff for itemForm
        public static readonly string youEntered = "you entered: \"";
        public static readonly string asDialog = "\" as ";
        public static readonly string intoDialog = " into ";
        public static readonly string confirmationDialog = "Confirmaiton";

        //dialog stuff for dialogForm
        public static readonly string typeDialog = "Select data type";
        public static readonly string stringDialog = "string";
        public static readonly string intDialog = "Int";
        public static readonly string doubleDialog = "double";
        public static readonly string dialogDescription = "Enter the name of the field here and select data type:";
        public static readonly string sameName = "please enter a different name"; 
        public static readonly string emptyString = "please enter a name for the field";
        public static readonly string selectFromList = "pelase select a type form list";
    }
}
