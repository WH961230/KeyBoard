using UnityEngine;

public class KeyBoardControl : MonoBehaviour
{
    [SerializeField] private AudioClip keyBoardDownClip;
    [SerializeField] private AudioClip keyBoardUpClip;
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
                animator.SetBool("KeyCode", true);
            }
            if (null != audioSource)
            {
                audioSource.clip = keyBoardDownClip;
                audioSource.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (null != animator)
            {
                animator.SetBool("KeyCode", false);
            }
            if (null != audioSource)
            {
                audioSource.clip = keyBoardUpClip;
                audioSource.Play();
            }
        }
    }
}
