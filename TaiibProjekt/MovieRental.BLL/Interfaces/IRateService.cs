using MovieRental.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Interfaces
{
    public interface IRateService
    {
        public IEnumerable<MovieRatingResult> GetAverageRatePerMovie();
        public IEnumerable<UserRatingResult> GetAverageRatePerUser();
    }
}
