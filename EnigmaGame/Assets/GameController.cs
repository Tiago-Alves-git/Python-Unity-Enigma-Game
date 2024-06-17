using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject EnigmaPanels;
    public GameObject LandingWindow;
    public GameObject HowToPanel;
    public AudioSource popBtn;
    public GameObject GameEndPanel;
    public Button PlayBtn, HowToBtn, CloseHowToPanel, Option1, Option2, Option3, Option4, playAgainBtn;
    public GameObject ImagePanel;
    public TextMeshProUGUI enigmaText, optionText1, optionText2, optionText3, optionText4, pointsResult, messagePoints;
    public int currentQuestion = 0;
    public int pontuation = 0;
    public List<QuestionsAndAnswers> questionsAndAnswers;

    void Start()
    {
        InitializeGameData();
        PlayBtn.onClick.AddListener(StartGame);
        HowToBtn.onClick.AddListener(ShowRules);
        CloseHowToPanel.onClick.AddListener(CloseRules);
    }

    void InitializeGameData()
    {
        TextAsset jsonData = Resources.Load<TextAsset>("EnigmaData");
        if (jsonData != null)
        {
            Debug.Log("JSON data loaded successfully.");
            questionsAndAnswers = QuestionsAndAnswers.LoadDataFromJson(jsonData.text);
            if (questionsAndAnswers != null && questionsAndAnswers.Count > 0)
            {
                Debug.Log("Questions and answers loaded successfully.");
            }
            else
            {
                Debug.LogError("Failed to load questions and answers from JSON.");
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON data.");
        }
    }

    void StartGame()
    {
        EnigmaPanels.SetActive(true);
        LandingWindow.SetActive(false);
        PopulateData();
    }

    void PopulateData()
    {
        if (currentQuestion < questionsAndAnswers.Count)
        {
            QuestionsAndAnswers currentQA = questionsAndAnswers[currentQuestion];
            enigmaText.text = currentQA.EnigmaQuote;
            Image imageComponent = ImagePanel.GetComponent<Image>();
            imageComponent.sprite = LoadSprite(currentQA.ImagePath);

            optionText1.text = currentQA.Answers[0];
            optionText2.text = currentQA.Answers[1];
            optionText3.text = currentQA.Answers[2];
            optionText4.text = currentQA.Answers[3];
            Option1.onClick.AddListener(()=> checkGuess(0));
            Option2.onClick.AddListener(()=> checkGuess(1));
            Option3.onClick.AddListener(()=> checkGuess(2));
            Option4.onClick.AddListener(()=> checkGuess(3)); 
        }
        else EndGame();
    }

    Sprite LoadSprite(string path)
    {
        string resourcePath = path.Replace("Assets/Resources/", "").Replace(".jpg", "");
        Texture2D texture = Resources.Load<Texture2D>(resourcePath);
        if (texture == null)
        {
            Debug.LogError($"Failed to load texture at path: {resourcePath}");
            return null;
        }
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    void checkGuess(int optionGuessed)
    {
        QuestionsAndAnswers currentQA = questionsAndAnswers[currentQuestion];

        Debug.Log($"Opção checada: {optionGuessed}");
        if (optionGuessed == currentQA.CorrectAnswer) {
            Debug.Log($"Vocë acertou! {currentQA.CorrectAnswer} era realmente a correta");
            currentQuestion++;
            pontuation += 10;
            RemoveListeners();
            PopulateData();
        } else {
            currentQuestion += 1;
            RemoveListeners();
            PopulateData();
        }
    }

    void RemoveListeners()
    {
            Option2.onClick.RemoveAllListeners(); // Remove existing listeners
            Option3.onClick.RemoveAllListeners(); // Remove existing listeners
            Option1.onClick.RemoveAllListeners(); // Remove existing listeners
            Option4.onClick.RemoveAllListeners(); // Remove existing listeners
    }

    void ShowRules()
    {
        HowToPanel.gameObject.SetActive(true);
    }

    void CloseRules()
    {
        HowToPanel.gameObject.SetActive(false);
    }

    void EndGame() 
    {
        pointsResult.text = pontuation.ToString();
        if (pontuation > 20) {
            messagePoints.text = "Nossa, meus parabens! a sua pontuação foi de:";
        } else {
            messagePoints.text = "Nossa, sinto muito! a sua pontuação foi de:";
        }
        GameEndPanel.SetActive(true);
        EnigmaPanels.SetActive(false);
        playAgainBtn.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        LandingWindow.SetActive(true);
        GameEndPanel.SetActive(false);
        pontuation = 0;
        currentQuestion = 0;
    }
}
