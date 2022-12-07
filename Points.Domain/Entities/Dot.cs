using System.Collections.Generic;

namespace Points.Domain.Entities
{
    public class Dot
    {
        public int Id { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float Radius { get; set; }
        public string Color { get; set; }
        public List<Comment> Comments { get; set; }
    }
}