using BaseOOPCompany;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BaseOOPProjectTests
{
    public class DesignerTests
    {
        Designer designer1, designer2, designer3;

        ISalaryCalculator salaryCalculator;

        [SetUp]
        public void Setup()
        {
            Manager manager1 = new Manager("Man1", "Manager1", 4000, 6);

            salaryCalculator = new SalaryCalculatorForDesigner();

            designer1 = new Designer("Des1", "Designer1", 600, 1, 1m, manager1);
            designer2 = new Designer("Des2", "Designer2", 900, 3, 0.8m, manager1);
            designer3 = new Designer("Des3", "Designer3", 1200, 6, 0.5m, manager1);

            manager1.Team = new List<Employee>()
                {
                    designer1, designer2, designer3
                };
        }

        [Test]
        public void EffectivenessCoefficient_LessThan0_ShouldThrow_ArgumentException()
        {
            void MethodToTest()
            {
                designer1.EffectivenessCoefficient = -0.8m;
            }

            ArgumentException ex = Assert.Catch<ArgumentException>(() => MethodToTest());

            Assert.AreEqual("-0,8 must be in range from 0 to 1", ex.Message);
        }

        [Test]
        public void EffectivenessCoefficient_MoreThan1_ShouldThrow_ArgumentException()
        {
            void MethodToTest()
            {
                designer1.EffectivenessCoefficient = 1.1m;
            }

            ArgumentException ex = Assert.Catch<ArgumentException>(() => MethodToTest());

            Assert.AreEqual("1,1 must be in range from 0 to 1", ex.Message);
        }

        [Test]
        public void CalculateSalary_When_Experience_1year_And_EffectivenessCoefficient_1()
        {
            Assert.AreEqual(600, (double)salaryCalculator.Calculate(designer1), 0.001);
        }

        [Test]
        public void CalculateSalary_When_Experience_3years_And_EffectivenessCoefficient_08()
        {
            Assert.AreEqual(880, (double)salaryCalculator.Calculate(designer2), 0.001);
        }

        [Test]
        public void CalculateSalary_When_Experience_6years_And_EffectivenessCoefficient_05()
        {
            Assert.AreEqual(970, (double)salaryCalculator.Calculate(designer3), 0.001);
        }
    }
}