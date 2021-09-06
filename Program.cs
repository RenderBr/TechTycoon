using System;
using System.Collections;
using System.Collections.Generic;

namespace TechTycoon
{
    class Program
    {
        static List<Company> companyList = new List<Company>();
        static List<string> types = new List<string>(){"Store", "Technology", "Research", "Media"};
        static List<string> storeTypes = new List<string>(){"Grocery", "Office Supplies", "Hardware", "Home & Deco", "Fashion", "Car"};        
        static List<string> technologyTypes = new List<string>(){"Mobile Phone", "Video Games", "Computers", "Social Media"};
        static List<string> mediaTypes = new List<string>(){"TV Channel", "Publishing", "Music Label", "Films"};
        static List<Employee> toFire = new List<Employee>();
        
        static int initialCompanies = 100;
        static int startYear = 2020;
        static public int currentYear;
        static void Main(string[] args)
        {
            Setup();
            userInput();
        

        static void Setup(){
            currentYear = startYear;
            for(int i = 0; i < initialCompanies; i++){
                Random r = new Random();
                Company temp = new Company();
                temp.id = i;
                temp.name = "Company" + i;
                temp.startupFunds = r.Next(250, 100000);
                temp.employeesToHire = 0;
                var e = r.Next(0, types.Count);
                if(types[e] == "Store"){
                    var sb = r.Next(0, storeTypes.Count);
                    temp.subType.Add(storeTypes[sb]);
                }
                if(types[e] == "Technology"){
                    var sb = r.Next(0, technologyTypes.Count);
                    temp.subType.Add(technologyTypes[sb]);
                }
                if(types[e] == "Media"){
                    var sb = r.Next(0, mediaTypes.Count);
                    temp.subType.Add(mediaTypes[sb]);
                }

                temp.type = types[e];
                temp.balance = temp.startupFunds;
                //Generate employees
                var n = r.Next(1, 12);
                for(int ie = 0; ie < n; ie++){
                    Employee employee = new Employee();
                    employee.id = ie;
                    employee.firstName = "John";
                    employee.lastName = "Doe" + employee.id;
                    employee.happiness = 100;
                    employee.skill = r.Next(0, 100);
                    employee.efficiency = r.Next(10, 100);
                    employee.salary = r.Next(25000, 60000);
                    employee.thoughts.Add("This is crazy! I'm part of a brand new startup!");
                    employee.role = "WIP";
                    employee.age = r.Next(20, 64);
                    temp.employeeList.Add(employee);
                }

                companyList.Add(temp);
                if(temp.subType.Count > 0){
                    Console.WriteLine("Created '" + companyList[i].name + "', of type " + companyList[i].type + ", specializing in " + companyList[i].subType[0] + " with $" + companyList[i].startupFunds + " in startup funds.");
                }else{
                    Console.WriteLine("Created '" + companyList[i].name + "', of type " + companyList[i].type + " with $" + companyList[i].startupFunds + " in startup funds.");
                }
            }
            Console.WriteLine("The year is 2020. There are " + companyList.Count + " companies that have been generated and will be competing against each other, what will happen next, I wonder?");
        }

        static void PassYear(){
            Console.WriteLine("One year is passing...");
            foreach(var company in companyList){
                if(company.employeeList.Count > 0){
                    foreach(var employee in company.employeeList){
                        bool fired;

                        if(employee.efficiency < 0){
                            toFire.Add(employee);
                            Console.WriteLine("{0} {1} has been fired for terrible work ethic by {2}", employee.firstName, employee.lastName, company.name);
                            fired = true;
                            company.employeesToHire += 1;
                        }else{
                            fired = false;
                        }

                        if(fired == false){
                        Random r = new Random();
                        company.balance -= employee.salary;
                        //Console.WriteLine("{0} {1} has gotten paid for their yearly salary of {2} by {3}", employee.firstName, employee.lastName, employee.salary, company.name);
                        employee.efficiency -= r.Next(-10, 7);

                        if(employee.efficiency > 30){
                            employee.salary = employee.salary * (1 + (employee.efficiency / 1000));
                            employee.happiness += r.Next(2, 10);
                            employee.efficiency += r.Next(1, 5);
                        }else{
                            employee.happiness -= r.Next(1, 4);
                            employee.efficiency -= r.Next(1, 5);
                        }
                        }
                    }
                    if(toFire.Count > 0){
                        foreach(var employee in toFire){
                                company.employeeList.Remove(employee);
                            }   
                    }
                }




                if(company.type == "Store"){
                    if(company.stores.Count <= 0 || company.balance > 100000){
                        Store store = new Store();
                        Random r = new Random();
                        store.id = company.stores.Count+1;
                        store.name = company.name + " store";
                        foreach(var subtype in company.subType){
                            if(subtype == "Grocery"){
                                store.initialCost = r.Next(350000, 750000);
                                store.rent = 0;
                                store.upkeep = r.Next(3500, 5500);
                                store.type = "Grocery";
                                store.monthlyYield = r.Next(30000, 14000000);
                                company.stores.Add(store);
                                company.balance -= store.initialCost;
                                Console.WriteLine("{0} just opened up a new {1} store for ${2}! Good luck to them!", company.name, store.type, store.initialCost);
                                

                                for(int i = 0; i < r.Next(1, 10); i++){
                                    Employee employee = new Employee();
                                    employee.id = i;
                                    employee.firstName = "Jim";
                                    employee.lastName = "Donda" + employee.id;
                                    employee.happiness = 100;
                                    employee.efficiency = r.Next(10, 100);
                                    employee.skill = r.Next(3, 38);
                                    employee.salary = r.Next(23000, 28000);
                                    employee.thoughts.Add("Just got hired at this new place, I'm kinda nervous...");
                                    employee.role = "Grocery Cashier";
                                    employee.age = r.Next(16, 75);
                                    company.employeeList.Add(employee);
                                    Console.WriteLine("{0} also hired a new staff member following the purchase of the grocery store, {1} {2}, with a salary of {3}", company.name, employee.firstName, employee.lastName, employee.salary);
                                }
                            }
                            }
                    }
                }

                if(company.employeesToHire > 0){
                    if(company.subType.Contains("Grocery")){
                        for(int i = 0; i < company.employeesToHire; i++){
                                    Random r = new Random();
                                    Employee employee = new Employee();
                                    employee.id = i;
                                    employee.firstName = "Jim";
                                    employee.lastName = "Donda" + employee.id;
                                    employee.happiness = 100;
                                    employee.efficiency = r.Next(10, 100);
                                    employee.skill = r.Next(3, 38);
                                    employee.salary = r.Next(23000, 28000);
                                    employee.thoughts.Add("Just replaced somebody here.. I'm kinda nervous...");
                                    employee.role = "Grocery Cashier";
                                    employee.age = r.Next(16, 75);
                                    company.employeeList.Add(employee);
                                    Console.WriteLine("{0} hired a new staff member following the firing of a previous employee, {1} {2}, with a salary of {3}", company.name, employee.firstName, employee.lastName, employee.salary);
                                    return;
                                }
                        company.employeesToHire = 0;
                    }

                    for(int i = 0; i < company.employeesToHire; i++){
                                    Random r = new Random();
                                    Employee employee = new Employee();
                                    employee.id = i;
                                    employee.firstName = "John";
                                    employee.lastName = "Doe" + employee.id;
                                    employee.happiness = 100;
                                    employee.skill = r.Next(0, 100);
                                    employee.efficiency = r.Next(10, 100);
                                    employee.salary = r.Next(25000, 60000);
                                    employee.thoughts.Add("This is crazy! I'm part of a brand new startup!");
                                    employee.role = "WIP";
                                    employee.age = r.Next(20, 64);
                                    company.employeeList.Add(employee);
                                    Console.WriteLine("{0} hired a new staff member following the firing of a previous employee, {1} {2}, with a salary of {3}", company.name, employee.firstName, employee.lastName, employee.salary);
                                    return;
                    }
                    company.employeesToHire = 0;
                    
                }
            }
            userInput();
        }

        static void userInput(){
            string line;

            line = Console.ReadLine();
                foreach(var company in companyList){
                    if(line == "e:" + company.name){
                        Console.WriteLine("Employees: ");
                        foreach(var employee in company.employeeList) {
                            Console.WriteLine("{0} {1} - current salary: ${2}, role: {3}, happiness: {4}%", employee.firstName, employee.lastName, employee.salary, employee.role, employee.happiness);
                    }
                }

                if(line == "stores:" + company.name){
                        Console.WriteLine("Stores: ");
                        foreach(var store in company.stores) {
                            Console.WriteLine("{0} - type: {1} - initial cost: {2} - upkeep: {3}", store.name, store.type, store.initialCost, store.upkeep);
                    }
                 
                    userInput();
                }

            if(line == "bal:" + company.name){
                        Console.WriteLine("{0} has a balance of ${1}", company.name, company.balance);
                        userInput();
                    }
        }

            if(line == "pass year"){
                PassYear();
            }
            userInput();
    }
}
}
}
