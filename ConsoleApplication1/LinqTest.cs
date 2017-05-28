using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class LinqTest
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        List<string> countries = new List<string>() { "India", "USA", "UK" };
        public void Print()
        {
            // Find all even number
            var evenNumbers = numbers.Where(x => x % 2 == 0);

            //Sum of all the numbers
            var total = numbers.Sum();

            //Sum of all even numbers
            var sumOfEven = numbers.Where(x => x % 2 == 0).Sum();

            //Count of numbers
            var count = numbers.Count();

            //Average of numbers
            var average = numbers.Average();

            // Min of numbers
            var min = numbers.Min();

            // Max of Numbers
            var max = numbers.Max();

            //Aggerate or concatenation of numbers
            var aggerate = numbers.Aggregate((a, b) => a * b); //1*2*3*4--so on

            //Aggerate for concatenation
            var concatenation = countries.Aggregate((a, b) => a + ", " + b);

            //Print each even number with their index
            var result = numbers.Select((number, index) => new { Number = number, Index = index }).Where(x => x.Number % 2 == 0);

            Employee employee = new Employee();

            //Select can be used different column or return anonymus object here (new) keyword is the projection operator.
            //Select employee id
            var employeeIds = employee.Employees.Select(emp => emp.Id);

            // Select employee firstname and lastname as anonymus object.
            var employeeDetails = employee.Employees.Select(emp => new { EmployeeFirstName = emp.FirstName, EmployeeLastName = emp.LastName });

            // SelectMany convert List<List<object> to single List<Object> note that return type is IEnumberable<string>
            // Use distinct for distinct records.
            var subjects = employee.Employees.SelectMany(emp => emp.Subjects).Distinct();

            //it can also be written as
            var subjectss = (from emp in employee.Employees
                             from subject in emp.Subjects
                             select subject).Distinct();

            string[] stringArray = { "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "0123456789" };
            var dt = stringArray.SelectMany(s => s);//It will concate two string and return IEnumberable<char>
            var st = from s in stringArray
                     from c in s
                     select c;

            //Employee name with Subject
            // Pankaj -Subject1
            // Pankaj -Subject2 etc
            var employeeWithSubject = employee.Employees.SelectMany(emp => emp.Subjects, (emp1, subject) => new { Name = emp1.FirstName, Subject = subject });
            var sqlLikeSyntax = from emp in employee.Employees
                                from subject in emp.Subjects
                                select new { Name = emp.FirstName, Subject = subject };

            //oderby
            var orderBy = employee.Employees.OrderBy(x => x.Id);
            var orderBySql = from emplo in employee.Employees
                             orderby emplo.Id
                             select emplo;
            //decending order
            var orderByDesc = employee.Employees.OrderByDescending(x => x.Id);
            var orderByDescSql = from emp1 in employee.Employees
                                 orderby emp1.Id descending
                                 select emp1;

            var orderByThenby = employee.Employees.OrderBy(x => x.Id).ThenBy(x => x.FirstName).ThenByDescending(x => x.LastName);
            var descByThenBy = from emp2 in employee.Employees
                               orderby emp2.Id, emp2.FirstName descending, emp2.LastName ascending
                               select emp2;

            //Reverse
            employee.Employees.Reverse();

            //Take
            var takeEmployee = employee.Employees.Take(2);
            var takeEmployeeSql = (from emp in employee.Employees
                                   select emp).Take(3);

            //skip will skip first employee return rest of employee
            var skipEmployee = employee.Employees.Skip(1);

            //TakWhile/skipwhile is conditional
            var takeWhile = employee.Employees.TakeWhile(x => x.FirstName.Length > 3);

            //skip until is condition met.
            var skipWhile = employee.Employees.SkipWhile(x => x.Id > 1);

            //Reterive records page wise
            int pageSize = 3;
            int pageNumber = 1;
            var pageRecords = employee.Employees.Skip((pageNumber - 1) * pageSize).Take(3); //it will display with 3 employees

            //Deferred excuetion , here the query will be executed when actually we are trying to use records form deferredQuer i.e.
            // foreach(var item in defredquery). So where,select ,take, while etc are deffered operators.
            var deferredQuery = employee.Employees.Where(x => x.Id > 2);

            //Eager execution , Tolist,Count,Min,Max,Average are the eager operators if we use any of the these query will be executed instantly.
            var egerQuery = employee.Employees.Where(x => x.Id > 2).ToList();

            //Dictonary vs ToLookup
            //BOth are are same as both contain key value pair, but in dictinary key should be unique while in tolookup uniqueness of key is not necessary
            var dictonaryEmp = employee.Employees.ToDictionary(x => x.Id, x => x.FirstName);
            var dictonrayEmpValueAsEmployeeObject = employee.Employees.ToDictionary(x => x.Id); //.ToDictonary(x=>x.Id,x=>x)

            var lookupEmp = employee.Employees.ToLookup(x => x.FirstName);


            //cast vs ofType , cast throw expecion if any of type is not match while converting, while ofType don't include the type in the result
            //list if type is not matched.
            var castEmp = employee.Employees.Select(x => x.Id).Cast<int>();

            var ofTypeEmp = employee.Employees.Select(x => x.Id).OfType<int>();

            //Group By
            var groupBy = employee.Employees.GroupBy(x => x.LastName);

            //find employee whose grouping count is greater than 1, we can also apply max,min,average,aggerate.
            foreach (var grup in groupBy)
            {
                System.Console.WriteLine(grup.Count(x => x.FirstName == "Pankaj"));
            }

            //order in group
            var groupbyOrder = from emp in employee.Employees
                               group emp by emp.LastName into grupName
                               orderby grupName.Key
                               select new
                               {
                                   Key = grupName.Key,
                                   Employee = grupName.OrderBy(x => x.FirstName)
                               };
            //group employee by First and LastName and then sort employees result with firstname then with lastname and later sort employee with id
            var groupByMulitpleColumn = employee.Employees.GroupBy(x => new { x.LastName, x.FirstName })
                                        .OrderBy(x => x.Key.FirstName).ThenBy(y => y.Key.LastName)
                                        .Select(x => new
                                        {
                                            EmpFirstName = x.Key.FirstName,
                                            LastName = x.Key.LastName,
                                            Employee = x.OrderBy(y => y.Id)
                                        });
            var grupsl = from emp in employee.Employees
                         group emp by new { emp.FirstName, emp.LastName } into egroup
                         orderby egroup.Key.FirstName, egroup.Key.LastName
                         select new
                         {
                             FirstNameEmp = egroup.Key.FirstName,
                             LastNameEmp = egroup.Key.LastName,
                             Employee = egroup.OrderBy(x => x.Id)

                         };




            var groupBySql = from emp in employee.Employees
                             group emp by emp.LastName;
            var groupbymulitpeSql = from emp in employee.Employees
                                    group emp by new { emp.LastName, emp.FirstName };

            var students = new Student();

            //Join in Linq
            var join = from emp in employee.Employees
                       join student in students.Students
                       on emp.Id equals student.EmployeeId
                       select new
                       {
                           Employee = emp,
                           Student = student
                       };
            //cross join
            var crossjoin = from emp in employee.Employees
                            from student in students.Students
                            select new { emp, student };

            //group or outer join
            var outerJoin = from emp in employee.Employees
                            join student in students.Students
                            on emp.Id equals student.EmployeeId into egroup
                            select new { emp, students }
                           ;

            //left join
            var leftJoin = from emp in employee.Employees
                           join student in students.Students
                           on emp.Id equals student.EmployeeId into egroup
                           from student in egroup.DefaultIfEmpty()
                           select new { emp, students }
                           ;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }

        public List<Student> Students { get; set; }

        public Student()
        {
            Students = new List<Student>() { new Student() { Id = 1, Name = "Name1", EmployeeId = 1 }, new Student() { Id = 2, Name = "Name2", EmployeeId = 2 } };
        }
    }
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Subjects { get; set; }
        public List<Employee> Employees { get; set; }

        public Employee()
        {
            Subjects = new List<string>();
            Employees = new List<Employee>() { new Employee() { Id = 1, FirstName = "Pankaj", LastName = "Kakkar", Subjects = new List<string>() { "Subject1", "Subject2" } }, new Employee() { Id = 2, FirstName = "Manish", LastName = "Kakkar", Subjects = new List<string>() { "Subject3", "Subject4" } } };
        }
    }
}
