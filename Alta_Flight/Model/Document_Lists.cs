using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alta_Flight.Model
{
    public class Document_Lists
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int document_list_id {  get; set; }
        public string document_name { get; set; }
        public DateTime createDate { get; set; }
        public float version { get; set; }
        public int accountID { get; set; }
        public int Permission_Id { get; set; }
        public int Update_Version_ID { get; set; }

        public int flight_ID {  get; set; }
        public int configuration_ID { get; set; }
    }
}
