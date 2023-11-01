using UnityEngine;

namespace Managers
{
    public class HighScoreListManager : MonoBehaviour
    {
        [SerializeField] private GameObject highScoreEntryPrefab;

        private void MakeHighScoreList()
        {
            HighScore.LoadScoresOrCreateNewList();
            var highScores = HighScore.GetScores();
            if (highScores.list.Count < 1)
                // display message that there are no entries
                return;

            var rotation = highScoreEntryPrefab.transform.rotation;
            var position = highScoreEntryPrefab.transform.position;
            foreach (var score in highScores.list)
            {
                position += new Vector3(0, -25);
                Instantiate(highScoreEntryPrefab, position, rotation);
            }
        }
    }
}