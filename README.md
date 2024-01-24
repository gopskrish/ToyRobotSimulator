# ToyRobotSimulator

## Overview

This console application simulates a toy robot moving on a square tabletop. The robot can be placed on the table, moved, rotated, and its position reported. The simulation is constrained within a 5x5 unit tabletop.

## Features

- Commands:
  - PLACE X,Y,F
  - MOVE
  - LEFT
  - RIGHT
  - REPORT
- Directions:
  - NORTH
  - EAST
  - SOUTH
  - WEST 
where X and Y integers and F is the Directions
## Getting Started
### Build and Run

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/ToyRobotSimulator.git
   ```
2. Navigate to the directory
3. Restore Nuget packages
     ```bash
     dotnet restore
     ```
4. Build the project
   ```bash
   dotnet build
   ```
5. Run the app
   ```bash
   dotnet run
   ```

### Output
Check the commands.txt file for some sample inputs and outputs
