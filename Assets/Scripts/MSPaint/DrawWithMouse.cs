using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    private CanvasRenderer canvasRenderer;
    [SerializeField] private Material drawMaterial;

    private void Awake()
    {

        canvasRenderer = this.GetComponent<CanvasRenderer>();


        Mesh mesh = new Mesh();

        

        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(-1, +1);
        vertices[0] = new Vector3(-1, -1);
        vertices[0] = new Vector3(+1, -1);
        vertices[0] = new Vector3(+1, -1);

        uv[0] = Vector2.zero;
        uv[1] = Vector2.zero;
        uv[2] = Vector2.zero;
        uv[3] = Vector2.zero;

        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 1;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.MarkDynamic();
        
        GetComponent<MeshFilter>().mesh = mesh;

        canvasRenderer.SetMesh(mesh);
        canvasRenderer.SetMaterial(drawMaterial, null);
    }


}
