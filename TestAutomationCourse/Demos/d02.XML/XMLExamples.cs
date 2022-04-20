namespace TestAutomationCourse.Demos.d02.XML
{
    internal class XMLExamples
    {
        //    <Person>
        //          <FirstName>Joe</FirstSmith>
        //          <SurName>Smith</SurName>
        //          <Children>
        //              <Child name="Jane"/>
        //              <Child name="Jim"/>
        //              <Child name="JJ"/>
        //          </Children>
        //      </Person>

        public static string GetPersonXML()
        {
            return "<Person>\n" +
                    "  <FirstName>Joe</FirstName>\n" +
                    "  <SurName>Smith</SurName>\n" +
                    "  <Children>\n" +
                    "    <Child name=\"Jane\"/>\n" +
                    "    <Child name=\"Jim\"/>\n" +
                    "    <Child name=\"JJ\"/>\n" +
                    "  </Children>  \n" +
                    "</Person>";
        }
    }
}

