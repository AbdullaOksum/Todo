namespace Todo.DTO.DTOs.AppUserDTOs
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Ad alani bos gecilemez")]
        //[Display(Name = "Ad")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Soy alani bos gecilemez")]
        //[Display(Name = "Soyad")]
        public string SurName { get; set; }
        //[Display(Name = "Email")]
        public string Email { get; set; }
        //[Display(Name = "Resim")]
        public string Picture { get; set; }
    }
}
