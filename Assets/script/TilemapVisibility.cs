using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapSortingLayer : MonoBehaviour
{
    public Tilemap targetTilemap; // ������ �� Tilemap "More"
    public string onTilemapSortingLayer = "OnTilemap"; // Sorting Layer �� Tilemap
    public string offTilemapSortingLayer = "Default"; // Sorting Layer ��� Tilemap

    private SpriteRenderer spriteRenderer; // ������ �� SpriteRenderer ����������
    private string originalSortingLayer;  // ��������� ������������ Sorting Layer
    private bool isOnTilemap = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("���� ������ �� ����� ���������� SpriteRenderer!");
            enabled = false; // ��������� ������, ���� ��� SpriteRenderer
            return;
        }

        originalSortingLayer = spriteRenderer.sortingLayerName; // ��������� ������������ Sorting Layer
    }

    void Update()
    {
        CheckTilemap();
    }

    void CheckTilemap()
    {
        // �������� ������� ������� � ����������� Tilemap
        Vector3Int cellPosition = targetTilemap.WorldToCell(transform.position);

        // ���������, ���� �� ���� � ���� �������
        TileBase tile = targetTilemap.GetTile(cellPosition);

        // ���� ���� ���� � ������ ��� �� �� Tilemap
        if (tile != null && !isOnTilemap)
        {
            // ������ Sorting Layer
            spriteRenderer.sortingLayerName = onTilemapSortingLayer;
            isOnTilemap = true;
            Debug.Log("������ ����� �� Tilemap!");
        }
        // ���� ����� ���, � ������ ��� �� Tilemap
        else if (tile == null && isOnTilemap)
        {
            // ���������� ������������ Sorting Layer
            spriteRenderer.sortingLayerName = offTilemapSortingLayer;
            isOnTilemap = false;
            Debug.Log("������ ����� � Tilemap!");
        }
    }
}