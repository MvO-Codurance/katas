Feature: Salary Slip

Scenario: Generate a salary slip for an employee with different taxation elements  
	Given an employee with a gross annual salary of <gross_salary>
	When we generate a salary slip for the employee
	Then the salary slip should contain a gross monthly salary of <monthly_gross_salary>
	
	Examples:
	  | gross_salary | monthly_gross_salary |
	  |         5000 |               416.67 |
   	  |         6000 |               500.00 |
	  |        11000 |               916.67 |
	  |        12000 |              1000.00 |
	  |        30000 |              2500.00 |
	  |        45000 |              3750.00 |
	  |       111000 |              9250.00 |
	  |       160000 |             13333.33 |