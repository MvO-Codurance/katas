Feature: Salary Slip

Scenario: Generate a salary slip for an employee with different taxation elements  
	Given an employee with a gross annual salary of <gross_salary>
	When we generate a salary slip for the employee
	Then the salary slip should contain a gross monthly salary of <monthly_gross_salary>
	And national insurance contribution of <national_insurance>
	
	Examples:
	  | gross_salary | monthly_gross_salary | national_insurance |
	  | 5000         | 416.67               | 0.00               |
	  | 6000         | 500.00               | 0.00               |
	  | 9060         | 755.00               | 10.00              |
	  | 11000        | 916.67               | 29.40              |
	  | 12000        | 1000.00              | 39.40              |
	  | 30000        | 2500.00              | 219.40             |

  
#     | 45000        | 3750.00              | 352.73             |
#	  | 111000       | 9250.00              | 462.73             |
#	  | 160000       | 13333.33             | 544.40             |