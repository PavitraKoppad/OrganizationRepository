using System;
namespace EmployeeAttendanceConsoleApp
{
    interface IEmployeeManager
    {
        void ApplyForLeave();
        void UpdateAttendance();
        void Retrieve();
        void UpdateEmpDetails();
    }
}
