using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Movie : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // �϶���� VideoPlayer ��������

    void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("No VideoPlayer assigned.");
            return;
        }

        // ������Ƶ���Ž����¼�
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // ��Ƶ���Ž���ʱ���ô˷���
    private void OnVideoEnd(VideoPlayer vp)
    {
        // �л�����һ������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
