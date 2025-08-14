using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HideAndSeek
{
    public class GameController
    {
        public readonly IEnumerable<Opponent> Opponents = new List<Opponent>()
            {
             new Opponent("Joe"),
             new Opponent("Bob"),
             new Opponent("Ana"),
             new Opponent("Owen"),
             new Opponent("Jimmy"),
            };

        /// <summary>
        /// Private list of opponents the player has found so far
        /// </summary>
        private readonly List<Opponent> foundOpponents = new List<Opponent>();
        /// <summary>
        /// Returns true if the game is over
        /// </summary>
        public bool GameOver => Opponents.Count() == foundOpponents.Count();

        /// <summary>
        /// The number of moves the player has made
        /// </summary>
        public int MoveNumber { get; private set; } = 1;

        /// <summary>
        /// The player's current location in the house
        /// </summary>
        public Location CurrentLocation { get; private set; }
        /// <summary>
        /// Returns the the current status to show to the player
        /// </summary>
        public string Status
        { get 
            {
            string result="";
            foreach (string dir in CurrentLocation.ExitList)
                {
                result =result +Environment.NewLine+ dir;
                }
                string founded = "You have not found any opponents";
                string hasHidingPlace = "";
                if (CurrentLocation.GetType() == typeof(LocationWithHidingPlace))

                {
                    var CL = CurrentLocation as LocationWithHidingPlace;

                    hasHidingPlace = $"Someone could hide {CL.HidingPlace.ToString()}" + Environment.NewLine;

                    //foundOpponents.Concat(CL.CheckHidingPlace());

                    if (foundOpponents.Count > 0)
                    {
                        
                        
                        founded = $"You have found {foundOpponents.Count} of 5 opponents: " +
                            $"{string.Join(", ", foundOpponents)}";

                    }
                   
                }

            result ="You are in the " + CurrentLocation +
                    ". You see the following exits:" 
                    +result+Environment.NewLine+ hasHidingPlace+
                    founded;

                return result;
            }
        }
      
        /// <summary>
        /// A prompt to display to the player
        /// </summary>
        public string Prompt => $"{MoveNumber}: Which direction do you want to go (or type 'check'): ";
        public GameController()
        {
            House.ClearHidingPlaces();
            foreach (var opponent in Opponents)
                opponent.Hide();
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
            if (!string.IsNullOrEmpty(input))
            {
                
                 input = char.ToUpper(input[0]) + input.Substring(1);
                
            }

            if (Enum.TryParse(input, out Direction result))
            {

                if (CurrentLocation.Exits.ContainsKey(result)){
                    CurrentLocation = CurrentLocation.GetExit(result);
          
                    MoveNumber++;
                    return "Moving " + result
 
                        ;
                }
                else return "There's no exit in that direction";
            }
            else {
                if (input=="Check")
                { 
                    MoveNumber++;
                    if(CurrentLocation.GetType() == typeof(LocationWithHidingPlace))
                    
                    {
                        var CL = CurrentLocation as LocationWithHidingPlace;
 //var check = CL.CheckHidingPlace();
 var count = 0;
                        foreach(Opponent opponent in  CL.CheckHidingPlace() )

                        {
                            count++; 
                            foundOpponents.Add(opponent);
                        
                        }
                        if (count > 0) return $"You found {count} opponent{s(count)} hiding {CL.HidingPlace.ToString()}";
                        else return $"Nobody was hiding { CL.HidingPlace.ToString()}";


                    }
                    else {return $"There is no hiding place in the {CurrentLocation.Name}"; }
                }
                else  return "That's not a valid direction"; 
         
            }
          
             
        }
        public string s(int cou) { if (cou > 1) return "s"; else return ""; }

    }
    /// <summary>
    /// Private list of opponents the player needs to find
    /// </summary>
    
}
