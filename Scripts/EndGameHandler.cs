using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] private Image fadeImage; 
    [SerializeField] private float fadeDuration = 2f; // 淡出持续时间
    [SerializeField] private string nextSceneName; 

    private bool isGameEnding = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 如果检测到的组件有 "sea" 标签，且游戏未结束
        if (other.CompareTag("Sea") && !isGameEnding)
        {
            Debug.Log("Sea touch!");
            isGameEnding = true;
            StartCoroutine(EndGame());
        }
    }

    //结束游戏
    private IEnumerator EndGame()
    {
        Time.timeScale = 0f;
        yield return StartCoroutine(FadeOut()); // 开始黑屏淡出
        // 等待淡出完成后，加载下一个场景
        SceneManager.LoadScene(nextSceneName);
    }

    // 实现黑屏淡出效果
    private IEnumerator FadeOut()
    {
        Color fadeColor = fadeImage.color;
        float fadeSpeed = 1f / fadeDuration;
        float fadeAmount = 0f;
        while (fadeAmount < 1f)
        {
            fadeAmount += fadeSpeed * Time.unscaledDeltaTime;
            fadeColor.a = Mathf.Clamp01(fadeAmount);
            fadeImage.color = fadeColor;
            yield return null;
        }
    }
}

