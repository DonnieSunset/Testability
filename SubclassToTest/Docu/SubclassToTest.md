# SubclassToTest Testability Pattern

Considered Antipattern

**Description:**

Subclass the ClassUnderTest.
Override method(s) that need to be faked/mocked/stubbed, for testing purposes.

**Pros:**
* It's quick easy and simple.
* Can expose private parts of the CuT
* Can add PoO and PoC to CuT

**Cons:**
* Complexity grows rapidly and unpredictably.
* Reuse of test code is difficult.
* Refactoring of production code becomes more and more difficult.


