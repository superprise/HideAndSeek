using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public  class LocationWithHidingPlace :Location
    {
        
        public LocationWithHidingPlace(String name, String HidingPlace) :base(name) 
        {
          
            this.HidingPlace = HidingPlace;
        }   
        public void Hide(Opponent opponent) { }

        public String HidingPlace
        
        ;
       public IEnumerable<Location> CheckHidingPlace() { return new List<Location>(); }
    }
}
