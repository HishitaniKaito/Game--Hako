using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    float _timer = 0.0f;
    [SerializeField] TMP_Text _timerText;
    [SerializeField] TMP_Text _hpText;
    [SerializeField] Player _player;
    [SerializeField]public key[] _Keys;
    [SerializeField] SceneChange Change;
    int _minits = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= 60 )
        {
            _timer -= 60;
            _minits++;
        }
        _timerText.text = $"経過時間:{_minits:00}分{_timer:00}秒";
        _hpText.text = $"体力:{_player.Hp}";
    }
    public void GameOver()
    {
        string _name = "";
        Change.Load(_name);
    }
}
