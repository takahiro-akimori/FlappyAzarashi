using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    //ゲームステート
    enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;
    int score;

    public AzarashiController azarashi;
    public GameObject blocks;
    public Text scoreLabel;
    public Text stateLabel;

	// Use this for initialization
	void Start () {
        //開始と同時にReadyステートに移行
        Ready();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        //ゲームのステートごとにイベントを監視
        switch(state)
        {
            case State.Ready:
                //タッチしたらゲームスタート
                if (Input.GetButtonDown("Fire1")) GameStart();
                break;
            case State.Play:
                //キャラクターが死亡したらゲームオーバー
                if (azarashi.IsDead()) GameOver();
                break;
            case State.GameOver:
                //タッチしたらシーンをリロード
                if (Input.GetButtonDown("Fire1")) Reload();
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;
        //各オブジェクトを無効
        azarashi.SetSteerActive(false);
        blocks.SetActive(false);

        //スコアラベルを0点に更新
        scoreLabel.text = "Score : " + 0;

        //statelabelはReady中は表示
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "Ready";
    }

    void GameStart()
    {
        state = State.Play;

        //各オブジェクトを有効
        azarashi.SetSteerActive(true);
        blocks.SetActive(true);

        //statelabelを非表示
        stateLabel.gameObject.SetActive(false);
        stateLabel.text = "";


        //最初の入力だけGameControllerから渡す
        azarashi.Flap();
    }

    void GameOver()
    {
        state = State.GameOver;

        //シーン中の全てのScrollObjectコンポーネントを探し出す
        //FindObjectsOfType<ScrollObject>...ScrollObjectがアタッチされいるものを全て探し出す
        //scrollObjectsに代入していく
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();

        //全ScrollObjectのスクロール処理を無効にする
        //scrollObjectsの中からひとつづつsoに代入しenabled = falseでコンポーネントをoffにしていく
        foreach (ScrollObject so in scrollObjects) so.enabled = false;


        //statelabelを表示してGameOverに更新
        stateLabel.gameObject.SetActive(true);
        stateLabel.text = "GameOver";
    }

    void Reload()
    {
        //現在読み込んでいるシーンを再読み込み
        //今ActiveになっているSceneの名前をもう一度LoadSceneをする
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void IncreaseScore()
    {
        score++;
        scoreLabel.text = "Score : " + score;
    }

}
