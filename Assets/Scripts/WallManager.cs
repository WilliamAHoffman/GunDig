using System.Linq;
using Unity.Collections;
using UnityEditor;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Tilemaps;

public class WallManager : MonoBehaviour
{
    public Tilemap walls;
    private int[,] wallHealth;

    public void hit(int damage, Vector3 pos){
        Vector3Int tilePoint = walls.WorldToCell(pos);
        if(walls.GetTile(tilePoint) != null){
            wallHealth[tilePoint.x,tilePoint.y] -= damage;
            if(wallHealth[tilePoint.x,tilePoint.y] <= 0){
                walls.SetTile(tilePoint, null);
            }
        }
    }

    public void setWorld(int x, int y){
        wallHealth = new int[x,y];

        for(int i = 0; i < x; i++){
            for(int j = 0; j < y; j++){
                wallHealth[i,j] = 0;
            }
        }
        
    }
    public void SetWorldTile(TileData tileData, int x, int y){
        walls.SetTile(new Vector3Int(x, y, 0), tileData.tile);
        wallHealth[x,y] = tileData.health;
    }
}