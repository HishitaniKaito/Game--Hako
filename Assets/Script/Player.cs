using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
     
    [SerializeField] float Jump = 1;//ジャンプ力
    [SerializeField] float Move = 1;//移動速度
    [SerializeField] Rigidbody Rb;
    [SerializeField] public int Hp = 10;//体力
    [SerializeField] int JcountLimit;//連続でジャンプできる回数
    [SerializeField] SceneChange Change;
    int Jcount = 0;//ジャンプした回数
    float timer;
    float interval = 1.0f;//ダメージを受けた後、次のダメージを受けるまでの猶予時間
    [SerializeField] Material _Muteki;
    [SerializeField] Material _NoneMaterial;
    Renderer _Rend;
    void Start()
    {
        _Rend = this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space) && Jcount < JcountLimit)
        {
            Rb.AddForce(Vector3.up * Jump, ForceMode.Impulse);//飛ぶ動作
            Debug.Log("Jump");
            Jcount++;
        }
        //前後左右の移動
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Rb.AddForce(h * Move, 0, v * Move);
        /*前後左右への移動(旧)
        if (Input.GetKey(KeyCode.A))
        {
            Rb.AddForce(Vector3.right * (Move * -1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rb.AddForce(Vector3.right * Move);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Rb.AddForce(Vector3.forward * Move);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Rb.AddForce(Vector3.forward * Move * -1);
        }*/

        timer += Time.deltaTime;
        if(timer > interval)
        {
            _Rend.material = _NoneMaterial;
        }
    }
    private void OnCollisionEnter(Collision collision)//地面についたらJcountをリセットする
    {
        if (collision.gameObject.name == "jimen")
        {
            Jcount = 0;
        }
    }
    private void OnTriggerStay(Collider other)//ダメージ床に触れている時の処理
    {
        if (other.gameObject.name == "Damage")
        {
            Damege();
        }
    }
    public void Damege()
    {
        if (timer > interval)//無敵時間の処理。intervalよりもtimerの値が大きかったらダメージを受ける
        {
            Hp--;
            if (Hp <= 0)
            {
                GameOver();//ダメージを受けてHpが0になったらゲームオーバーの処理を行う
            }
            timer = 0.0f;
        }
        else
        {
            _Rend.material = _Muteki;//無敵状態用のマテリアルに変化
        }
    }
    public void GameOver()
    {
        //ゲームオーバーの画面へ移動する
        string name = "Fail Scene";
        Change.Load(name);
    }
    
}
