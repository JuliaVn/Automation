using EF.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Tests
    {
        [Test, Description("​Validate that there are Persons who bought Cars NOT in their home City​")]
        public void PersonsWhoBoughtCarsNotInTheirCity​()
        {
            using (var context = new MasterContext())
            {
                var result = context.BuyersInfoes.Where(row => row.CityID != row.Person.CityID).Count();
                Assert.IsTrue(result > 0);
            }
        }
        [Test, Description("Validate that All Persons who bought cars are older than their BuyersInfo year​")]
        public void CheckBuyerInfoYearGreaterThanPersonYear()
        {
            using (var context = new MasterContext())
            {
                var years = context.BuyersInfoes.Select(year => new { infoYear = year.Year, personYear = year.Person.Year }).ToList();
                Assert.That(years.All(year => year.infoYear > year.personYear));
            }
        }
        [Test, Description("​Validate that All Persons bought Cars")]
        public void CheckAllPeopleBoughtCars()
        {
            using (var context = new MasterContext())
            {
                var personID = context.People.Select(person => person.ID).ToList();
                var personIDInfo = context.BuyersInfoes.Select(info => info.PersonID).Distinct().ToList();
                Assert.IsTrue(personID.All(id => personIDInfo.Contains(id)));
            }
        }
        static void Main() {}
    }
}
