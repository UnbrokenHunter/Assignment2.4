using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
	[SerializeField] private float spawnRate = 10;
	[SerializeField] private float spawnMult = 1;

    private int count = 1;

	[SerializeField] private Vector3 spawnPosition = Vector3.zero;
	[SerializeField] private Vector2 range = Vector3.zero;
	[SerializeField] private Vector2 rangeY = Vector3.zero;

	private float timer = 0;


    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnRate)
        {
            timer = 0;

            if(spawnRate - 1 > 0)
                spawnRate -= spawnMult;
            else
                count++;

            for (int i = 0; i < count; i++)
            {
				Vector3 pos = spawnPosition;
				pos += new Vector3(Random.Range(range.x, range.y), Random.Range(rangeY.x, rangeY.y), 0);
			    Instantiate(prefab, pos, Quaternion.identity, gameObject.transform);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rain")
            Destroy(collision.gameObject);
    }

    private void OnDrawGizmos()
    {

		Gizmos.DrawCube(new Vector3(range.x + spawnPosition.x, rangeY.x + spawnPosition.y, 0), Vector3.one);
		Gizmos.DrawCube(new Vector3(range.y + spawnPosition.x, rangeY.y + spawnPosition.y, 0), Vector3.one);
	}
}
