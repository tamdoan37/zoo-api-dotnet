using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZooApi.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Health { get; set; } = string.Empty;

        [JsonPropertyName("location")]

        public AnimalLocation Location { get; set; }

        [JsonPropertyName("feeding schedule")]
        public FeedingSchedule FeedingSchedule { get; set; }

        [JsonPropertyName("maintenance record")]
        public MaintenanceRecord MaintenanceRecord { get; set; }
    }

    public class AnimalLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class FeedingSchedule
    {
        public string Time { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }

    public class MaintenanceRecord
    {
        public string Date { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;
    }
}