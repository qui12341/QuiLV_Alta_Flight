using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alta_Flight.Model
{
    public class Configurations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int configuration_ID {  get; set; }
        public string document_Type {  get; set; }
        public DateTime createDate { get; set; }
        public string creator {  get; set; }
        public string note { get; set; }
        public int Permission_Id {  get; set; }
    }
}
