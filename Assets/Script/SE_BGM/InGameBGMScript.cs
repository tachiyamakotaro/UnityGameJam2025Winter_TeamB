using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameBGMScript : MonoBehaviour
{
    //[SerializeField]
    //private AudioSource BGMSource;
    [SerializeField]
    private SoundManagerScript soundManager;

    [SerializeField]
    private AudioClip InGameBGM_No1;

    [SerializeField]
    private AudioClip InGameBGM_No2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        soundManager.PlayBGM(InGameBGM_No1);
     
    }
}
