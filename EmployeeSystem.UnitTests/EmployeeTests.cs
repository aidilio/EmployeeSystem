using NUnit.Framework;
using System;

namespace EmployeeSystem.UnitTests
{
    public class EmployeeTests
    {
        private DateTime _referenceDate;

        [SetUp]
        public void Setup()
        {
            _referenceDate = new DateTime(2022, 05, 26);
        }

        [Test]
        [TestCase(2017, 12, 24, ExpectedResult = 4)]
        [TestCase(2014, 3, 12, ExpectedResult = 8)]
        [TestCase(2022, 1, 1, ExpectedResult = 0)]
        [TestCase(2021, 6, 6, ExpectedResult = 0)]
        public int GetYearsInCompany_ReturnsYearsPassedSinceArrivalDate(int year, int month, int day)
        {
            var arrivalDate = new DateTime(year, month, day);
            var employee = new Employee("John", arrivalDate);
            return employee.GetYearsInCompany(_referenceDate);
        }

        [Test]
        [TestCase(2017, 12, 24, ExpectedResult = 50400)] // 4 years
        [TestCase(2014, 3, 12, ExpectedResult = 55800)] // 8 years
        [TestCase(2022, 1, 1, ExpectedResult = 45000)] // 0 years
        [TestCase(2021, 6, 6, ExpectedResult = 45000)] // 0 years
        public decimal GetSalary_TotalSalaryDoesNotExceedMax_ReturnsTotalEmployeeSalary(int year, int month, int day)
        {
            var arrivalDate = new DateTime(year, month, day);
            var employee = new Employee("John", arrivalDate);

            return employee.GetSalary(_referenceDate);
        }

        [Test]
        [TestCase(2012, 4, 12, ExpectedResult = 58500)]
        [TestCase(2011, 2, 12, ExpectedResult = 58500)]
        [TestCase(2003, 5, 17, ExpectedResult = 58500)]
        [TestCase(1996, 2, 1, ExpectedResult = 58500)]
        public decimal GetSalary_TotalSalaryExceedsMax_ReturnsMaxPossibleSalary(int year, int month, int day)
        {
            var arrivalDate = new DateTime(year, month, day);
            var employee = new Employee("John", arrivalDate);

            return employee.GetSalary(_referenceDate);
        }
    }
}