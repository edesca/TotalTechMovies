using System;
using System.Collections.Generic;
using System.Text;

namespace TotalTechMovies.Models
{

    public class Popular
    {
        public int page { get; set; }
        public Result[] results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

}
