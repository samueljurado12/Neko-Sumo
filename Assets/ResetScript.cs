using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResetScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)){
            UnityEditor.SceneManagement.EditorSceneManager.LoadScene("Test");
        }
    }
}
