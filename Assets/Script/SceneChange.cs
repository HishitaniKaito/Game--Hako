using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    string scenename;

    // Start is called before the first frame update
    void Start()
    {
        

    }


    public void Load(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
