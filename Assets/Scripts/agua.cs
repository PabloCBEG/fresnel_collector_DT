
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class agua : MonoBehaviour {

    public float waveSpeed = 0.5f;      // The speed of the waves
    public float waveHeight = 0.05f;    // The height of the waves
    public float noiseStrength = 0.1f;  // The strength of the noise effect
    public float noiseWalk = 1.0f;      // The speed of the noise effect
    public float waveLength = 0.75f;    // The length of the waves

    private float[] yPositions;         // The vertical position of each vertex
    private Mesh mesh;                  // The mesh of the water
    private Vector3[] vertices;         // The vertices of the mesh
    private Vector3[] normals;          // The normals of the mesh

    void Start () {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        normals = mesh.normals;
        yPositions = new float[vertices.Length];

        for (int i = 0; i < vertices.Length; i++) {
            yPositions[i] = vertices[i].y;
        }
    }

    void Update () {
        for (int i = 0; i < vertices.Length; i++) {
            Vector3 vertex = vertices[i];
            vertex.y = yPositions[i] + CalculateHeight(vertex.x, vertex.z, Time.time);
            vertices[i] = vertex;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }

    float CalculateHeight(float x, float z, float time) {
        float noise = Mathf.PerlinNoise(x + time * waveSpeed, z + time * waveSpeed) * waveHeight * noiseStrength;
        float wave = Mathf.Sin((x / waveLength) + (time * waveSpeed)) * waveHeight;
        return noise + wave;
    }
}
