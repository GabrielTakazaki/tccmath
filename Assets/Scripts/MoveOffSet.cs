using System.Collections;
using UnityEngine;

public class MoveOffSet : MonoBehaviour
{
    private Material currentMaterial;
    public float speed;
    private float offset;

    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * 0.05f ;       
        currentMaterial.SetTextureOffset ("_MainTex", new Vector2 (offset*speed, 0));
    }
}
