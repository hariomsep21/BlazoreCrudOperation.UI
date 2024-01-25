﻿using NewDemo.Models.Model;

namespace NewDemo
{
    public partial class Student
    {

        IEnumerable<StudentModel> EmpObj;
        protected StudentModel student = new();

        protected override async Task OnInitializedAsync()
        {
            EmpObj = await _studentService.GetStudents();
        }

        

    }
}
