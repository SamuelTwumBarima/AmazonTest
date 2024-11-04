Feature: Amazon

A user searches for laptop on Amazon

@tag1
Scenario: A user selects product from second page on Amazon
	Given I open the amazon website "https://www.amazon.co.uk/"
	When I search for "laptop" on second page
	And I add item number 3 to the basket
	Then The item should be added to my basket
	
