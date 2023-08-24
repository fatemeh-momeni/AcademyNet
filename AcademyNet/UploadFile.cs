namespace AcademyNet
{
    public class UploadFile
    {
        //از طریق پراپرتی یا ویژگی زیر می توان به اظلاعات هاست مانند آدرس و چیز های دیگر دسترسی داشته باشیم
        //  میتوان این پراپرتی را مقدار دهی و استفاده کردconstractor uplaodو در .

        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string Upload(IFormFile file)
        {
            if (file == null) return "";
            var path = _webHostEnvironment.WebRootPath + "\\images\\Human\\" + file.FileName;
            using var f = System.IO.File.Create(path);
            file.CopyTo(f);
            return file.FileName;
        }
    }
}
