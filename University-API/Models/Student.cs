using System.ComponentModel.DataAnnotations.Schema;

namespace University_API.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? Gender { get; set; }

        public string? City { get; set; }

        public string? Email { get; set; }

        public string? Photo { get; set; } = "studentPhoto.png";


    }
}
