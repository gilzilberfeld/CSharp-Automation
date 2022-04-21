using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Linq;

namespace TestAutomationCourse.Solutions.e07.Combo
{
    [TestFixture]
    public class MCUTests
    {
        [Test]
        public void mcu_films()
        {
            MCU mcu = new MCU();
            mcu.AddMovie(new Movie("Thor").withCharacter("Thor"));
            mcu.AddMovie(new Movie("Captain America - The First Avenger").withCharacter("Cap"));
            mcu.AddMovie(new Movie("Black Widow").withCharacter("Black Widow"));
            mcu.AddMovie(new Movie("The Avengers")
                    .withCharacter("Thor")
                    .withCharacter("Cap")
                    .withCharacter("Black Widow")
                    .withCharacter("Hawkeye")
                    .withCharacter("Hulk")
                    .withCharacter("Iron Man"));

            string json = JsonConvert.SerializeObject(mcu);

            Assert.That(json, Does.Contain("Cap"));
            Assert.That(json, Does.Contain("Hawkeye"));
            Assert.That(json, Does.Not.Contain("Ant-Man"));

            //// the last one is not exact
            var jsonModel = JObject.Parse(json);
            var jsonAvengers = jsonModel["movies"][3];
            var jsonCharacers = jsonAvengers["characters"];

            int ant_man_count = jsonCharacers.Count(character => character.Equals("Ant-Man"));
            Assert.That(ant_man_count, Is.EqualTo(0));

        }
    }
}