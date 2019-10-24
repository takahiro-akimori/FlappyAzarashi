using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour {

    public float speed = 1.0f;
    public float startPosition;
    public float endPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //毎フレームXポジションを少しづつ移動させる
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0); //スクロールの処理

        //スクロールが目標まで到達したかをチェック
        if (transform.position.x <= endPosition) ScrollEnd();   //スクロール終了の判断
	}

    void ScrollEnd()
    {
        //スクロールする距離分戻す
        transform.Translate(-1 * (endPosition - startPosition), 0, 0);

        //同じゲームオブジェクトにアタッチされているコンポーネントにメッセージを送る
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}
