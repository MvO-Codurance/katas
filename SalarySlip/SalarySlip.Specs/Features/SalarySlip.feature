﻿Feature: Salary Slip

Scenario: Generate a salary slip for an employee with different taxation elements  
	Given an employee with a gross annual salary of <gross_salary>
	When we generate a salary slip for the employee
	Then the salary slip should contain a gross monthly salary of <monthly_gross_salary>
	And national insurance contribution of <national_insurance>
	And tax-free allowance of £ <tax_free_allowance>
	And taxable income of £ <taxable_income>
	And tax payable of £ <tax_payable>
	
	Examples:
	  | gross_salary | monthly_gross_salary | national_insurance | tax_free_allowance | taxable_income | tax_payable |
	  | 5000         | 416.67               | 0.00               | 416.67             | 0.00           | 0.00        |
	  | 6000         | 500.00               | 0.00               | 500.00             | 0.00           | 0.00        |
	  | 9060         | 755.00               | 10.00              | 755.00             | 0.00           | 0.00        |
	  | 11000        | 916.67               | 29.40              | 916.67             | 0.00           | 0.00        |
	  | 12000        | 1000.00              | 39.40              | 916.67             | 83.33          | 16.67       |
	  | 30000        | 2500.00              | 219.40             | 916.67             | 1583.33        | 316.67      |
	  | 45000        | 3750.00              | 352.73             | 916.67             | 2833.33        | 600.00      |
	  | 101000       | 8416.67              | 446.07             | 875.00             | 7541.67        | 2483.33     |
	  | 111000       | 9250.00              | 462.73             | 458.33             | 8791.67        | 2983.33     |
	  | 122000       | 10166.67             | 481.07             | 0.00               | 10166.67       | 3533.33     |
	  | 150000       | 12500.00             | 527.73             | 0.00               | 12500.00       | 4466.67     |
	  | 160000       | 13333.33             | 544.40             | 0.00               | 13333.33       | 4841.67     |
