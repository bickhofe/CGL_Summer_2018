using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class LoadJSON : MonoBehaviour
{

    public string name;
    public string score;
    public string level;

    void Save()
    {
        JSONObject playerJson = new JSONObject();
        playerJson.Add("Name", name);
        playerJson.Add("Score", score);
        playerJson.Add("Level", level);

        JSONArray position = new JSONArray();
        position.Add(transform.position.x);
        position.Add(transform.position.y);
        position.Add(transform.position.z);

        playerJson.Add("Position", position);

        Debug.Log(playerJson.ToString());
        string path = Application.persistentDataPath + "/PlayerSave.json";
        File.WriteAllText(path, playerJson.ToString());
    }

    void Load()
    {
        string path = Application.persistentDataPath + "/PlayerSave.json";
        string jsonString = File.ReadAllText(path);
        JSONObject playerJson = (JSONObject)JSON.Parse(jsonString);

        name = playerJson["Name"];
        score = playerJson["Score"];
        level = playerJson["Level"];

        transform.position = new Vector3(
            playerJson["Position"].AsArray[0],
            playerJson["Position"].AsArray[1],
            playerJson["Position"].AsArray[2]
        );
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) Save();
        if (Input.GetKeyDown(KeyCode.L)) Load();

    }
}
