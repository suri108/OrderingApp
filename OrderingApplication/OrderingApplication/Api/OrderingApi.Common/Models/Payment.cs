using System.ComponentModel.DataAnnotations;

namespace OrderingApi.Common.Models
{
    public class Payment
    {
        [Required]
        public string Selection { get; set; }
    }
}