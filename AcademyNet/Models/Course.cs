using Business_Entity;

namespace AcademyNet.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public float TotalTime { get; set; }
        public string Descript { get; set; }
        public IFormFile VideoIntro { get; set; }
        public string VideoUrl { get; set; }
        public float Price { get; set; }
        public List<int> teachers { get; set; }
        
    }
}
