using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DotnetCoreTDDTests.LINQ
{
    class JoinTests
    {
        /// <summary>
        /// 公司
        /// </summary>
        public class Company
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        /// <summary>
        /// 員工
        /// </summary>
        public class Employee
        {
            public int CompanyID { get; set; }
            public string Name { get; set; }
        }

        private List<Company> _companies;
        private List<Employee> _employees;

        [SetUp()]
        public void Init()
        {
            _companies = new List<Company>
            {
                new Company { ID=1, Name="A公司" },
                new Company { ID=2, Name="B公司" },
                new Company { ID=3, Name="C公司" },
            };

            _employees = new List<Employee> 
            { 
                new Employee { CompanyID=1, Name="小明" },
                new Employee { CompanyID=1, Name="小王" },
                new Employee { CompanyID=1, Name="小美" },
                new Employee { CompanyID=2, Name="小鐘" },
                new Employee { CompanyID=2, Name="小傑" },
            };
        }

        [Test()]
        public void InnerJoinTest()
        {
            var query = (from employee in _employees
                        join company in _companies on employee.CompanyID equals company.ID
                        where employee.Name is "小明"
                        select new
                        {
                            Name = employee.Name,
                            CompanyName = company.Name,
                            CompanyID = company.ID
                        }).FirstOrDefault();

            Assert.AreEqual("A公司", query.CompanyName);
        }

        [Test()]
        public void LeftOuterJoinTest()
        {
            Assert.True(true, "未完成");
        }

        [Test()]
        public void RightOuterJoinTest()
        {
            Assert.True(true, "未完成");
        }
    }
}
