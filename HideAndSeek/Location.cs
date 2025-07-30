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
        public IEnumerable<string> ExitList => from exit in Exits
                                               orderby Exits.Values 
                                               select "the " + exit.Value.ToString() + " is to the " + exit.Key.ToString();
        /// <summary>
        /// Adds an exit to this location
        /// </summary>
        /// <param name="direction">Direction of the connecting location</param>
        /// <param name="connectingLocation">Connecting location to add</param>
        public void AddExit(Direction direction, Location connectingLocation)
        {
            Exits.Add((Direction)((int)direction), connectingLocation);

            //ExitList.Append("the "+connectingLocation+" is to the "+direction);
            //Debug.Write("ок "+ direction.ToString() +" "+ connectingLocation );
            //AddReturnExit(direction, connectingLocation);
            foreach (var dir in ExitList) { Debug.WriteLine(dir.ToString()); }
                Debug.WriteLine(ExitList.Count());
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
            if (Exits.ContainsKey(direction))
            {
                return Exits[direction];
            }
            else return new Location("TESTING"); ;


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
