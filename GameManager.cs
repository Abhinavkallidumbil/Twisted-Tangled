using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    TangledSnakeUIScript homeUiScript;
    public int SnakesLeft;
    public int ChanceRemaining;
    public TextMeshProUGUI SnakesCountUI;
    public TextMeshProUGUI MovesCountUI;
    public GameObject loosePanel;

    private void Start()
    {
        homeUiScript = FindAnyObjectByType<TangledSnakeUIScript>();
    }
    private void Update()
    {
        CompletedGame();
    }

    public void CompletedGame()
    {
        if (ChanceRemaining <= 0)
        {
            loosePanel.SetActive(true);
        }
        MovesCountUI.text = "Chance Left:"+ChanceRemaining.ToString();
        SnakesCountUI.text = "Snakes Left:"+SnakesLeft.ToString();

        if(SnakesLeft <= 0)
        {
            homeUiScript.WinPanelShows();
        }
    }
    
}
