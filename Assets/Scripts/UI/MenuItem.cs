using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class MenuItem : MonoBehaviour
    {
        private const string MarkerLeft = ">";
        private const string MarkerRight = "<";
        private Color _selectedColor;
        private string _text;
        private TextMeshProUGUI _textMeshPro;
        private Color _unselectedColor;

        private void Awake()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
            _text = _textMeshPro.text;
            _selectedColor = Color.yellow;
            _unselectedColor = Color.white;
        }

        public void Select()
        {
            _textMeshPro.text = MarkerLeft + _text + MarkerRight;
            _textMeshPro.color = _selectedColor;
        }

        public void DeSelect()
        {
            _textMeshPro.text = _text;
            _textMeshPro.color = _unselectedColor;
        }

        public abstract void Execute();
    }
}