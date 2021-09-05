using System;
using System.Collections;
using System.Collections.Generic;

namespace TechTycoon
{
    class Program
    {
        static List<Company> companyList = new List<Company>();
        static List<string> companyTypes = new List<string>(){"Store", "Technology", "Research", "Media"};
        static List<string> storeTypes = new List<string>(){"Grocery", "Office Supplies", "Hardware", "Home & Deco", "Fashion", "Car"};        
        static List<string> technologyTypes = new List<string>(){"Mobile Phone", "Video Games", "Computers", "Social Media"};


        static int initialCompanies = 100;
        static int startYear = 2020;
        static public int currentYear;
        static void Main(string[] args)
        {
            Setup();
            string line;
            while ((line = Console.ReadLine()) == "next year")
            {
                Console.WriteLine("");
            }
        }

        static void Setup(){
            currentYear = startYear;
            for(int i = 0; i < initialCompanies; i++){
                Random r = new Random();
                Company temp = new Company();
                temp.id = i;
                temp.name = "Company" + i;
                temp.startupFunds = r.Next(250, 100000);
                var e = r.Next(0, companyTypes.Count);
                if(companyTypes[e] == "Store"){
                    var sb = r.Next(0, storeTypes.Count);
                    temp.subType.Add(storeTypes[sb]);
                }
                if(companyTypes[e] == "Technology"){
                    var sb = r.Next(0, technologyTypes.Count);
                    temp.subType.Add(technologyTypes[sb]);
                }

                temp.companyType = companyTypes[e];
                companyList.Add(temp);
                Console.WriteLine("Created '" + companyList[i].name + "', of type " + companyList[i].companyType + ", specializing in " + companyList[i].subType[0] + " with $" + companyList[i].startupFunds + " in startup funds.");
            }
            Console.WriteLine("The year is 2020. There are " + companyList.Count + " companies that have been generated and will be competing against each other, what will happen next, I wonder?");
        }
    }
}
