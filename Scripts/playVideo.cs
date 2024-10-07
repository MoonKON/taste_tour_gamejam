using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class playVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    public IEnumerator Play()
    {
        Debug.Log("Video Play1!!");
        videoPlayer.Play();
        while (videoPlayer.isPlaying)
        {
            yield return null; // �ȴ���Ƶ����
        }
        yield return new WaitForSeconds(1f);

        // �л�����һ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
