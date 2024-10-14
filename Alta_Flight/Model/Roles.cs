using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alta_Flight.Model
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int role_id { get; set; } // ID của vai trò
        public string role_name { get; set; } // Tên của vai trò
    }
}
