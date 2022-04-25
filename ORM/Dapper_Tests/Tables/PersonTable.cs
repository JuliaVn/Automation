using Dapper_Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Tests
{
    class PersonTable : BaseContext
    {
        public List<int> GetID()
        {
            var people = PerformQuery<Person>("SELECT * FROM Person");
            return people.Select(person => person.ID).ToList();
        }
    }
}
