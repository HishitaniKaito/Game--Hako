using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] SceneChange change;
    string name = "Success Scene";
    private void OnCollisionEnter(Collision collision)
    {
        change.Load(name);
    }
}
