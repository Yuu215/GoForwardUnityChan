using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    //キューブの移動速度
    private float speed = -12f;

    //消滅位置
    private float deadLine = -10;

    //効果音
    public AudioClip se1;
    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceを取得する
        this.myAudioSource = GetComponent<AudioSource>();
        if (myAudioSource == null)
        {
            Debug.LogError("AudioSourceが取得できませんでした。");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //キューブがキューブに接触したときに効果音を鳴らす
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            myAudioSource.PlayOneShot(se1);
        }
    }
}
