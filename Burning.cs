using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Burning : MonoBehaviour
{
    [SerializeField]
    public Slider burningBar;

    private float maxVal = 100;
    public float curVal = 0;

    public static Burning instance = null;

    private float decreaseInterval = 0.01f;
    private float lastDecreaseTime = 0f;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        burningBar.value = curVal / maxVal;
    }

    // Update is called once per frame
    void Update()
    {
        if (curVal > 0 && curVal < 100) {
            if (Time.time - lastDecreaseTime > decreaseInterval) {
                DecreaseVal();
                lastDecreaseTime = Time.time;
                // Debug.Log(lastDecreaseTime); // 시간 체크용 로그
            }
        } else if (curVal >= 100){ // 값이 100을 못넘어가게 99로 제한
            curVal = 99f;
        }
    }

    public void IncreaseVal()
    {
        curVal += 1;
        // Debug.Log(curVal);
        // burningBar.value = Mathf.Lerp(burningBar.value, curVal / maxVal, Time.deltaTime * 10); // 더 부드러운 게이지 움직임
        burningBar.value = curVal / maxVal;
    }
    public void DecreaseVal()
    {
        curVal -= 0.1f;
        // burningBar.value = Mathf.Lerp(burningBar.value, curVal / maxVal, Time.deltaTime * 10); // 더 부드러운 게이지 움직임
        burningBar.value = curVal / maxVal;
    }
}
