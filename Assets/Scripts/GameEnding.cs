using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField]
    private float fadeDuration = 1f;
    private float displayImageDuration = 1f;
    private bool isPlayerAtExit = false;

    [SerializeField]
    private CanvasGroup exitCanvasGroup;

    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAtExit)
        {
            timer += Time.deltaTime;
            exitCanvasGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0f, 1f);
        }

        if (timer > (fadeDuration + displayImageDuration))
        {
            EndLevel();
        }
    }

    private void EndLevel()
    {
        Application.Quit();
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerAtExit = true;
        }
    }
}
