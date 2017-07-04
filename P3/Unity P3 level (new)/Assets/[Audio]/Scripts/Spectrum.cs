using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour 
{
	public GameObject prefab;
	public int objectCount = 24;
	public float radius = 4;
	public GameObject[] cubes;

	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < objectCount; i++)
		{
			float angle = i * Mathf.PI * 2 / objectCount;
			Vector3 pos = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * radius;
			GameObject cube = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
			cube.transform.parent = this.transform;
			cube.name = "SoundCube"+(i+1);
		}

		cubes = GameObject.FindGameObjectsWithTag("Sound Cube");
	}
	
	// Update is called once per frame
	void Update () 
	{
		float[] spectrum = new float[64];
		AudioListener.GetOutputData(spectrum, 0);

		for (int i = 0; i < cubes.Length; i++)
		{
			Vector3 previousScale = cubes[i].transform.localScale;
			previousScale.y = Mathf.Lerp (previousScale.y, spectrum[i] * 50, Time.deltaTime * 10 );

			//Vector3 previousScale = Vector3.one;

			cubes[i].transform.localScale = previousScale;
		}
	}
}
