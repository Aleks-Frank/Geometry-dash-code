using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupAnimation : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        if (animator != null)
        {
            animator.SetBool("IsOpen", true); // Устанавливаем параметр аниматора для запуска анимации
        }
    }
}
