using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    static public class House
    {
        public static Dictionary<String, Location> _locations = new Dictionary<String, Location>();

        public static Random Random;//stub
        static House()
        {
            
            Location Hallway=new Location("Hallway");
            Location Landing = new Location("Landing");
            Location MasterBedroom = new LocationWithHidingPlace("Master Bedroom","under the bed");
            Entry = new Location("Entry");
            _locations.Add("Entry", Entry);
            Entry.AddExit(Direction.Out, new LocationWithHidingPlace("Garage","in the car"));//
            Entry.AddExit(Direction.East,Hallway );//
            Hallway.AddExit(Direction.North, new LocationWithHidingPlace("Bathroom","in the basin" ));//
            Hallway.AddExit(Direction.Northwest, new LocationWithHidingPlace("Kitchen", "in the cupboard"));//
            Hallway.AddExit(Direction.South, new LocationWithHidingPlace("Living Room", "under the sofa"));//
            Landing.AddExit(Direction.Up, new LocationWithHidingPlace("Attic","in old cardbox"));//
            Hallway.AddExit(Direction.Up, Landing);//
            Landing.AddExit(Direction.Southeast, new LocationWithHidingPlace("Kids Room", "in the closet"));//
            Landing.AddExit(Direction.Northwest, MasterBedroom);//
            Landing.AddExit(Direction.Southwest, new LocationWithHidingPlace("Nursery", "in the cot"));//
            Landing.AddExit(Direction.South, new LocationWithHidingPlace("Pantry", "under the pile of durty underwears"));//
            Landing.AddExit(Direction.West, new LocationWithHidingPlace("Second Bathroom", "under the toilet"));//                                                        //    
            MasterBedroom.AddExit(Direction.East,new LocationWithHidingPlace("Master Bath","in the basin"));//

        }
        static public Location RandomExit(Location name) {
            int ran = Random.Next(0, name.Exits.Count);
            return  name.Exits.ElementAt(ran).Value;
            Debug.Write(Environment.NewLine+"got " + ran+ Environment.NewLine);

        } //stub

        static public Location GetLocationByName(String name) {
            if (_locations.ContainsKey(name))
            { return _locations[name]; }
            else return Entry;
        } // takes the name of a location and returns a reference to the Location with
        //that name(or the entry, if the name isn’t found).

        public static void ClearHidingPlaces()
        {
            var op = from item in _locations 
                     where item.Value.GetType() == typeof(LocationWithHidingPlace) 
                     select item.Value as LocationWithHidingPlace;

            foreach (var item in op)
           
            {
           item.CheckHidingPlace();
            }
        }

        static public  Location Entry {  get; private set; }//contains a reference to the Entry location

//       It will create a separate Location object for
//each room in the house, using their AddExit methods to link them together.


    }
}
