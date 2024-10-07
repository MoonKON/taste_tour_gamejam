using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private int lastLevelIndex; // ��¼��ɫ����ǰ�Ĺؿ�

    void Awake()
    {
        // ȷ�� LevelManager �ڳ����䱣��Ψһ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ��¼��ǰ�ؿ�������
    public void SetLastLevelIndex()
    {
        lastLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // �л�����������
    public void LoadDeadScene()
    {
        SceneManager.LoadScene("Dead"); // "DeadScene" ����������������
    }

    // ���¼�������ǰ�Ĺؿ�
    public void ReloadLastLevel()
    {
        SceneManager.LoadScene(lastLevelIndex);
    }
}

