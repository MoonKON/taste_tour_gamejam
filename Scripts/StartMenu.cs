using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer; // �϶� Video Player GameObject ������
    public RawImage rawImage;

    private void Start()
    {
        // �� Raw Image ��͸��������Ϊ 0
        Color rawImageColor = rawImage.color;
        rawImageColor.a = 0f;
        rawImage.color = rawImageColor;

        // �� Video Player ��ͼ����Ⱦ�� Raw Image
        videoPlayer.targetTexture = new RenderTexture(1920, 1080, 0); // ����һ����Ⱦ����
        rawImage.texture = videoPlayer.targetTexture; // �� Raw Image ����������Ϊ��Ⱦ����
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

        // �ȴ���Ƶ�������
        while (videoPlayer.isPlaying)
        {
            yield return null; // �ȴ���Ƶ����
        }

        // �ȴ� 1 ��
        yield return new WaitForSeconds(38f);

        // �л�����һ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
