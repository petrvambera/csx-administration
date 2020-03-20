using DataAccess.Interface;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository() : base()
        {

        }



    }
}
