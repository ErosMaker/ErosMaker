using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ErosUtils
{
    public class ErosGridCell : MonoBehaviour
    {

        private int x;
        private int z;

        private static Vector3[] vertexCoords = { new Vector3(0, 0, 0),
                                       new Vector3(1, 0, 0),
                                       new Vector3(1, 0, 1),
                                       new Vector3(0, 0, 1) };

        private static int[] trianglesIndex = { 0, 1, 2,
                                     0, 2, 3 };
        public ErosGridCell(int x, int z)
        {
            this.x = x;
            this.z = z;
        }

        public static GameObject CreateCell(int x, int z)
        {
            GameObject cell = new GameObject("cell", typeof(MeshRenderer));
            Material material = Resources.Load<Material>("Assets/Materials/GridCell");

            cell.AddComponent<MeshRenderer>();

            Mesh mesh = new Mesh();

            mesh.vertices = vertexCoords;
            mesh.triangles = trianglesIndex;

            MeshRenderer renderer = cell.GetComponent<MeshRenderer>();

            renderer.material = material;

            return cell;
        }
    }
}
