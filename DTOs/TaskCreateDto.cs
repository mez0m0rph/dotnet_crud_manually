namespace project
{
    public class TaskCreateDto
    {
        [Required(ErrorMessage = "Заголовок обязателен")]
        [MaxLength(200, ErrorMessage = "Максимум 200 символов")]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
