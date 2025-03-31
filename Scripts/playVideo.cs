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
        while (videoPlayer.isPlaying) //wait for the video to play
        {
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        // exchange to the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
