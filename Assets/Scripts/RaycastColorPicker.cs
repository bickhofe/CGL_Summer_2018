using UnityEngine;
using UnityEngine.UI;

public class RaycastColorPicker : MonoBehaviour
{
    public Texture2D texture;
    public Material material;
    public Color color;
    public Transform cube;


    void Start()
    {
        texture = new Texture2D(512, 512);
        material.mainTexture = texture;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(transform.position, fwd, out hit, 100.0f))
        {
            cube.transform.position = hit.point;
            print("Hit at: " + hit.point.x);

            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= texture.width;
            pixelUV.y *= texture.height;

            texture.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
            //texture.SetPixel((int)hit.textureCoord.x, (int)hit.textureCoord.y, color);
            texture.Apply();
        }

        else

        {
            print("no hit");
        }
        
        //debug only
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}