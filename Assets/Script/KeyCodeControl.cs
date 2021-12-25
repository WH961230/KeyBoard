using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class KeyCodeControl : MonoBehaviour
{
    private bool holdingDown = false;
    
    public KeyCode code;
    public AudioClip codeDownClip;
    public AudioClip codeUpClip;
    private AudioSource source;
    private bool isWrite = false;
    [NonSerialized] public Vector3 codeOrignVec;
    [NonSerialized] public Tweener codeTweener;
    private Text txt;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void Init(KeyCode code, bool isWrite, Vector3 offsetVec, float downTime, AnimationCurve curve, AudioClip codeDownClip,
        AudioClip codeUpClip, Text txt)
    {
        codeOrignVec = transform.position;
        codeTweener = transform.DOMove(codeOrignVec + offsetVec, downTime).SetEase(curve);
        codeTweener.SetAutoKill(false);
        codeTweener.Pause();
        this.isWrite = isWrite;
        this.code = code;
        this.codeDownClip = codeDownClip;
        this.codeUpClip = codeUpClip;
        this.txt = txt;
    }

    void Update()
    {
        if (Input.GetKeyDown(code))
        {
            source.Stop();
            source.clip = codeDownClip;
            source.Play();
            if (isWrite)
            {
                this.txt.text += code.ToString();
            }
            codeTweener.PlayForward();
        }

        if (Input.GetKeyUp(code))
        {
            source.Stop();
            source.clip = codeUpClip;
            source.Play();
            codeTweener.PlayBackwards();
        }
    }
}
