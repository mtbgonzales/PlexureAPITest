using NUnit.Framework;
using PlexureAPITest;
using TechTalk.SpecFlow;

namespace SpecFlowAPI.Specs.Steps
{
    [Binding]
    public sealed class ConsumerShoppingPurchaseStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly Test _apitest = new Test();

        string apiResponseMessage = "";

        public ConsumerShoppingPurchaseStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _apitest.Setup();
        }

        [Given(@"I log in as a valid user successfully")]
        public void GivenILogInAsAValidUserSuccessfully()
        {
            _apitest.TEST_001_Login_With_Valid_User();
        }

        [When(@"I check the points for the valid user")]
        public void WhenICheckThePointsForTheValidUser()
        {
            _apitest.TEST_002_Get_Points_For_Logged_In_User();
        }


        [When(@"I purchase productId1 successfully")]    
        public void WhenIPurchaseAProduct()
        {
            _apitest.TEST_003_Purchase_Product();

        }

        [Then(@"I earn (.*) credit points")]
        public void ThenTheUserEarnsCreditPoints(int expectedPoints)
        {
            int pointsEarned = _apitest.TEST_004_Get_Points_Earned();
            Assert.AreEqual(expectedPoints, pointsEarned);
        }

        [When(@"I purchase an invalid product")]
        public void WhenIPurchaseAnInvalidProduct()
        {
            apiResponseMessage = _apitest.TEST_007_Purchase_Invalid_Product();
        }

        [Then(@"I get a purchase error message ""(.*)""")]
        public void ThenIGetAPurchaseErrorMessage(string apiMessage)
        {
            apiResponseMessage.Contains(apiMessage);
        }

        [Then(@"credit points stay the same")]
        public void ThenCreditPointsStayTheSame()
        {
            int pointsEarned = _apitest.TEST_004_Get_Points_Earned();
            Assert.AreEqual(0, pointsEarned);
        }

    }
}
