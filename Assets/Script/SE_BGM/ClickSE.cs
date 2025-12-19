using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSE : MonoBehaviour
{
    [SerializeField]
    private SoundManagerScript soundManager;

    [SerializeField]
    private AudioClip ClickSEClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        soundManager.PlaySE(ClickSEClip);
    }
}
