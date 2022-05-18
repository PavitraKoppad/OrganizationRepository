using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EmployeeAttendanceConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           EmployeeManager empObj = new EmployeeManager();
           Console.WriteLine("Select any option from below list :");
           Console.WriteLine(" 1.Retrive Employee Details : \n 2.Update Employee Details \n 3.Apply for Leave \n 4.Update the attendance");
           int input = Convert.ToInt32(Console.ReadLine());
           switch(input)
           {
               case 1:
                   {
                       empObj.Retrieve();
                       break;
                   }
               case 2:
                   {
                       empObj.UpdateEmpDetails();
                       break;
                   }
               case 3:
                   {
                       empObj.ApplyForLeave();
                       break;
                   }
               case 4:
                   {
                       empObj.UpdateAttendance();
                       break;
                   }
               default:
                   Console.WriteLine("Unknown Command.");
                   break;
           }

 
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
        /*public static void ApplyforLeave()
             {
            SaveChanges();
                 Console.WriteLine("\n1:");
              var now = DateTime.Today;
               // string empId;
                // Console.WriteLine("\n Enter employee Id to apply for leave :");
                 // empId = Console.ReadLine();
    using (OrganizationDbContext db = new OrganizationDbContext())
    {
        Console.WriteLine("\nAdding Employee Leave :");
         Leave leave = new Leave();
         leave = db.Leaves.Where(d => d.emp_id == 101).First();
          leave.date = now;
          leave.LeaveType = "Casual Leave";
          db.Leaves.Add(leave);
        //Console.WriteLine("Status Before SaveChanges " + db.Entry(leave).State.ToString());   //Added
        db.SaveChanges();
        //Console.WriteLine("Status After SaveChanges  " + db.Entry(leave).State.ToString());  //Unchanged
        Console.WriteLine("\nAdded :");
    }

    Console.WriteLine("Press any key to continue ");
    Console.ReadKey();
   }

    public static override int SaveChanges()
    {
        try
        {
            return base.SaveChanges();
        }
        catch (DbEntityValidationException vex)
        {
            var exception = HandleDbEntityValidationException(vex);
            throw exception;
        }
        catch(DbUpdateException dbu)
        {
            var exception = HandleDbUpdateException(dbu);
            throw exception;
        }
    }

    private Exception HandleDbUpdateException(DbUpdateException dbu)
    {
        var builder = new StringBuilder("A DbUpdateException was caught while saving changes. ");

        try
        {
            foreach (var result in dbu.Entries)
            {
                builder.AppendFormat("Type: {0} was part of the problem. ", result.Entity.GetType().Name);
            }
        }
          catch (Exception e)
        {
            builder.Append("Error parsing DbUpdateException: " + e.ToString());
        }
    }
} */
