using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;
using System.Xml;

namespace TestAutomationCourse.Solutions.e07.Combo
{
    [TestFixture]
    public class PaulTests
    {
        string artist_name;
        string instrument;
        private bool paul_plays_bass = false;


        [Test]
        public void Paul_plays_bass()
        {
            XmlElement rootElement = getRootElement();
            var artist_list = rootElement.GetElementsByTagName("Artist");
            find_paul_in_xml(artist_list);
            Assert.That(paul_plays_bass, Is.True);

            // reset result
            paul_plays_bass = false;

            find_paul_in_json();
            Assert.That(paul_plays_bass, Is.True);
        }


        private XmlElement getRootElement()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(".//Exercises//e04.Xml//Beatles.xml");
            var root_element = xmlDoc.DocumentElement;

            return root_element;
        }

        private void find_paul_in_xml(XmlNodeList artist_list)
        {
            foreach (var artist in artist_list)
            {
                // get the artist element
                var artistElement = (XmlElement)artist;

                artist_name = artistElement.GetAttribute("name");

                // get the instrument
                XmlNode instrument_node = artistElement.GetElementsByTagName("Plays").Item(0);
                instrument = instrument_node.InnerText;

                if (artist_is_paul_and_plays_bass())
                {
                    paul_plays_bass = true;
                    break;
                }
            }
        }

        private void find_paul_in_json()
        {
            JArray jsonArtists = getJsonArtists();
            foreach (var jsonArtist in jsonArtists)
            {
                artist_name = (string)jsonArtist["Name"];
                instrument = (string)jsonArtist["Plays"];

                if (artist_is_paul_and_plays_bass())
                {
                    paul_plays_bass = true;
                    break;
                }
            }
        }


        private JArray getJsonArtists()
        {
            JToken jsonBeatles;
            using (var sr = new StreamReader(".//Exercises//e05.JSON//Beatles.json"))
            {
                var reader = new JsonTextReader(sr);
                jsonBeatles = JObject.Load(reader)["Beatles"];
            }
            JArray jsonArtists = (JArray)jsonBeatles["Artists"];
            return jsonArtists;
        }
        private bool artist_is_paul_and_plays_bass()
        {
            return artist_name.Equals("Paul McCartney") && instrument.Equals("Bass");
        }
    }

}
