using Microsoft.AspNetCore.Http;

namespace AcademyNet.Models
{
    // چیزی که قراره کاربر واقعا بفرسته سمت سرور
    //چون عکس ما دقیقا از نوع فایل هست بنابراین نمیتوان آن را از همان بیزینس انتیتی فرستاد و در مدل این کلاس را ساختیم
    public class Human
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public Role role { get; set; }
        public enum Role
        {
            Student, Teacher
        }
        public Gender gender { get; set; }
        public enum Gender
        {
            Male, Female
        }
        public IFormFile? Picture { get; set; }

    }
}
