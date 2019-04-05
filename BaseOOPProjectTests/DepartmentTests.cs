using BaseOOPCompany;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BaseOOPProjectTests
{
    public class DepartmentTests
    {
        Department department;

        [SetUp]
        public void Setup()
        {
            Manager manager2 = new Manager("Man2", "Manager2", 1500, 1);

            Developer developer8 = new Developer("Dev8", "Developer8", 1000, 2, manager2);

            Developer developer9 = new Developer("Dev9", "Developer9", 1700, 3, manager2);

            Developer developer10 = new Developer("Dev10", "Developer10", 3000, 7, manager2);

            Designer designer5 = new Designer("Des5", "Designer5", 2000, 3, 0.9m, manager2);

            Designer designer6 = new Designer("Des6", "Designer6", 600, 1, 0.4m, manager2);

            manager2.Team = new List<Employee>()
                {
                    developer8, developer9, developer10,
                    designer5, designer6
                };

            department = new Department(new List<Manager> { manager2 });
        }

        [Test]
        public void PaySalary_ShouldOutput_AllEmployeesGotSalary()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                department.PaySalary();

                string expected = "Man2 Manager2: got salary: 1650,00"
                    + "\r\n" + "Dev8 Developer8: got salary: 1000,00"
                    + "\r\n" + "Dev9 Developer9: got salary: 1900,00"
                    + "\r\n" + "Dev10 Developer10: got salary: 4100,00"
                    + "\r\n" + "Des5 Designer5: got salary: 1980,00"
                    + "\r\n" + "Des6 Designer6: got salary: 240,00" + "\r\n";

                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void AccureSalary_ShouldOutput_Manager2GotSalary()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                department.AccrueSalary(department.Managers[0]);

                string expected = "Man2 Manager2: got salary: 1650,00" + "\r\n";

                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [Test]
        public void AddManager_ShouldAdd_Manager1()
        {
            Manager manager1 = new Manager("Man1", "Manager1", 4000, 6);

            department.AddManager(manager1);

            List<Manager> expectedManagers = department.Managers;

            expectedManagers.Add(manager1);

            Assert.IsTrue(expectedManagers.SequenceEqual(department.Managers));
        }

        [Test]
        public void RemoveManager_ShouldRemove_Manager2()
        {
            Manager manager1 = new Manager("Man1", "Manager1", 4000, 6);

            Manager manager3 = new Manager("Man3", "Manager3", 2500, 3);

            department.Managers.AddRange(new List<Manager> { manager1, manager3 });

            department.RemoveManager(department.Managers[0]);

            List<Manager> expectedManagers = new List<Manager> { manager1, manager3 };

            Assert.IsTrue(expectedManagers.SequenceEqual(department.Managers));
        }
    }
}