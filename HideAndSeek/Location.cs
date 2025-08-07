using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class Location
    {
        /// <summary>
        /// The name of this location
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// The exits out of this location
        /// </summary>
        public IDictionary<Direction, Location> Exits { get; private set; }
        = new Dictionary<Direction, Location>();
        
        /// <summary>
        /// The constructor sets the location name
        /// </summary>
        /// <param name="name">Name of the location</param>
        public Location(string name) => this.Name =name;// конструктор
        public override string ToString() => Name;
        /// <summary>
        /// Returns a sequence of descriptions of the exits, sorted by direction
        /// </summary>
        public IEnumerable<string> ExitList => Exits
            .OrderBy(keyValuePair => (int)keyValuePair.Key)
            .OrderBy(keyValuePair => Math.Abs((int)keyValuePair.Key))
            .Select(keyValuePair => $" - the {keyValuePair.Value} is {DescribeDirection(keyValuePair.Key)}");

        //from exit in Exits
        //                                   orderby exit.Key
        //                                   select " - the " + exit.Value.ToString()
        //                                   + " is "+ DescribeDirection(exit.Key) ;
        /// <summary>
        /// Adds an exit to this location
        /// </summary>
        /// <param name="direction">Direction of the connecting location</param>
        /// <param name="connectingLocation">Connecting location to add</param>
        public void AddExit(Direction direction, Location connectingLocation)
        {
            Exits.Add((Direction)((int)direction), connectingLocation);
            connectingLocation. AddReturnExit(direction, this);
            if(!House._locations.ContainsKey(connectingLocation.Name))
            House._locations.Add(connectingLocation.Name, connectingLocation); //заполняет словарь для get location by name
  


            //Debug.Write("ок "+ direction.ToString() +" "+ connectingLocation );
            //Debug.WriteLine(ExitList.Count());
            //}

        }
        private void AddReturnExit(Direction direction, Location connectingLocation) =>
 Exits.Add((Direction)(-(int)direction), connectingLocation);
        /// <summary>
        /// Gets the exit location in a direction
        /// </summary>
        /// <param name="direction">Direciton of the exit location</param>
        /// <returns>The exit location, or this if there is no exit in that direction</returns>
        public Location GetExit(Direction direction)
        {

            ///тут все не правильно
            if (Exits.ContainsKey(direction))
            {
                return Exits[direction];
            }
            else return this;


        }
        private string DescribeDirection(Direction d) => d switch
        {
            Direction.Up => "Up",
            Direction.Down => "Down",
            Direction.In => "In",
            Direction.Out => "Out",
            _ => $"to the {d}",
        };

    }
}
