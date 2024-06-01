using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Получаем индекс текущей сцены
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Проверяем текущую сцену и воспроизводим музыку в зависимости от нее
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
