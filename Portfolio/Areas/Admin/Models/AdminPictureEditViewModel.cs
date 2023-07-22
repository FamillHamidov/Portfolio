namespace Portfolio.Areas.Admin.Models
{
	public class AdminPictureEditViewModel
	{
        public int Id { get; set; }
        public string PictureUrl { get; set; } = null!;
		public IFormFile Picture { get; set; } = null!;
    }
}
