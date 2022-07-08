# kata-PasswordValidation
See https://katalyst.codurance.com/password-validation

Password Validation Kata
========================

_created by [Emmanuel Valverde](https://github.com/khru)_

Iteration 1
-----------

### Goal

Design and implement a software that validates a password applying TDD.

The password will be introduced by the user (as an argument of the method) and should return if the password is valid or not.

#### A valid password should meet the following requirements:

*   Have more than 8 characters
*   Contains a capital letter
*   Contains a lowercase
*   Contains a number
*   Contains an underscore

### Technical requirements:

*   We want a method that answers if the password is valid or not.
*   We don't want to know the reason when the password is invalid (the return value is a boolean)

Iteration 2
-----------

### Goal

Design and implement software that can adapt to different password validation rules, with TDD and focus on the OOP principles.

Let's pretend that now we want to create another type of password validations because on our app we need different types of passwords, such as:

#### Validation 2:

*   Have more than 6 characters
*   Contains a capital letter
*   Contains a lowercase
*   Contains a number

#### Validation 3:

*   Have more than 16 characters
*   Contains a capital letter
*   Contains a lowercase
*   Contains an underscore

### Things to practice

In this iteration, we should try to identify a good abstraction and try to work on OOP principles as well as on design patterns like Builder and Factory