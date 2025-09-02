using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour {
    public Button[] tiles;

    private int emptyIndex = 8;

    void Start() {
        for (int i = 0; i < tiles.Length; i++) {
            int index = i;
            tiles[i].onClick.AddListener(() => TryMove(index));
        }
    }

    void TryMove(int index) {
        if (IsAdjacent(index, emptyIndex)) {
            SwapTiles(index, emptyIndex);
            emptyIndex = index;
        }
    }

    bool IsAdjacent(int clickTileIndex, int emptyTileIndex) {
        int clickTilePosX = clickTileIndex % 3, clickTilePosY = clickTileIndex / 3;
        int emptyTilePosX = emptyTileIndex % 3, emptyTilePosY = emptyTileIndex / 3;

        return (Mathf.Abs(clickTilePosX - emptyTilePosX) + Mathf.Abs(clickTilePosY - emptyTilePosY)) == 1;
    }

    void SwapTiles(int a, int b) {
        Transform tileA = tiles[a].transform;
        Transform tileB = tiles[b].transform;

        Vector3 temPos = tileA.position;
        tileA.position = tileB.position;
        tileB.position = temPos;

        Button temp = tiles[a];
        tiles[a] = tiles[b];
        tiles[b] = temp;
    }
}
