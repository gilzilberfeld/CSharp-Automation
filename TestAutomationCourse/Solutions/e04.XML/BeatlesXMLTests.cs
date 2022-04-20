using NUnit.Framework;
using System.Xml;

namespace TestAutomationCourse.Solutions.e04.Xml
{
    internal class BeatlesXMLTests
    {
        private XmlDocument xmlDoc;
        private XmlElement root_element;

        [SetUp]
        public void Setup()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(".//Exercises//e04.Xml//Beatles.xml");
            root_element = xmlDoc.DocumentElement; 
        }

        [Test]
        public void There_are_four_artists()
        {
            var artist_list = root_element.GetElementsByTagName("Artist");
            Assert.That(artist_list.Count, Is.EqualTo(4));
        }

        [Test]
        public void Two_are_dead_and_two_are_alive()
        {
            var artist_list = root_element.GetElementsByTagName("Artist");
            int countAlive = 0;
            int countDead = 0;

            foreach (XmlElement artist in artist_list)
            {
                string isAliveText = artist.GetElementsByTagName("IsAlive").Item(0).InnerText;
                if (isAliveText.Equals("Yes"))
                    countAlive++;
                if (isAliveText.Equals("No"))
                    countDead++;
            }
            Assert.That(countAlive, Is.EqualTo( 2) );
            Assert.That(countDead, Is.EqualTo( 2) );

        }

        [Test]
        public void Ringo_plays_drums()
        {
            bool ringo_plays_drums = false;
            var artist_list = root_element.GetElementsByTagName("Artist");
            foreach (XmlElement artist in artist_list)
            {
                string name = artist.Attributes["name"].Value;
                if (name.Equals("Ringo Starr"))
                {
                    var plays_element = (XmlElement) artist.GetElementsByTagName("Plays").Item(0);
                    if (plays_element.InnerText.Equals("Drums"))
                        ringo_plays_drums = true;
                    break;
                }
            }
            Assert.That(ringo_plays_drums, Is.True);

        }

    }
}
