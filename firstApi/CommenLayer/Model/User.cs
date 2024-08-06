using System.ComponentModel.DataAnnotations;

namespace firstApi.CommenLayer.Model
{
    public class User
    {
        [Required(ErrorMessage = "Email is required")]
       // [RegularExpression(@"^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+$", ErrorMessage = "Email format invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "UserName cannot be null")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
       // [RegularExpression(@"^\+?(\d{1,3})?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?$", ErrorMessage = "PhoneNumber format invalid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
       // [RegularExpression(@"^(?i)(Male|Female|M|F)$", ErrorMessage = "Gender must be 'Male', 'Female', 'M', 'F', 'MALE', or 'FEMALE'")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a number greater than 0")]
        public int Salary { get; set; }
    }

    public class AddUserRequest : User { }

    public class AddUserResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class LoginRequest
    {
        [Required(ErrorMessage = "Email is required")]
       // [RegularExpression(@"^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+$", ErrorMessage = "Email format invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
