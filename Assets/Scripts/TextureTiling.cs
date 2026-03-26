using UnityEngine;

[ExecuteInEditMode]
public class UniformTextureTiling : MonoBehaviour
{
    public float textureSize = 1f; 

    void Update()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend == null) return;

        Vector3 scale = transform.localScale;

       
        Vector3 right = transform.right;
        Vector3 up = transform.up;
        Vector3 forward = transform.forward;

       
        float dotX = Mathf.Abs(Vector3.Dot(up, Vector3.up));
        float dotY = Mathf.Abs(Vector3.Dot(forward, Vector3.up));
        float dotZ = Mathf.Abs(Vector3.Dot(right, Vector3.up));

        Vector2 tiling;

        if (dotX > dotY && dotX > dotZ)
        {
          
            tiling = new Vector2(scale.x, scale.z);
        }
        else if (dotY > dotX && dotY > dotZ)
        {
           
            tiling = new Vector2(scale.x, scale.y);
        }
        else
        {
           
            tiling = new Vector2(scale.z, scale.y);
        }

        rend.material.mainTextureScale = tiling / textureSize;
    }
}