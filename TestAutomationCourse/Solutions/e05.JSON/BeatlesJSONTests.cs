using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;

namespace TestAutomationCourse.Solutions.e05.JSON
{
    [TestFixture]
    internal class BeatlesJSONTests
    {
        private JToken jsonBeatles;

        [SetUp]
        public void Setup()
        {
            using (var sr = new StreamReader(".//Exercises//e05.JSON//Beatles.json"))
            {
                var reader = new JsonTextReader(sr);
                jsonBeatles = JObject.Load(reader)["Beatles"];
            }
        }

        [Test]
        public void There_are_four_artists()
        {
            JArray jsonArtists = (JArray)jsonBeatles["Artists"];
            Assert.That(jsonArtists.Count, Is.EqualTo(4));

        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
            int countAlive = 0;
            int countDead = 0;
            JArray jsonArtists = (JArray)jsonBeatles["Artists"];
            foreach (var artist in jsonArtists)
            {
                string isAliveText = (string) artist["IsAlive"];
                if (isAliveText.Equals("Yes"))
                    countAlive++;
                if (isAliveText.Equals("No"))
                    countDead++;
            }
            Assert.That(countAlive, Is.EqualTo(2));
            Assert.That(countDead, Is.EqualTo(2));

        }

        [Test]
        public void Ringo_plays_drums()
        {
            bool ringo_plays_drums = false;
            JArray jsonArtists = (JArray)jsonBeatles["Artists"];
            foreach (var artist in jsonArtists)
            {
                string name = (string) artist["Name"];
                string instrument = (string) artist["Plays"];
                if (name.Equals("Ringo Starr") && instrument.Equals("Drums"))
                {
                    ringo_plays_drums = true;
                    break;
                }
            }
            Assert.That(ringo_plays_drums, Is.True);

        }

    }
}
