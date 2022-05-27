using System;
using NUnit.Framework;

namespace EmployeeSystem.UnitTests
{
    public class SalesManagerTests
    {
        private DateTime _referenceDate;

        [SetUp]
        public void Setup()
        {
            _referenceDate = new DateTime(2022, 05, 26);
        }

        [TestCase(2014, 4, 12, ExpectedResult = 53921.7)]
        [TestCase(2011, 2, 12, ExpectedResult = 55437.75)]
        public decimal GetSalary_WithSubordinates_ReturnSalaryWithSubordinateBonus_HandleSubordinatesOfSubordinates(int year, int month, int day)
        {
            var salesManager = new SalesManager("John", new DateTime(year, month, day));
            var subordinate1 = new Manager("Lin", new DateTime(year, month, day));
            var subordinate2 = new Employee("Robert", new DateTime(year, month, day));
            var subordinate3 = new Employee("Steven", new DateTime(year, month, day));

            salesManager.AddSubordinate(subordinate1);
            salesManager.AddSubordinate(subordinate2);
            subordinate1.AddSubordinate(subordinate3);

            var salary = salesManager.GetSalary(_referenceDate);
            return salary;
        }
    }
}
