using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0.0f, -1.0f, 0.0f);
    private RectTransform rectTransform;
    private Camera mainCamera;

    [SerializeField] private PlayerStateScript playerState;
    [SerializeField] private Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;

        //初期設定。
        hpSlider.maxValue = playerState.maxHp;
        hpSlider.value = playerState.currentHp;
    }

    // Update is called once per frame
    void Update()
    {
        //InspecterViewからPlayerを渡す。
        //↓
        //Findは名前を変更すると壊れてしまう恐れがあるから。
        hpSlider.value = playerState.currentHp;

        CameraFollow();
    }

    void CameraFollow()
    {
        if(player != null)
        {
            //プレイヤーのワールド座標を画面座標に変換。
            Vector3 screenPos = mainCamera.WorldToScreenPoint(player.position + offset);
            rectTransform.position = screenPos;

            Vector2 anchoredPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform.parent as RectTransform,
                screenPos,
                mainCamera,
                out anchoredPos
            );

            rectTransform.anchoredPosition = anchoredPos;
        }
    }
}
