using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem
{
    public class Employee
    {
        #region Fields

        protected decimal salaryIncreasePerYearInCompany;

        protected decimal maxBaseSalaryIncreaseForYearsInCompany;


        #endregion

        #region Properties

        public string Name { get; }
        public DateTime ArrivalDate { get; }

        public decimal BaseSalary { get; }

        public Employee Supervisor { get; set; }

        #endregion

        #region Constructors

        public Employee(string name, DateTime arrivalDate, 
            decimal baseSalary = 45000m, 
            decimal percentageOfBaseSalaryForBonus = 0.03m, 
            decimal maxBaseSalaryIncreaseForYearsInCompanyAsBaseSalaryPercentage = 0.3m)
        {
            Name = name;
            ArrivalDate = arrivalDate;
            BaseSalary = baseSalary;
            salaryIncreasePerYearInCompany = BaseSalary * percentageOfBaseSalaryForBonus;
            maxBaseSalaryIncreaseForYearsInCompany = BaseSalary * maxBaseSalaryIncreaseForYearsInCompanyAsBaseSalaryPercentage;
        }

        #endregion

        #region Methods
        
        public decimal GetSalary()
        {
            return GetSalary(DateTime.Now);
        }

        public decimal GetSalary(DateTime forAGivenDate)
        {
            if (forAGivenDate < ArrivalDate) 
                throw new ArgumentException("Cannot calculate a salary for a time when employee was not in our company.");

            int yearsInCompany = GetYearsInCompany(forAGivenDate);
            
            var totalBonusForYearsInCompany = yearsInCompany * salaryIncreasePerYearInCompany;

            if (totalBonusForYearsInCompany > maxBaseSalaryIncreaseForYearsInCompany)
            {
                totalBonusForYearsInCompany = maxBaseSalaryIncreaseForYearsInCompany;
            };

            return CalculateSalaryWithoutYearsInCompanyBonus() + totalBonusForYearsInCompany;
        }

        public int GetYearsInCompany()
        {
            return GetYearsInCompany(DateTime.Now);
        }

        public int GetYearsInCompany(DateTime atThisDate)
        {
            return (atThisDate - ArrivalDate).Days / 365;
        }

        protected virtual decimal CalculateSalaryWithoutYearsInCompanyBonus()
        {
            return BaseSalary;
        }

        #endregion
    }
}
