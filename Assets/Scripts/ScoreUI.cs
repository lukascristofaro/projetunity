using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI ScoreText;

    void Update()
    {
        string text = PlayerController.score.ToString();
        ScoreText.text = text;
    }
}