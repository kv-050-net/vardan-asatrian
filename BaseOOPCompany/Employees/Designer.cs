using System;

namespace BaseOOPCompany
{
    public class Designer : Employee
    {
        private decimal effectivenessCoefficient;

        public decimal EffectivenessCoefficient
        {
            get
            {
                return effectivenessCoefficient;
            }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException($"{value} must be in range from 0 to 1");
                }

                effectivenessCoefficient = value;
            }
        }

        public Designer(string firstName, string secondName, decimal salary, int experience,decimal effectivenessCoefficient, Manager manager = null)
            : base(firstName, secondName, salary, experience, manager)
        {
            EffectivenessCoefficient = effectivenessCoefficient;
        }
    }
}
