using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameWindow;
    public GameObject scoreWindow;
    public Text rulesText;
    public Text scoreText;
    public Button playButton;
    public Button rulesButton;
    public Button retryButton;

    void Start()
    {
        playButton.onClick.AddListener(StartGame);
        rulesButton.onClick.AddListener(ShowRules);
        retryButton.onClick.AddListener(RestartGame);
    }

    void StartGame()
    {
        mainMenu.SetActive(false);
        gameWindow.SetActive(true);
    }

    void ShowRules()
    {
        rulesText.text = "Regras do jogo:\n" + 
                         "1. Cada imagem terá até 5 textos enigmáticos.\n" + 
                         "2. Você terá 2 tentativas para clicar no objeto certo.\n" + 
                         "3. Pontuação: Acertar de primeira = 10 pontos, de segunda = 5 pontos, errar = 0 pontos.";
        rulesText.gameObject.SetActive(true);
    }

    public void EndGame(int score)
    {
        gameWindow.SetActive(false);
        scoreWindow.SetActive(true);
        scoreText.text = "Sua pontuação: " + score;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
