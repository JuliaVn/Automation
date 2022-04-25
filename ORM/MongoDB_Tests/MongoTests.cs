using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_Tests.Model;
using NUnit.Framework;
using System.Linq;

namespace MongoDB_Tests
{
    public class Tests
    {
        private readonly string mongoServerAddress = "mongodb://localhost:27017";
        private readonly string dbName = "local";

        private const int year = 1900;

        [Test, Description("Validate that user ‘Harris’ has alignment ‘Evil’​")]
        public void UserHasAppropriateAlignment()
        {
            var client = new MongoClient(mongoServerAddress);
            IMongoDatabase db = client.GetDatabase(dbName);
            var usersCollection = db.GetCollection<User>("users");
            var alignmentCollection = db.GetCollection<Alignment>("alignments");
            var alignmentId = alignmentCollection.AsQueryable().First(a => a.AlignmentName.Equals("Evil")).ID;
            var alignmentIdOfUser = usersCollection.AsQueryable().Where(u => u.LastName.Equals("Harris")).First().AlignmentId;
            Assert.That(alignmentId.Equals(alignmentIdOfUser));
        }
        [Test, Description("Validate that All Alignments have at least one user that uses them")]
        public void AllAlignmentsHaveUser()
        {
            var client = new MongoClient(mongoServerAddress);
            IMongoDatabase db = client.GetDatabase(dbName);
            var usersCollection = db.GetCollection<User>("users");
            var alignmentCollection = db.GetCollection<Alignment>("alignments");
            var usersAlignmentID = usersCollection.AsQueryable().Select(u => u.AlignmentId).Distinct().ToList();
            var alignmentID = alignmentCollection.AsQueryable().Select(a => a.ID).ToList();
            Assert.IsTrue(alignmentID.All(id => usersAlignmentID.Contains(id)));
        }
        [Test, Description("Validate that there are ‘Neutral’ Alignments born after 1900")]
        public void NeutralAlignmentsBornAfterYear()
        {
            var client = new MongoClient(mongoServerAddress);
            IMongoDatabase db = client.GetDatabase(dbName);
            var usersCollection = db.GetCollection<User>("users");
            var alignmentCollection = db.GetCollection<Alignment>("alignments");
            var alignmentId = alignmentCollection.AsQueryable().First(a => a.AlignmentName.Equals("Neutral")).ID;
            var usersResult = usersCollection.AsQueryable().Where(user => user.AlignmentId == alignmentId)
                .Where(user => user.Year > year).Count();
            Assert.IsTrue(usersResult > 0);
        }
    }
}