using UnityEngine;

namespace Manager
{
    public class CursorManager : MonoBehaviour
    {
        public static CursorManager current = null;
        [SerializeField] private RectTransform _mouseCursor;
        private void Start()
        {
            if (current != null) {
                Destroy(gameObject);
                return;
            }
            else {
                current = this;
            }
            Cursor.visible = false;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            _mouseCursor.position = Input.mousePosition + new Vector3(30,-30,0);
        }
    }
}
