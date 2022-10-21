Feature: Delivery date service

Scenario: Calculate the estimated dispatch date of an order
	Given the ID of a customer order
	When I ask for an estimated delivery date
	Then the result should be the estimated delivery date
	
		
Scenario: Products ordered are delivered <NumberOfDays> after their order date
	Given a supplier that supplies a product 
	And the product has a <NumberOfDays> lead time
	When the product is ordered
	Then the product is delivered <NumberOfDays> later
	
# The above isn't very good. Needs a lot more knowledge and work.