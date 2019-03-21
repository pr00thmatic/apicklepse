using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destroyable : MonoBehaviour {
    public float strength = 5;

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Explode();
        }
    }

    public void Explode () {
        Vector3 center = transform.Find("centro").position;

        foreach (Transform child in transform) {
            if (child.name != "centro") {
                Rigidbody body = child.GetComponent<Rigidbody>();
                body.isKinematic = false;
                body.useGravity = true;
                body.AddForce((child.position - center + Random.insideUnitSphere * Random.Range(0, strength * 0.25f)).normalized * strength, ForceMode.Impulse);
            }
        }

        StartCoroutine(EventuallyDestroy());
    }

    private IEnumerator EventuallyDestroy () {
        yield return new WaitForSeconds(2);
        float elapsed = 0;
        float total = 0.5f;
        Vector3 initial = transform.GetChild(0).localScale;

        while (elapsed < total) {
            elapsed += Time.deltaTime;
            Vector3 current = Vector3.Lerp(initial, Vector3.zero, elapsed / total);

            foreach (Transform child in transform) {
                child.localScale = current;
            }

            yield return null;
        }

        Destroy(gameObject);
    }
}
