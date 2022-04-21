using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestAutomationCourse.Solutions.d04.Serialization
{
    [TestFixture]
    internal class JSONSerializationTests
    {
        Album album;

        [SetUp]
        public void Setup()
        {
            string json = File.ReadAllText(".//Exercises//e05.JSON//Beatles.json");
            album = JsonConvert.DeserializeObject<Album>(json);
        }

        [Test]
        public void There_are_four_artists()
        {
            Assert.That(album.beatles.artists.Length, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
            IEnumerable<Artist> artists = album.beatles.artists;
            int dead_count = artists.Count(artist => artist.isAlive == "No");
            int live_count = artists.Count(artist => artist.isAlive == "Yes");
            Assert.That(dead_count, Is.EqualTo(2));
            Assert.That(live_count, Is.EqualTo(2));
        }

        [Test]
        public void Ringo_plays_drums()
        {
            IEnumerable<Artist> artists = album.beatles.artists;
            var ringo = album.beatles.artists
                .First(artist => artist.name == "Ringo Starr");
            Assert.That(ringo.plays.ToLower, Is.EqualTo("drums"));
        }


    }
}
