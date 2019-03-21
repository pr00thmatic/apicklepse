using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

// TabcT
// T \in {B, ' ' }: is a bonus wall?
// a, b, c \in {1, 0}: is floor?

public class WorldPiece : MonoBehaviour {
    public static string BONUS_WALL = "bonus wall";
    public static string WALL = "wall";
    public static string FLOOR = "floor";
    public static string BONUS_FLOOR = "floorB";
    public string debugHashPiece;

    public void Initialize (string hashPiece, Transform parent) {
        InitializeTransform(parent);
        SetWall(hashPiece, 0);
        SetWall(hashPiece, 1);

        for (int i=0; i < hashPiece.Length - 2; i++) {
            // char floorChar = hashPiece[i+1] == 'R'? Random.Range(0, 2): hashPiece[i+1];
            SetTile(FLOOR + i, hashPiece[i+1] == '1');
        }

        debugHashPiece = hashPiece;
    }

    public void InitializeTransform (Transform parent) {
        transform.parent = parent;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localPosition = new Vector3(0, 0, transform.GetSiblingIndex() * 4);
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void SetWall (string hashPiece, int index) {
        char wallChar = hashPiece[index == 0? 0: hashPiece.Length-1];
        wallChar = wallChar == 'R'? (Random.Range(0, 1.0f) < 0.8f? 'N': 'B'): wallChar;
        bool isBonus = hashPiece[index == 0? 0: hashPiece.Length-1] == 'B';
        SetTile(BONUS_WALL + index, isBonus);
        SetTile(WALL + index, !isBonus);
        SetTile(BONUS_FLOOR + index, isBonus);
    }
        
    public void SetTile (string name, bool active) {
        transform.Find(name).gameObject.SetActive(active);
    }
}
