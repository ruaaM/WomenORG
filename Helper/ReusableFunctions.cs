using WomenORG.DTOs;

namespace WomenORG.Helper
{
    public class ReusableFunctions
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReusableFunctions(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public GeneralResponseDTO FillGeneralResponseWithData(String? Message,
            Boolean isSuccess, int? ResponseCode, IEnumerable<string>? Errors)
        {
            return new GeneralResponseDTO
            {
                Message = Message,
                isSuccess = isSuccess,
                ResponseCode = ResponseCode,
                Errors = Errors
            };
        }
        public dynamic UploadImage(IFormFile formFile, string folderName)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            if (!String.IsNullOrEmpty(filePath))
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }
            return new 
            {
                FileName = uniqueFileName,
                FilePath = filePath,
            };

        }

    }
}
