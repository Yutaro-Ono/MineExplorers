//-----------------------------------------------------------//
// Rewiredの使い方(サンプルプログラム)
//----------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// これを追加
using Rewired;

public class RewiredSample
{
    // RewiredのPlayerクラス(これにどのコントローラーをアサインするかを定義する)
    Player playerInput;

    float speedX;
    float speedY;

    void Start()
    {
        // GetPlayer( RewiredEditor上で決めたプレイヤーのID )
        // 0 → 1Pコントローラ | 1 → 2Pコントローラ...
        playerInput = ReInput.players.GetPlayer(0);
    }

    void Update()
    {
        // エディタ上で"Jump"とタグ付けされたボタンが押されたら
        if (playerInput.GetButtonDown("Jump")) { }

        // 左スティックX軸の入力値とY軸の入力値を得る
        speedX = playerInput.GetAxis("Move_X");
        speedY = playerInput.GetAxis("Move_Y");
    }

}
