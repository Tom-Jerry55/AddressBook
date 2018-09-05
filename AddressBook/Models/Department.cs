﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Department
    {
        public int ID { get; set; }
        public  string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
