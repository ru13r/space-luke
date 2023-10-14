using UnityEngine;

public class HitAnimation: MonoBehaviour
    {
        private Renderer _renderer;
        private Color _originalColor;
        
        public void Start()
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
            _originalColor = _renderer.material.color;
        }
        public void Play()
        {
            _renderer.material.color = Color.red;
            Invoke(nameof(RestoreColor), 0.2f);
        }
        private void RestoreColor()
        {
            _renderer.material.color = _originalColor;
        }
        
    }
