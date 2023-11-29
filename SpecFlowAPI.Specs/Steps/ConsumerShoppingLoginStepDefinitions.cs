using NUnit.Framework;
using PlexureAPITest;
using TechTalk.SpecFlow;

namespace SpecFlowAPI.Specs.Steps
{
    [Binding]
    public sealed class ConsumerShoppingLoginStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly Test _apitest = new Test();

        string apiResponseMessage="";

        public ConsumerShoppingLoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _apitest.Setup();
        }

        [Given(@"I log in as a valid user")]
        public void GivenILogInAsAValidUser()
        {
            _apitest.TEST_001_Login_With_Valid_User();
        }

        [Given(@"I log with invalid username ""(.*)""")]
        public void GivenILogWithInvalidUsername(string invalidUser)
        {
            apiResponseMessage = _apitest.TEST_005_Login_With_Invalid_User(invalidUser);
        }


        [Then(@"I get a login error message ""(.*)""")]
        public void ThenIGetALoginErrorMessage(string apiMessage)
        {
            apiResponseMessage.Contains(apiMessage);
        }

        [Given(@"I log with invalid password ""(.*)""")]
        public void GivenILogWithInvalidPassword(string invalidPwd)
        {
            apiResponseMessage = _apitest.TEST_006_Login_With_Invalid_Password(invalidPwd);
        }


    }
}
