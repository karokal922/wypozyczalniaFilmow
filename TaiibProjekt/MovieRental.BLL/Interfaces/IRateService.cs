using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Interfaces
{
    public interface IRateService
    {
        public IEnumerable<object> GetAverageRatePerMovie();
        public IEnumerable<object> GetAverageRatePerUser();
    }
}
