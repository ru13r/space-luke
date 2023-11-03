using Persistence;
using UnityEngine;

namespace UI.Screens
{
    public class HighScoreDisplay : GenericScreen
    {
        [SerializeField] private GameObject highScoreLinePrefab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                MyScreenManager.ChangeScreen(Globals.Screens.Menu);
        }

        private void MakeHighScoreList()
        {
            HighScoreList.Initialize();
            var highScores = HighScoreList.GetScores();
            if (highScores.list.Count < 1)
                // display message that there are no entries
                return;

            var rotation = highScoreLinePrefab.transform.rotation;
            var position = highScoreLinePrefab.transform.position;
            foreach (var score in highScores.list)
            {
                position += new Vector3(0, -25);
                Instantiate(highScoreLinePrefab, position, rotation);
            }
        }
    }
}