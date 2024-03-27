namespace WomenORG.DTOs
{
    public class GeneralResponseDTO
    {
        public String? Message { get; set; }
        public Boolean isSuccess { get; set; }
        public int? ResponseCode { get; set; }
        public IEnumerable<string>? Errors { get; set; }

    }
}
