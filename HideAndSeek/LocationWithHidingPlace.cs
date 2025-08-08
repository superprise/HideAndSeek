using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public  class LocationWithHidingPlace :Location
    {
        Queue<Opponent> pla
                = new Queue<Opponent>();
        
        public LocationWithHidingPlace(String name, String HidingPlace) :base(name) 
        {
          
            this.HidingPlace = HidingPlace;
        }   
        public void Hide(Opponent opponent) 
        {
            
            pla.Enqueue(opponent);
        }

        public String HidingPlace;
       public IEnumerable<Opponent> CheckHidingPlace() 
        {
            var allItems = pla.ToArray();
            pla.Clear();//зачем мне очередь я так с любой коллекцией могу сделать
            return allItems; 
      
        }
    }
}
