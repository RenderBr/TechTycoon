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
        public string companyType;
        public List<string> subType = new List<string>();
        public bool storeIsOnline = false;
    }
}
