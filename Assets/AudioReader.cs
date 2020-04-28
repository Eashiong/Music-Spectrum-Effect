using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReader : MonoBehaviour {
    AudioSource audioSource;
    private float[] samples = new float[64];
    public GameObject item;
    private GameObject[] items = new GameObject[64];
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        for(int i = 0;i<samples.Length;i++)
        {
            items[i] = Instantiate(item,transform);
            items[i].transform.localPosition = new Vector3(i * 0.2f, 0, 0);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
        for(int i = 0;i<samples.Length;i++)
        {
            items[i].transform.localScale = new Vector3(1, samples[i]*100, 1);
           
        }
	}
}
