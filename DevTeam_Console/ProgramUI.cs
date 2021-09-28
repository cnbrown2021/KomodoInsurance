using Developer_Repository;
using DevTeams_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Console
{
    class ProgramUI
    {
        private DeveloperRepository _repo = new DeveloperRepository();
        private TeamRepository _repository = new TeamRepository();
        public void Run()
        {
            SeeData();
            RunMenu();
        }

        //This method Starts the application
        private void RunMenu()
        {
            //Create menu options

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine
                    (
                    "Welcome to Komodo Insurance\n" +
                    "\n" +
                    "Enter the number of your selection:\n" +
                    "1. Create new Developer\n" +
                    "2. Show Developer Directory\n" +
                    "3. Show Teams\n" +
                    "4. Create new Team\n" +
                    "5. Update Developer\n" +
                    "6. Remove Content\n" +
                    "7. Exit"
                    );

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Create new developer
                        CreateNewDeveloper();
                        break;

                    case "2":
                        //Show Developer directory
                        ShowAllContent();
                        break;

                    case "3":
                        //Show Teams
                        ShowAllTeams();
                        break;

                    case "4":
                        //Create new team
                        CreateNewTeam();
                        break;

                    case "5":
                        //Update developer
                        UpdateDeveloper();
                        break;

                    case "6":
                        //Remove Content
                        RemoveFromRepository();
                        break;

                    case "7":
                        //Exit
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 6\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;
                }
            }

        }
        //Creating developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer content = new Developer();

            //Name
            Console.WriteLine("Please enter name");
            content.Name = Console.ReadLine();

            //ID
            Console.WriteLine("Enter ID");
            string developerIdString = Console.ReadLine();
            content.DeveloperId = int.Parse(developerIdString);
            //content.DeveloperId = int.Parse(Console.ReadLine());

            //Access?
            Console.WriteLine("Access to Plural Sight? (True/False)");
            content.AccessToPluralSight = bool.Parse(Console.ReadLine());

            DeveloperRepository _repo = new DeveloperRepository();

            _repo.AddContentToDirectory(content);
        }

        //Getting all Content
        private void ShowAllContent()
        {
            Console.Clear();

            List<Developer> listOfContent = _repo.GetContent();

            foreach (Developer content in listOfContent)
            {
                DisplayContent(content);

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        //Getting Team List 
        private void ShowAllTeams()
        {
            Console.Clear();
            List<Team> listOfTeams = _repository.GetTeams();

            foreach (Team content in listOfTeams)
            {
                TeamContent(content);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        //Create new team
        private void CreateNewTeam()
        {
            Console.Clear();
            Team team = new Team();

            Console.WriteLine("Please enter team name:");
            //string teamname = Console.ReadLine();
            team.TeamName = Console.ReadLine();

            Console.WriteLine("Please enter team member");

            team.TeamMembers = Console.ReadLine();

            Console.WriteLine("Enter Team ID");
            string teamIdString = Console.ReadLine();
            //int teamId = int.Parse(teamIdString);
            team.TeamId = int.Parse(teamIdString);

            _repository.AddContentToDirectory(team);
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }


        //Update Team
        private void UpdateDeveloper()
        {
            Console.Clear();

            Console.WriteLine("Which Developer do you want to update?");
            string targetName = Console.ReadLine();

            Developer targetContent = _repo.GetDeveloper(targetName);

            if(targetContent == null)
            {
                Console.WriteLine("That Developer is not in the system");
                Console.WriteLine("Press any key to continue");
                return;
            }

            Developer updatedContent = new Developer();
            
            //Name
            Console.WriteLine($"Original name: {targetContent.Name}\n" +
                $"Please update name");
            updatedContent.Name = Console.ReadLine();

            //ID
            Console.WriteLine($"Original ID: {targetContent.DeveloperId}\n" +
                "Enter new ID");
            string developerIdString = Console.ReadLine();
            updatedContent.DeveloperId = int.Parse(developerIdString);

            //Access?
            Console.WriteLine($"Original Access: {targetContent.AccessToPluralSight}\n" +
                "Does Developer have Access to Plural Sight? (True/False)");
            updatedContent.AccessToPluralSight = bool.Parse(Console.ReadLine());

            if(_repo.UpdateExistingContent(targetContent, updatedContent))
            {
                Console.WriteLine("Developer Updated");
            }
            else
            {
                Console.WriteLine("Unable to Update");
            }

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        //Deleting Content
        private void RemoveFromRepository()
        {
            Console.Clear();

            List<Developer> contentList = _repo.GetContent();

            int option = 1;

            foreach (Developer content in contentList)
            {
                Console.WriteLine($"{option}.{content.Name}");
                option++;
            }

            Console.WriteLine("Which Developer would you like to removed?");
            int targetDeveloperId = int.Parse(Console.ReadLine());
            int targetOption = targetDeveloperId - 1;

            if (targetOption >= 0 && targetOption < contentList.Count)
            {
                Developer targetContent = contentList[targetOption];
                if (_repo.DeleteContent(targetContent))
                {
                    Console.WriteLine($"{targetContent.DeveloperId} was sucessfully deleted");
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
            else
            {
                Console.WriteLine("Please try again");
            }

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
            

        }

        //Exit

        //Help
        private void DisplayContent(Developer content)
        {
            Console.WriteLine
                    (
                        $"Name: {content.Name}\n" +
                        $"Developer Id: {content.DeveloperId}\n" +
                        $"Access to Plural Sight: {content.AccessToPluralSight}\n\n"
                    );

        }

        private void TeamContent(Team content)
        {
            Console.WriteLine
                (
                    $"Team: {content.TeamName}\n" +
                    $"Members {content.TeamMembers}\n" +
                    $"Team ID {content.TeamId}\n\n"
                );
        }

        private void SeeData()
        {
            Developer charlesmiller = new Developer("Charles Miller", 987, false);
            Developer ciarabrown = new Developer("Ciara Brown", 123, true);
            Developer zyairemoore = new Developer("Zyaire Moore", 234, true);
            Developer elijahmiller = new Developer("Elijah Miller", 876, false);

            _repo.AddContentToDirectory(charlesmiller);
            _repo.AddContentToDirectory(ciarabrown);
            _repo.AddContentToDirectory(zyairemoore);
            _repo.AddContentToDirectory(elijahmiller);


            Team numOne = new Team("Beehive", "Ciara Brown", 4567);
            Team numTwo = new Team("Cochella", "Elijah Miller", 7654);

            _repository.AddContentToDirectory(numOne);
            _repository.AddContentToDirectory(numTwo);

        }
    }
}
     

