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
      case Direction.South: Location=Location.AdjustYBy(-1); break;
      case Direction.West: Location=Location.AdjustXBy(-1); break;
    }
  }

  public void MoveBackward()
  {
    switch(Orientation)
    {
      case Direction.North: Location = Location.AdjustYBy(-1); break;
      case Direction.East: Location = Location.AdjustXBy(-1); break;
      case Direction.South: Location = Location.AdjustYBy(1); break;
      case Direction.West: Location = Location.AdjustXBy(1); break;
    }
  }
}