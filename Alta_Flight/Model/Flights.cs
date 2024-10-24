using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alta_Flight.Model
{
    public class Flights
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự sinh ID
        public int flight_ID { get; set; }
        public string route { get; set; }
        public string flight_no { get; set; }
        public DateTime departure_date {  get; set; }
        public string pound_of_loading {  get; set; }
        public string pound_of_unloading {  get; set; }
        public int? document_list_id { get; set; }

    }
}
