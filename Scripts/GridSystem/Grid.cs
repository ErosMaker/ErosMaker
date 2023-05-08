using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErosUtils;

public class Grid<TGridObject>
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 origin;
    private Color color;
    private TGridObject[,] gridArray;
    private TextMesh[,] debugText;
    private GameObject[] gridLinesX;
    private GameObject[] gridLinesZ;
    [SerializeField] private Transform parent;
    private GameObject gridMesh;
    private bool isEnabled;
    private float lineWidth = .02f;
    private bool isGizmosEnabled = true;
    private Material source;

    public Grid(int width, int height, float cellSize, Color color, Vector3 origin, bool enabled, Material source)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.origin = origin;
        this.debugText = new TextMesh[width, height];
        this.gridLinesX = new GameObject[width+1];
        this.gridLinesZ = new GameObject[height+1];
        this.color = color;
        this.isEnabled = enabled;
        this.source = source;

        gridArray = new TGridObject[width, height];

        Material _source = new Material(source);
        _source.color = this.color;

        for (int x = 0; x <= width; x++)
        {
            gridLinesX[x] = new GameObject("GridLine", typeof(LineRenderer));
            gridLinesX[x].GetComponent<LineRenderer>().startColor = color;
            gridLinesX[x].GetComponent<LineRenderer>().endColor = color;
            gridLinesX[x].GetComponent<LineRenderer>().startWidth = lineWidth;
            gridLinesX[x].GetComponent<LineRenderer>().endWidth = lineWidth;
            gridLinesX[x].GetComponent<LineRenderer>().material = _source;
        }

        for (int z = 0; z <= width; z++)
        {
            gridLinesZ[z] = new GameObject("GridLine", typeof(LineRenderer));
            gridLinesZ[z].GetComponent<LineRenderer>().startColor = color;
            gridLinesZ[z].GetComponent<LineRenderer>().endColor = color;
            gridLinesZ[z].GetComponent<LineRenderer>().material = _source;
            gridLinesZ[z].GetComponent<LineRenderer>().startWidth = lineWidth;
            gridLinesZ[z].GetComponent<LineRenderer>().endWidth = lineWidth;
        }

        RenderGizmos();

        Debug.Log("Grid created with size: " + this.width + ", " + this.height);

        gridMesh = new GameObject("GridMesh", typeof(MeshFilter), typeof(MeshCollider));
        gridMesh.transform.position = origin;
        gridMesh.transform.localScale = new Vector3(width, 1, height) * cellSize;

        Vector3[] gridMeshVertices = {  new Vector3(0, 0, 0),
                                        new Vector3(0, 0, 1),
                                        new Vector3(1, 0, 1),
                                        new Vector3(1, 0, 0) };

        int[] gridMeshTriangles = { 0, 1, 2, 0, 2, 3 };

        Mesh _mesh = new Mesh();
        _mesh.vertices = gridMeshVertices;
        _mesh.triangles = gridMeshTriangles;

        gridMesh.GetComponent<MeshFilter>().mesh = _mesh;
        gridMesh.GetComponent<MeshCollider>().sharedMesh = _mesh;

        this.cellSize = cellSize;
    }

    private void CreateLine(Vector3[] positions)
    {
        GameObject gameObject = new GameObject("line");

        gameObject.transform.SetParent(parent);
        LineRenderer line = gameObject.AddComponent<LineRenderer>();
        line.positionCount = 2;
        line.SetPositions(positions);
    }

    public void GetXZ(Vector3 worldPosition, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPosition - origin).x / cellSize);
        z = Mathf.FloorToInt((worldPosition - origin).z / cellSize);
    }

    public Vector3 GetWorldPosition(float x, float z)
    {
        return new Vector3(x, 0, z) * cellSize + origin;
    }

    public TGridObject[,] GetGridArray()
    {
        return this.gridArray;
    }

    public TGridObject this[int x, int y]
    {
        get { return this.gridArray[x, y]; }
        set { this.gridArray[x, y] = value; }
    }


    public void SetValue(int x, int z, TGridObject value)
    {
        if(x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z] = value;
            debugText[x, z].GetComponent<TextMesh>().text = gridArray[x, z].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, TGridObject value)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetValue(x, z, value);
    }

    public float GetCellSize()
    {
        return this.cellSize;
    }

    public void ToggleEnable()
    {
        isEnabled = !isEnabled;
        gridMesh.GetComponent<MeshCollider>().enabled = isEnabled;
    }

    public void ToggleGizmosEnabled()
    {
        isGizmosEnabled = !isGizmosEnabled;

        if(isGizmosEnabled)
        {
            RenderGizmos();
        }

        else
        {
            UnrenderGizmos();
        }
    }

    public void RenderGizmos()
    {
        for(int x = 0; x < width; x++)
        {
            gridLinesX[x].GetComponent<LineRenderer>().positionCount = 2;
            gridLinesX[x].GetComponent<LineRenderer>().SetPosition(0, GetWorldPosition(x, 0));
            gridLinesX[x].GetComponent<LineRenderer>().SetPosition(1, GetWorldPosition(x, height));
        }

        for(int z = 0; z < height; z++)
        {
            gridLinesZ[z].GetComponent<LineRenderer>().positionCount = 2;
            gridLinesZ[z].GetComponent<LineRenderer>().SetPosition(0, GetWorldPosition(0, z));
            gridLinesZ[z].GetComponent<LineRenderer>().SetPosition(1, GetWorldPosition(width, z));
        }

        for(int x = 0; x < width;x++)
        {
            for(int z = 0; z < height; z++)
            {
                Vector3 pos = GetWorldPosition(x, z);
                debugText[x, z] = ErosText.CreateTextMesh(TextType.STATIC, x + ", " + z, null, Mathf.RoundToInt(20 * cellSize), TextAnchor.MiddleCenter, TextAlignment.Center, Color.white, GetWorldPosition(x + .5f, z + .5f));
            }
        }

        gridLinesX[width].GetComponent<LineRenderer>().positionCount = 2;
        gridLinesX[width].GetComponent<LineRenderer>().SetPosition(0, GetWorldPosition(0, height));
        gridLinesX[width].GetComponent<LineRenderer>().SetPosition(1, GetWorldPosition(width, height));

        gridLinesZ[height].GetComponent<LineRenderer>().positionCount = 2;
        gridLinesZ[height].GetComponent<LineRenderer>().SetPosition(0, GetWorldPosition(width, 0));
        gridLinesZ[height].GetComponent<LineRenderer>().SetPosition(1, GetWorldPosition(width, height));
    }

    public void UnrenderGizmos()
    {
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                Object.Destroy(debugText[x, z]);
            }
        }

        for(int x = 0; x < width; x++)
        {
            gridLinesX[x].GetComponent<LineRenderer>().positionCount = 0;
        }

        for (int z = 0; z < height; z++)
        {
            gridLinesZ[z].GetComponent<LineRenderer>().positionCount = 0;
        }

        gridLinesX[width].GetComponent<LineRenderer>().positionCount = 0;

        gridLinesZ[height].GetComponent<LineRenderer>().positionCount = 0;
    }
}
