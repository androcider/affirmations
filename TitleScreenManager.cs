using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TitleScreenManager : MonoBehaviour
{
    public Image backgroundImage;
    public Button howToUseButton;
    public Button getAffirmationButton;

    private List<Sprite> backgrounds;

    void Start()
    {
        LoadBackgroundsFromResources();
        DisplayRandomBackground();

        howToUseButton.onClick.AddListener(OnHowToUseButtonClicked);
        getAffirmationButton.onClick.AddListener(OnGetAffirmationButtonClicked);
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

    void OnHowToUseButtonClicked()
    {
        Debug.Log("How to Use button clicked.");
        // Load the "How to Use" scene or display information
        SceneManager.LoadScene("Scenes/HowTo"); // Uncomment if you have a scene for "How to Use"
    }

    void OnGetAffirmationButtonClicked()
    {
        Debug.Log("Get Affirmation button clicked.");
        // Load the main scene with affirmations
        SceneManager.LoadScene("Scenes/MainScene"); // Ensure this matches the exact name of your main scene
    }
}
