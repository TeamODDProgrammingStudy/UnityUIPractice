using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager current = null;
    [SerializeField] private RectTransform _mouseCursor;
    private void Start()
    {
        if (current != null) {
            Destroy(current.gameObject);
        }
        Cursor.visible = false;
        current = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        _mouseCursor.position = Input.mousePosition + new Vector3(30,-30,0);
    }
}
