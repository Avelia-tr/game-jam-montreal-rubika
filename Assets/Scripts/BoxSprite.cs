using UnityEngine;

public class BoxSprite : MonoBehaviour, IBox
{
    public Board board { get; set; }
    public Vector2Int Position { get; set; }

    void Awake()
    {
        Position = new(((int)transform.position.x), ((int)transform.position.z));
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

        var newPosition = new Vector3(Position.x, transform.position.y, Position.y);

        transform.position = newPosition;
    }
}
