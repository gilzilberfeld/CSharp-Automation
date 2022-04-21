using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using TestAutomationCourse.Demos.d02.XML;

namespace TestAutomationCourse.Solutions.d04.Serialization
{
    [TestFixture]
    internal class XMLSerializationTests
    {
        Person person;

        [SetUp]
        public void Setup()
        {
            XmlSerializer serializer =
                 new XmlSerializer(typeof(Person));

            using (TextReader reader = new StringReader(XMLExamples.GetPersonXML()))
            {
                person = (Person)serializer.Deserialize(reader);
            }
        }

        [Test]
        public void First_name_is_joe()
        {
            Assert.That(person.FirstName, Is.EqualTo("Joe"));
        }

        [Test]
        public void Joe_has_three_children()
        {
            Assert.That(person.Children.Child.Count, Is.EqualTo(3));
        }

        [Test]
        public void Second_child_name_is_jim()
        {
            Assert.That(person.Children.Child[1].name, Is.EqualTo("Jim"));
        }
    }
}