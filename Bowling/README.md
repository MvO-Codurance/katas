# kata-Bowling
See https://katalyst.codurance.com/bowling


Summary
-------

The Bowling kata is a fairly advanced kata, so it is advised you try this once you've practised some of the easier katas that help you to learn TDD.

If you haven't practised the basic skills of classical TDD (such as moving in baby steps and employing the red-green-refactor cycle), you should go and hone these skills first by trying both the FizzBuzz kata and the Leap Year kata.

Additionally, it is recommended you should try the Roman Numerals kata if you haven't done so already. Both the Roman Numerals and Bowling katas are useful for helping a developer to learn how to evolve an algorithm in small steps. With Roman Numerals the progression of tests is a little easier to work out (you move to accommodate bigger and bigger numbers). With this kata, working out the next test to write is more difficult and you will have to rely on the TPP rules more.

This kata will help you to practice the 'driving' element of TDD in a way that is relatively low cost in terms of risk. By moving forward in small steps and reversing back when you take a bad decision, it allows you to move forward confidently, knowing that mistakes are easy to recover from. The fast feedback means that you will see the problems almost immediately, and the small steps you take make it easy to identify where you went wrong. It may even make you slightly bolder in your choices and more willing to experiment.

It is recommended you read the Article below: _**The Transformation Priority Premise by Robert C. Martin**_ before you start this kata. If done properly whilst practising this kata, TPP should make you more proficient in selecting the next small step to make.

Instructions
------------

Write a program to score a game of Ten-Pin Bowling.

This online app can help you: [http://www.bowlinggenius.com/](http://www.bowlinggenius.com/)

**Input**: a string (described below) representing a bowling game  
**Ouput**: an integer score

### Rules

Each game (or "line") of bowling includes ten turns (or "frames") for the bowler.

In each frame, the bowler gets up to two tries to knock down all ten pins.

If the first ball in a frame knocks down all ten pins, this is called a "strike". The frame is over. The score for the frame is ten plus the total of the pins knocked down in the next two balls.

If the second ball in a frame knocks down all ten pins, this is called a "spare". The frame is over. The score for the frame is ten plus the number of pins knocked down in the next ball.

If, after both balls, there is still at least one of the ten pins standing, the score for that frame is simply the total number of pins knocked down in those two balls.

If you get a spare in the last (10th) frame you get one more bonus ball. If you get a strike in the last (10th) frame you get two more bonus balls. These bonus throws are taken as part of the same turn. If a bonus ball knocks down all the pins, the process does not repeat. The bonus balls are only used to calculate the score of the final frame.

The game score is the total of all frame scores.

### Symbol meanings

*   `X` indicates a strike
*   `/` indicates a spare
*   `-` indicates a miss
*   `|` indicates a frame boundary
*   The characters after the `||` indicate bonus balls

### Examples

`X|X|X|X|X|X|X|X|X|X||XX` Ten strikes on the first ball of all ten frames. Two bonus balls, both strikes. Score for each frame = 10 + score for next two balls = 10 + 10 + 10 = 30 Total score = 10 frames x 30 = 300

`9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||` Nine pins hit on the first ball of all ten frames. Second ball of each frame misses last remaining pin. No bonus balls. Score for each frame = 9 Total score = 10 frames x 9 = 90

`5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5` Five pins on the first ball of all ten frames. Second ball of each frame hits all five remaining pins, a spare. One bonus ball, hits five pins. Score for each frame = 10 + score for next one ball = 10 + 5 = 15 Total score = 10 frames x 15 = 150

`X|7/|9-|X|-8|8/|-6|X|X|X||81` Total score = 167

Credit: [Kata-Log](http://kata-log.rocks/bowling-game-kata)

Useful Links
------------

### Articles

*   [The Transformation Priority Premise](http://blog.cleancoder.com/uncle-bob/2013/05/27/TheTransformationPriorityPremise.html)
*   [Bowling Kata in Clojure, F# and Scala](https://codurance.com/2016/05/16/bowling-kata-in-clojure-fsharp-scala/)

### Solutions

*   [Kotlin](https://github.com/codurance/bowling_game_kata) by Sergio Rodrigo
*   [Clojure](https://github.com/mashooq/katas/tree/master/clojure/bowling) by [Mashooq Badar](https://codurance.com/publications/author/mashooq-badar/)
*   [F#](https://github.com/pedromsantos/FSharpKatas/blob/master/BowlingV2.fs) by [Pedro Santos](https://codurance.com/publications/author/pedro-santos/)
*   [Scala](https://github.com/sandromancuso/bowling_kata_scala) by [Sandro Mancuso](https://codurance.com/publications/author/sandro-mancuso)

### Videos

[

![Codurance Screencast: Bowling Kata in Kotlin](https://images.ctfassets.net/ofnietn7wwjz/2x82WzYIKhjd26MiQpSLME/10016b279ae9bf7f83c1d8db54b6892d/bowling_background.png)

Codurance Screencast: Bowling Kata in Kotlin

![Sergio Rodrigo Royo](https://images.ctfassets.net/ofnietn7wwjz/19rTYNAsmrwijEH7mrjeWr/427d572edbb8a55d7fc1fd7832afaf69/sergio.jpg)

Sergio Rodrigo Royo

](https://www.youtube.com/watch?v=bp0GhlY03wA)

[Algorithm Design](/browse?query=Algorithm Design)[Data Structures](/browse?query=Data Structures)[Outside-In TDD](/browse?query=Outside-In TDD)