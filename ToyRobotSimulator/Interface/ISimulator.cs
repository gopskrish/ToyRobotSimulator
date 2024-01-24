using ToyRobotSimulator.enums;

namespace ToyRobotSimulator.Interface;

public interface ISimulator
{
    void Place(int XPlace, int YPlace, Directions facing);
    void Move();
    void TurnDirection(Commands commands);
    void GetReport();
}

