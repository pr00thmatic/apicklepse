using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Races {
    public Dictionary<TypesOfCat, CatType> typeToCat;

    public CatType[] available = {
        new CatType ("coffee and milk",
                     TypesOfCat.coffeeAndMilk,
                     new Uniform(-2, 0),
                     new Uniform(1, 1.2f)),

        new CatType ("milk and coffee",
                     TypesOfCat.milkAndCoffee,
                     new Uniform(-2, 2),
                     new Uniform(0.8f, 1.2f)),

        new CatType ("gloomy gloves",
                     TypesOfCat.gloomyGloves,
                     new Uniform(0, 4),
                     new Uniform(0.7f, 0.9f))
    };

    public Races () {
        typeToCat = new Dictionary<TypesOfCat, CatType>();
        foreach (CatType availableCat in available) {
            typeToCat[availableCat.race] = availableCat;
        }
    }

    public void RollTheDiceOfDestiny (Cat cat) { // xD
        cat.agent.speed = GameController.instance.catPrototype.
            GetComponent<NavMeshAgent>().speed + typeToCat[cat.race].speed.Value();
        cat.transform.localScale =
            GameController.instance.catPrototype.transform.localScale *
            typeToCat[cat.race].size.Value();

        cat.SetMaterial(Resources.Load<Material>("cat skins/" +
                                                 typeToCat[cat.race].verboseName));

        // left handed cats
        cat.transform.localScale =
            Vector3.Scale(new Vector3(Random.Range(0, 1.0f) < 0.5f? -1: 1, 1, 1),
                          cat.transform.localScale);

        // random rotation
        cat.transform.Rotate(0, Random.Range(0, 360), 0);
    }
}
