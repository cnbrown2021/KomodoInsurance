using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    //Plain Old C# Object --POCO
    public class Team
    {
     public Team()
        {

        }

        public string TeamMembers { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; }

        public Team (string teamName, string teamMembers, int teamId)
        {
            TeamName = teamName;
            TeamMembers = teamMembers;
            TeamId = teamId;
            
        }
    }

}
