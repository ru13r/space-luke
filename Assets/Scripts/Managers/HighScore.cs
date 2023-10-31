using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Managers
{
    [Serializable]
    public struct ScoreEntry
    {
        public string name;
        public int score;

        public ScoreEntry(int score, string name)
        {
            this.score = score;
            this.name = name;
        }
    }

    [Serializable]
    public struct ScoreList
    {
        public List<ScoreEntry> list;
    }

    [Serializable]
    public static class HighScore
    {
        private const int MaxSize = 10;
        private static ScoreList _scores;

        private static readonly string Path = Application.persistentDataPath + "/HighScores.json";


        public static bool IsNewTopScore(int score)
        {
            return !IsEmpty() && score > GetTopScore();
        }

        public static bool IsNewHighScore(int score)
        {
            return IsEmpty() || HasSpace() || score > GetBottomScore();
        }

        private static bool IsEmpty()
        {
            return _scores.list == null || _scores.list.Count == 0;
        }

        private static bool HasSpace()
        {
            return _scores.list.Count < MaxSize;
        }

        public static void AddScore(int score, string name)
        {
            _scores.list.Add(new ScoreEntry(score, name));
            _scores.list = _scores.list.OrderByDescending(s => s.score).ToList();
            if (_scores.list.Count > MaxSize) _scores.list.RemoveAt(MaxSize);

            SaveScores();
        }

        public static ScoreList GetScores()
        {
            return _scores;
        }

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
                _scores = JsonUtility.FromJson<ScoreList>(json);
            }
            else
            {
                _scores = new ScoreList();
            }
        }

        private static int GetTopScore()
        {
            return _scores.list.Count == 0 ? 0 : _scores.list[0].score;
        }

        private static int GetBottomScore()
        {
            return _scores.list.Count == 0 ? 0 : _scores.list[^1].score;
        }
    }
}