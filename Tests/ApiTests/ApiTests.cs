using Newtonsoft.Json;
using Business.Models;
using Business.Models.Builders;
using System.Net;
using Core.HttpClients;
using RestSharp;

namespace Tests.ApiTests
{
    [TestFixture, Category("ApiTest")]
    [Parallelizable(scope: ParallelScope.All)]
    public class ApiTests : BaseApiTest
    {
        [Test]
        public void ValidateThatListOfUsersCanBeReceivedSuccessfull()
        { 
            var request = new RestRequest("/users");
            var response = client.GetWithLogs(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "The status code is incorrect.");

            var users = JsonConvert.DeserializeObject<User[]>(response.Content);
            Assert.Multiple(() => 
            {
                foreach (var user in users)
                {
                    Assert.NotNull(user.Address, "Address is NULL");
                    Assert.NotNull(user.Company, "Company in NULL");
                    Assert.NotNull(user.Email, "Email in NULL");
                    Assert.NotNull(user.Id, "Id is NULL");
                    Assert.NotNull(user.Name, "Name is NULL");
                    Assert.NotNull(user.Phone, "Phone is NULL");
                    Assert.NotNull(user.Username, "Username is NULL");
                    Assert.NotNull(user.Website, "Website is NULL");
                }
            });
        }

        [Test]
        public void ValidateResponseHeaderForListOfUser()
        {  
            var request = new RestRequest("/users");
            var response = client.GetWithLogs(request);
    
            Assert.Multiple(() =>
            {
                Assert.IsNotNull(response.ContentType, "Content-Type is NULL.");
                Assert.AreEqual("application/json", response.ContentType, "Content-Type header has incorrect value");
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Resonse has invalid status code.");
                Assert.IsNull(response.ErrorMessage, $"Response contains error message {response.ErrorMessage}");
            });
        }

        [Test]
        public void ValidateResponseHeaderForListOfUsers()
        {
            int expectedUsersCount = 10;
            var request = new RestRequest("/users");
            var response = client.GetWithLogs(request);
            var users = JsonConvert.DeserializeObject<User[]>(response.Content);
            
            Assert.Multiple(() => 
            {
                Assert.AreEqual(expectedUsersCount, users.Count(), "There is incorrect count of users in the response.");
                Assert.AreEqual(expectedUsersCount, users.Select(user => user.Id).ToList().Distinct().Count(), "List contains non-unique");
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response received with incorrect status code.");
                Assert.IsNull(response.ErrorMessage, "Reponse contains error message.");

                foreach (var user in users)
                {
                    Assert.NotNull(user.Name, "User has Name = NULL");
                    Assert.NotNull(user.Username, "User has Username = NULL");
                    Assert.NotNull(user.Company, "User doesn't contain Company in the response.");
                    Assert.NotNull(user.Company.Name, "User ontains Company with Name = NULL");
                }
            });
        }

        [Test]
        public void ValidateThatUserCanBeCreated()
        {
            var requestUser = new UserBuilder().AddName("Piter Parker").AddUsername("PiterParker").Build();
            var body = JsonConvert.SerializeObject(requestUser);
            var request = new RestRequest("/users").AddBody(body);
            
            var response = client.PostWithLogs(request);
            var responseUser = JsonConvert.DeserializeObject<User>(response.Content);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode, "Response received with incorrect status code.");
            Assert.IsNull(response.ErrorMessage, "Reponse contains error message.");
            Assert.NotNull(response.Content, "Response is empty");
            Assert.NotNull(responseUser.Id, "Created user with Id = NULL");
        }

        [Test]
        public void ValidateThatUserIsNotifiedIfResourceDoesntExist()
        {
            var request = new RestRequest("/invalidendpoint");
            var response = client.GetWithLogs(request);
        
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode, "Response has unexpected status code.");
            Assert.IsNull(response.ErrorMessage, "Response contains error message.");
        }
    }
}