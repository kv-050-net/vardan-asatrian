using BaseOOPCompany;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BaseOOPProjectTests
{
    // Test for developer include all methods that implemented in Employee abstract class and they fair for all employees.
    public class DeveloperTests
    {
        Developer developer1, developer2, developer3, developer4;

        ISalaryCalculator salaryCalculator;

        [SetUp]
        public void Setup()
        {
            Manager manager1 = new Manager("Man1", "Manager1", 4000, 6);

            salaryCalculator = new SalaryCalculatorForDeveloper();

            developer1 = new Developer("Dev1", "Developer1", 800, 1, manager1);
            developer2 = new Developer("Dev2", "Developer2", 1500, 3, manager1);
            developer3 = new Developer("Dev3", "Developer3", 3000, 6, manager1);
            developer4 = new Developer("Dev4", "Developer4", 2700, 5);

            manager1.Team = new List<Employee>()
                {
                    developer1, developer2, developer3
                };
        }

        [Test]
        public void FirstName_IsNullOrEmpty_ShouldThrow_ArgumentException()
        {
            void MethodToTest()
            {
                developer1.FirstName = "";
            }

            ArgumentException ex = Assert.Catch<ArgumentException>(() => MethodToTest());

            Assert.AreEqual("First Name can't be empty!", ex.Message);
        }

        [Test]
        public void SecondName_IsNullOrEmpty_ShouldThrow_ArgumentException()
        {
            void MethodToTest()
            {
                developer1.SecondName = "";
            }

            ArgumentException ex = Assert.Catch<ArgumentException>(() => MethodToTest());

            Assert.AreEqual("Second Name can't be empty!", ex.Message);
        }

        [Test]
        public void Experience_LessThan0_ShouldThrow_ArgumentException()
        {
            void MethodToTest()
            {
                developer1.Experience = -1;
            }

            ArgumentException ex = Assert.Catch<ArgumentException>(() => MethodToTest());

            Assert.AreEqual("Experience can't be negative number!", ex.Message);
        }

        [Test]
        public void Salary_LessThan0_ShouldThrow_ArgumentException()
        {
            void MethodToTest()
            {
                developer1.Salary = -1000;
            }

            ArgumentException ex = Assert.Catch<ArgumentException>(() => MethodToTest());

            Assert.AreEqual("Salary can't be negative number!", ex.Message);
        }

        [Test]
        public void CalculateSalary_When_Experience_1year()
        {
            Assert.AreEqual(800, (double)salaryCalculator.Calculate(developer1), 0.001);
        }

        [Test]
        public void CalculateSalary_When_Experience_3years()
        {
            Assert.AreEqual(1700, (double)salaryCalculator.Calculate(developer2), 0.001);
        }

        [Test]
        public void CalculateSalary_When_Experience_6years()
        {
            Assert.AreEqual(4100, (double)salaryCalculator.Calculate(developer3), 0.001);
        }

        [Test]
        public void ToString_ShouldWrite_Developer1()
        {
            Assert.AreEqual("Dev1 Developer1, manager: Manager1, experience: 1", developer1.ToString());
        }

        [Test]
        public void ToString_When_ManagerIsNull_ShouldWrite_Developer4()
        {
            Assert.AreEqual("Dev4 Developer4, manager: none, experience: 5", developer4.ToString());
        }
    }
}