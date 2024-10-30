using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alta_Flight.Model
{
    public class Accounts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự sinh ID
        public int accountID { get; set; }

        [Required]
        public string name { get; set; }

        public string phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int role_id { get; set; }

        // group_id tùy chọn, không bắt buộc
        public int? group_id { get; set; }

    }
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Audience { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
