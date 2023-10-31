using System.Collections;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class BlinkingObject : MonoBehaviour
    {
        private const float BlinkDelay = 0.2f;
        private const int BlinkCount = 10;
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            StartCoroutine(nameof(Blink));
        }

        private IEnumerator Blink()
        {
            for (var i = 0; i < BlinkCount; i++)
            {
                _text.enabled = false;
                yield return new WaitForSeconds(BlinkDelay);
                _text.enabled = true;
                yield return new WaitForSeconds(BlinkDelay);
            }

            gameObject.SetActive(false);
        }
    }
}