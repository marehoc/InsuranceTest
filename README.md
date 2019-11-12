# Instructions

Create an algorithm to calculate the reinsurance loss as explained in the section below

## Guidelines

* Model the problem below using OO principles.
* Aim for high cohesion when designing your classes.
* The VS solution project is just a template. Feel free to use the IDE and IDE version of your choice.
* Support your solution with tests.
* There is no need to build a user interface. All the inputs into the calculations are presented below.
* The correct answers to the algorithm is detailed below for verification purposes.

## The problem

An event represents a natural catastrophe and has the following attributes:

* an id
* peril (1 = hurricane, 2 = earthquake, 3 = flood)
* region (1 = California, 2 = Louisiana, 3 = Florida)
* the total loss from the event

A deal is an insurance cover that we have sold to protect a client from insurance losses and has the following attributes:

* a retention
* a limit
* a list of the perils that it covers
* a list of the regions that it covers

The retention is the portion of the loss the client retains (similar to the excess on your car insurance policy) and the limit caps the maximum losses we are liable for. 100 of retention with 500 of limit is expressed as 500x100 (500 in eXcess of 100).

Imagine an reinsurance company that has bought into the following deals:

* Deal 1 covers California earthquake, and is 500x100
* Deal 2 covers Florida hurricane, and is 3000x1000
* Deal 3 covers Florida and Louisiana for both hurricane and flood and is 250x250

Supposing that the events below occurrs.

| id | peril      | region     | loss |
|----|------------|------------|------|
| 3  | flood      | Florida    | 750  |
| 2  | flood      | Louisiana  | 500  |
| 1  | earthquake | California | 1000 |
| 4  | hurricane  | Florida    | 2000 |

*Alongside this instructions file, you will find a C# class 'Data.cs' that provides an unstructured list of the events in table above.*

Write a program that calculates the reinsurance company's losses for each event. The expected answers are:

* Event 1 only affects deal 1 and the reinsurance company's loss is 500
* Event 2 only affects deal 3 and the reinsurance company's loss is 250
* Event 3 only affects deal 3 and the reinsurance company's loss is 250
* Event 4 affects deal 2 and the reinsurance company's loss is 1000
* Event 4 also affects deal 3 and the reinsurance company's loss is 250