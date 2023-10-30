using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Managers
{
    public static class HighScore
    {
        private static List<(int score, string name)> _scores;
        private const int MaxSize = 10;

        private static readonly string Path = Application.persistentDataPath + "/HighScores.json";


        public static bool IsNewHighScore(int score)
        {
            if (_scores.Count == 0)
            {
                return false;
            }
            return (score > GetHighestScore());
        }
    
        public static void AddScore(int score, string name)
        {
            _scores.Add((score, name));
            _scores = _scores.OrderByDescending(s => s.score).ToList();

            if (_scores.Count > MaxSize)
            {
                _scores.RemoveAt(MaxSize);
            }
        }

        public static List<(int score, string name)> GetScores() => _scores;
    
        public static void SaveScores()
        {
            var jsonScores = JsonUtility.ToJson(_scores);
            File.WriteAllText(Path, jsonScores);
        }

        public static void LoadScoresOrCreateNewList()
        {
            if (File.Exists(Path))
            {
                var json = File.ReadAllText(Path);
                _scores = JsonUtility.FromJson<List<(int score, string name)>>(json);
            }
            else
            {
                _scores = new List<(int score, string name)>();
            }
        }
    
        private static int GetHighestScore() => _scores.Count == 0 ? 0 : _scores[0].score;
    

    }
}
