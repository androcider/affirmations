using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class AffirmationManager : MonoBehaviour
{
    public TextMeshProUGUI affirmationText; // Use TextMeshProUGUI instead of Text
    public Button newAffirmationButton;
    public Image backgroundImage; // Add a reference to the Image component for the background
    private List<string> affirmations;
    private List<Sprite> backgrounds; // List to store background images

    void Start()
    {
        LoadAffirmationsFromCSV();
        LoadBackgroundsFromResources();
        DisplayRandomAffirmationAndBackground();
        newAffirmationButton.onClick.AddListener(DisplayRandomAffirmationAndBackground);
    }

    void LoadAffirmationsFromCSV()
    {
        affirmations = new List<string>();
        TextAsset csvFile = Resources.Load<TextAsset>("affirmations"); // Note: Do not include the .csv extension

        if (csvFile != null)
        {
            using (StringReader sr = new StringReader(csvFile.text))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    affirmations.Add(line);
                }
            }
        }
        else
        {
            Debug.LogError("CSV file not found in Resources folder.");
        }
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

    void DisplayRandomAffirmationAndBackground()
    {
        DisplayRandomAffirmation();
        DisplayRandomBackground();
    }

    void DisplayRandomAffirmation()
    {
        if (affirmations != null && affirmations.Count > 0)
        {
            int randomIndex = Random.Range(0, affirmations.Count);
            affirmationText.text = affirmations[randomIndex];
        }
        else
        {
            affirmationText.text = "No affirmations available.";
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
}
