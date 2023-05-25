using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExSceneController0 : MonoBehaviour
{
    public float tilNext;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", tilNext);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("ExScene1");
    }
}
