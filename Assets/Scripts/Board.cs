using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Board : MonoBehaviour
{
    // get input and do logic

    public Vector2Int PlayerPosition;

    public bool PlayerDead = false;

    public Vector2Int direction;
    public Vector2Int[] Boxes;

    public Tiles[][] tiles;

    public Dictionary<Vector2Int, Tiles> tiles2;


    public delegate void eventsTick();
    public event eventsTick ticks;

    // replace those data with the actual objects ?
    // with maybe a hashTable on Vector2Int

    void Start()
    {
        var query = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<ILogicComponents>().ToArray();

        foreach (var entities in query)
        {
            switch (entities)
            {
                case IPlayer player:
                    break;
                case IBox box:
                    break;
                case IWall wall:
                    break;
                case IGoal goal:
                    break;
                default:
                    break;
            }
        }
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
        var newPosition = PlayerPosition + move;

        if (tiles[newPosition.x][newPosition.y] == Tiles.Wall) return;

        var boxCheck = IsBoxIn(newPosition);

        if (boxCheck is null)
        {
            PlayerPosition = newPosition;
            // Move Anim event ?
            return;
        }

        var newBoxPosition = newPosition + move;

        if (tiles[newBoxPosition.x][newBoxPosition.y] == Tiles.Wall)
        {
            // we cannot do the movement so everything stops
            return;
        }

        // pushevent anim ?

        Boxes[boxCheck.Value] = newBoxPosition;
        PlayerPosition = newPosition;
    }

    public void Pull()
    {
        if (PlayerDead) return;
        PullLogic();

        PlayerDead = DeathCheck();
        // raise tick event ?

        ticks.Invoke();
        // winCheck
    }
    public void PullLogic()
    {
        var boxToPull = PlayerPosition + direction;

        var boxCheck = IsBoxIn(boxToPull);

        if (boxCheck is null)
        {
            //nothing happens 
            //empty pull event ?
            return;
        }

        PlayerPosition -= direction;
        Boxes[boxCheck.Value] = PlayerPosition;
    }

    bool DeathCheck() { throw new NotImplementedException(); }

    bool WinCheck() { throw new NotImplementedException(); }

    int? IsBoxIn(Vector2Int position)
    {
        for (int i = 0; i < Boxes.Length; i++)
        {
            if (Boxes[i] == position) return i;
        }

        return null;
    }
}

public enum Tiles
{
    None,
    Wall,
    Targets,
}
