Feature: ConsumerShoppingPoints
	API Tests on checking user points

Background: 
	Given I log in as a valid user

Scenario: Get logged in user points
	Then I can get the user's current points

Scenario: Get logged in user points - Unauthorized
    When I get the user's current points without token
	Then I get a points error message "Unathorized"
