using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using MongoDB.Bson;
using MongoDB.Driver;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [System.Serializable]
    public class ScoreData
    {
        public int score;
    }

    public TextMeshProUGUI scoreText;
    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<BsonDocument> collection;

    void Start()
    {
        client = new MongoClient("mongodb+srv://game22403051:peepeepoopoo@cluster0.ya2ut.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
        database = client.GetDatabase("kimatsu1202");
        collection = database.GetCollection<BsonDocument>("kimatsutest");
        int finalScore = ScoreManager.Instance.GetScore();
        scoreText.text = "Score: " + finalScore.ToString();
        SaveScore(finalScore);
    }

    void SaveScore(int score)
    {
        SaveToJson(score);
        SendScoreToMongo(score);
    }

    

    void SaveToJson(int score)
    {
        string path = Application.dataPath + "/score.json";
        ScoreData data = new ScoreData { score = score };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    void SendScoreToMongo(int score)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("doc_id", 0);
        collection.UpdateOne(filter, Builders<BsonDocument>.Update.Set("score", score));
        collection.UpdateOne(filter, Builders<BsonDocument>.Update.Set("timestamp", System.DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));
    }

    public void RestartGame()
    {
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene("GameScene");
    }

}
