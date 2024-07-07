using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HomeScreenManager : MonoBehaviour
{
    public Image backgroundImage;
    public Button homeButton;

    private List<Sprite> backgrounds;

    void Start()
    {
        LoadBackgroundsFromResources();
        DisplayRandomBackground();

        homeButton.onClick.AddListener(HomeButtonClicked);

    }

    void LoadBackgroundsFromResources()
    {
        backgrounds = new List<Sprite>();
        Object[] loadedBackgrounds = Resources.LoadAll("Backgrounds", typeof(Sprite));

        foreach (Object obj in loadedBackgrounds)
        {
            backgrounds.Add(obj as Sprite);
        }
    }

    void DisplayRandomBackground()
    {
        if (backgrounds != null && backgrounds.Count > 0)
        {
            int randomIndex = Random.Range(0, backgrounds.Count);
            backgroundImage.sprite = backgrounds[randomIndex];
        }
        else
        {
            Debug.Log("No backgrounds available.");
        }
    }

    void HomeButtonClicked()
    {
        Debug.Log("How to Use button clicked.");
        // Load the "How to Use" scene or display information
        SceneManager.LoadScene("Scenes/TitleScreen"); // Uncomment if you have a scene for "How to Use"
    }
}