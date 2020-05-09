public class Rover
{
  public Direction Orientation { get; set; }
  public Coordinate Location { get; set; }

  public Rover()
  {
    Location = new Coordinate();
  }

  public void MoveForward()
  {
    switch (Orientation)
    {
      case Direction.North: Location = Location.AdjustYBy(1); break;
      case Direction.East: Location = Location.AdjustXBy(1); break;
      case Direction.South: Location = Location.AdjustYBy(-1); break;
      case Direction.West: Location = Location.AdjustXBy(-1); break;
    }
  }

  public void MoveBackward()
  {
    switch (Orientation)
    {
      case Direction.North: Location = Location.AdjustYBy(-1); break;
      case Direction.East: Location = Location.AdjustXBy(-1); break;
      case Direction.South: Location = Location.AdjustYBy(1); break;
      case Direction.West: Location = Location.AdjustXBy(1); break;
    }
  }

  public void TurnLeft()
  {
    switch (Orientation)
    {
      case Direction.North: Orientation = Direction.West; break;
      case Direction.West: Orientation = Direction.South; break;
      case Direction.South: Orientation = Direction.East; break;
      case Direction.East: Orientation = Direction.North; break;
    }
  }

  public void TurnRight()
  {
    switch (Orientation)
    {
      case Direction.North: Orientation = Direction.East; break;
      case Direction.East: Orientation = Direction.South; break;
      case Direction.South: Orientation = Direction.West; break;
      case Direction.West: Orientation = Direction.North; break;
    }
  }
}