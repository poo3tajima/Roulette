using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouretteController : MonoBehaviour
{
    float rotSpeed = 0;  // 回転速度
    bool is_rotating = false;
    bool is_secondClick = false;

    // 最初に一回だけ動く
    void Start()
    {
        // Debug.Log("Start!");
        // フレームレートを60に固定する
        Application.targetFrameRate = 60;
    }

    // メイン実行部分
    void Update()
    {
        // Debug.Log("Update!");
        // マウスが押されたら回転速度を設定する
        if (Input.GetMouseButtonDown(0))
        {
            if (is_rotating == false)
            {
                this.rotSpeed = 10;
                is_rotating = true;
                Debug.Log("is_rotating:" + is_rotating);
            }
            // 回転中なら、2クリックに変更
            else
            {
                is_secondClick = true;
                Debug.Log("is_secondClick:" + is_secondClick);
            }
        }
        // 2クリックなら、減速する
        if (is_secondClick == true)
        {
            this.rotSpeed *= 0.96f;
        }

        transform.Rotate(0, 0, this.rotSpeed);

        // transform.Translate(0.01f, 0, 0, Space.World);
    }
}
