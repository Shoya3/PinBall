using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour {

    //表示するテキスト用変数
    private GameObject scoreText;
    //スコア計算用変数
    private int score = 0;
    //アンカーの座標
    private Vector2 anchor;
    //スコアを表示する座標
    private Vector2 v;

	// Use this for initialization
	void Start () {
        this.score = 0;
        this.scoreText = GameObject.Find("ScoreText");
        SetScore();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        //衝突したオブジェクトのタグを取得
        string tag = collision.gameObject.tag;

        //スコアを加算する
        if (tag == "SmallStarTag")
        {
            score += 10;
        }else if (tag == "LargeStarTag")
        {
            score += 20;
        }else if (tag == "SmallCloudTag")
        {
            score += 15;
        }else if (tag == "LargeCloudTag")
        {
            score += 30;
        }

        SetScore();

    }

    void SetScore()
    {
        //アンカーの座標
        anchor = new Vector2(0, 0);
        //スコアを表示する座標
        Vector2 v = new Vector2(87, 252);
        //UIにアンカーの座標を設定する
        scoreText.GetComponent<RectTransform>().anchoredPosition = anchor;
        //UIに表示する座標の情報を設定する
        scoreText.GetComponent<RectTransform>().localPosition = v;
        //スコアをテキストにして表示
        scoreText.GetComponent<Text>().text = string.Format("Score:{0}",score);
    }
}
