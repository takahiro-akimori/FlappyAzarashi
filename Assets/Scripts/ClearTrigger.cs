using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour {

    GameObject gameController;

	// Use this for initialization
	void Start () {

        //ゲーム開始時にGameControllerを取得
        gameController = GameObject.FindWithTag("GameController");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameController.SendMessage("IncreaseScore");
    }
}
