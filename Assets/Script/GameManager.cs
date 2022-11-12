using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]float _timer = 0.0f;
    [SerializeField] TMP_Text _timerText;
    [SerializeField] TMP_Text _hpText;
    [SerializeField] Player _player;
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
    }
}
