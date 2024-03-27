

public static class ImageValidation
{
    private static readonly List<string> AllowedImageExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif" };
    private const int MaxImageSizeInBytes = 5 * 1024 * 1024; // 5 MB

    public static bool IsImageValid(IFormFile file, out string errorMessage)
    {
        errorMessage = null;

        if (file == null || file.Length == 0)
        {
            errorMessage = "No file selected.";
            return false;
        }

        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!AllowedImageExtensions.Contains(fileExtension))
        {
            errorMessage = "Invalid file type. Only JPG, JPEG, PNG, and GIF images are allowed.";
            return false;
        }

        if (file.Length > MaxImageSizeInBytes)
        {
            errorMessage = "File size exceeds the limit. Maximum allowed size is 5 MB.";
            return false;
        }

        // You can perform additional validations here if required, such as image dimensions or aspect ratio.

        return true;
    }
}