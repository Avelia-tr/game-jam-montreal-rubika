using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Board : MonoBehaviour
{
    // get input and do logic

    public IPlayer player;

    public bool PlayerDead = false;

    public Vector2Int direction;
    public IBox[] Boxes;

    public Dictionary<Vector2Int, Tiles> tiles;


    public delegate void eventsTick();
    public event eventsTick ticks;

    // replace those data with the actual objects ?
    // with maybe a hashTable on Vector2Int

    void OnEnable()
    {
        SetUpData();
    }

    public void Move(Vector2Int move)
    {
        if (PlayerDead) return;
        MoveLogic(move);
        // ticks ?
        ticks.Invoke();
        direction = move;
    }

    public void MoveLogic(Vector2Int move)
    {
        var newPosition = player.Position + move;

        if (CheckTileAt(newPosition, Tiles.Wall)) return;

        var boxCheck = IsBoxIn(newPosition);

        if (boxCheck is null)
        {
            player.Position = newPosition;
            // Move Anim event ?
            return;
        }

        var newBoxPosition = newPosition + move;

        if (CheckTileAt(newBoxPosition, Tiles.Wall))
        {
            // we cannot do the movement so everything stops
            return;
        }

        // pushevent anim ?

        Boxes[boxCheck.Value].Position = newBoxPosition;
        player.Position = newPosition;

        if (WinCheck())
        {
            PlayerDead = true;
            print("WINNNNNNNNNNNNNN");
        }
    }

    public void Pull()
    {
        if (PlayerDead) return;
        PullLogic();

        PlayerDead = DeathCheck();
        // raise tick event ?

        ticks.Invoke();
        // winCheck
        //

        if (WinCheck())
        {
            PlayerDead = true;
            print("WINNNNNNNNNNNNNN");
        }
    }
    public void PullLogic()
    {
        var boxToPull = player.Position + direction;

        var boxCheck = IsBoxIn(boxToPull);

        if (boxCheck is null)
        {
            //nothing happens 
            //empty pull event ?
            return;
        }

        Boxes[boxCheck.Value].Position = player.Position;
        player.Position -= direction;
    }

    bool DeathCheck() => Boxes.Any(a => a.Position == player.Position);

    bool WinCheck() => Boxes.All(a => CheckTileAt(a.Position, Tiles.Targets));

    bool CheckTileAt(Vector2Int position, Tiles type)
    {
        Tiles ToTest = Tiles.None;
        return tiles.TryGetValue(position, out ToTest) && ToTest == type;
    }

    int? IsBoxIn(Vector2Int position)
    {
        for (int i = 0; i < Boxes.Length; i++)
        {
            if (Boxes[i].Position == position) return i;
        }

        return null;
    }

    void SetUpData()
    {
        var query = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<ILogicComponents>().ToArray();

        tiles = new();
        var lboxes = new List<IBox>();

        foreach (var entities in query)
        {
            switch (entities)
            {
                case IPlayer lplayer:
                    player = lplayer;
                    player.board = this;
                    break;
                case IBox box:
                    box.board = this;
                    lboxes.Add(box);
                    break;
                case IWall:
                    tiles.Add(entities.Position, Tiles.Wall);
                    break;
                case IGoal:
                    tiles.Add(entities.Position, Tiles.Targets);
                    break;
                default:
                    break;
            }
        }

        Boxes = lboxes.ToArray();
    }

}

public enum Tiles
{
    None,
    Wall,
    Targets,
}
