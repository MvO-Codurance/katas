# kata-Parallel-Change
See https://github.com/unclejamal/parallel-change

# Parallel Change (Or Expand, Migrate, and Contract)
The technique of Parallel Change was an original idea of Joshua Kerievsky. It was explained in 2010, in a talk called The
Limited Red Society. InfoQ, Joshua Kerievsky, The Limited Red Society: https://www.infoq.com/presentations/The-Limited-Red-Society.

Parallel Change, also known as expand, migrate, and contract, is a refactor pattern to implement breaking changes safely
(staying in the green). It consists of three steps: expand, migrate, and contract.

## Expand
Introduce new functionality by adding new code instead of changing existing code. If you are expanding a class or an
interface, introduce new methods instead of changing existing ones. If the behavior from the outside is similar and only the
implementation changes, duplicate existing tests and point them to the new code, leaving the existing tests untouched. Make
sure tests for existing code are still working.

Implement new functionality starting from the tests, either by writing new tests or by adapting duplicated old tests. Make sure
to write new code using TDD practices. Once all new functionality is implemented, move to the migration step.

## Migrate
Deprecate old code and allow clients to migrate to new expanded code, or change client code to point to new code.

## Contract
Once all client code is migrated to new code, remove old functionality by removing deprecated code and its tests.