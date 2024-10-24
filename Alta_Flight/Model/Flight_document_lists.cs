using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alta_Flight.Model
{
    public class Flight_document_lists
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int flight_document_lists {  get; set; }
        public int document_list_id { get; set; }
        public int flight_ID { get; set; }

    }
}
