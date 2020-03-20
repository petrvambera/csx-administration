using DataAccess.Model;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        public DriverRepository() : base()
        {

        }
    }
}
