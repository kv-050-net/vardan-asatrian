using BaseOOPCompany;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseOOPProjectTests
{
    internal class TestDesigner : Designer
    {
        public TestDesigner() : base("Dev", "Developer", 1000m, 1, 0.5m)
        {
        }
    }

    internal class TestDeveloper : Developer
    {
        public TestDeveloper() : base("Des", "Designer", 1000m, 1)
        {
        }
    }

    public class ManagerTests
    {
        Manager manager1, manager2, manager3;

        ISalaryCalculator salaryCalculator;

        [SetUp]
        public void Setup()
        {
            manager1 = new Manager("Man1", "Manager1", 1000, 1);

            manager2 = new Manager("Man2", "Manager2", 2500, 3);

            manager3 = new Manager("Man3", "Manager3", 4000, 6);

            salaryCalculator = new SalaryCalculatorForManager();

            Developer developer8 = new Developer("Dev8", "Developer8", 1000, 2, manager2);

            Developer developer9 = new Developer("Dev9", "Developer9", 1700, 3, manager2);

            Developer developer10 = new Developer("Dev10", "Developer10", 3000, 7, manager2);

            Designer designer5 = new Designer("Des5", "Designer5", 2000, 3, 0.9m, manager2);

            Designer designer6 = new Designer("Des6", "Designer6", 600, 1, 0.4m, manager2);

            Designer designer7 = new Designer("Des7", "Designer7", 1300, 2, 0.65m, manager2);

            Designer designer8 = new Designer("Des8", "Designer8", 700, 1, 0.8m, manager2);


            manager1.Team = new List<Employee>()
                {
                    new TestDeveloper(), new TestDeveloper(),
                    new TestDesigner(), new TestDesigner()
                };

            manager2.Team = new List<Employee>()
                {
                    developer8, developer9, developer10,
                    designer5, designer6, designer7, designer8
                };

            manager3.Team = new List<Employee>()
                {
                    new TestDeveloper(), new TestDeveloper(), new TestDeveloper(), new TestDeveloper(),
                    new TestDeveloper(), new TestDeveloper(), new TestDeveloper(),
                    new TestDesigner(), new TestDesigner(), new TestDesigner(), new TestDesigner(), new TestDesigner()
                };
        }

        [Test]
        public void AddEmployee_ShouldAdd_Designer1()
        {
            Designer designer9 = new Designer("Des9", "Designer9", 1200, 2, 0.95m);

            List<Employee> expectedEmployees = new List<Employee>();

            expectedEmployees.AddRange(manager2.Team);

            expectedEmployees.Add(designer9);

            manager2.AddTeamMember(designer9);

            Assert.IsTrue(expectedEmployees.SequenceEqual(manager2.Team));
        }

        [Test]
        public void RemoveEmployee_ShouldRemove_Developer9()
        {
            List<Employee> expectedEmployees = new List<Employee>();

            expectedEmployees.AddRange(manager2.Team);

            expectedEmployees.Remove(expectedEmployees[1]);

            manager2.RemoveTeamMember(manager2.Team[1]);

            Assert.IsTrue(expectedEmployees.SequenceEqual(manager2.Team));
        }

        [Test]
        public void CalculateSalary_When_Experience_1year_And_4PersonTeam_And_DevelopersEqualsHalf()
        {
            Assert.AreEqual(1000, (double)salaryCalculator.Calculate(manager1), 0.001);
        }

        [Test]
        public void CalculateSalary_When_Experience_3years_And_7PersonTeam_And_DevelopersLessThenHalf()
        {
            Assert.AreEqual(2900, (double)salaryCalculator.Calculate(manager2), 0.001);
        }

        [Test]
        public void CalculateSalary_When_Experience_6years_And_12PersonTeam_And_DevelopersMoreThenHalf()
        {
            Assert.AreEqual(6160, (double)salaryCalculator.Calculate(manager3), 0.001);
        }
    }
}