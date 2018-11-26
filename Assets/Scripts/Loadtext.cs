using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadtext : MonoBehaviour
{
    public string txtFile = "test";
    string txtContents;

    // Use this for initialization
    void Start()
    {
        TextAsset txtAssets = (TextAsset)Resources.Load(txtFile);
        txtContents = txtAssets.text;

        print(txtContents);
    }

    private void OnGUI()
    {
        GUILayout.Label(txtContents);
    }

}
