using UnityEngine;

public interface ILogicComponents
{
    public Vector2Int Position { get; }
}

public interface IBox : ILogicComponents
{
    public Board board { get; set; }
    new public Vector2Int Position { get; set; }
}

public interface IPlayer : ILogicComponents
{
    public Board board { get; set; }
    new public Vector2Int Position { get; set; }
}

public interface IWind : ILogicComponents { }

public interface ITile : ILogicComponents { }

public interface IGoal : ITile { }
public interface IWall : ITile { }
public interface INone : ITile { }
