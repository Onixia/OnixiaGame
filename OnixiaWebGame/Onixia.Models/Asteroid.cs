namespace Onixia.Models
{
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Class used to denote the position of a mission.
    /// It also has a speed and it changes position over time.
    /// </summary>
    public class Asteroid : SpaceObject
    {
        public int Id { get; set; }
        public ResourceBank Resources { get; set; }
    }
}