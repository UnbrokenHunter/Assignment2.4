using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    private Rigidbody2D rb;
	[SerializeField] private float rotSpeed = 5;
	[SerializeField] private float offset = 90;

	[SerializeField] private int poppedCount = 0;

	[SerializeField] private TMP_Text text;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		// Position
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = Camera.main.nearClipPlane;
		Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);

		// Angle
		var dir = Worldpos - transform.position;
		var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		var newAngle = Quaternion.AngleAxis(angle + offset, Vector3.forward);

		Quaternion rot = Quaternion.Lerp(transform.rotation, newAngle, rotSpeed);

		if(dir != Vector3.zero)
			transform.rotation = rot;
		
		transform.position = Worldpos;

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "Rain")
		{
			Destroy(collision.gameObject);

			poppedCount++;
			text.text = "Popped: " + poppedCount;
		}

	}


}
