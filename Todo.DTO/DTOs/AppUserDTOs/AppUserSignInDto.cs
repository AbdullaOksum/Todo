namespace Todo.DTO.DTOs.AppUserDTOs
{
    public class AppUserSignInDto
    {
        //[Display(Name = "Kullanici Adi")]
        //[Required(ErrorMessage = "Kullanici adi bos gecilemez")]
        public string UserName { get; set; }

        //[Display(Name = "Parola")]
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Parola alani bos gecilemez")]
        public string Password { get; set; }

        //[Display(Name = "Beni hatirla")]
        public bool RememberMe { get; set; }
    }
}
