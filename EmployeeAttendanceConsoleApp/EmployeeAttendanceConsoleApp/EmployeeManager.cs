using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeAttendanceConsoleApp
{
    class EmployeeManager : EmployeeAttendanceConsoleApp.IEmployeeManager
    {
        public void ApplyForLeave()
        {
            using (var db = new OrganizationDbContext())
            {
                try
                {
           
                    int maxId, empId, managerId;
                    string leaveType, dt; 
                    Console.WriteLine("\nEnter employee Id to apply for leave :");
                    empId = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nApply leave for any date for above employee :");
                    Console.WriteLine("\nId :");
                    maxId = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nmanagerId :");
                    managerId = int.Parse(Console.ReadLine());
                    Console.Write("Leave Type:");
                    leaveType = Console.ReadLine();
                    Console.Write("Date :");
                    dt = Console.ReadLine();


                    /*var maxId = from row in db.Leaves
                                 group row by true into r
                                 select new
                                 {
                                     max = r.Max(z => z.id)
                                 };
                    */

                    Leave objLeave = new Leave() { id =maxId, emp_id = empId, date = dt, manager_id = managerId, LeaveType = leaveType };
                    db.Leaves.Add(objLeave);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            
        }

        public void UpdateEmpDetails()
        {
          using (var db = new OrganizationDbContext())
            {
            try
            {
                int empId, salary;
                string empName, gender;
                Console.WriteLine("\nEnter employee Id for attendance update :");
                empId = int.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter Employee Details for Empoyee Id {0} :", empId);
                Console.Write("Employee Name :");
                empName = Console.ReadLine();
                Console.Write("Salary:");
                salary = int.Parse(Console.ReadLine());
                Console.Write("Gender :");
                gender = Console.ReadLine();

                var query = from empDetails in db.Employees
                            orderby empDetails.employee_name
                            select empDetails;
                //Console.WriteLine("Employee Details in DB");
                foreach (Employee fullDetails in query)
                {
                    if (fullDetails.emp_id == empId)
                    { 
                        fullDetails.emp_id = empId;
                        fullDetails.employee_name = empName;
                        fullDetails.salary = salary;
                        fullDetails.gendar = gender;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //Console.WriteLine("Status Before SaveChanges " + db.Entry(db.Employees).State.ToString());   //Added
            db.SaveChanges();
            //Console.WriteLine("Status After SaveChanges  " + db.Entry(db.Employees).State.ToString());  //Unchange
        } 
    }

        public void UpdateAttendance()
        {
            using (var db = new OrganizationDbContext())
            {
                try
                {
                    int empId, id;
                    string attdnce, dt;
                    Console.WriteLine("\nEnter attendance Id for attendance update :");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nEnter employee Id for attendance update :");
                    empId = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nEnter attendance for any date for Emp Id {0} :", empId);
                    Console.Write("Present or Absent:");
                    attdnce = Console.ReadLine();
                    Console.Write("Date :");
                    dt = Console.ReadLine();

                    var query2 = from attendanceDetails in db.Attendances
                                 select attendanceDetails;

                    foreach (Attendance details in query2)
                    {
                        if (details.emp_id == empId && details.id == id)
                        {
                            details.attendance1 = attdnce;
                            details.date = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                //Console.WriteLine("Status Before SaveChanges " + db.Entry(db.Attendances).State.ToString());   //Added
                db.SaveChanges();
                //Console.WriteLine("Status After SaveChanges  " + db.Entry(db.Attendances).State.ToString());  //Unchange
            }
        }

        public void Retrieve()
        {
            using (var db = new OrganizationDbContext())
            {
                //var empl = db.Employees.Include(e => e.Leaves);
                //Console.WriteLine(empl.ToList());
                string EmpName;
                Console.WriteLine("Enter employee Name :");
                EmpName = Console.ReadLine();

                var query = from empDetails in db.Employees
                            orderby empDetails.employee_name
                            select empDetails;

                Console.WriteLine("Employee Details in DB");
                foreach (Employee fullDetails in query)
                {
                    if (fullDetails.employee_name == EmpName)
                    {
                        Console.Write("Employee Id: " + fullDetails.emp_id + ", Employee Name: " + fullDetails.employee_name + ", Employee Salary: " + fullDetails.salary + ", Employee Gender: " + fullDetails.gendar);
                    }
                }
            }
        }
    }
}
