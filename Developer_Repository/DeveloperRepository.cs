using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Repository
{
    //CRUD
    //Create
    //Read
    //Update
    //Delete
    public class DeveloperRepository
    {
        public readonly List<Developer> _contentDirectory = new List<Developer>();
        
        //Create
        public bool AddContentToDirectory(Developer content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<Developer> GetContent()
        {
            return _contentDirectory;
        }

        //Get by Name
        public Developer GetDeveloper(string TheNameYouAreLookingFor)
        {
            foreach (Developer content in _contentDirectory)
            {
                if (content.Name == TheNameYouAreLookingFor)
                {
                    return content;
                }
            }
            return null;
        }

        //Get by ID
        public Developer GetDeveloperId(int TheID)
        {
            foreach (Developer content in _contentDirectory)
            {
                if (content.DeveloperId == TheID)
                {
                    return content;
                }
            }
            return null;
        }


        //Update
        public bool UpdateExistingContent(Developer existingContent, Developer newContent)
        {
            if(existingContent != newContent)
            {
                existingContent.Name = newContent.Name;
                existingContent.DeveloperId = newContent.DeveloperId;
                existingContent.AccessToPluralSight = newContent.AccessToPluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteContent (Developer existingContent)
        {
            bool result = _contentDirectory.Remove(existingContent);
            return result;
        }
        public Developer GetContentByName(string name)
        {
            throw new NotImplementedException();
        }
        public Developer GetContentByDeveloperId()
        {
            throw new NotImplementedException();
        }
    }
}
