using System.ComponentModel.DataAnnotations;

namespace Personal_Budgeting_Web_App.Models
{
    public class ExpenseModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(45, MinimumLength = 2, ErrorMessage = "The name must be between 2-45 characters long")]
        public string Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "The price must be at least $0.01")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(45, MinimumLength = 2, ErrorMessage = "The category must be between 2-45 characters long")]
        public string Category { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [StringLength(1024, MinimumLength = 0, ErrorMessage = "The description must be no longer than 1024 characters")]
        public string Description { get; set; }

        public enum MonthNames
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            Devember
        };
    }
}
