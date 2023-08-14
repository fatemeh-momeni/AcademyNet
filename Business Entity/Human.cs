namespace Business_Entity
{
    public class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Role { get; set;}
        public string Email  { get; set; }
        public string Password { get; set; }
        public Gender gender { get; set; }
        public enum Gender
        {
            Male,Female
        }
        public string Picture { get; set; }

    }
}