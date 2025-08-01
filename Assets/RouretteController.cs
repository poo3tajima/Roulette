using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouretteController : MonoBehaviour
{
    float rotSpeed = 0;  // 回転速度
    bool is_rotating = false; // 回転中か
    bool is_secondClick = false; // 2回目のクリックか

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
        // マウスが押されたら回転開始
        // フラグを変更
        if (Input.GetMouseButtonDown(0))
        {
            if (is_rotating == false)
            {
                this.rotSpeed = 20;
                is_rotating = true;
                Debug.Log("is_rotating:" + is_rotating);
            }
            // 回転中なら、フラグ2クリックに変更
            else
            {
                is_secondClick = true;
                Debug.Log("is_secondClick:" + is_secondClick);
            }
        }
        // 2クリックなら、減速する
        if (is_secondClick == true)
        {
            this.rotSpeed *= 0.98f;
        }

        transform.Rotate(0, 0, this.rotSpeed);

        // 回転が遅くなってきたら、止める
        // フラグを初期値へ戻す
        if (this.rotSpeed < 0.2f)
        {
            this.rotSpeed = 0;
            is_rotating = false;
            is_secondClick = false;
        }

        // transform.Translate(0.01f, 0, 0, Space.World);
    }
}
