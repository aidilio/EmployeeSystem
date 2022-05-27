namespace EmployeeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyStartedDate = new DateTime(2014, 11, 7);
            var companyEmployees = new List<Employee>();

            var salesManager = new SalesManager("John", companyStartedDate);
            var manager = new Manager("Lin", companyStartedDate);
            var employee1 = new Employee("Robert", companyStartedDate);
            var employee2 = new Employee("Steven", companyStartedDate);

            salesManager.AddSubordinate(manager);
            salesManager.AddSubordinate(employee1);
            manager.AddSubordinate(employee2);

            companyEmployees.Add(salesManager);
            companyEmployees.Add(manager);
            companyEmployees.Add(employee1);
            companyEmployees.Add(employee2);

            var totalSalary = 0m;

            foreach (var employee in companyEmployees)
            {
                totalSalary += employee.GetSalary();
            }

            Console.WriteLine($"Total company expenditure for salaries: ${Math.Round(totalSalary, 2)}");
        }
    }
}