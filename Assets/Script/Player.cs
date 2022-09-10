using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float jump = 1;
    public float Move = 1;
    [SerializeField] Rigidbody Rb;
    [SerializeField] int Hp = 100;
    int Jcount;
    [SerializeField] int JcountLimit;
    void Start()
    {
        Jcount = JcountLimit;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Ppos = this.transform.position;//プレイヤーの位置
        Vector3 direction = new Vector3(0, -1, 0);//Y軸方向表すベクトル
        Ray ray = new Ray(Ppos, direction);//地面を感知するrayの生成
        Debug.DrawRay(Ppos, direction, Color.black, 0.01f, false);
        if (Input.GetKeyDown(KeyCode.Space) && Jcount > 0)
        {
            Rb.AddForce(Vector3.up * jump, ForceMode.Impulse);//飛ぶ動作
            Debug.Log("Jump");
            Jcount--;
        }
        //左右への移動
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
        }
        /*RaycastHit hit;
        if (Input.GetKey(KeyCode.S))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("rayは機能している");

                if (hit.collider.gameObject.name == "buttai")
                {
                    Debug.Log("持てるやつ感知");
                }
            }

        }
        */

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "jimen")
        Jcount = JcountLimit;
    }
    public void worp(Vector3 wpos)
    {
        this.gameObject.transform.position = wpos;
    }


    public void GameOver()
    {

    }
    public void Damege()
    {
        if (Hp <= 0)
        {
            GameOver();
        }
    }
}
