using UnityEngine;
using System.Collections;




public class Billboard : MonoBehaviour
{
	public bool travarOrientacaoEmY = true;
	public Transform camCam;
	public Vector3 posCam;
	public Quaternion lastPos;
	public float turnSpeed = 20f;

	private void Awake()
	{
		camCam = Camera.main.transform;
	}

	private void Update()
	{
		posCam = camCam.position - transform.position;

		// se travar orientação em y, sempre alinhado no eixo y
		if (travarOrientacaoEmY) {
			posCam.y = 0;
		}

		lastPos = Quaternion.LookRotation(-posCam);
		transform.rotation = Quaternion.Slerp(transform.rotation, lastPos, Time.deltaTime * turnSpeed);
	}
}
