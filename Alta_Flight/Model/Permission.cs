using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alta_Flight.Model
{
    public class Permission
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự sinh ID
        public int Permission_Id { get; set; }
        public string Permission_Name { get; set; }
        public int group_id { get; set; }
    }
}
