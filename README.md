# Fraction.UCI

UCI Library to assist with the UCI parsing n stuff...

# Getting started

Lets have an example project named CE *because im lazy*.

1. Clone this repo or add this repo as submodule to an existing repo.  
   `[CE]$ git submodule add https://github.com/Fraction-ChessEngine/Fraction.UCI deps/Fraction.UCI`

2. Add Fraction.UCI.csproj as project reference  
   `[CE]$ dotnet add reference deps/Fraction.UCI/Fraction.UCI/`

3. Create a ~~static~~ class that will later be our engine similar to this:
   ```csharp
   using Fraction.UCI;
   class CE : Engine {
     public CE() : base() {}
     protected override void handle(ICommand command) {
       throw new NotImplementedException();
     }
   }
   ```

4. Implement the handle() function.
   This function will be called every time the engine receives a command.
   I recommend something like the following:
   ```csharp
   switch (command) {
     ...
     case Unknown:
       this.Log(LogLevel.Warning, $"Received unknown command '{command.Serialize()}'");
       break;
   
     default:
       this.Log(LogLevel.Warning, $"Not handling command '{command.Serialize()}'");
       break;
   }
   ```

5. Add boilerplate in Program.cs:
   ```csharp
   var ce = new CE();
   ce.run();
   ```
   
6. Enjoy!
   See the Wiki for more information on Custom commands and uci in general.
   If you have questions or ideas, feel free to open up issues.

# Implementation status *hopefully accurate, as we do not have unit testing as of yet*
- [ ] Unit Testing
- [ ] UCI commands
  - [x] uci
  - [x] debug
  - [x] isready
  - [x] setoption
  - [ ] register
  - [x] ucinewgame
  - [x] position
  - [x] go
  - [x] stop
  - [x] ponderhit
  - [x] quit
  - [x] id
  - [x] uciok
  - [x] readyok
  - [x] bestmove
  - [ ] copyprotection
  - [ ] registration
  - [ ] info *partially*
  - [x] option
- [ ] GUI Side code
- [ ] Comprehensive Wiki
  - [ ] Custom commands
  - [ ] more detail about this lib
  - [x] UCI
- [ ] Nuget package
