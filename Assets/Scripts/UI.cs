using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    Button MainMenuButton, BackButton;

    const string MAIN_MENU_SCENE_NAME = "Main Menu";

    [SerializeField]
    GameObject endPannel, WinText, LooseText;

    void Start()
    {
        MainMenuButton.onClick.AddListener(GoBackToMainMenu);
        BackButton.onClick.AddListener(GoBackToMainMenu);

        var board = FindFirstObjectByType<Board>();

        board.OnPlayerDeath += Loose;
        board.OnPlayerWin += Win;
    }

    void GoBackToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_SCENE_NAME);
    }

    void Win()
    {
        endPannel.SetActive(true);
        WinText.SetActive(true);
    }

    void Loose()
    {
        endPannel.SetActive(true);
        LooseText.SetActive(true);
    }
}
