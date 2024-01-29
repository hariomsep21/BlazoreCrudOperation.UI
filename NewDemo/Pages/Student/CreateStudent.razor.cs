using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using NewDemo.Models.Model;
using NewDemo.Services.Interface;
using static System.Net.WebRequestMethods;
using System.ComponentModel.DataAnnotations;

namespace NewDemo.Pages.Student
{

    public partial class CreateStudent
    {
        [Parameter]
        public int studentId { get; set; }
        protected string Title = "Add";
        private StudentModel newStudent = new();

        protected override async Task OnParametersSetAsync()
        {
            if (studentId != 0)
            {
                Title = "Edit";
                try
                {
                    newStudent = await _studentService.GetById(studentId);
                    // Additional logic if needed...
                }
                catch (HttpRequestException ex)
                {
                    // Handle other types of exceptions if needed
                    Console.WriteLine($"HTTP request error: {ex.Message}");
                }

            }
        }

        private async Task CreateStudentRecord()
        {
            if (newStudent.Id != 0)
            {
                ServiceResponse res = await _studentService.Update(newStudent);

                if (res.Success)
                {
                    // Handle success (e.g., navigate to another page)
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    // Handle error (e.g., display error message)
                    Console.WriteLine($"Error: {res.Message}");
                }
            }
            else
            {

                ServiceResponse response = await _studentService.Create(newStudent);

                if (response.Success)
                {
                    // Handle success (e.g., navigate to another page)
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    // Handle error (e.g., display error message)
                    Console.WriteLine($"Error: {response.Message}");
                }
            }
        }

        private void ValidateField(object model, string propertyName)
        {
            var validationContext = new ValidationContext(model, null, null) { MemberName = propertyName };
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(model.GetType().GetProperty(propertyName)?.GetValue(model), validationContext, validationResults))
            {
                // Handle validation errors or update UI as needed
            }
        }

        private void ClearValidationMessage(object model, string propertyName)
        {
            // Clear validation error message when the user focuses on the input field
            typeof(StudentModel).GetProperty(propertyName)?.SetValue(model, null);
        }

        public void Cancel()
            {
                NavigationManager.NavigateTo("/");
            }

        }
    }


    

