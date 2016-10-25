using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Alchemist
{
    public class Globals
    {
        public static User loggedInUser = null;
        public static string DBConn = "Data Source=localhost;Initial Catalog=ALCHEMIST;Integrated Security=True";
        public static UserSettings userSettings = UserSettings.Settings;
        public static AlchemistGame game;
        public static System.Media.SoundPlayer player = new System.Media.SoundPlayer();
    }
}
