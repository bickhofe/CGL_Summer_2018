using UnityEngine;
using System.Collections;

public class SetPixel : MonoBehaviour
{
    public Texture2D texture;

    void Start()
    {
        texture = new Texture2D(1 , 2048);
        GetComponent<Renderer>().material.mainTexture = texture;

        //pattern
        //for (int y = 0; y < texture.height; y++)
        //{
        //    for (int x = 0; x < texture.width; x++)
        //    {
        //        Color color = ((x & y) != 0 ? Color.white : Color.gray);
        //        texture.SetPixel(x, y, color);
        //    }
        //}

        ////noise
        //for (int y = 0; y < texture.height; y++)
        //{
        //    //Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //    for (int x = 0; x < texture.width; x++)
        //    {
        //        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //        texture.SetPixel(x, y, color);
        //    }
        //}

        //lines
        //for (int y = 0; y < texture.height; y++)
        //{
        //    Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //    for (int x = 0; x < texture.width; x++)
        //    {
        //        texture.SetPixel(x, y, color);
        //    }
        //}

        //texture.Apply();
    }

    private void Update()
    {
        //lines
        for (int y = 0; y < texture.height; y++)
        {
            Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            for (int x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
    }
}