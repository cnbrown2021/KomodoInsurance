using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Repository
{
    //POCO
    public class Developer
    {
        public Developer()
        {

        }
        public string Name { get; set; }
        public int DeveloperId { get; set; }
        public bool AccessToPluralSight { get; set; }



        public Developer(string name, int developerId, bool accessToPluralSight)
        {
            Name = name;
            DeveloperId = developerId;
            AccessToPluralSight = accessToPluralSight;

        }

        public bool Access
        {
            get
            {
                if ((bool)AccessToPluralSight)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
