# kata-ConwaysGameOfLife
See https://katalyst.codurance.com/conways-game-of-life

Summary
-------

This kata is done by Codurance apprentices during the Design stage of the apprenticeship. The process of arriving at the solution for this exercise reinforces the principles of object-oriented design and also helps with learning to move forward in small steps, also known as "baby steps".

The kata deals with a solution where complex state logic needs to be maintained. It will show how good object-oriented design can help you to drive out a solution.

### Baby Steps

One of the fallacies of TDD is the perception that it is more time-consuming than coding an implementation only, or writing code and retro-fitting unit tests after the fact. This is only true for people who are new to the method! Adept TDDers are usually are no slower than people who write code in a non-test-driven manner. They also generally spend much less time debugging and fixing problems downstream.

Baby steps is the ideal way to practice TDD. Once you are proficient in doing this, you can incrementally progress to a solution to a problem. You will be surprised at how quick and efficient this process is once you’re accomplished at it.

Instructions
------------

Implement a finite version of [Conway's Game of Life](http://en.wikipedia.org/wiki/Conway's_Game_of_Life).

Here are the rules (courtesy of Wikipedia):

> The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of two possible states: alive or dead. Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent to it. At each step in time, the following transitions occur:
>
> *   Any live cell with fewer than two live neighbours dies, as if caused by under-population.
> *   Any live cell with two or three live neighbours lives on to the next generation.
> *   Any live cell with more than three live neighbours dies, as if by overcrowding.
> *   Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
>
> The initial pattern constitutes the seed of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed—births and deaths occur simultaneously, and the discrete moment at which this happens is sometimes called a tick (in other words, each generation is a pure function of the preceding one)

Your game should be constructed with initial state of a two-dimensional array of boolean values, and a single public method to move to the next generation:

    public class GameOfLife {
      public GameOfLife(boolean[][] board);
      public void nextGen();
    }


#### Notes

*   The dimensions of the array stay constant throughout the game - the 'universe' never grows.
*   Cells outside the bounds of the array should be considered permanently dead (they never come to life).

Credit: [Kata-Log](http://kata-log.rocks/game-of-life-kata)

Useful Links
------------

### Articles

*   [`test && commit || revert`](https://medium.com/@kentbeck_7670/test-commit-revert-870bbd756864) by Kent Beck

### Solutions

*   [Java](https://github.com/andretorres-codurance/gameoflife) by [Andre Torres](https://codurance.com/publications/author/andre-torres/)
*   [F#](https://github.com/MiyamotoAkira/ConwaysGameOfLife/) by [Jorge Gueorguiev Garcia](https://codurance.com/publications/author/jorge-gueorguiev-garcia/)