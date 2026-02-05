using UnityEngine;

public class BoxSprite : MonoBehaviour, IBox
{
    public Board board { get; set; }

    void Start() { }

    void Update() { }

    void UpdatePosition()
    {
        //Do Animation/Tween ?
        //

        var newPosition = new Vector3(board.PlayerPosition.x, transform.position.y, board.PlayerPosition.y);

        transform.position = newPosition;
    }
}
