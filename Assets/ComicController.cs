﻿using UnityEngine;
using System.Collections;

public class ComicController : MonoBehaviour {

	public GameObject CameraRig;
	public GameObject CamAnchorComic;
	public GameObject CamAnchorGame;
	public GameObject GameController;

	private bool toGame = false;

	private float lerpTimer = 0;
	private float lerpTime = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(toGame) {
			lerpTimer += Time.deltaTime;
			CameraRig.transform.position = Vector3.Lerp(CamAnchorComic.transform.position, CamAnchorGame.transform.position, lerpTimer / lerpTime);
			if(lerpTimer / lerpTime >= 1) {
				toGame = false;
				GameController.GetComponent<GameController>().GetReady();
			}
		}
	}

	public void StartComic() {
		CameraRig.transform.position = CamAnchorComic.transform.position;
	}

	public void StartGame() {
		toGame = true;
	}
}
