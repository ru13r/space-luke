using UnityEngine;

public class HitScript: MonoBehaviour
    {
        private Renderer _renderer;
        private Color _originalColor;
        
        public void Start()
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
            _originalColor = _renderer.material.color;
        }
        public void HitAnimation()
        {
            _renderer.material.color = Color.red;
            Invoke(nameof(RestoreColor), 0.2f);
        }
        
        public void DestroyAnimation()
        {
            _renderer.material.color = Color.red;
            Invoke(nameof(RestoreColor), 0.2f);
        }

        private void RestoreColor()
        {
            _renderer.material.color = _originalColor;
        }
        
        private void DestroyObject()
        {
            _renderer.material.color = _originalColor;
        }
    }
