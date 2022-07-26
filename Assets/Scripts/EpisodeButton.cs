using UnityEngine;

public class EpisodeButton : MonoBehaviour
{
    [SerializeField] private int EpisodeNumber = 1;

    public void OnClick()
    {
        Debug.Log($"{EpisodeNumber:0,0}" + " 에피소드가 선택되었습니다.");
    }
}
