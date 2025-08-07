using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    static public class House
    {
        public static Dictionary<String, Location> _locations = new Dictionary<String, Location>();//Entry нет в справочнике, а нужна?
        

        public static Random Random;//stub
        static House()
        {
            
            Location Hallway=new Location("Hallway");
            Location Landing = new Location("Landing");
            Location MasterBedroom = new Location("Master Bedroom");
            Entry = new Location("Entry");
            Entry.AddExit(Direction.Out, new Location("Garage"));//
            Entry.AddExit(Direction.East,Hallway );//
            Hallway.AddExit(Direction.North, new Location("Bathroom"));//
            Hallway.AddExit(Direction.Northwest, new Location("Kitchen"));//
            Hallway.AddExit(Direction.South, new Location("Living Room"));//
            Hallway.AddExit(Direction.Up, Landing);//
            Landing.AddExit(Direction.Northwest, MasterBedroom);//
            MasterBedroom.AddExit(Direction.East,new Location("Master Bath"));//
            Landing.AddExit(Direction.West, new Location("Second Bathroom"));//
            Landing.AddExit(Direction.Southwest, new Location("Nursery"));//
            Landing.AddExit(Direction.South, new Location("Pantry"));//
            Landing.AddExit(Direction.Southeast, new Location("Kids Room"));//
            Landing.AddExit(Direction.Up, new Location("Attic"));//
         

        }
        static public Location RandomExit(Location name) { 
            
            return new Location("ты че, ты кто тебе что надо то от меня"); 
        
        
        } //stub

        static public Location GetLocationByName(String name) {
            if (_locations.ContainsKey(name))
            { return _locations[name]; }
            else return Entry;
        } // takes the name of a location and returns a reference to the Location with
        //that name(or the entry, if the name isn’t found).

        public static void ClearHidingPlaces()
        {
            throw new NotImplementedException();
        }

        static public  Location Entry {  get; private set; }//contains a reference to the Entry location

//        It will create a separate Location object for
//each room in the house, using their AddExit methods to link them together.


    }
}
