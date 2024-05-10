using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    Text textComponent; // Corrected variable name to match Text component
    public static int coinAmount;

    void Start()
    {
        textComponent = GetComponent<Text>(); // Corrected to use Unity's built-in Text component
        UpdateScoreText(); // Call this function to initialize the text with the initial coinAmount
    }

    // Update is called once per frame
    void Update()
    {
        // You may not need to update the score every frame if it doesn't change dynamically
        // If it does, then you can leave this method as is.
    }

    // Call this function whenever the coinAmount changes, e.g., when the player collects a coin
    public void UpdateScoreText()
    {
        textComponent.text = coinAmount.ToString();
    }
}
