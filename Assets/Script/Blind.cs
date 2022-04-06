using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blind : MonoBehaviour
{
    MeshRenderer mesh;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 0);
        StartCoroutine("Transparent");
    }

    IEnumerator Transparent()
    {
        while (true)
        {
            for (int i = 0; i < 100; i++)
            {
                mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
            }

            yield return new WaitForSeconds(0.2f);

            for (int k = 0; k < 100; k++)
            {
                mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 1);
            }

            yield return new WaitForSeconds(0.2f);

        }
    }
}
