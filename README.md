
# One Way of Looking at


## 13 ways of looking at a turtle

This fork of [13 Ways of looking at a Turtl](https://github.com/swlaschin/13-ways-of-looking-at-a-turtle). This Fantastic [Article/Blog Post](http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/) inspired me to use it has the basis for demonstrating the power of having a Single Source of Truth (SSoT) when developing software. 

The code can be found on [GitHub](https://github.com/eejai42/13-ways-of-looking-at-a-turtle).

The purpose of the original article, was to demonstrate 13 different ways to solve the same problem. The reason this is such a great starting place to domonstrate the SSoT toolset, is that "the code" is what it is. In other words, the decision of what the code should be is already decided. 

The question asked by this fork of the repo is, what would be the best way to Create/Manage that code in a "production" environment. 

The code in this branch have been created by following the following steps in an iterative fashion. To begin with, I created an empty Single Source of Truth (**SSoT**) in the form of a [Google Spreadsheet](https://docs.google.com/spreadsheets/d/1kjyb0JGswSufELAKuy5jtuhs6I0ZyvY9Zwa5Nei6aAo/edit#gid=1093073527). This SSoT serves as the place to put decisions. Specifically, things that are true independantly of which language or context/environment that it's used. 


  1. Copy information from the code into the [SSoT Google Spreadsheet](https://docs.google.com/spreadsheets/d/1kjyb0JGswSufELAKuy5jtuhs6I0ZyvY9Zwa5Nei6aAo/edit#gid=1093073527)
  2. Prototype a change in the code, which isolates the parts dealing with the new SSoT
  3. Create a tool (or use an existing tool) which can write that kind of code (for the full set).
  4. Update the "hand code" to call the "derived" version fo the code
  5. Delete the hand code version
  6. Rinse and Repeat

Included next are examples of the kind of information which is usually embeeded in "source code" directly, but which are much better described outside of the code. Databases and Spreadsheets work well for SSoT - but there are many options for gathering SSoT data from. 

  
The kinds of data that were moved over to the SSoT are: 


  * First and foremost - the list of "ways" of looking at a turtle
  * Valid Turtle Commands (like move/turn/...)
  * Common Shapes (like Triangle and ThreeLines)
  * The specific commands for those shapes
  * See the [SSoT Google Spreadsheet](https://docs.google.com/spreadsheets/d/1kjyb0JGswSufELAKuy5jtuhs6I0ZyvY9Zwa5Nei6aAo/edit#gid=1093073527) for more
### Commands

The "basic" Turtle is able to perform these commands. 

**Move**  
  Moves the specified distance in whatever direction 'the turtle' is currently pointing.  
  **Turn**  
  Turn the specified degrees from the current position  
  **PenUp**  
  Lift the pen off of the paper  
  **PenDown**  
  Put the pen down on the paper  
  **SetColor**  
  Set the color of the pen  
  Some of the tools developed after the first 13 ways, include the following additional commands. 

**DrawPolygon**  
  Turn the number of degrees based on the number of sides passed in  
  **DrawLine**  
  Put the pen down, move distance and the left the pen up  
  **TurnSide**  
  Turn the number of degrees based on the number of sides  
  **Repeat**  
  Repeats the previous N commands the specified number of times  
  **Exec**  
  Executes the given command  
  
### Predefined Scripts

The original article uses these simple commands to demonstrate 13 ways of looking at a turtlle. In each example, he demonstrates the approach by drawing: 


  1. A Triangle
  2. Three Lines
  3. A Polygon

In Designing the single source of truth for this project, I call the first two examples "PredefinedScript". This is a script which only uses the basic Turtle Commands to complete a certain sequence of steps (a "PredefinedScriptStep"). 

  
At this point in time, the SSoT for this project includes 3 Predefined Scripts. They are: 


  * ##### Drawing a Triangle
    
    
      1. **Move** 100
      2. **Turn** 120
      3. **Move** 100
      4. **Turn** 120
      5. **Move** 100
      6. **Turn** 120
  * ##### Drawing a ThreeLines
    
    
      1. **PenDown**
      2. **SetColor** Black
      3. **Move** 100
      4. **PenUp**
      5. **Turn** 90
      6. **Move** 100
      7. **Turn** 90
      8. **PenDown**
      9. **SetColor** Red
      10. **Move** 100
      11. **PenUp**
      12. **Turn** 90
      13. **Move** 100
      14. **Turn** 90
      15. **PenDown**
      16. **SetColor** Blue
      17. **Turn** 45
      18. **Move** 100
  * ##### Drawing a Box
    
    
      1. **Move** 100
      2. **Turn** 90
      3. **Move** 100
      4. **Turn** 90
      5. **Move** 100
      6. **Turn** 90
      7. **Move** 100
      8. **Turn** 90
### The Ways

The purpose of this code is demonstrate different ways to solve the same problem. Variations on a theme. These 18 are listed below. 

##### Way 01 - OOTurtle

Simple OO -- a class with mutable state   
In this design, a simple OO class represents the turtle, and the client talks to the turtle directly.   
  
##### Way 02 - FPTurtle

Simple FP - a module of functions with immutable state   
In this design, the turtle state is immutable. A module contains functions that return a new turtle state, and the client uses these turtle functions directly. The client must keep track of the current state and pass it into the next function call.   
  
##### Way 03 - Api_OO_Core

API (OO Approach) -- OO API calling stateful core class   
In this design, an API layer communicates with a turtle class and the client talks to the API layer. The input to the API are strings, and so the API validates the input and returns a Result containing any errors.   
  
##### Way 04 - Api_FP_Core

API (OO/FP hybrid approach) -- OO API calling stateless functions   
In this design, an API layer communicates with pure turtle functions and the client talks to the API layer. The API layer manages the state (rather than the client) by storing a mutable turtle state. *This approach has been named \   
  
##### Way 05 - TurtleAgent

API (hybrid approach) -- OO API posting messages to an Agent   
In this design, an API layer communicates with a TurtleAgent and the client talks to the API layer. Because the Agent has a message queue, all possible commands are managed with a single discriminated union type (`TurtleCommand`). There are no mutables anywhere. The Agent manages the turtle state by storing the current state as a parameter in the recursive message processing loop.   
  
##### Way 06 - DependencyInjection_Interface1

Dependency injection (using interfaces) -- v1: OO interface   
In this design, an API layer communicates with a Turtle Interface (OO style) or a record of TurtleFunctions (FP style) rather than directly with a turtle. The client injects a specific turtle implementation via the API's constructor.   
  
##### Way 06 - DependencyInjection_Interface2

Dependency injection (using interfaces) - v2: records of functions   
In this design, an API layer communicates with a Turtle Interface (OO style) or a record of TurtleFunctions (FP style) rather than directly with a turtle. The client injects a specific turtle implementation via the API's constructor.   
  
##### Way 07 - DependencyInjection_Functions1

Dependency injection using functions (v1: pass in all functions)   
In this design, an API layer communicates via one or more functions that are passed in as parameters to the API call. These functions are typically partially applied so that the call site is decoupled from the `injection` No interface is passed to the constructor.   
  
##### Way 07 - DependencyInjection_Functions2

Dependency injection using functions (v2: pass in a single function)   
In this design, an API layer communicates via one or more functions that are passed in as parameters to the API call. These functions are typically partially applied so that the call site is decoupled from the `injection` No interface is passed to the constructor.   
  
##### Way 08 - StateMonad

Batch oriented -- Using a state monad (computation expression)   
In this design, the client uses the FP Turtle functions directly. As before, the client must keep track of the current state and pass it into the next function call, but this time the state is kept out of sight by using a State monad (called `turtle` computation expression here) As a result, there are no mutables anywhere.   
  
##### Way 09 - BatchCommands

Batch oriented -- Using a list of commands   
In this design, the client creates a list of `Command`s that will be intepreted later. These commands are then run in sequence using the Turtle library functions. This approach means that there is no state that needs to be persisted between calls by the client.   
  
##### Way 10 - EventSourcing

Event sourcing -- Building state from a list of past events   
In this design, the client sends a `Command` to a `CommandHandler`. The CommandHandler converts that to a list of events and stores them in an `EventStore`. In order to know how to process a Command, the CommandHandler builds the current state from scratch using the past events associated with that particular turtle. Neither the client nor the command handler needs to track state. Only the EventStore is mutable.   
  
##### Way 11 - FRP

Functional Retroactive Programming -- Business logic is based on reacting to earlier events   
In this design, the `write-side` follows the same pattern as the event-sourcing example. A client sends a Command to a CommandHandler, which converts that to a list of events and stores them in an EventStore. However in this design, the CommandHandler only updates state and does NOT do any complex business logic. The domain logic is done on the \   
  
##### Way 12 - BranchingOnResponse

Monadic control flow -- Making decisions in the turtle computation expression   
In this design, the turtle can reply to certain commands with errors. The code demonstrates how the client can make decisions inside the turtle computation expression while the state is being passed around behind the scenes.   
  
##### Way 13 - InterpreterV1

The interpreter pattern   
In this design, the client builds a data structure (`TurtleProgram`) that represents the instructions. This Turtle Program can then interpreted later in various ways   
  
##### Way 13 - InterpreterV2

The interpreter pattern   
In this design, the client builds a data structure (`TurtleProgram`) that represents the instructions. This Turtle Program can then interpreted later in various ways   
  
##### Way 14 - AdtTurtle

Abstract Data Turtle - a private type with an associated module of functions   
In this design, the details of the turtle structure is hidden from the client, so the it could be changed without breaking any code. See https://www.reddit.com/r/fsharp/comments/36s0zr/structuring_f_programs_with_abstract_data_types/? for more on ADTs in F#.   
  
##### Way 15 - CapabilityBasedTurtle

API with capabilities   
In this design, the turtle exposes a list of functions (capabilities) after each action. These are the ONLY actions available to the client More on capability-based security at http://fsharpforfunandprofit.com/posts/capability-based-security/   
  
  
