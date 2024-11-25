using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float decreaseInterval = 1f;
    private float lastDecreaseTime = 0f;

    void Update()
    {
        if (GameManager.instance.timer > 0){
            if (Time.time - lastDecreaseTime > decreaseInterval) {
                GameManager.instance.DecreaseTimer();
                lastDecreaseTime = Time.time;
            }
        } else {
            GameManager.instance.TimeOverPanel();
        }
    }
}
