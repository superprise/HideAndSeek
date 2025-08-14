using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class Opponent//stub
    {
        public readonly string Name;
        public Opponent(string name) => Name = name;
        public override string ToString() => Name;
        public void Hide()
        {
            LocationWithHidingPlace locW;
            Random random = new Random();
            Location loc = House.Entry;

 while (loc.GetType() == typeof(Location)) { 
            for (int i = 0; i < random.Next(0, 50); i++)
            {
            loc = House.RandomExit(loc);
            //Debug.Write(i+". go to " + loc.Name+Environment.NewLine );
            }
            }
          
            locW = (LocationWithHidingPlace)loc;
            locW.Hide(this);
           //Debug.Write(Environment.NewLine+" stop to " + loc.Name+ Environment.NewLine + Environment.NewLine + Environment.NewLine);

 System.Diagnostics.Debug.WriteLine($" {Name} is hiding " +
$"{(locW as LocationWithHidingPlace).HidingPlace} in the {loc.Name}");
        }
    }
}
