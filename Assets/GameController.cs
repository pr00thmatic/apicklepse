using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public Races races;
    public GameObject catPrototype;

    void Awake () {
        if (instance == null) {
            instance = this;
            races = new Races();
        } else {
            Destroy(this.gameObject);
        }
    }
}
