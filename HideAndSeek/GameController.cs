using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class GameController
    {
        /// <summary>
        /// The player's current location in the house
        /// </summary>
        public Location CurrentLocation { get; private set; }
        /// <summary>
        /// Returns the the current status to show to the player
        /// </summary>
        public string Status{ get {string result="";
            foreach (string dir in CurrentLocation.ExitList)
            {
                result =result +Environment.NewLine+ dir;
            }

            return "You are in the " + CurrentLocation + ". You see the following exits:" +result; } } 

        
             
        
            //        +(string.Join(Environment.NewLine,
            //from loc in CurrentLocation.ExitList
            //select loc + Environment.NewLine + loc))
            
        //from loc in CurrentLocation.ExitList select loc.;
        /// <summary>
        /// A prompt to display to the player
        /// </summary>
        public string Prompt => "Which direction do you want to go: ";
        public GameController()
        {

            CurrentLocation = House.Entry;
        }
        /// <summary>
        /// Move to the location in a direction
        /// </summary>
        /// <param name="direction">The direction to move</param>
        /// <returns>True if the player can move in that direction, false oterwise</returns>
        public bool Move(Direction direction)
        {
            if (CurrentLocation.Exits.ContainsKey(direction))
            {
                CurrentLocation=CurrentLocation.GetExit(direction);
                return true;
            }
            else
                return false;

        }
        /// <summary>
        /// Parses input from the player and updates the status
        /// </summary>
        /// <param name="input">Input to parse</param>
        /// <returns>The results of parsing the input</returns>
        public string ParseInput(string input)
        {
            if (Enum.TryParse(input, out Direction result))
            {

                if (CurrentLocation.Exits.ContainsKey(result)){
                    CurrentLocation = CurrentLocation.GetExit(result);
                    //string youSee=""; 
                    //foreach(string loc in CurrentLocation.ExitList)
                    //{
                    //    youSee =loc+( Environment.NewLine + "the " + loc);
                    //}

                    return "Moving " + result
                        //+ Environment.NewLine +
                        //"You are in the Hallway. You see the following exits:" + youSee
                       

                        ;
                }
                else return "There's no exit in that direction";
            }
            else { return "That's not a valid direction"; }
            
            return CurrentLocation.ToString();
        }
    }
}
