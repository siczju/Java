﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace Exercicio1.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } // associação entre as duas classes
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();
        public Worker() { }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department) 
        {
        this.Name = name;  
        this.Level = level;
        this.BaseSalary = baseSalary;
        this.Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract) 
        {
            Contracts.Remove(contract);
        }
        public double Income(int year, int month) 
        {
            double sum = BaseSalary;
            foreach(HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                    sum += contract.TotalValue();
            }
            return sum;
        }
        public override string ToString()
        {
            return "Name: " + Name + "\n" +
                   "Department: " + Department.Name;
        }
    }
}
