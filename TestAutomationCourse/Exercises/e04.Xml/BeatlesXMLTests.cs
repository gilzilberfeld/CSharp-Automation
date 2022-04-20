using NUnit.Framework;
using System.Xml;

namespace TestAutomationCourse.Exercises.e04.Xml
{
    internal class BeatlesXMLTests
    {
        private XmlDocument doc;

        [SetUp]
        public void Setup()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(".//Exercises//e04.Xml//Beatles.xml");
        }

        [Test]
        public void There_are_four_artists()
        {
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {

        }

        [Test]
        public void Ringo_plays_drums()
        {

        }

    }
}
