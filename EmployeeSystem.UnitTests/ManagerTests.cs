using System;
using NUnit.Framework;

namespace EmployeeSystem.UnitTests
{
    public class ManagerTests
    {
        private DateTime _referenceDate;

        [SetUp]
        public void Setup()
        {
            _referenceDate = new DateTime(2022, 05, 26);
        }

        [Test]
        [TestCase(2015, 10, 5, ExpectedResult = 58500)]
        [TestCase(2017, 2, 17, ExpectedResult = 56250)]
        [TestCase(2022, 04, 2, ExpectedResult = 45000)]
        [TestCase(2021, 01, 1, ExpectedResult = 47250)]
        public decimal GetSalary_NoSubordinates_ReturnsSalaryWithoutSubordinateBonus(int year, int month, int day)
        {
            var manager = new Manager("John", new DateTime(year, month, day));
            var salary = manager.GetSalary(_referenceDate);
            return salary;
        }

        [Test]
        [TestCase(2014, 4, 12, ExpectedResult = 63000)]
        [TestCase(2011, 2, 12, ExpectedResult = 63000)]
        [TestCase(2003, 5, 17, ExpectedResult = 63000)]
        [TestCase(1996, 2, 1, ExpectedResult = 63000)]
        public decimal GetSalary_NoSubordinates_ReturnMaxPossibleSalary(int year, int month, int day)
        {
            var manager = new Manager("John", new DateTime(year, month, day));
            var salary = manager.GetSalary(_referenceDate);
            return salary;
        }

        [Test]
        [TestCase(2014, 4, 12, ExpectedResult = 68580)]
        [TestCase(2011, 2, 12, ExpectedResult = 68850)]
        [TestCase(2021, 5, 17, ExpectedResult = 51885)]
        [TestCase(2019, 2, 1, ExpectedResult = 56655)]
        public decimal GetSalary_WithSubordinates_ReturnSalaryWithSubordinateBonus(int year, int month, int day)
        {
            var manager = new Manager("John", new DateTime(year, month, day));
            var subordinate1 = new Employee("Robert", new DateTime(year, month, day));
            var subordinate2 = new Employee("Steven", new DateTime(year, month, day));

            manager.AddSubordinate(subordinate1);
            manager.AddSubordinate(subordinate2);

            var salary = manager.GetSalary(_referenceDate);
            return salary;
        }

        [TestCase(2014, 4, 12, ExpectedResult = 69079.5)]
        [TestCase(2011, 2, 12, ExpectedResult = 69221.25)]
        public decimal GetSalary_WithSubordinates_ReturnSalaryWithSubordinateBonus_IgnoreSubordinatesOfSubordinates(int year, int month, int day)
        {
            var manager = new Manager("John", new DateTime(year, month, day));
            var subordinate1 = new Manager("Lin", new DateTime(year, month, day));
            var subordinate2 = new Employee("Robert", new DateTime(year, month, day));
            var subordinate3 = new Employee("Steven", new DateTime(year, month, day));

            manager.AddSubordinate(subordinate1);
            manager.AddSubordinate(subordinate2);
            subordinate1.AddSubordinate(subordinate3);

            var salary = manager.GetSalary(_referenceDate);
            return salary;
        }
    }
}
