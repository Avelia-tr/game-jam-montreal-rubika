interface ILogicComponents { }

interface IBox : ILogicComponents
{
    public Board board { get; set; }
}

interface IPlayer : ILogicComponents
{
    public Board board { get; set; }
}

interface IWind : ILogicComponents { }

interface ITile : ILogicComponents { }

interface IGoal : ITile { }
interface IWall : ITile { }
interface INone : ITile { }
