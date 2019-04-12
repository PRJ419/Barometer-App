using System.ComponentModel.DataAnnotations;

namespace RESTClient.DTOs
{
    /// <summary>
    /// Transfer object for reviews
    /// </summary>
    public class ReviewDto
    {
        [Required]
        public int BarPressure { get; set; }

        [MaxLength(150)]
        public string BarName { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }
    }
}