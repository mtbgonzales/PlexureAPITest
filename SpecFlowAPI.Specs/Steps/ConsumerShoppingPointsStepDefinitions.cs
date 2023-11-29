using NUnit.Framework;
using PlexureAPITest;
using TechTalk.SpecFlow;

namespace SpecFlowAPI.Specs.Steps
{
    [Binding]
    public sealed class ConsumerShoppingPointsStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly Test _apitest = new Test();

        string apiResponseMessage = "";

        public ConsumerShoppingPointsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _apitest.Setup();
        }

        [Then(@"I can get the user's current points")]
        public void ThenICanGetTheUserSCurrentPoints()
        {
            _apitest.TEST_002_Get_Points_For_Logged_In_User();
        }

        [When(@"I check the points for tha valid user")]
        public void WhenICheckedThePointsForThaValidUser()
        {
            _apitest.TEST_002_Get_Points_For_Logged_In_User();
        }

        [When(@"I get the user's current points without token")]
        public void WhenIGetTtheUserSCurrentPointsWithoutToken()
        {
            apiResponseMessage = _apitest.TEST_008_Get_Points_Without_Token();
        }


        [Then(@"I get a points error message ""(.*)""")]
        public void ThenIGetAPointsErrorMessage(string apiMessage)
        {
            apiResponseMessage.Contains(apiMessage);
        }
    }
}
