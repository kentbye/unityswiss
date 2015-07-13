using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using SwissEphNet;
using animamundi;
using Vectrosity;



public class main : MonoBehaviour {
	public double inputDate;
	//public double[] planetLongitude = new double[20]; // Store the longitude for up to 20 objects
	public GameObject[] planet;
	public float smooth; 
	public float tiltAngle;
	public float degToRad;
	private GameObject cube;
	private double d_timezone;
	private Int32 iyear_utc;
	private Int32 imonth_utc;
	private Int32 iday_utc;
	private	Int32 ihour_utc;
	private Int32 imin_utc; 
	private double dsec_utc;
	private Int32 retval; 
	private double tjd_et, tjd_ut;
	private double[] dret;
	private string serr;
	private astro Astrotest;
	private astro Astrotester;
	private float height;
	private double[] houseCusps;
	private int orbitLineResolution = 150;
	private VectorLine outerCircle;
	private VectorLine innerCircle;
	

	// Use this for initialization
	void Start () {
		
		cube = GameObject.Find("Cube");
		planet = new GameObject[20];
		dret = new double[2];
		astro Astrotest = new astro();
		astro Astrotester = new astro();

		d_timezone = 0.0;
		// inputDate = 2443022.71180555;
		// inputDate = 2443022.71235167; // dret[0] is tjd_et -- Calculate Planet -- TODO WHY?
		// inputDate = 2443022.71180576; // dret[1] is tjd_ut -- Calculate Houses


		// Get the Julian Date given a UTC time

		Astrotest.getUTCTime (1976, 9, 1, 5, 5, 0, d_timezone, ref iyear_utc, ref imonth_utc, ref iday_utc, ref ihour_utc, ref imin_utc, ref dsec_utc);
		Debug.Log (iyear_utc + " " + imonth_utc + " " + iday_utc + " " + ihour_utc + " " + imin_utc + " " + dsec_utc);
//		retval = Astrotester.getJulianDayUTC (iyear_utc, imonth_utc, iday_utc, ihour_utc, imin_utc, dsec_utc, dret, ref serr);
		inputDate = astro.getJulianDay (iyear_utc, imonth_utc, iday_utc, ihour_utc + (imin_utc)/60.0 + (dsec_utc)/3600.0);
//		inputDate = astro.getJulianDay (1976, 9, 1, 5.0833333);
		Debug.Log (inputDate);
		smooth = 2.0F;
		tiltAngle = 30.0F;
		degToRad = Mathf.PI/180.0F;

		//Set up array and textures of major planets
		//int[] selectedPlanets = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
		int[] selectedPlanets = new int[] { 0, 2, 3, 4};
		string[] planetTextureArray = new string[] { 
			"sunmap",
			"moonmap1k",
			"mercurymap",
			"venusmap",
			"marsmap1k",
			"jupiter2_1k",
			"saturnmap",
			"uranusmap",
			"neptunemap",
			"plutomap1k",
			"sunmap", // node
			"sunmap", // node
			"sunmap", // Apogee
			"sunmap", // Apogee
			"earthmap1k"
		};
		 // Relative sizes of the planets
//		 float[] planetDiameter = new float[] {
//						109.167f,
//						0.27256f,
//						0.3829f,
//						0.9496f,
//						0.53320f,
//						11.2212f,
//						9.4597f,
//						4.01177f,
//						3.884790f,
//						0.185214f
//				};
//		float[] planetDiameter = new float[] {
//			0.3f,
//			0.27256f,
//			0.2529f,
//			0.3f,
//			0.33320f,
//			1.0f,
//			0.85f,
//			2.7f,
//			2.3f,
//			0.7f,
//			0.1f,
//			0.1f, // Crashes with "IndexOutOfRangeException: Array index is out of range" error at 11
//			0.1f,
//			0.1f,
//			0.2f
//		};

		float[] planetDiameter = new float[] {
			0.7f,
			0.5f,
			0.3829f,
			0.9496f,
			0.53320f,
			0.5f,
			0.5f,
			0.5f,
			0.5f,
			0.5f,
			0.5f,
			0.5f, // Crashes with "IndexOutOfRangeException: Array index is out of range" error at 11
			0.5f,
			0.5f,
			0.5f,
		};



		double[] planetLongitude = new double[30];

//		foreach (int planetNumber in selectedPlanets) {
//			planetLongitude[planetNumber] = astro.getLongitude (planetNumber, inputDate);
//			Debug.Log(planetNumber + " " + planetLongitude[planetNumber]);
//		}

//		GameObject lightGameObject = new GameObject("The Light");
//		lightGameObject.AddComponent<Light>();
//		lightGameObject.transform.position = new Vector3(-3, 3, -3);
//		// Outer planets are so far away that they are not illuminated by this light source
//		lightGameObject.GetComponent<Light>().intensity = 1.0f;


		float planetRadius = 2.0f;
		string name;
		float height = 2.5f;
		foreach (int planetNumber in selectedPlanets) {

			planetLongitude[planetNumber] = astro.getLongitude (planetNumber, inputDate);
			Destroy(cube, 1.3F);

			//Debug.Log(planetNumber + " " + planetLongitude[planetNumber]); 
			//Debug.Log (planetLongitude[planetNumber] + " " + planetNumber);

			planet[planetNumber] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			planet[planetNumber].name = "Planet" + planetNumber;


			planet[planetNumber].transform.position = new Vector3((float)(planetRadius*Mathf.Sin((float)planetLongitude[planetNumber]*degToRad)), 4.5f, (float)(planetRadius*Mathf.Cos((float)planetLongitude[planetNumber]*degToRad)));
			planet[planetNumber].transform.position = new Vector3((float)(planetRadius*Mathf.Sin(180.0F-(float)planetLongitude[planetNumber]*degToRad)), height, (float)(planetRadius*Mathf.Cos(180.0F-(float)planetLongitude[planetNumber]*degToRad)));
			height = height - 0.7f;
			planet[planetNumber].transform.localScale = new Vector3(planetDiameter[planetNumber], planetDiameter[planetNumber], planetDiameter[planetNumber]);
			Texture2D planetTexture = Resources.Load(planetTextureArray[planetNumber]) as Texture2D;
			planet[planetNumber].GetComponent<Renderer>().material.mainTexture = planetTexture;

		}

		
		houseCusps = new double[23];
		houseCusps = astro.getHouses (inputDate, 39.7910, -86.1480, Constants.C_HOUSES_PLACIDUS);
//		for (int i = 0; i < 13; i++) {
//			Debug.Log (i + " " + houseCusps[i]); // Verify that the house system is working correctly.
//		}

		// Draw Vectrosity Circles
		innerCircle = new VectorLine("OrbitLine", new Vector3[orbitLineResolution], null, 2.0f, LineType.Continuous);
		innerCircle.MakeCircle (Vector3.zero, Vector3.up, 1.8f);
		innerCircle.Draw3DAuto();
		outerCircle = new VectorLine("OrbitLine", new Vector3[orbitLineResolution], null, 2.0f, LineType.Continuous);
		outerCircle.MakeCircle (Vector3.zero, Vector3.up, 5.0f);
		outerCircle.Draw3DAuto();
		VectorLine.SetLine (Color.white, new Vector3(0, 0, 0), new Vector3(15, 15, 0));
		
		
		
		//		double[][] planetXYZ = new double[30][];
//		foreach (int planetNumber in selectedPlanets) {
//			planetXYZ[planetNumber] = new double[3];
//			planetXYZ[planetNumber] = astro.getPlanetXYZ (planetNumber, inputDate);
//			planet[planetNumber] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			planet[planetNumber].name = "Planet" + planetNumber;
//			planet[planetNumber].transform.position = new Vector3((float)planetXYZ[planetNumber][0], (float)planetXYZ[planetNumber][2], (float)planetXYZ[planetNumber][1]);
//			planet[planetNumber].transform.localScale = new Vector3(planetDiameter[planetNumber], planetDiameter[planetNumber], planetDiameter[planetNumber]);
//			Texture2D planetTexture = Resources.Load(planetTextureArray[planetNumber]) as Texture2D;
//			planet[planetNumber].GetComponent<Renderer>().material.mainTexture = planetTexture;
//
//		}


		
//		double[][] planetHeliocentric = new double[20][];
//		foreach (int planetNumber in selectedPlanets) {
//			planetHeliocentric[planetNumber] = new double[3];
//			planetHeliocentric[planetNumber] = swisseph.getPlanetHeliocentric (planetNumber, inputDate);
//			for (int i = 0; i < 3; i++) { 
//				Debug.Log(planetNumber + " " + planetHeliocentric[planetNumber][i]); 
//			}
//		}


	}
	
