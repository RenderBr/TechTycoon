using System;
using System.Collections;
using System.Collections.Generic;

namespace TechTycoon
{
    class Company
    {
        public string name;
        public int id;
        public int startupFunds;
        public int balance;
        public int employeesToHire;
        public string type;
        public List<Employee> employeeList = new List<Employee>();
        public List<string> subType = new List<string>();
        public bool storeIsOnline = false;
        public List<Product> productList = new List<Product>();
        public List<Product> productsInDevelopment = new List<Product>();
        public List<Store> stores = new List<Store>();
    }
}
