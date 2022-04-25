using NUnit.Framework;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using Dapper_Tests.Models;
using System.Collections.Generic;

namespace Dapper_Tests
{
    public class Tests
    {
        private readonly string connStr = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";

        [Test, Description("​Validate that there are Persons who bought Cars NOT in their home City​")]
        public void PersonsWhoBoughtCarsNotInTheirCity​()
        {
            string query = "SELECT p.ID as PersonID, p.CityID as PersonCityID, b.CityID as BuyerCityID " +
                           "FROM Person p JOIN BuyersInfo b on p.ID = b.PersonID;";

            using (var connection = new SqlConnection(connStr))
            {
                var rows = connection.Query(query);
                var result = rows.Where(row => row.PersonCityID != row.BuyerCityID).Count();
                Assert.IsTrue(result > 0);
            }
        }
        [Test, Description("Validate that All Persons who bought cars are older than their BuyersInfo year​")]
        public void CheckBuyerInfoYearGreaterThanPersonYear()
        {
            string query = "SELECT p.ID, p.Year as PersonYear, b.Year as BuyerYear " +
                           "FROM Person p JOIN BuyersInfo b on p.ID = b.PersonID";

            using (var connection = new SqlConnection(connStr))
            {
                var rows = connection.Query(query);
                Assert.That(rows.All(row => row.BuyerYear > row.PersonYear));
            }
        }
        [Test, Description("​Validate that All Persons bought Cars​")]
        public void CheckAllPeopleBoughtCars()
        {
            var personID = new PersonTable().GetID();
            var infoPersonID = new BuyersInfoTable().GetPersonID();
            Assert.IsTrue(personID.All(id => infoPersonID.Contains(id)));
        }
    }
}