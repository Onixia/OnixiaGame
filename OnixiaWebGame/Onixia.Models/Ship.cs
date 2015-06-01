using System;

namespace Onixia.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Ship
    {
        [Key]
        public int Id                        { get; set; }
        public WeaponType WeaponType         { get; set; }
        [Required]
        public float Armor                   { get; set; }
        [Required]
        public float Shield                  { get; set; }
        public float Damage                  { get; set; }
        public virtual ResourceBank ShipCost { get; set; }
        public float Speed                   { get; set; }
        public float Range                   { get; set; }
        public TimeSpan BuildTime            { get; set; }
        public int Cargo                     { get; set; }
    }

    public enum WeaponType
    {
        Laser,
        Rocket,
        Fragmentation
    }
}