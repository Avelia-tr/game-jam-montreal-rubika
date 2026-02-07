using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Board board;

    void Start() { }

    private void OnMove(InputValue _input)
    {
        var input = _input.Get<Vector2>();

        if (input.x == 0 && input.y == 0) return;

        board.Move(new(Mathf.RoundToInt(input.x), Mathf.RoundToInt(input.y)));

        if (input.x < 0)
        {
            //animator.ResetTrigger( "Gauche");
          animator.Play("Gauche", 0,0f);
            //animator.SetTrigger("Gauche");
        }
        if (input.x > 0)
        {
     
            //animator.SetTrigger("Droite");
            animator.Play("Droite", 0,0f);
        }
        if (input.y < 0)
        {

            //animator.SetTrigger("Bas");
        }
        if (input.y > 0)
        {

            //animator.SetTrigger("Haut");
        }
        //automatize input on hold
    }

    private void OnPull(InputValue _input)
    {
        if (!_input.isPressed) return;
        board.Pull();
    }
}
