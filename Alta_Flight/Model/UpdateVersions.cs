using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alta_Flight.Model
{
    public class UpdateVersions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự sinh ID
        public int Update_Version_ID {  get; set; }
        public string Update_Version_Name {  get; set; }
        public string type {  get; set; }
        public DateTime date { get; set; }
        public int accountID { get; set; }


    }
}
