using UnityEngine;
using System;
using System.Linq;

public class Board : MonoBehaviour
{
    // get input and do logic

    Vector2Int PlayerPosition;

    bool PlayerDead = false;

    Vector2Int direction;
    Vector2Int[] Boxes;

    Tiles[][] tiles;

    void Start()
    {
    }

    public void Move(Vector2Int move)
    {
        if (PlayerDead) return;
        MoveLogic(move);
        // ticks ?
        direction = move;
    }

    public void MoveLogic(Vector2Int move)
    {
        var newPosition = PlayerPosition + move;

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

enum Tiles
{
    None,
    Wall,
    Targets,
}
