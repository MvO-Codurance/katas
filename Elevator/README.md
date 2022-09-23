# Elevator Kata by Marco Consolaro

Implement a controller for an elevator system considering the following requirements.
For evaluation purposes, assume that it takes one second to move the elevator from one floor to another and the doors stay
open for three seconds at every stop.

## Part 1
The building has a total of five floors, including the basement and the ground floor. The elevator can be called at any floor only
when it is not in use via one call button.

Given the elevator is positioned on the ground floor:
- When there is a call from floor 3 to go to the basement
- And there is a call from the ground floor to go to the basement
- And there is a call from floor 2 to go to the basement
- And there is a call from floor I to go to floor 3

Then the doors should open at floor 3, basement, ground, basement, floor 2, basement, floor 1, and floor 3 in this order

## Part 2
The elevator is not fast enough, so as an experiment to speed it up, the idea is to allow the elevator to queue the requests and
optimize the trips.

The elevator can now queue the stop requests from the floors and collect people along the way, but cannot change direction
once it's started until all calls in the same direction have been fulfilled.

Given the elevator is positioned on the ground floor:
- When there is a call from floor 3 to go to the basement
- And there is a call from the ground floor to go to the basement
- And there is a call from floor 2 to go to the basement
- And there is a call from floor 1 to go to floor 3

Then the doors should open at floor 3, floor 2, the ground floor, the basement, floor 1, and floor 3, in this order.

### Nonfunctional requirement: 
The total time spent in the process of Part 2 should be less than the time spent with the
algorithm of Part 1.
