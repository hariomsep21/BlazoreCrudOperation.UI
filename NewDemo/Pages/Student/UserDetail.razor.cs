using Microsoft.AspNetCore.Components;
using NewDemo.Models.Model;
using NewDemo.Services.Service;
using static System.Net.WebRequestMethods;

namespace NewDemo.Pages.Student
{
    public partial class UserDetail
    {
        [Parameter]
        public int StudentId { get; set; }
        StudentModel student = new ();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                student = await _studentService.GetById(StudentId);
                // Additional logic if needed...
            }
            catch (HttpRequestException ex)
            {
                // Handle other types of exceptions if needed
                Console.WriteLine($"HTTP request error: {ex.Message}");
            }
        }

        protected async Task RemoveUser(int userID)
        {
            try
            {
                var deletedStudent = await _studentService.Delete(userID);

                if (deletedStudent != null)
                {
                    // Handle success (e.g., navigate to another page)
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    // Handle error (e.g., display error message)
                    Console.WriteLine("Student not found or deletion failed.");
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle other types of exceptions if needed
                Console.WriteLine($"HTTP request error: {ex.Message}");
            }
        }


        void Cancel()
        {
            NavigationManager.NavigateTo("/");
        }

    }
}
