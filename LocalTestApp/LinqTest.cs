using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalTestApp
{
    class LinqTest
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee{ EmpId=1, Name="Adam_1", Salary=120, City="Chicago"},
            new Employee{ EmpId=1, Name="Adam_2", Salary=80, City="Chicago"},
            new Employee{ EmpId=1, Name="Adam_3", Salary=70, City="Chicago"},

            new Employee{ EmpId=1, Name="Scott_1", Salary=150, City="SFO"},
            new Employee{ EmpId=1, Name="Scott_2", Salary=140, City="SFO"},
            new Employee{ EmpId=1, Name="Scott_3", Salary=130, City="SFO"},

            new Employee{ EmpId=1, Name="BIll_1", Salary=100, City="Dallas"},
            new Employee{ EmpId=1, Name="Bill_2", Salary=90, City="Dallas"},
            new Employee{ EmpId=1, Name="Bill_3", Salary=80, City="Dallas"},

            new Employee{ EmpId=1, Name="Mike_1", Salary=130, City="Seattle"},
            new Employee{ EmpId=1, Name="Mike_2", Salary=125, City="Seattle"},
            new Employee{ EmpId=1, Name="Mike_3", Salary=120, City="Seattle"},
        };

        public void ListOfEmployees()
        {
            Console.WriteLine("List of all employees");
            employees.Print();
            Console.WriteLine();
        }

        public void GetTopPaidEmployees(int count)
        {
            Console.WriteLine("Get top-paid employees overall");
            //USING QUERY KEYWORDS
            var employee = (from e in employees
                            orderby e.Salary descending
                            select e).Take(count);

            //USING QUERY OPERATORS
            var employee2 = employees.OrderByDescending(e => e.Salary).Take(count);
            
            Console.WriteLine("::::USING QUERY KEYWORDS::::");
            employee.Print();
            Console.WriteLine();

            Console.WriteLine("::::USING QUERY OPERATORS::::");
            employee2.Print();
            Console.WriteLine();
        }

        public void GetTopPaidEmployeesByCity(int count)
        {
            Console.WriteLine("Get top-paid employees on each city");
            //USING QUERY KEYWORDS
            var employee = from emp in employees
                    group emp by emp.City into g
                    let salary = g.OrderByDescending(e => e.Salary).Take(count)
                    from emp in salary
                    select emp;

            Console.WriteLine("::::USING QUERY KEYWORDS::::");
            employee.Print();
            Console.WriteLine();

            //USING QUERY OPERATORS
            var groupEmp = employees.GroupBy(e => e.City);
            List<Employee> employee2 = new List<Employee>();
            foreach (var item in groupEmp)
            {
                employee2.AddRange(item.OrderByDescending(i => i.Salary).Take(count));
            }

            Console.WriteLine("::::USING QUERY OPERATORS::::");
            employee2.Print();
            Console.WriteLine();
        }

        public void AggregateTest()
        {
            Console.WriteLine("Get highest paid employee");
            var emp = employees.Aggregate((e1, e2) => e1.Salary > e2.Salary ? e1 : e2);
            Console.WriteLine(emp);
        }
    }

    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, City: {1}, Salary: {2}", Name, City, Salary);
        }
    }
}
