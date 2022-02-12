namespace Todo.DTO.DTOs.AppUserDTOs
{
    public class AppUserAddDto
    {
        //[Display(Name = "Kullanici Adi")]
        //[Required(ErrorMessage = "Kullanici adi bos gecilemez")]
        public string UserName { get; set; }

        //[Display(Name = "Parola")]
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Parola alani bos gecilemez")]
        public string Password { get; set; }

        //[Display(Name = "Parolanizi tekrar girinuz :")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Parolalar eslesmiyor")]
        public string ConfirmPassword { get; set; }

        //[Display(Name = "Email")]
        //[Required(ErrorMessage = "Email alani bos gecilemez")]
        public string Email { get; set; }

        //[Display(Name = "Adiniz")]
        //[Required(ErrorMessage = "Ad alani bos gecilemez")]
        public string Name { get; set; }

        //[Display(Name = "Soyadiniz")]
        //[Required(ErrorMessage = "Soyad alani bos gecilemez")]
        public string SurName { get; set; }

    }
}
