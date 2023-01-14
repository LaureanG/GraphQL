using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    public class Platform
    {
        [KeyAttribute]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string? LicenseKey { get; set; }

    }
}