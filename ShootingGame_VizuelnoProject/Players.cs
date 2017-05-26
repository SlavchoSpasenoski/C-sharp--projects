using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame_VizuelnoProject
{
   public class Players
    {
       public string Name { get; set; }
       public int Poeni { get; set; }


       public Players(string name, int poeni)
       {
           Name = name;
           Poeni = poeni;
       }

       public override string ToString()
       {
           return String.Format("{0, -20}{1:0}", Name, Poeni);    
       }
    }
}
