using UnityEngine;

public class KeyBoardControl : MonoBehaviour
{
    [SerializeField] private AudioClip keyBoardClip;
    private AudioSource audioSource;
    private Animator animator;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (null != animator)
            {
                animator.SetTrigger("KeyCodeSpace");
            }
            if (null != audioSource)
            {
                audioSource.clip = keyBoardClip;
                audioSource.Play();
            }
        }
    }
}
