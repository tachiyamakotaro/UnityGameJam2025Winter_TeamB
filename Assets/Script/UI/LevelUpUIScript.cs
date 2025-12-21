using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpUIScript : MonoBehaviour
{
    [Header("表示テキスト(ドラッグで設定)")]
    public TMP_Text levelUpText;


    // Start is called before the first frame update
    void Start()
    {
        levelUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //レベルアップ時の表示処理
    public void ShowLevelUp(int level)
    {
        levelUpText.text = $"レベル{level}にアップ";
        levelUpText.gameObject.SetActive(true);

        //2秒後にUIが消える
        Invoke(nameof(HideText), 2f);
    }

    private void HideText()
    {
        levelUpText.gameObject.SetActive(false);
    }
}
