using System.Collections;
using UnityEngine;

public class Blaster : MonoBehaviour {
    [SerializeField]
    private int damage;

    [SerializeField]
    private LayerMask hitMask;

    LineRenderer lineRenderer;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) shoot();
    }

    public void shoot() {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 500f, hitMask);

        lineRenderer.SetPositions(new Vector3[] {transform.position, transform.forward * 20});
        StartCoroutine(ShowLine(0.1f));

        if (hit.collider != null) {
            hit.collider.GetComponent<Health>().TakeDamage(damage);
        }
    }

    IEnumerator ShowLine(float duration) {
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(duration);
        lineRenderer.enabled = false;
    }
}