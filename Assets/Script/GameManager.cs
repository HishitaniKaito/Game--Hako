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
    [SerializeField]public key[] _Keys;
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
        _timerText.text = $"Œo‰ßŽžŠÔ:{_minits:00}•ª{_timer:00}•b";
        _hpText.text = $"‘Ì—Í:{_player.Hp}";
    }
}
