using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().Stop();

    }
	
	// Update is called once per frame
	void Update () {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {

        // ブロック＆地面に衝突した場合（追加）
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "Block")
        {
            GetComponent<AudioSource>().Play();
        }
        // ユニティに当たった場合
        else if (collision.gameObject.tag == "UnityChan2D")
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }
}
