using System.Collections.Generic;

namespace TestAutomationCourse.Solutions.e07.Combo
{
    public class MCU
    {
        public List<Movie> movies = new List<Movie>();
        public void AddMovie(Movie name)
        {
            movies.Add(name);
        }
    }

    public class Movie
    {
        public string name;
        public List<string> characters;

        public Movie(string name)
        {
            this.name = name;
            characters = new List<string>();
        }

        public Movie withCharacter(string character)
        {
            characters.Add(character);
            return this;
        }
    }   
}
