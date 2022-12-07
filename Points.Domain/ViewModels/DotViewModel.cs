using System.Collections.Generic;

namespace Points.Domain.ViewModels
{
    public class DotViewModel
    {
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float Radius { get; set; }
        public string Color { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}