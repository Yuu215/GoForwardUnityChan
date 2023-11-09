using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    //�L���[�u�̈ړ����x
    private float speed = -12f;

    //���ňʒu
    private float deadLine = -10;

    //���ʉ�
    public AudioClip se1;
    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        //AudioSource���擾����
        this.myAudioSource = GetComponent<AudioSource>();
        if (myAudioSource == null)
        {
            Debug.LogError("AudioSource���擾�ł��܂���ł����B");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //��ʊO�ɏo����j������
        if(transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //�L���[�u���L���[�u�ɐڐG�����Ƃ��Ɍ��ʉ���炷
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            myAudioSource.PlayOneShot(se1);
        }
    }
}
