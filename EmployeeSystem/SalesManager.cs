using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem
{
    public class SalesManager : Manager
    {
        #region Constructors

        public SalesManager(string name, 
            DateTime arrivalDate,
            decimal baseSalary = 45000m,
            decimal percentageOfBaseSalaryForBonus = 0.01m,
            decimal maxBaseSalaryIncreaseForYearsInCompanyAsBaseSalaryPercentage = 0.35m,
            decimal bonusPercentageFromSubordinateSalary = 0.03m) 
            : base(name, arrivalDate, baseSalary, percentageOfBaseSalaryForBonus, maxBaseSalaryIncreaseForYearsInCompanyAsBaseSalaryPercentage, bonusPercentageFromSubordinateSalary)
        {
        }

        #endregion

        #region Methods

        protected override decimal CalculateSalaryWithoutYearsInCompanyBonus()
        {
            var allSubordinateSalary = GetSalaryOfAllSubordinateHierarchy();
            var totalSalary = BaseSalary + (allSubordinateSalary * bonusPercentageFromSubordinateSalary);

            return totalSalary;
        }

        #endregion
    }
}
