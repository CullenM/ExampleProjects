using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.CherwellQuestion
{
    public class Triangle
    {
        public string Text { get; set; }
        
        public int Row { get; set; }

        public int Column { get; set; }

        public List<Tuple<int, int>> GetPoints()
        {
            List<Tuple<int, int>> points = new List<Tuple<int, int>>();

            if ((Column+1) % 2 == 0)
            {
                points.Add(new Tuple<int, int>(((Column+1) / 2) * 10, Row * 10));
            }
            else
            {
                points.Add(new Tuple<int, int>(((Column / 2) * 10), (Row + 1) * 10));
            }
            points.Add(new Tuple<int, int>((Column/2) * 10, Row * 10));          
            points.Add(new Tuple<int, int>(((Column/2) + 1) * 10, (Row+1) * 10));

            return points;
        }
    }
}
