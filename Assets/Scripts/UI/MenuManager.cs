using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] items;
        private List<MenuItem> _options;
        private int _selectedIndex;

        private void Awake()
        {
            _options = new List<MenuItem>();
            foreach (var item in items) _options.Add(item.GetComponent<MenuItem>());
            _selectedIndex = 0;
        }

        private void Start()
        {
            _options[_selectedIndex].Select();
        }

        private void Update()
        {
            if (_options == null || _options.Count == 0) return;
            if (Input.GetKeyDown(KeyCode.DownArrow)) SelectNext();
            if (Input.GetKeyDown(KeyCode.UpArrow)) SelectPrevious();
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) ExecuteMenuItem();
        }

        private void ExecuteMenuItem()
        {
            _options[_selectedIndex].Execute();
        }

        private void SelectNext()
        {
            _options[_selectedIndex].DeSelect();
            _selectedIndex = (_selectedIndex + 1) % _options.Count;
            _options[_selectedIndex].Select();
        }

        private void SelectPrevious()
        {
            _options[_selectedIndex].DeSelect();
            _selectedIndex = _selectedIndex > 0 ? _selectedIndex - 1 : _options.Count - 1;
            _options[_selectedIndex].Select();
        }
    }
}