using Dapper_Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Tests
{
    class BuyersInfoTable : BaseContext
    {
        public List<int> GetPersonID()
        {
            var buyersInfo =  PerformQuery<BuyersInfo>("SELECT * FROM BuyersInfo");
            return buyersInfo.Select(info => info.PersonID).Distinct().ToList();
        }
    }
}
