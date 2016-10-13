using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Alchemist
{
    /*
     * This class houses the information on players as retrieved from
     * the database.
     */ 
    public class User
    {
        /*
         * Struct containing information relating to the high score of the user.
         * Public so that anyone can create a new UserHighestScoreInfo.
         */
        public struct UserHighestScoreInfo                                                                          
        {
            private int mHighestLevel;                                                                              // The highest level reached by the user
            private DateTime mHighestLevelDate;                                                                     // The date that the user reached the highest level

            public DateTime HighestLevelDate
            {
                get
                {
                    return mHighestLevelDate;
                }

                set
                {
                    mHighestLevelDate = value;
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
        }
        
        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ *
         *                         Attributes                              *
         * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
        private string mUserName;                                                                                   // The name of the user
        private string mUserPassword;                                                                               // The password of the user - in case we require to change or retrieve 
        private UserHighestScoreInfo mUserHighestScoreInfo;                                                         // Contains all the neccessary info pertaining to highest score

        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ *
         *                          Functions                              *
         * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
        public User() { }                                                                                           // Empty constructor if one wishes to set the attributes via properties

        public User(string userName, string userPassword, UserHighestScoreInfo highestScore)                        // Parameterised constructor - parameters are self-documenting
        {
            UserName = userName;
            UserPassword = userPassword;
            UserHighestScore = highestScore;
        }

        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ *
         *                          Properties                             *
         * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
        public string UserName
        {
            get
            {
                return mUserName;
            }

            set
            {
                mUserName = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return mUserPassword;
            }

            set
            {
                mUserPassword = value;
            }
        }

        public UserHighestScoreInfo UserHighestScore
        {
            get
            {
                return mUserHighestScoreInfo;
            }

            set
            {
                mUserHighestScoreInfo = value;
            }
        }
    }
}
