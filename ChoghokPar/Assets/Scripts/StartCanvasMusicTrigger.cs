using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCanvasMusicTrigger : MonoBehaviour
{
    private bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        var musicManager = FindObjectOfType<MusicManager>();
        if (musicManager != null)
        {
            Debug.Log("پخش موزیک منو");
            musicManager.PlayMainMenuMusic();
        }
        else
        {
            Debug.Log("MusicManager پیدا نشد!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
