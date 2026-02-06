using UnityEngine;

public class Void : MonoBehaviour, INone
{
    public Vector2Int Position
    {
        get =>
         new(((int)transform.position.x), ((int)transform.position.z));
    }
}
