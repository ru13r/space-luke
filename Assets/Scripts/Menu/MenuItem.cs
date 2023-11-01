using TMPro;
using UnityEngine;

namespace Menu
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class MenuItem : MonoBehaviour
    {
        private const string MarkerLeft = ">";
        private const string MarkerRight = "<";
        private bool _isSelected;
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
            _isSelected = false;
        }

        private void Update()
        {
            if (!_isSelected) return;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) Execute();
        }

        public void Select()
        {
            _isSelected = true;
            _textMeshPro.text = MarkerLeft + _text + MarkerRight;
            _textMeshPro.color = _selectedColor;
        }

        public void DeSelect()
        {
            _isSelected = false;
            _textMeshPro.text = _text;
            _textMeshPro.color = _unselectedColor;
        }

        protected abstract void Execute();
    }
}