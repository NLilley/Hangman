using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hangman
{
    /// <summary>
    /// This class parses the "usersettings.xml" file and extracts the user settings.
    /// It also rewrites this file when the user makes an alteration during runtime.
    /// </summary>
    static class UserSettings
    {

        static XmlReader Reader { get; set; }
        static XmlWriter Writer { get; set; }

        public static string Language { get; private set; }
        public static bool IsMuted { get; private set; }

        //Read the required settings from the file.
        public static void SetupSettings()
        {
            
            try
            {
                Reader = XmlReader.Create(@".\assets\usersettings.xml");

                while (Reader.Read())
                {
                    if (Reader.Name == "Language" && Reader.NodeType != XmlNodeType.EndElement)
                    {
                        Reader.Read();
                        Language = Reader.Value;
                    }

                    if (Reader.Name == "IsMuted" && Reader.NodeType != XmlNodeType.EndElement)
                    {
                        Reader.Read();
                        if (Reader.Value.ToLower() == "true")
                        {
                            IsMuted = true;
                            SharedAssets.IsMuted = true;
                        }
                        else
                        {
                            IsMuted = false;
                            SharedAssets.IsMuted = false;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem Reading usersettings.xml " + e.Message);
            }
            finally
            {
                Reader.Close();
            }

        }

        //Change the language of the application and then rewrite the usersettings.xml file.
        public static void SetLanguage(string NewLanguage)
        {
            Language = NewLanguage;
            WriteUserSettingsXML();

        }

        //Change the volume settings and then rewrite the usersettings.xml file.
        public static void SetIsMuted(bool isMuted)
        {
            SharedAssets.IsMuted = isMuted;
            IsMuted = isMuted;
            WriteUserSettingsXML();
        }

        //Write a new "usersettings.xml" file with the current user settings.
        private static void WriteUserSettingsXML()
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                Writer = XmlWriter.Create(@".\assets\usersettings.xml", settings);

                Writer.WriteStartDocument();
                Writer.WriteStartElement("UserSettings");
                Writer.WriteElementString("Language", Language);
                Writer.WriteElementString("IsMuted", IsMuted.ToString());
                Writer.WriteEndElement();
                Writer.WriteEndDocument();

                Writer.Flush();

            }
            catch (Exception e)
            {
                Console.WriteLine("Problem writing XML File: " + e.Message);
            }
            finally
            {
                Writer.Close();
            }

        }
    }
}
