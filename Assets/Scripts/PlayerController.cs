using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeReference]
    Board board;

    void Start() { }

    private void OnMove(InputValue _input)
    {
        var input = _input.Get<Vector2>();
        board.Move(new(Mathf.RoundToInt(input.x), Mathf.RoundToInt(input.y)));

        //automatize input on hold
    }

    private void OnPull(InputValue _input)
    {
        if (!_input.isPressed) return;
        board.Pull();
    }
}
