using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float projectileLifeTime;
    public float playerProjectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(FiniteLife));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(playerProjectileSpeed * Time.deltaTime * Vector3.up);
    }

    private IEnumerator FiniteLife()
    {
        yield return new WaitForSeconds(projectileLifeTime);
        Destroy(gameObject);
    }
}
