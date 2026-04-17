using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button playButton;
    public Button narrationButton;
    public Button quitButton;
    public Button backButton;
    public VisualElement mainMenu;
    public VisualElement narrationMenu;
    void PlayButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void NarrationButtonPressed()
    {
        mainMenu.style.display = DisplayStyle.None;
        narrationMenu.style.display = DisplayStyle.Flex;
    }
    void BackButtonPressed()
    {
        mainMenu.style.display = DisplayStyle.Flex;
        narrationMenu.style.display = DisplayStyle.None;
    }
    void QuitButtonPressed()
    {
        Application.Quit();
    }
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        playButton = root.Q<Button>("PlayButton");
        narrationButton = root.Q<Button>("NarrationButton");
        quitButton = root.Q<Button>("QuitButton");
        backButton = root.Q<Button>("BackButton");
        mainMenu = root.Q<VisualElement>("MainMenu");
        narrationMenu = root.Q<VisualElement>("NarrationMenu");
        playButton.clicked += PlayButtonPressed;
        narrationButton.clicked += NarrationButtonPressed;
        backButton.clicked += BackButtonPressed;
        quitButton.clicked += QuitButtonPressed;
    }
}
