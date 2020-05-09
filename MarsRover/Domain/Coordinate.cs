using System;

public struct Coordinate
{
  public int X {get;}
  public int Y {get;}

  public Coordinate(int x, int y)
  {
    X = x;
    Y = y;
  }
  public Coordinate AdjustXBy(int adjustment)
  {
    return new Coordinate(this.X+adjustment, this.Y);
  }
  public Coordinate AdjustYBy(int adjustment)
  {
    return new Coordinate(this.X, this.Y+adjustment);
  }
}