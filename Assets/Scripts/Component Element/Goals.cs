using UnityEngine;

public class Goals : MonoBehaviour, IGoal
{

    public Vector2Int Position
    {
        get =>
         new(((int)transform.position.x), ((int)transform.position.y));
    }
}
