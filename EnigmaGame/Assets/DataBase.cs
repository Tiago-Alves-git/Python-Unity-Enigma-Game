using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionsAndAnswers
{
    public string EnigmaQuote;
    public string ImagePath;
    public string[] Answers;
    public int CorrectAnswer;

    public static List<QuestionsAndAnswers> LoadDataFromJson(string json)
    {
        Debug.Log("Parsing JSON data...");
        QuestionsAndAnswersList questionsAndAnswersList = JsonUtility.FromJson<QuestionsAndAnswersList>(json);
        if (questionsAndAnswersList != null && questionsAndAnswersList.questions != null)
        {
            Debug.Log($"Loaded {questionsAndAnswersList.questions.Count} questions.");
            return questionsAndAnswersList.questions;
        }
        else
        {
            Debug.LogError("Failed to parse JSON into QuestionsAndAnswersList.");
            return null;
        }
    }
}

[System.Serializable]
public class QuestionsAndAnswersList
{
    public List<QuestionsAndAnswers> questions;
}
