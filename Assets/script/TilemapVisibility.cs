using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapSortingLayer : MonoBehaviour
{
    public Tilemap targetTilemap; // Ссылка на Tilemap "More"
    public string onTilemapSortingLayer = "OnTilemap"; // Sorting Layer на Tilemap
    public string offTilemapSortingLayer = "Default"; // Sorting Layer вне Tilemap

    private SpriteRenderer spriteRenderer; // Ссылка на SpriteRenderer компонента
    private string originalSortingLayer;  // Сохраняем оригинальный Sorting Layer
    private bool isOnTilemap = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("Этот объект не имеет компонента SpriteRenderer!");
            enabled = false; // Отключаем скрипт, если нет SpriteRenderer
            return;
        }

        originalSortingLayer = spriteRenderer.sortingLayerName; // Сохраняем оригинальный Sorting Layer
    }

    void Update()
    {
        CheckTilemap();
    }

    void CheckTilemap()
    {
        // Получаем позицию объекта в координатах Tilemap
        Vector3Int cellPosition = targetTilemap.WorldToCell(transform.position);

        // Проверяем, есть ли тайл в этой позиции
        TileBase tile = targetTilemap.GetTile(cellPosition);

        // Если тайл есть и объект еще не на Tilemap
        if (tile != null && !isOnTilemap)
        {
            // Меняем Sorting Layer
            spriteRenderer.sortingLayerName = onTilemapSortingLayer;
            isOnTilemap = true;
            Debug.Log("Объект вошел на Tilemap!");
        }
        // Если тайла нет, а объект был на Tilemap
        else if (tile == null && isOnTilemap)
        {
            // Возвращаем оригинальный Sorting Layer
            spriteRenderer.sortingLayerName = offTilemapSortingLayer;
            isOnTilemap = false;
            Debug.Log("Объект вышел с Tilemap!");
        }
    }
}