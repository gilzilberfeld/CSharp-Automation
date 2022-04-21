using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;

namespace TestAutomationCourse.Exercises.e05.JSON
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
                jsonBeatles = JObject.Load(reader);
            }
        }

        [Test]
        public void There_are_four_artists()
        {

        }

        [Test]
        public void two_are_dead_and_two_are_alive()
        {

        }

        [Test]
        public void ringo_plays_drums()
        {

        }

    }
}
