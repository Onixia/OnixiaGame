namespace Onixia.Models.ObjectTemplates
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Onixia.Models.PlayerAssets;
    /*
     * Ship class containing base template statistics for every ship buildable by the players.
     */
    public class Ship
    {
        [Key]
        public int Id { get; set; }

        public WeaponType WeaponType { get; set; }

        [Required]
        public float Armor { get; set; }

        [Required]
        public float Shield { get; set; }

        public float Damage { get; set; }

        [Required]
        public ResourceBank ShipCost { get; set; }

        public float Speed { get; set; }

        public float Range { get; set; }

        public TimeSpan BuildTime { get; set; }

        public int Cargo { get; set; }
    }

        /*
         * Enumeration containing different weapon types. 
         * Can be used for creating more dynamic loginc behind space battles.
         */
        ;
    public enum WeaponType
    {
        Laser,
        Rocket,
        Fragmentation
    }
}