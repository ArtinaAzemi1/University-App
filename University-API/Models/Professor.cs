namespace University_API.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? BirthDate { get; set; }

        public string? Gender { get; set; }

        public string? City { get; set; }

        public string? Email { get; set; }

        public string? Photo { get; set; } = "professorPhoto.png";

    }
}
