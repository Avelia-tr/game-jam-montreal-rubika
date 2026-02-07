using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button exit, levelSelect, backButton;

    [SerializeField]
    GameObject levelSelectScreen, TitleScreen;

    void Start()
    {
        exit.onClick.AddListener(Application.Quit);
        levelSelect.onClick.AddListener(ShowLevelSelect);
        backButton.onClick.AddListener(ShowTitleScreen);

    }

    void ShowLevelSelect()
    {
        levelSelectScreen.SetActive(true);
        TitleScreen.SetActive(false);
    }

    void ShowTitleScreen()
    {
        levelSelectScreen.SetActive(false);
        TitleScreen.SetActive(true);
    }

}
