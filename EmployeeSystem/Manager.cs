using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem
{
    public class Manager : Employee
    {
        #region Fields

        protected decimal bonusPercentageFromSubordinateSalary;

        #endregion

        #region Constructors

        public Manager(string name, 
            DateTime arrivalDate,
            decimal baseSalary = 45000m,
            decimal percentageOfBaseSalaryForBonus = 0.05m,
            decimal maxBaseSalaryIncreaseForYearsInCompanyAsBaseSalaryPercentage = 0.4m,
            decimal bonusPercentageFromSubordinateSalary = 0.05m) 
            : base(name, arrivalDate, baseSalary, percentageOfBaseSalaryForBonus, maxBaseSalaryIncreaseForYearsInCompanyAsBaseSalaryPercentage)
        {
            this.bonusPercentageFromSubordinateSalary = bonusPercentageFromSubordinateSalary;
            Subordinates = new List<Employee>();
        }

        #endregion

        #region Properties

        protected List<Employee> Subordinates { get; private set; }

        #endregion

        #region Methods

        public void AddSubordinate(Employee employee)
        {
            if (employee.Supervisor != null)
            {
                throw new ArgumentException("Employee already has a supervisor.");
            }

            employee.Supervisor = this;
            Subordinates.Add(employee);
        }

        protected override decimal CalculateSalaryWithoutYearsInCompanyBonus()
        {
            var directSubordinateSalary = GetSalaryOfDirectSubordinates();
            var salary = BaseSalary + (directSubordinateSalary * bonusPercentageFromSubordinateSalary);

            return salary;
        }


        protected virtual decimal GetSalaryOfDirectSubordinates()
        {
            decimal totalSum = 0;
            foreach (var subordinate in Subordinates)
            {
                totalSum += subordinate.GetSalary();
            }

            return totalSum;
        }

        protected virtual decimal GetSalaryOfAllSubordinateHierarchy()
        {
            decimal totalSum = 0;
            foreach (var subordinate in Subordinates)
            {
                totalSum += subordinate.GetSalary();

                if (subordinate is Manager mngr)
                {
                    totalSum += mngr.GetSalaryOfAllSubordinateHierarchy();
                }
            }

            return totalSum;
        }

        #endregion
    }
}
