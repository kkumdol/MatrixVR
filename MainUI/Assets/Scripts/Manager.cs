﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// SINGLETON MANAGER CLASS FOR ALL SCENES AND SCRIPT 

public class Manager {
	
	private static Manager _instance;
	public static Manager Instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = new Manager();
			}
			return _instance;
		}
	}
	// FOR STREETVIEWER.SCENE VARIABLES AND FUNCTIONS
	public string panoramaID;
	public string[] nextIDs;
	public string[] nextDegrees;
    public Stack<string> panoramaStack;
	
	public int processCount;
	
	// FOR MainUI.scene VARIABLES AND FUNCTIONS
	
	public string thumbnailID;
	public string thumbnailText;
	public Texture2D thumbnailImg;
    public string wikiText;
	
	// FOR CAMERA RIG
	public Vector3 CameraRotation;
	public Quaternion CameraOrientation;
	
}