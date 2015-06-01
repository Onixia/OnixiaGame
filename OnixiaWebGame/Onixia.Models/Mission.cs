namespace Onixia.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    class Mission
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public TimeSpan MissionLength { get; set; }
        public virtual ResourceBank ResourceReward { get; set; }
        public MissionType Type { get; set; }
    }

    enum MissionType
    {
        Attack, // Engage in battle with another 
        Astromining, // Send Probe to asteroid for gas.
        Transport, // Transport resources from one planet to another.
        Espionage, // Send a spy to another player's planet to steal a technology.
        Colonisation, // Send a special unit to colonise another planet for the player to control
        Restationing // Move ships from one planet to another
    }
}
