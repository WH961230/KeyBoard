using System;
using UnityEngine;

public class KeyBoardControl : MonoBehaviour
{
    [SerializeField] private AudioClip keyBoardDownClip;
    [SerializeField] private AudioClip keyBoardUpClip;
    private const string KeyCodeAnimParam = "KeyCode";
    private AudioSource audioSource;
    private Animator animator;
    private Action keyCodeEvent;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        keyCodeEvent += KeyCodeAction;
    }

    void Update()
    {
        if (Input.anyKeyDown) {
            keyCodeEvent.Invoke();
        }
    }

    void Quit() {
        keyCodeEvent -= KeyCodeAction;
    }

    void KeyCodeAction() 
    {
        foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode)) {
                animator.SetBool(KeyCodeAnimParam, true);
                audioSource.clip = keyBoardDownClip;
                audioSource.Play();
            }

            if (Input.GetKeyUp(kcode)) {
                animator.SetBool(KeyCodeAnimParam, false);
                audioSource.clip = keyBoardUpClip;
                audioSource.Play();
            }
        }
    }
}
