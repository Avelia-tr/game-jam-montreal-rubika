using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    string scene;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoToLevel);
    }

    void GoToLevel()
    {
        SceneManager.LoadScene(scene);
    }

}
