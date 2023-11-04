using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ClientInfo
    {
        public int Id { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string ClientName { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsProcessed { get; set; } = false;

        public override string ToString()
        {
            return
                $"His/Her name: {ClientName}\n" +
                $"Phone number: {PhoneNumber}\n" +
                $"Theme of the dialog: {Description}";
        }
    }
}
