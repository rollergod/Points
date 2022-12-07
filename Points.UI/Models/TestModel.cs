using Points.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.UI.Models
{
    public class TestModel
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
