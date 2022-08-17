# kata-Bank
See https://katalyst.codurance.com/bank

Summary
-------

When designing a big system, we like to base our design on the way that the system will be used. That way, user stories and acceptance criteria become much more than just a finish line: they are a guiding principle for the entire system.

This solves a variety of problems. For example, it eliminates over-engineering (since we only write what we know the user needs). Starting at the public interface moves risk away from the end of the project (nobody wants an integration nightmare when deadline day is looming).

This Kata aims to distill that experience into a problem that can be knocked on the head in a couple of hours, writing a primitive bank account program. In this case, our user interface is just some public methods - assume we're writing a library. But the same principles hold.

It's a fantastic way to practice using acceptance tests to guide your design. If done correctly, the result will be a system that evolves itself with no extraneous effort and no nasty surprises at the end. You will see how the outside-in way of working can be a powerful way of creating object-oriented software.

You can attempt this using Mockist or Classicist TDD, but we find that it's especially well suited to a Mockist approach. Consider using [Sandro Mancuso](https://codurance.com/publications/author/sandro-mancuso)'s [screencast](https://codurance.com/videos/2015-05-12-outside-in-tdd-part-1/) implementation as a reference.

Instructions
------------

Write a class named Account that implements the following public interface:

    public interface AccountService
    {
        void deposit(int amount) 
        void withdraw(int amount) 
        void printStatement()
    }


### Rules

*   You cannot change the public interface of this class.

### Desired Behaviour

Here's the specification for an acceptance test that expresses the desired behaviour for this

_Given_ a client makes a deposit of 1000 on 10-01-2012  
_And_ a deposit of 2000 on 13-01-2012  
_And_ a withdrawal of 500 on 14-01-2012  
_When_ they print their bank statement  
_Then_ they would see:

    Date       || Amount || Balance
    14/01/2012 || -500   || 2500
    13/01/2012 || 2000   || 3000
    10/01/2012 || 1000   || 1000

### Notes

*   We're using `int`s for the money amounts to keep the auxiliaries as simple as possible. In a real system, we would always use a datatype with guaranteed arbitrary precision, but doing so here would distract from the main purpose of the exercise.
*   Don't worry about spacing and indentation in the statement output. (You could instruct your acceptance test to ignore whitespace if you wanted to.)
*   Use the acceptance test to guide your progress towards the solution. Sandro does this by making all unimplemented methods throw an exception, so that he can immediately see what remains to be implemented when he runs the acceptance test.
*   When in doubt, go for the simplest solution!

Useful Links
------------

### Articles

*   [Bank kata in Haskell - dealing with state](https://codurance.com/2019/02/11/bank-kata-in-haskell-state/)
*   [Bank kata in Haskell - printing a statement](https://codurance.com/2019/02/21/bank-kata-in-haskell-printing/)
*   [Bank kata in Haskell - using and testing date](https://codurance.com/2019/03/12/bank-kata-in-haskell-date/)
*   [A case for outside-in development](https://codurance.com/2017/10/23/outside-in-design/)

### Solutions

*   [C#](https://github.com/Gryff/bank-kata) by [Liam Griffin-Jowett](https://codurance.com/publications/author/liam-griffin/)
*   [Java](https://github.com/sandromancuso/bank-kata-outsidein-screencast) by [Sandro Mancuso](https://codurance.com/publications/author/sandro-mancuso)
*   [Java](https://github.com/richardjwild/bank-kata) by [Richard Wild](https://codurance.com/publications/author/richard-wild/)

### Videos

[

![Outside-in TDD: The Bank Kata (1/3)](https://images.ctfassets.net/ofnietn7wwjz/5PkOEwt08rKYJWOrF44YV8/a372a51dc978e7145dcafd0f132cc6d8/screencast_1_background.jpg)

Outside-in TDD: The Bank Kata (1/3)

![Sandro Mancuso](https://images.ctfassets.net/ofnietn7wwjz/6s1ugUepKNmLECHLiyZnBM/7608f9b667e6b75ba304418a39b3544b/sandro_mancuso.jpg)

Sandro Mancuso

](https://codurance.com/videos/2015-05-12-outside-in-tdd-part-1/)[

![Outside-in TDD: The Bank Kata (2/3)](https://images.ctfassets.net/ofnietn7wwjz/5ziRjzStSDf3MJOQrMbJfm/7f4bbe15c5c28b619e0571ba10ccd246/screencast_2_background.jpg)

Outside-in TDD: The Bank Kata (2/3)

![Sandro Mancuso](https://images.ctfassets.net/ofnietn7wwjz/6s1ugUepKNmLECHLiyZnBM/7608f9b667e6b75ba304418a39b3544b/sandro_mancuso.jpg)

Sandro Mancuso

](https://codurance.com/videos/2015-05-12-outside-in-tdd-part-2/)[

![Outside-in TDD: The Bank Kata (3/3)](https://images.ctfassets.net/ofnietn7wwjz/2q0mwD0ozvoB63VCxPJXGx/9b6e95cd0f1c3aec595cef34f535a586/screencast_3_background.jpg)

Outside-in TDD: The Bank Kata (3/3)

![Sandro Mancuso](https://images.ctfassets.net/ofnietn7wwjz/6s1ugUepKNmLECHLiyZnBM/7608f9b667e6b75ba304418a39b3544b/sandro_mancuso.jpg)

Sandro Mancuso

](https://codurance.com/videos/2015-05-12-outside-in-tdd-part-3/)

[Outside-In TDD](/browse?query=Outside-In TDD)[Object Oriented Design](/browse?query=Object Oriented Design)