# ProjectEuler
Project Euler was started by Colin Hughes (a.k.a. euler) in October 2001 as a sub-section on mathschallenge.net. Who could have known how popular these types of problems would turn out to be? Since then the membership has continued to grow and Project Euler moved to its own domain in 2006.

## What is this?
It is important to code every day to keep our skills sharp. I have created this repository for my solutions to Project Euler challenges. This particular repository contains my solutions written in C#. I have similar repositories for Python, Rust, Java, Scala, and C++.

## Structure of this code
This application runs as a console application. It is built for .Net running on Windows. The solution is organized into three folders, which also reflect the namespaces of the project. These are:

- ** ProjectEuler ** this contains a single source file (Program.cs) and the App.config.
- ** EulerLibrary ** this is the parent folder for the solution's class libraries.
- ** ProjectEulerTests ** these are the unit tests for the solution.

## Main Program
The main program prompts the user for a problem number, then runs the appropriate problem and reprompts the user. To end the program the user types "q" and presses enter.

The main program calls functions to validate the user's input, and then uses a factory pattern to obtain the class for the selected problem. Run times are tracked and reported by the main program.

## EulerLibrary
The EulerLibrary is the SDK for the solutions. The library is composed to two child libraries: MathLibrary and Problems.

### MathLibrary
The MathLibrary contains the algorithms needed to solve the problems. There are four source files in this namespace, these are:

- ** MathLibrary.cs ** this contains match functions, such as finding lowest common denominators or prime numbers.
- ** Premutations.cs ** this is a class for creating premutations of sets of items.
- ** ReallyBig.cs ** this contains the class for implementing ReallyBigInt, allowing for math on integers of hundreds of digits.
- ** Utilities.cs ** this contains miscellaneous utilities, such as formatting of milliseconds as HH:MM:SS:mmm.

## Problems
The Problems namespace contains the solution to the Project Euler problems. Each problem has its' own source file. In addition, the factory class (ProblemFactory.cs) is here. The factory accepts an integer problem number and returns the appropriate class to solve that problem. The problems are based on the interface *IEulerSolution*.