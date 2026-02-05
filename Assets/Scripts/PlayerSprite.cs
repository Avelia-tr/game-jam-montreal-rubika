using UnityEngine;

public class PlayerSprite : MonoBehaviour, IPlayer
{
    public Board board { get; set; }
    public Vector2Int Position { get; set; }

    void Awake()
    {
        Position = new(((int)transform.position.x), ((int)transform.position.y));
    }

    void Start()
    {
        board.ticks += UpdatePosition;
    }

    void Update() { }

    void UpdatePosition()
    {
        //Do Animation/Tween ?
        //

        var newPosition = new Vector3(board.PlayerPosition.x, transform.position.y, board.PlayerPosition.y);

        transform.position = newPosition;
    }
}
