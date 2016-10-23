using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace The_Alchemist
{
    /*
     * 
     *  Responsible for reading and wrtiting to user-settings.xml.
     *  As a result it will get and set the various user settings
     *  
     */
    public class UserSettings
    {
        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ *
         *                         Attributes                              *
         * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
        private const string userSettingsFilename = "user-settings.xml";                                                        // The xml file to read user settings from and write settings to

        private CharacterType mUserCharacterType;                                                                               // The type of character according to user settings
        private int mCurrentLevel;                                                                                              // The level the user was last on before exitting
        private int mHighestLevel;                                                                                              // The highest level the user has achieved    
        private string mUsername;                                                                                               // The user's username
        private Theme mTheme;                                                                                                   // The theme as selected by the user        

        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ *
         *                          Functions                              *
         * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

        /*
         * Initialises object by reading from the user settings xml file
         */
        public UserSettings()
        {
            readSettings();
        }

        /*
         * Write the settings to the xml file upon destruction of the object
         */
        ~UserSettings()
        {
            writeSettings();
        }

        /*
         * Opens the file specified by userSettingsFilename, reads through
         * the file and initialises the required attributes.
         */
        private void readSettings()
        {
            XmlDocument userSettingsDocument = new XmlDocument();                                                               // Create new xml document object
            userSettingsDocument.Load(userSettingsFilename);                                                                    // Load the document based on userSettingsFilename string

            Username = userSettingsDocument.SelectSingleNode("user-settings/username").InnerText;
            UserCharacterType =  getCharacterType(userSettingsDocument.SelectSingleNode("user-settings/character").InnerText);
            UserTheme = getTheme(userSettingsDocument.SelectSingleNode("user-settings/user-theme").InnerText);
            CurrentLevel = getLevel(userSettingsDocument.SelectSingleNode("user-settings/current-level").InnerText);
            HighestLevel = getLevel(userSettingsDocument.SelectSingleNode("user-settings/highest-level").InnerText);

        }

        /*
         * Determines the character type based on input string
         * and returns a valid character type
         */
        private CharacterType getCharacterType(string characterTypeString)
        {
            switch (characterTypeString)
            {
                case "Earth":
                    return CharacterType.Earth;

                case "Fire":
                    return CharacterType.Fire;

                case "Water":
                    return CharacterType.Water;

                case "Wind":
                    return CharacterType.Wind;

                default:
                    return CharacterType.Earth;                                                                             // Return a default value if something went wrong
            }
        }

        /*
         * Converts a string to an int in the case of retrieving the user's
         * current level and highest level from the xml file.
         */
        private int getLevel(string levelString)
        {
            try
            {
                return Convert.ToInt32(levelString);                                                                        // Attempt to convert the string to int and return it
            }

            catch (Exception)
            {
                return 0;                                                                                                   // If something went wrong return the default value of 0
            }
        }

        /*
         * Determines the theme based on input string
         * and returns a valid theme
         */
        private Theme getTheme(string theme)
        {
            switch (theme)
            {
                case "Ice":
                    return Theme.Ice;

                case "Fire":
                    return Theme.Fire;

                default:
                    return Theme.Ice;                                                                                        // Return a default value if something went wrong
            }
        }

        /*
         * Converts the character type passed as a parameter to a string.
         */
        private string placeCharacterType(CharacterType characterType)
        {
            switch (characterType)
            {
                case CharacterType.Earth:
                    return "Earth";

                case CharacterType.Fire:
                    return "Fire";

                case CharacterType.Water:
                    return "Water";

                case CharacterType.Wind:
                    return "Wind";

                default:
                    return "Earth";                                                                                         // Return a default value if something went wrong
            }
        }

        /*
         * Converts the theme passed as a parameter to a string.
         */
        private string placeTheme(Theme theme)
        {
            switch (theme)
            {
                case Theme.Ice:
                    return "Ice";

                case Theme.Fire:
                    return "Fire";

                default:
                    return "Ice";                                                                                           // Return a default value if something went wrong
            }
        }

        /*
         * Writes the settings currently in the object out to the xml file
         * specified in the userSettingsFilename string.
         */
        private void writeSettings()
        {
            XmlDocument userSettingsDocument = new XmlDocument();                                                           // Create new xml document object
            userSettingsDocument.Load(userSettingsFilename);                                                                // Load the document based on userSettingsFilename string

            userSettingsDocument.SelectSingleNode("user-settings/username").InnerText = Username;
            userSettingsDocument.SelectSingleNode("user-settings/character")
                .InnerText = placeCharacterType(UserCharacterType);
            userSettingsDocument.SelectSingleNode("user-settings/user-theme").InnerText = placeTheme(UserTheme);
            userSettingsDocument.SelectSingleNode("user-settings/current-level").InnerText = CurrentLevel.ToString();
            userSettingsDocument.SelectSingleNode("user-settings/highest-level").InnerText = HighestLevel.ToString();

            userSettingsDocument.Save(userSettingsFilename);                                                                // Save the user settings to the actual xml document
        }

        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ *
         *                        Properties                               *
         * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
        public CharacterType UserCharacterType
        {
            get
            {
                return mUserCharacterType;
            }

            set
            {
                mUserCharacterType = value;
            }
        }

        public int CurrentLevel
        {
            get
            {
                return mCurrentLevel;
            }

            set
            {
                mCurrentLevel = value;
            }
        }

        public string Username
        {
            get
            {
                return mUsername;
            }

            set
            {
                mUsername = value;
            }
        }

        public int HighestLevel
        {
            get
            {
                return mHighestLevel;
            }

            set
            {
                mHighestLevel = value;
            }
        }

        public Theme UserTheme
        {
            get
            {
                return mTheme;
            }

            set
            {
                mTheme = value;
            }
        }
    }
}
