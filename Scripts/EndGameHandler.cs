using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] private Image fadeImage; // ���ں���������Image
    [SerializeField] private float fadeDuration = 2f; // ��������ʱ��
    [SerializeField] private string nextSceneName; // ��Ҫ���ص���һ����������

    private bool isGameEnding = false;

    // ��ײ���
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �����⵽������� "sea" ��ǩ��������Ϸ��δ����
        if (other.CompareTag("Sea") && !isGameEnding)
        {
            Debug.Log("Sea touch!");
            isGameEnding = true; // ��ֹ��δ���
            StartCoroutine(EndGame());
        }
    }

    // ��Ϸ����Э��
    private IEnumerator EndGame()
    {
        // ��ͣ��Ϸ
        Time.timeScale = 0f;

        // ��ʼ��������
        yield return StartCoroutine(FadeOut());

        // �ȴ�������ɺ󣬼�����һ������
        SceneManager.LoadScene(nextSceneName);
    }

    // ʵ�ֺ�������Ч����Э��
    private IEnumerator FadeOut()
    {
        Color fadeColor = fadeImage.color;
        float fadeSpeed = 1f / fadeDuration;
        float fadeAmount = 0f;

        // ѭ���ı�Image��Alphaֵ��ʵ�ֵ���Ч��
        while (fadeAmount < 1f)
        {
            fadeAmount += fadeSpeed * Time.unscaledDeltaTime; // ʹ��unscaledDeltaTime����ӦTime.timeScaleΪ0
            fadeColor.a = Mathf.Clamp01(fadeAmount);
            fadeImage.color = fadeColor;
            yield return null;
        }
    }
}

