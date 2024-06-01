using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // �������� ������ ������� �����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ��������� ������� ����� � ������������� ������ � ����������� �� ���
        if (currentSceneIndex == 0 || currentSceneIndex == 1)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
