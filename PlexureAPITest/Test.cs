using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlexureAPITest
{
    [TestFixture]
    public class Test
    {
        Service service;
        int userBeforePoints;

        
        [OneTimeSetUp]
        public void Setup()
        {
            service = new Service();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            if (service != null)
            {
                service.Dispose();
                service = null;
            }
        }

        [Test]
        public void TEST_001_Login_With_Valid_User()
        {
            var response = service.Login("Tester", "Plexure123");

            response.Expect(HttpStatusCode.OK);
            response.Entity.UserName.Equals("Tester");
            Assert.IsNotNull(response.Entity.UserId);
            Assert.IsNotNull(response.Entity.AccessToken);

        }

        [Test]
        public void TEST_002_Get_Points_For_Logged_In_User()
        {
            var points = service.GetPoints();
            userBeforePoints = points.Entity.Value;

            points.Entity.UserId.Equals("1");
            Assert.IsNotNull(points.Entity.Value);
        }

        [Test]
        public void TEST_003_Purchase_Product()
        {
            int productId = 1;
            service.Purchase(productId);
        }

        [Test]
        public int TEST_004_Get_Points_Earned()
        {
            var latestUserPoints = service.GetPoints();
            return latestUserPoints.Entity.Value - userBeforePoints;
        }

        [Test]
        public string TEST_005_Login_With_Invalid_User(string uName)
        {
            string loginMsg;

            if (uName.Length == 0)
            {
                var response = service.Login(null, "Plexure123");
                response.Expect(HttpStatusCode.BadRequest);
                loginMsg = response.Error;
            }
            else
            {
                var response = service.Login(uName, "Plexure123");
                response.Expect(HttpStatusCode.Unauthorized);
                loginMsg = response.Error;
            }

            return loginMsg;

        }

        [Test]
        public string TEST_006_Login_With_Invalid_Password(string pwd)
        {
            string loginMsg;

            if (pwd.Length == 0)
            {
                var response = service.Login("Tester", null);
                response.Expect(HttpStatusCode.BadRequest);
                loginMsg = response.Error;
            }
            else
            {
                var response = service.Login("Tester", pwd);
                response.Expect(HttpStatusCode.Unauthorized);
                loginMsg = response.Error;
            }
            
            return loginMsg;
        }

        [Test]
        public string TEST_007_Purchase_Invalid_Product()
        {
            var response = service.Purchase(9999);
            response.Expect(HttpStatusCode.BadRequest);
            return response.Error;
        }

        [Test]
        public string TEST_008_Get_Points_Without_Token()
        {
            service.RemoveRequestHeaderToken();
            var response = service.GetPoints();
            response.Expect(HttpStatusCode.Unauthorized);
            return response.Error;
        }
    }
}
