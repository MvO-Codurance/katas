Feature: Delivery date service

	Scenario: Calculate the estimated dispatch date of an order
		Given the id of a customer order
		When we ask for the estimated dispatch date for the order
		Then the result should be the estimated dispatch date for the order
		
		
	Scenario: Supplier starts to process an order on the day that it is received
		Given the id of a customer order
		When the order is received by the supplier
		Then the supplier starts to process the order on the same day
		
		
	Scenario: During the week, a supplier sends a product to the Delivery Office in <lead_time> days
		Given the id of a customer order
		And a product that the supplier supplies that has a lead time of <lead_time> days
		And the order received date plus <lead_time> days falls on a week day
		When the order is received by the supplier
		Then the product is sent to the delivery office <lead_time> days later
		
		
	Scenario: Over a weekend, a supplier sends a product to the Delivery Office on the next weekday plus <lead_time> days
		Given the id of a customer order
		And a product that the supplier supplies that has a lead time of <lead_time> days
		And the order received date plus <lead_time> days falls on a weekend
		When the order is received by the supplier
		Then the product is sent to the delivery office on the next weekday plus the remaining <lead_time> days
		
		
	Scenario: During the week, an order is dispatched to the customer on the same day as all products have been received at the Delivery Office
		Given the id of a customer order
		And the day of the week is a weekday
		When all products on the order have been received by the Delivery Office
		Then the order is dispatched to the customer on the same day
		
	Scenario: Over the weekend, an order is dispatched to the customer on the same day as all products have been received at the Delivery Office
		Given the id of a customer order
		And the day of the week is a weekend
		When all products on the order have been received by the Delivery Office
		Then the order is dispatched to the customer on the next weekday
		