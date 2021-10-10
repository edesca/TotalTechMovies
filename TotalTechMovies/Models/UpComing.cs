using System;
using System.Collections.Generic;
using System.Text;

namespace TotalTechMovies.Models
{

    public class UpComing
    {
        public int page { get; set; }
        public Result[] results { get; set; }
        public Dates dates { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

    public class Dates
    {
        public string maximum { get; set; }
        public string minimum { get; set; }
    }


}
