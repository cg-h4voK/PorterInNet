# PorterInNet
Description:
* This application tests the Porter2 algorythm in C# with the implementation by Kamil Bartocha. We will create an alphabetized list of unique words (by stem) and also count the total occurrences as well as in which sentences they appear.

How to run:
* This is a simple console application. Clone or download this git.

* If you have problems building the application remember to use NuGet Packet Manager Restore. Right click on the solution in Visual Studio and select "Manage NuGet Packages". On the top right there will be a button in a yellow warning called "Restore". After restoring it should build normally.

* Do not forget to visit the unit tests!

Clarifications: 
* This is part of a job interview exam

* These words are exceptions that must not be logged: a, the, and, of, in, be, also, as

* These words are being logged although it could sound like they should not be: an, or, not, is

* The Porter2 algorythm we have transforms all text into lower case. This is not a requirement of the exam. However the library availability for stemming in C# is limited, so I have decided to not handle casing as it did not add value at this point.

* Unit Test coverage is above 70%. Going further seemed outside the scope of this evaluation.
