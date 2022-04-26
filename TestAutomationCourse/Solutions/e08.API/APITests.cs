using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TestAutomationCourse.Solutions.e08.API
{
    [TestFixture]
    internal class APITests
    {
        private RestResponse response;
        private RestResponse response2;
        private RestClient client;
        private RestRequest request2;

        // JsonPlaceHolder api
        [Test]
        public async Task number_of_total_posts_is_100()
        {
            RestClient client = new RestClient("http://jsonplaceholder.typicode.com/posts");
            RestRequest request = new RestRequest();

            var response = await client.GetAsync(request);
            JArray posts = JArray.Parse(response.Content);

            int size = posts.Count;
            Assert.That(size, Is.EqualTo(100));
        }


        [Test]
        public async Task title_of_first_post_for_userid_1_contains_facere()
        {
            RestClient client = new RestClient("http://jsonplaceholder.typicode.com/");
            RestRequest request = new RestRequest(@"posts/1");

            var response = await client.GetAsync(request);
            JObject post = JObject.Parse(response.Content);

            Assert.That((string)post["title"], Does.Contain("facere"));
        }

        // apichallenges api
        [Test]
        public async Task create_todo_and_get_it_by_its_id()
        {
            Todo newTodo = new Todo();
            newTodo.title = "My Todo";
            newTodo.doneStatus = false;
            newTodo.description = "dognabbit";

            await create_todo(newTodo);
        

            int id = (int)JObject.Parse(response.Content)["id"];
            await get_todo_by(id);

            var body = JObject.Parse(response2.Content);
            var todo = body["todos"][0];

            Assert.That((string)todo["title"], Is.EqualTo("My Todo"));

        }

        
        // use body("Y", hasItem(X)); to find if the ID was added.
        [Test]
        public async Task create_todo_and_check_if_added_to_todos()
        {
            Todo newTodo = new Todo();
            newTodo.title = "My Todo";
            newTodo.doneStatus = false;
            newTodo.description = "dognabbit";

            await create_todo(newTodo);

            int id = (int)JObject.Parse(response.Content)["id"];
            RestResponse response2 = await get_all_todos();

            var body = JObject.Parse(response2.Content);
            var todos = (JArray)body["todos"];

            JToken the_todo = todos.Children().FirstOrDefault(
                a_todo => ((string)a_todo["title"]).Equals("My Todo"));

            Assert.That(the_todo, Is.Not.Null);

        }


        // Update the description field
        //[Test]
        //public async Task create_get_update_delete()
        //{
            //Todo newTodo = new Todo();
            //newTodo.title = "new title";
            //newTodo.description = "new description";
            //newTodo.doneStatus = false;

            //await create_todo(newTodo);
            //int id = (int)JObject.Parse(response.Content)["id"];

            //var query_todo = "http://apichallenges.herokuapp.com/todos?id=" + id;
            //Todo the_todo = await client.GetJsonAsync<Todo>(query_todo);

            //the_todo.description = "new new description";
        
            //var path_to_todo = "http://apichallenges.herokuapp.com/todos/" + id + "/";
            //HttpStatusCode httpStatusCode = await client.PostJsonAsync(path_to_todo, the_todo);

            //Assert.That(httpStatusCode, Is.EqualTo(200));

        //}

        private async Task get_todo_by(int id)
        {
            request2 = new RestRequest();
            request2.AddQueryParameter("id", id);

            response2 = await client.GetAsync(request2);
            Assert.That(response2.IsSuccessful, Is.True);
        }

        private async Task create_todo(Todo newTodo)
        {
            client = new RestClient("http://apichallenges.herokuapp.com/todos");

            RestRequest request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(newTodo);

            response = await client.PostAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

        }

        private async Task<RestResponse> get_all_todos()
        {
            request2 = new RestRequest();
            var response2 = await client.GetAsync(request2);
            return response2;
        }

    }
}
