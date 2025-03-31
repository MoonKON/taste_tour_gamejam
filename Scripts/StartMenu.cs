using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;

    private void Start()
    {
        // 将 Raw Image 的透明度设置为 0
        Color rawImageColor = rawImage.color;
        rawImageColor.a = 0f;
        rawImage.color = rawImageColor;

        // 将 Video Player 的图像渲染到 Raw Image
        videoPlayer.targetTexture = new RenderTexture(1920, 1080, 0); 
        rawImage.texture = videoPlayer.targetTexture;
    }


    public void StartGame()
    {
        Debug.Log("StartGame");
        StartCoroutine(StartVideo());
    }

    private IEnumerator StartVideo()
    {
        Debug.Log("Start raw image");
        Color rawImageColor = rawImage.color;
        rawImageColor.a = 0f;
        rawImage.color = rawImageColor;


        float duration = 1f;
        for (float t = 0; t <= duration; t += Time.deltaTime)
        {
            rawImageColor.a = Mathf.Lerp(0f, 1f, t / duration); 
            rawImage.color = rawImageColor;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        videoPlayer.Play();

        // 等待视频播放完成
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // 间隔1s缓冲
        yield return new WaitForSeconds(38f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
