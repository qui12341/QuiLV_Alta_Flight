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

        public int phone { get; set; }

        public int role_id { get; set; }

        // group_id tùy chọn, không bắt buộc
        public int? group_id { get; set; }


    }
}
