using System;
using System.Collections.Generic;

abstract class Employee
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string Position { get; set; }

    public Employee(string name, int id, string position)
    {
        Name = name;
        Id = id;
        Position = position;
    }

    public abstract decimal CalculateSalary();
}

class Worker : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public Worker(string name, int id, string position, decimal hourlyRate, int hoursWorked)
        : base(name, id, position)
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override decimal CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }
}

class Manager : Employee
{
    public decimal FixedSalary { get; set; }
    public decimal Bonus { get; set; }

    public Manager(string name, int id, string position, decimal fixedSalary, decimal bonus)
        : base(name, id, position)
    {
        FixedSalary = fixedSalary;
        Bonus = bonus;
    }

    public override decimal CalculateSalary()
    {
        return FixedSalary + Bonus;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        employees.Add(new Worker("Ivan", 1, "Junior Word Developer", 500, 160));
        employees.Add(new Worker("Petr", 2, "Senior Excel Developer", 400, 150));
        employees.Add(new Manager("Serega", 3, "Manager", 60000, 15000));
        employees.Add(new Manager("Anna", 4, "Teamlead", 80000, 20000));

        foreach (var emp in employees)
        {
            Console.WriteLine($"{emp.Name} ({emp.Position}) - salary: {emp.CalculateSalary()} $.");
        }
    }
}