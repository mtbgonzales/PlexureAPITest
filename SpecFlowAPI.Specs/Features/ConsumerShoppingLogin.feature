Feature: ConsumerShoppingLogin
	API Tests on user login

Scenario: Login Successful
	Given I log in as a valid user

Scenario: Login Invalid User - Unauthorized
	Given I log with invalid username "Testar"
	Then I get a login error message "Unathorized"

Scenario: Login Invalid Password - Unauthorized
	Given I log with invalid password "Password123"
	Then I get a login error message "Unathorized"

Scenario: Login Missing User - Bad Request
	Given I log with invalid username ""
	Then I get a login error message "Username and password are required"

Scenario: Login Missing Password - Bad Request
	Given I log with invalid password ""
	Then I get a login error message "Username and password are required"