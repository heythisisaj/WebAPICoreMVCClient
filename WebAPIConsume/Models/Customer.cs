using System.ComponentModel.DataAnnotations;



namespace WebAPIConsume.Models
{

    
    public class Customer
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Please put a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please put an address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please put a valid 10 digit telephone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Please put an email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
        public string Email { get; set; }
        
    }
}