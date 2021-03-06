﻿using UnityEngine;
using System.Collections;

/*
public class LoadingScreen : MonoBehaviour {

	public string levelToLoad;

	public GameObject background;
	public GameObject text;
	public GameObject progressBar;

	private int loadProgress = 0;

	// Use this for initialization
	void Start () {
		background.SetActive(false);
		text.SetActive(false);
		progressBar.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")) {
			StartCoroutine(DisplayLoadingScreen(levelToLoad));
		}
	}

	IEnumerator DisplayLoadingScreen(string level) {
		background.SetActive(true);
		text.SetActive(true);
		progressBar.SetActive(true);

		progressBar.transform.localScale = new Vector3(loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);

		text.guiText.text = "Loading Progress " + loadProgress + "%";

		AsyncOperation async = Application.LoadLevelAsync(levelToLoad);

		while (!async.isDone) {
			loadProgress = (int)(async.progress * 100);
			text.guiText.text = "Loading Progress " + loadProgress + "%";
			progressBar.transform.localScale = new Vector3(loadProgress, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
			
			yield return null;
		}
	}

	
}
*/
public class LoadingScreen : MonoBehaviour {

	public GameObject background;
	public GameObject text;
	public GameObject progressBar;
	public GameObject locationText;

	public InformationButton informationButton;

	static LoadingScreen _instance;

	public GameObject backAnim;

	void Awake()
	{
		if (_instance)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;

		//gameObject.AddComponent<GUITexture>().enabled = false;
		//guiTexture.texture = texture;
		//transform.position = new Vector3(0.5f, 0.5f, 0.0f);
		Deactive();

		DontDestroyOnLoad(this);
	}

	static void Active()
	{
		print ("Active");
		_instance.background.SetActive(true);
		_instance.text.SetActive(true);
		_instance.progressBar.SetActive(true);
		_instance.locationText.SetActive(true);
	}

	static void Deactive()
	{
		print ("Deactive");
		_instance.background.SetActive(false);
		_instance.text.SetActive(false);
		_instance.progressBar.SetActive(false);
		_instance.locationText.SetActive(false);
		anim += 1;

		_instance.informationButton.Pointed ();
		//_instance.GetComponent<InformationButton> ().Pointed ();

	}

	private void StartAnim()
	{

	}

	public static void Load(int index)
	{
		if(NoInstance()) return;

		Active();
		Application.LoadLevel(index);
		Deactive();
	}

	public static void Load(string name)
	{
		if(NoInstance()) return;
		Active();
		Application.LoadLevel(name);
		Deactive();
	}

	public static void SetLocationText(string text)
	{
		if(NoInstance()) return;
		_instance.locationText.guiText.text = text;
	}

    public static void SetLoadingText(string text)
    {
        if (NoInstance()) return;
        _instance.text.guiText.text = text;
    }

	public static void Show()
	{
		if(NoInstance()) return;

		Active();
	}

	public static void Hide()
	{
		if(NoInstance()) return;

		Deactive();
	}

	static bool NoInstance()
	{
		if(!_instance)
		{
			Debug.LogError("Loading Screen is not existing in scence.");
			return true;
		}
		return false;
	}

	// Use this for initialization
	void Start () {
		
	}
	static int anim = 0;

	// Update is called once per frame
	void Update () {
		if(anim == 3)
			backAnim.SetActive (true);
        SetLoadingText("LOADING - " + Manager.Instance.GetProgress().ToString() + " %");
	}
}
