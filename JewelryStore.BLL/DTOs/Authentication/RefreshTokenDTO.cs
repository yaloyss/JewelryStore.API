using System.ComponentModel.DataAnnotations;

namespace JewelryStore.BLL.DTOs.Authentication
{
	public class RefreshTokenDTO
	{
        //[Required]
        //public string AccessToken { get; set; }

        [Required(ErrorMessage = "Refresh token є is required")]
        public string RefreshToken { get; set; }
    }
}

