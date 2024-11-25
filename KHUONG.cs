using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KHUONE : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public Sprite defaultSprite; // 기본 스프라이트를 인스펙터에서 설정
    public Sprite clickSprite; // 변경할 스프라이트를 인스펙터에서 설정
    public Sprite burningSprite; // 변경할 스프라이트를 인스펙터에서 설정
    public Sprite burnClickSprite; // 변경할 스프라이트를 인스펙터에서 설정
    public Image uiImage; // UI 이미지 컴포넌트 연결
    public GameObject Fire;

    private bool isKeyPressed = false;

    void Update()
    {
        for (KeyCode key = KeyCode.A; key <= KeyCode.Z; key++) {
            if (Input.GetKeyDown(key)) {
                ChangeSpriteAndIncreaseScore();
                isKeyPressed = true;
                break;  // 한 번에 한 키만 처리되도록 한다
            } else if (Input.GetKeyUp(key) && isKeyPressed) {
                ResetSprite();
                isKeyPressed = false;
                break;  // 한 번에 한 키만 처리되도록 한다
            }
        }
        if (Burning.instance.curVal <= 70 && isKeyPressed == false){
            ResetSprite();
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        ChangeSpriteAndIncreaseScore();
    }

    public void OnPointerUp(PointerEventData eventData) {
        ResetSprite();
    }

    private void ChangeSpriteAndIncreaseScore() {
        uiImage.sprite = clickSprite;
        if (Burning.instance.curVal > 70){
            Fire.SetActive(true);
        }
        GameManager.instance.IncreaseScore();
    }

    private void ResetSprite() {
        uiImage.sprite = defaultSprite;
        if (Burning.instance.curVal <= 70){
            Fire.SetActive(false);
        }
    }
}
