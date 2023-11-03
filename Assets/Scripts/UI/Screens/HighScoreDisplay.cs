using System.Collections.Generic;
using Persistence;
using TMPro;
using UnityEngine;

namespace UI.Screens
{
    public class HighScoreDisplay : GenericScreen
    {
        [SerializeField] private GameObject highScoreLinePrefab;
        [SerializeField] private GameObject noHighScoreMessage;
        private List<GameObject> _lines;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                MyScreenManager.ChangeScreen(Globals.Screens.Menu);
        }

        private void OnEnable()
        {
            MakeHighScoreList();
        }

        private void OnDisable()
        {
            if (_lines == null || _lines.Count <= 0) return;
            foreach (var line in _lines) Destroy(line);
        }

        private void MakeHighScoreList()
        {
            HighScoreList.Initialize();
            var highScores = HighScoreList.GetScores();
            if (highScores.list.Count < 1)
            {
                noHighScoreMessage.SetActive(true);
                return;
            }

            _lines = new List<GameObject>();
            var localPosition = new Vector3(0, 140, 0);
            foreach (var scoreEntry in highScores.list)
            {
                var line = Instantiate(highScoreLinePrefab, localPosition, Quaternion.identity);
                line.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").transform, false);
                line.transform.localPosition = localPosition;
                line.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>().text = scoreEntry.name;
                line.transform.Find("Score").gameObject.GetComponent<TextMeshProUGUI>().text =
                    scoreEntry.score.ToString();
                _lines.Add(line);
                localPosition += new Vector3(0, -25);
            }
        }
    }
}