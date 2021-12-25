using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
class KeyCodeInfo
{
    public KeyCode code;
    public Transform codeTran;
    public AudioClip codeDownClip;
    public AudioClip codeUpClip;
    public bool isWrite;
}

public class KeyBoardControl : MonoBehaviour
{
    [SerializeField] private AudioClip keyBoardDownClip;
    [SerializeField] private AudioClip keyBoardUpClip;
    [SerializeField] private AnimationCurve curve = new AnimationCurve(new Keyframe(0,0));
    [SerializeField] private List<KeyCodeInfo> keyCodeList;
    [SerializeField] private Vector3 offsetVec;
    [SerializeField] private float downTime = 1f;
    [SerializeField] private Text text;

    void Start()
    {
        SetDefaultKeyCodeInfo();
    }

    void SetDefaultKeyCodeInfo()
    {
        foreach (var kcl in keyCodeList)
        {
            KeyCodeControl kcc = kcl.codeTran.gameObject.AddComponent<KeyCodeControl>();
            var downClip = kcl.codeDownClip ? kcl.codeDownClip : keyBoardDownClip;
            var upClip = kcl.codeUpClip ? kcl.codeUpClip : keyBoardUpClip;
            kcc.Init(kcl.code, kcl.isWrite, offsetVec, downTime, curve, downClip, upClip, text);
        }
    }

    void Update()
    {
    }
}
