namespace Onixia.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    class Mission
    {
        [Required]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan MissionLength { get; set; }
        public ResourceBank ResourceReward { get; set; }
        public User Player { get; set; }
        public bool IsCompleted { get; set; }
    }
}
