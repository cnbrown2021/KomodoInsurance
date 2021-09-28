using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repo
{
    public class TeamRepository
    {
        public readonly List<Team> _contentDirectory = new List<Team>();

        //Create
        public bool AddContentToDirectory(Team content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<Team> GetTeams()
        {
            return _contentDirectory;
        }

        //Get Team


        //Update
        public bool UpdateExistingTeam(Team existingContent, Team newContent)
        {
            if(existingContent != newContent)
            {
                existingContent.TeamMembers = newContent.TeamMembers;
                existingContent.TeamName = newContent.TeamName;
                existingContent.TeamId = newContent.TeamId;
                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete
        public bool DeleteInfo(Team existingContent)
        {
            bool result = _contentDirectory.Remove(existingContent);
            return result;
        }

        public Team GetMemberById(string teamMember)
        {
            throw new NotImplementedException();
        }

    }
}
