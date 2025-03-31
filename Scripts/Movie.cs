using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Movie : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("No VideoPlayer assigned.");
            return;
        }
        // 监听视频播放结束事件
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    
    // 视频播放结束时调用此方法
    private void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
