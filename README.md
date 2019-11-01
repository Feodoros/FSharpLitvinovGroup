# FSharpLitvinovGroup
Home Works F# lang.

This repo contains all homeworks from [this course](http://hwproj.me/courses/31).

Below are listed all tasks with links and descriptions.

## Homework 1. 
15.02.19 

- [1.1](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW1/Factorial)

   Count factorial.

- [1.2](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW1/Fibonacchi)

   Count fibonacci numbers (on linear time).

- [1.3](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW1/ReverseList)

   Make function that reverses list (on linear time).

- [1.4](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW1/SeriesOfNumber)

   Make function that given n and m and returns list of elements [2n; 2n + 1; ...; 2n + m].

## Homework 2. 
22.02.19 

 - [2.1](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW2/FirstAppereance)
 
   Make function that returns index of first appearance of element in list

 - [2.2](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW2/PalindromeCheck)

   Make function that checks if given string is a palindrome.

 - [2.3](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW2/MergeSort)

   Make mergesort: function that given list and returns sorted list.

## Homework 3.
01.03.19 

 - [3.1](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW3/EvenNumInList)

   Make three variants of a function, that counts number of even elements in list (using default functions map, filter, fold). Recursion if forbidden.

 - [3.2](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW3/MapForTrees)

   Make function that applies given function to every element of binary tree and returns new binary tree every element of which --- result of applying function to corresponding element given tree (map for trees).

 - [3.3](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW3/ArithmeticOperationTree)

   Count value of tree of arithmetical expression given throw inserted discriminated unions.

 - [3.4](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW3/InfSeqOfPrimeNumbers)

   Make function that generate an infinite sequence of prime numbers.

## Homework 4. 
15.03.19 

 - [4.1](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW4/BetaReduction)

   Make β-reduction of λ-term ((λa.(λb.b b) (λb.b b)) b) ((λc.(c b)) (λa.a)).

 - [4.2](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW4/SKK%3DI)

   Prove that S K K = I.

 - [4.3](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW4/InterpreterOfLambdaExp)

   Make a lamda expression calculator that makes β-reduction on normal strategy. Lambda expressions are given throw discriminated unions. Should be an α-conversion support to avoid capturing free variables.

## Homework 5. 
22.03.19 

 - [5.1](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW5/IsBalanced)

   Make function that checks if brackets sequence is correct in given string. There are three type of brackets.

 - [5.2](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW5/PointFree)

   Rewrite in point-free style func x l = List.map (fun y -> y * x) l. Write steps and check result with FsCheck.

 - [5.3](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW5/PhoneBook)

   Write phone book. It should be able to store names and phone numbers and make these operations in an interactive mode:
   -- exit.
   -- add record (and and phone).
   -- find phone by name.
   -- find name by phone.
   -- print all book content.
   -- save current data to file.
   -- read data from file.

## Homework 6. 
29.03.19 

 - [6.1](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW6/OOP)

   In object-oriented style model work of local network:
   * exists several computers that are connected to each other (how – for example with adjacency matrix);
   * on every computer exists ОС (Windows, Linux, etc...);
   * in network are walking viruses, so for every machine exist non-zero probability to be infected (probability     depends on OS type), infecting computers, which are connected to infected ones;
   infection (and checks, if computer is infected) happens discretely – on turns.
   Program should print state of network periodically.

   There is need in unit testing, checking correctness of infecting algorithm: if probability of infection always 1, virus should behave as breadth-first, if 0 – nobody should be infected.

## Homework 7. 
05.04.19 

 - [7.1](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW7/MathWorkflow)

   Make Workflow, that makes arithmetical operations with given (as Builder argument) accuracy. For example,
   ```fsharp
    rounding 3 {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
   ```
    should return 0.048.

 - [7.2](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW7/StringMathWorkflow)

   Make Workflow, that makes calculations with numbers, given in strings. For example,
   ```fsharp
    let result = calculate {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }
   ```
   should return result that contains 3, аnd
   ```fsharp
    let res = calculate {
        let! x = "1"
        let! y = "Ъ"
        let z = x + y
        return z    
    }
   ```
   should return result that point on the fact that there is no result.

## TestWork. 
12.04.19

 - [Test, 1](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/TestWork/MeanSin)

   Find the arithmetic mean of the sine of all numbers from the list using tail recursion. Imperative programming constructs cannot be used.

 - [Test, 3](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/TestWork/Trie)

   Implement a [Bor/Trie](http://neerc.ifmo.ru/wiki/index.php?title=%D0%91%D0%BE%D1%80)
   The following methods should be supported:

- boolean Add(String element) (returns true if there was no such string yet, works for O (|element|))
- boolean Contains(String element) (works for O (|element|))
- int Size () (works for O(1))
- int HowManyStartsWithPrefix(String prefix) (works for O (|prefix|))

## Homework 8. 
19.04.19 

 - [8.1](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW8/ILazy)

   Inherit interface, providing lazy calculations:
   ```fsharp
    type ILazy<'a> =
    abstract member Get: unit -> 'a    
   ```
   Object Lazy on the result of calculations (presented by lambda-function supplier : unit -> 'a).
   * First call of Get() calls calculation and returns result.
   * Repeated calls of Get() return the same object as first call.
   * In a single-threaded mode calculation should start no more than once.

   Objects should be created with help of class LazyFactory, that have three methods, for example
   ```fsharp
    static member CreateSingleThreadedLazy supplier 
   ```
   three different realizations of Lazy<'a>:
   - Simple version with guarantee of correct work in a single thread mode (without synchronization).
   - Guarantee of correct work in a multithreaded mode. Calculation should not be made more than once.
   - Guarantee of correct work in a multithreaded mode but lock-free. Calculation may run more than once, but Lazy.Get always should return same object.

 - [8.2](https://github.com/Feodoros/FSharpLitvinovGroup/tree/master/HW8/WebSaver)

   Make function that gets web page, downloads all pages that have their links on input page and prints information about every page in format "url --- number of symbols". Download of pages should run asynchronously.

## Homework 9. 
10.05.19

- [Coursework presentation](https://github.com/Feodoros/PoemClassifier/blob/master/papers/slides_classifier.pdf)
- [Coursework text](https://github.com/Feodoros/PoemClassifier/blob/master/papers/text/text_classifier_zhilkin.pdf)
- Protection