	// Update is called once per frame
	void Update () {

//		int[] selectedPlanets = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		int[] selectedPlanets = new int[] { 0, 2, 3, 4};
		
		if(Input.GetKey(KeyCode.RightArrow)) {
			float speed = 50.0f;
			transform.Rotate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Space.World);
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)) {
			float speed = 50.0f;
			transform.Rotate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Space.World);
		}

		// UPDATE POSITION OF THE PLANETS IN XYZ COORDINATES
//		double[][] planetXYZ = new double[20][];
//		foreach (int planetNumber in selectedPlanets) {
//			planetXYZ[planetNumber] = new double[3];
//			planetXYZ[planetNumber] = astro.getPlanetXYZ (planetNumber, inputDate);
//			planet[planetNumber].transform.position = new Vector3((float)planetXYZ[planetNumber][0], (float)planetXYZ[planetNumber][2], (float)planetXYZ[planetNumber][1]);
//		}
//		inputDate = inputDate + 0.2;

		double[] planetLongitude = new double[20];
		float planetRadius = 2.0f;
		float height = 2.5f;
//		Animate the panets
		foreach (int planetNumber in selectedPlanets) {
			planetLongitude[planetNumber] = astro.getLongitude (planetNumber, inputDate);
			planet[planetNumber].transform.position = new Vector3((float)(planetRadius*Mathf.Sin(180.0F-(float)planetLongitude[planetNumber]*degToRad)), height, (float)(planetRadius*Mathf.Cos(180.0F-(float)planetLongitude[planetNumber]*degToRad)));
			height = height - 0.7f;
		}

		//		Debug.Log (inputDate + " " + planetLongitude[0] + " " + planetLongitude[1] + " " + planetLongitude[2] + " " + planetLongitude[3] + " " + planetLongitude[4] + " " + planetLongitude[5]
		//		           + " " + planetLongitude[6] + " " + planetLongitude[7] + " " + planetLongitude[8] + " " + planetLongitude[9]);

//		Increment the date		
		inputDate = inputDate + 0.25;
//		inputDate = inputDate + 1.0;

		/*
		foreach (int planetNumber in selectedPlanets) {
			planetLongitude[planetNumber] = swisseph.getLongitude (planetNumber, inputDate);
			Debug.Log(planetNumber + " " + planetLongitude[planetNumber]);
		}
		inputDate++;
		*/
		
	}
}