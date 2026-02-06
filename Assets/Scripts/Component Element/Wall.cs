using UnityEngine;

public class Wall : MonoBehaviour, IWall
{

    public Vector2Int Position
    {
        get =>
         new(((int)transform.position.x), ((int)transform.position.z));
    }
}
