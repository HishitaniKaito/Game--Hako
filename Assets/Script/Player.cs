using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
     
    [SerializeField] float jump = 1;//�W�����v��
    [SerializeField] float Move = 1;//�ړ����x
    [SerializeField] Rigidbody Rb;
    [SerializeField] int Hp = 10;//�̗�
    [SerializeField] int JcountLimit;//�A���ŃW�����v�ł����
    [SerializeField] SceneChange Change;
    int Jcount = 0;//�W�����v������
    float timer;
    float interval = 1.0f;//�_���[�W���󂯂���A���̃_���[�W���󂯂�܂ł̗P�\����
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space) && Jcount < JcountLimit)
        {
            Rb.AddForce(Vector3.up * jump, ForceMode.Impulse);//��ԓ���
            Debug.Log("Jump");
            Jcount++;
        }
        //�O�㍶�E�ւ̈ړ�
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
        timer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)//�n�ʂɂ�����Jcount�����Z�b�g����
    {
        if (collision.gameObject.name == "jimen")
        {
            Jcount = 0;
        }
    }
    private void OnTriggerStay(Collider other)//�_���[�W���ɐG��Ă��鎞�̏���
    {
        if (other.gameObject.name == "Damage")
        {
            Damege();
        }
    }
    public void Damege()
    {
        if(timer > interval)//���G���Ԃ̏����Binterval����timer�̒l���傫��������_���[�W���󂯂�
        {
            Hp--;
            if (Hp <= 0)
            {
                GameOver();
                //�_���[�W���󂯂�Hp��0�ɂȂ�����Q�[���I�[�o�[�̏������s��
            }
            timer = 0.0f;
        }
        
    }
    public void GameOver()
    {
        //�Q�[���I�[�o�[�̉�ʂֈړ�����
        string name = "Fail Scene";
        Change.Load(name);
    }
    
}
