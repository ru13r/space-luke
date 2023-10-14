using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.Screen.IsOffScreen(gameObject))
        {
            Destroy(gameObject);
        }
        
    }
}
