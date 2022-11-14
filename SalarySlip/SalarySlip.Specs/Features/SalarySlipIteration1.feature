Feature: Salary Slip Iteration 1

Scenario: Calculate the gross monthly salary of an employee with a gross annual salary of £5000.00 
	Given an employee with a gross annual salary of 5000.00
	When we generate a salary slip for the employee
	Then the salary slip should contain a gross monthly salary of 416.67