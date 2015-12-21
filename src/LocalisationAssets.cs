using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hangman
{
    /// <summary>
    /// This class provides a means to have localised assets appear in the game.
    /// These assets are extracted from the "lang.xml" file where they match the 
    /// users language choice in the UserSettings static class.
    /// </summary>
    static class LocalisationAssets
    {
        //Used to store the available languages from which the user can choose.
        public static List<string> Languages;

        //locations for specific word dictionaries.
        public static string EasyDictionary { get; set; }
        public static string MediumDictionary { get; set; }
        public static string HardDictionary { get; set; }

        //Appropriate characters for the language being used.
        public static string CharacterSet { get; set; }

        //The strings which will be used in Buttons, etc.
        public static string EasyString { get; set; }
        public static string MediumString { get; set; }
        public static string HardString { get; set; }
        public static string OptionsString { get; set; }
        public static string MenuString { get; set; }
        public static string CreditsString { get; set; }
        public static string ReplayString { get; set; }
        public static string YouWinString { get; set; }
        public static string YouLoseString { get; set; }
        public static string MuteString { get; set; }

        static LocalisationAssets()
        {
            Languages = new List<string>();
        }

        public static void ReadAssets()
        {

            try
            {
                XmlReader Reader = XmlReader.Create(@".\assets\lang.xml");

                /*
                 * The following chunk of code parses every part of the lang.xml document and 
                 * extracts the relevant data from it.  It begins extraction when it finds the 
                 * xml element with the same name as the language the user has selected and then
                 * sifts throught the nodes to obtain the necessary information.
                */
                while (Reader.Read())
                {
                    //Check if the given element is a language element.
                    if (Reader.Name == "Language")
                    {
                        //Add each language to the languages list
                        string languageName = Reader.GetAttribute("Name");
                        if (Reader.NodeType != XmlNodeType.EndElement)
                        {
                            Languages.Add(languageName);
                        }

                        //If the language currently being parsed is the users choice language, then start extracting data.
                        if (languageName == UserSettings.Language)
                        {
                            //Keep reading nodes until we find the closing node (which will have the same name as the first).
                            while (Reader.Read() && Reader.Name != "Language")
                            {
                                //Check to see if the node contains data we want.
                                //If so, jump to the content and read it.
                                //The !=XmlNodeType.EndElement prevents the node being checked twice.
                                if (Reader.Name == "EasyDictionary" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    EasyDictionary = Reader.Value;
                                }
                                else if (Reader.Name == "MediumDictionary" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    MediumDictionary = Reader.Value;

                                }
                                else if (Reader.Name == "HardDictionary" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    HardDictionary = Reader.Value;
                                }
                                else if (Reader.Name == "CharacterSet" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    CharacterSet = Reader.Value;
                                }
                                else if (Reader.Name == "EasyString" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    EasyString = Reader.Value;
                                }
                                else if (Reader.Name == "MediumString" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    MediumString = Reader.Value;
                                }
                                else if (Reader.Name == "HardString" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    HardString = Reader.Value;
                                }
                                else if (Reader.Name == "OptionsString" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    OptionsString = Reader.Value;
                                }
                                else if (Reader.Name == "MenuString" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    MenuString = Reader.Value;
                                }
                                else if (Reader.Name == "ReplayString" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    ReplayString = Reader.Value;
                                }
                                else if (Reader.Name == "YouWinString" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    YouWinString = Reader.Value;
                                }
                                else if (Reader.Name == "YouLoseString" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    YouLoseString = Reader.Value;
                                }
                                else if (Reader.Name == "CreditsString" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    CreditsString = Reader.Value;
                                }
                                else if (Reader.Name == "MuteString" && Reader.NodeType != XmlNodeType.EndElement)
                                {
                                    Reader.Read();
                                    MuteString = Reader.Value;
                                }

                            }
                        }
                    }
                }

                Reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem reading locaisation assets: " + e.Message);
            }

        }

    }
}
