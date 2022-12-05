using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
     
    [SerializeField] float Jump = 1;//�W�����v��
    [SerializeField] float Move = 1;//�ړ����x
    [SerializeField] Rigidbody Rb;
    [SerializeField] public int Hp = 10;//�̗�
    [SerializeField] int JcountLimit;//�A���ŃW�����v�ł����
    int Jcount = 0;//�W�����v������
    float timer;
    float interval = 1.0f;//�_���[�W���󂯂���A���̃_���[�W���󂯂�܂ł̗P�\����
    [SerializeField] Material _Muteki;
    [SerializeField] Material _NoneMaterial;
    [SerializeField] Camera _PlayerCamera;
    Renderer _Rend;
    GameManager _Gm;
    void Start()
    {
        _Rend = this.gameObject.GetComponent<Renderer>();
        _Gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space) && Jcount < JcountLimit)
        {
            Rb.AddForce(Vector3.up * Jump, ForceMode.Impulse);//��ԓ���
            Debug.Log("Jump");
            Jcount++;
        }
        //�O�㍶�E�̈ړ�
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Rb.AddForce(h * Move, 0, v * Move);
        if(_Gm._Keys.Length == 0)
        {
            _PlayerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 6, transform.position.z - 6);
            _PlayerCamera.transform.rotation = Quaternion.Euler(45, 0, 0);
        }
        for(int i = 0; i < _Gm._Keys.Length; i++)
        {
            if(_Gm._Keys[i].doordelete == false)
            {
                _PlayerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 6, transform.position.z - 6);
                _PlayerCamera.transform.rotation = Quaternion.Euler(45, 0, 0);
            }
        }
        /*�O�㍶�E�ւ̈ړ�(��)
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
        if (timer > interval)//���G���Ԃ̏����Binterval����timer�̒l���傫��������_���[�W���󂯂�
        {
            Hp--;
            if (Hp <= 0)
            {
                _Gm.GameOver();//�_���[�W���󂯂�Hp��0�ɂȂ�����Q�[���I�[�o�[�̏������s��
            }
            timer = 0.0f;
        }
        else
        {
            _Rend.material = _Muteki;//���G��ԗp�̃}�e���A���ɕω�
        }
    }   
}
