using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {
    public delegate void WorldReadyDelegate ();
    public event WorldReadyDelegate OnWorldReady;

    public GameObject worldPiecePrototype;
    public int length = 20;
    public float floorSize = 3;

    private Transform _tiles;

    void Start () {
        GenerateWithHash(GenerateRandomLevelHash(length, 3));
    }

    public void GenerateWithHash (string hash) {
        if (_tiles != null) {
            Destroy(_tiles);
        }
        _tiles = new GameObject().transform;
        _tiles.position = transform.position;
        _tiles.transform.parent = transform;
        _tiles.name = "tiles";

        string[] pieces = hash.Split('\n');
        for (int i=0; i < pieces.Length; i++) {

            WorldPiece created = Instantiate(worldPiecePrototype).
                GetComponent<WorldPiece>();
            created.Initialize(pieces[i], _tiles);
        }

        NavMeshSurface surface = _tiles.gameObject.AddComponent<NavMeshSurface>();
        surface.useGeometry = NavMeshCollectGeometry.PhysicsColliders;
        surface.BuildNavMesh();
        if (OnWorldReady != null) {
            print("world ready! o_O");
            OnWorldReady();
        }
    }

    public static string GenerateRandomLevelHash (int length, int floorWidth) {
        string hash = "";

        for (int i=0; i<length; i++) {
            hash += Random.Range(0, 2) == 1? "B": " ";
            int holeCount = 0;
            for (int j=0; j<floorWidth; j++) {
                if (i%2 == 0 && holeCount < floorWidth-1 && Random.Range(0, 2) == 0) {
                    hash += "0";
                    holeCount++;
                } else {
                    hash += "1";
                }
            }
            hash += (Random.Range(0, 2) == 1? "B": " ") + "\n";
        }

        return hash.Trim();
    }
}
