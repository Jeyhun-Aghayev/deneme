namespace hacaton.ViewModels.Profile
{
    public class UpdateProfileVM
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Paswword { get; set; } = null!;
        public string Image { get; set; }

        public IFormFile? Photo { get; set; }
    }
}
