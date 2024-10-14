using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alta_Flight.Model
{
    public class Account_Groups
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự sinh ID

        public int Id { get; set; }

        public int? accountID { get; set; }

        public int? group_id { get; set; }
    }
}
