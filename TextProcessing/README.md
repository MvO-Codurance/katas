# kata-TextProcessing
See https://katalyst.codurance.com/text-processing

Text Processing Kata
====================

_created by: [Matheus Marabesi](https://github.com/marabesi/) and [Emmanuel Valverde](https://github.com/khru)_

Introduction
------------

As a developer that writes blog posts I want a tool that helps me to understand better the text I am writing. For that I need a way to know the following:

1.  What are the most common words used in the text?
2.  How many characters does the text have?

    interface Processor {
    analyse(text: string);
    }


The usage of such interface is not required.

First challenge
---------------

Given the following text:

    Hello, this is an example for you to practice. You should grab this text and make it as your test case.

The output should be:

    Those are the top 10 words used:
    
    1. you
    2. this
    3. your
    4. to
    5. text
    6. test
    7. should
    8. practice
    9. make
    10. it
    
    The text has in total 21 words


### Some side notes:

*   As you may have noticed, the example assumes that You and you are the same, in other words, it's not case sensitive.
*   There is no order in which the words that have the same number are listed. For example, this and it, appear once, and they are not alphabetically ordered.

Next up, the kata starts to be a bit more complex. Make sure to complete this challenge first before going on into the second.

Second challenge
----------------

Now I would like to know how much time would it take the user to read my post, for that I should apply the following formula:

(The average reading rate is actually **238**, according to this study, but **200** is a nice compromise and is easier to remember.)

Here's the formula:

*   Get your total word count (including the headline and subhead).
*   Divide total word count by 200. The number before the decimal is your minutes.
*   Take the decimal points and multiply that number by .60. That will give you your seconds.

Example:

    783 words ÷ 200 = 3.915 (3 = 3 minutes)
    .915 × .60 = .549 (a little over 54 seconds, so I'd bump it up to 60 seconds, or a full minute)

reading time for this example article is 4 minutes.

Third challenge
---------------

Besides the previous features, the text processing also should have:

*   A way to ignore a given piece of text to analyse (For example, a code snippets - the code snippet is in between `javascript` anything inside should be ignored)
*   A way to offer stop words and remove them from the analysis

Given the example for 1, this would be a text with code snippets:

    Hello, this is an example for you to practice. You should grab
    this text and make it as your test case:
    
    if (true) {
      console.log('should should should')
    }


The text processing output should ignore the code snippet. Meaning, that the output should be:

    Those are the top 10 words used:
    
    1. you
    2. this
    3. your
    4. to
    5. text
    6. test
    7. should
    8. practice
    9. make
    10. it
    
    The text has in total 21 words


Note that, the word should is the same, and it does not goes up in the list as should appears four times (more than the word you).