Feature: ConsumerShoppingPurchase
API Tests enabling users to purchase predetermined products and earn points.

Background: 
	Given I log in as a valid user successfully

Scenario: Purchase and get points

	When I check the points for the valid user
	And I purchase productId1 successfully
	Then I earn 100 credit points

Scenario: Purchase invalid product
	When I check the points for the valid user
	And I purchase an invalid product
	Then I get a purchase error message "Invalid product id"
	And credit points stay the same
