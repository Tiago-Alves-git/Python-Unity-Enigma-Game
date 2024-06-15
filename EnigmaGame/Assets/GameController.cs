using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject EnigmaPanels;
    public GameObject LandingWindow;
    public GameObject HowToPanel;
    public Button PlayBtn, HowToBtn, CloseHowToPanel;

    void Start()
    {
        PlayBtn.onClick.AddListener(StartGame);
        HowToBtn.onClick.AddListener(ShowRules);
        CloseHowToPanel.onClick.AddListener(CloseRules);
    }

    void StartGame()
    {
        EnigmaPanels.SetActive(true);
        LandingWindow.SetActive(false);
    }

    void ShowRules()
    {
        HowToPanel.gameObject.SetActive(true);
    }

    void CloseRules()
    {
        HowToPanel.gameObject.SetActive(false);
    }
}
