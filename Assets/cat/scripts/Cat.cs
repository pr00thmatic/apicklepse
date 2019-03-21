using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Cat : MonoBehaviour {
    public TypesOfCat race;
    public float triggerRange = 2;

    public NavMeshAgent agent;
    public Animator animator;
    public Renderer mesh;

    private WorldController _worldController;

    void Awake () {
        race = (TypesOfCat) Random.Range(0, 3);
        _worldController = transform.GetComponentInParent<WorldController>();
        _worldController.world.OnWorldReady += HandleWorldReady;
        gameObject.SetActive(false);
    }

    void Update () {
        if (agent != null) {
            if (!_worldController.laser.isInSurface) {
                animator.SetBool("saw laser", false);
                agent.isStopped = true;
            } else if (!animator.GetBool("saw laser")) {
                Vector3 dif = _worldController.laser.transform.position -
                    transform.position;
                if (dif.magnitude < triggerRange &&
                    !Physics.Raycast(transform.position, dif, dif.magnitude)) {
                    animator.SetBool("saw laser", true);
                }
            } else {
                agent.SetDestination(_worldController.laser.transform.position);
                agent.isStopped = false;
            }

            animator.SetFloat("speed", agent.velocity.magnitude);
        }
    }

    public void HandleWorldReady () {
        gameObject.SetActive(true);
        float normalSpeed = agent.speed;
        GameController.instance.races.RollTheDiceOfDestiny(this);
        animator.SetFloat("anim speed", agent.speed / normalSpeed);
    }

    public void SetMaterial (Material material) {
        mesh.material = material;
    }
}
