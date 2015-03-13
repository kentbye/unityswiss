using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using SwissEphNet;

class main : MonoBehaviour {
	public double inputDate = 2443022.711806;
	public double[] planetLongitude = new double[20]; // Store the longitude for up to 20 objects
	public GameObject[] planet = new GameObject[20];
	public float smooth = 2.0F; 
	public float tiltAngle = 30.0F;
	
	// Use this for initialization
	void Start () {
		// 1976 September 01 05:04:59.5 UT  Wednesday
		// CE 1976 September  1 05:05:00.0 UT
		//Debug.Log("getDayFromJd " + swisseph.getDayFromJd(2443022.711806, 1));
		//swisseph.getDayFromJd (inputDate, 1);
		//swisseph.swe_set_ephe_path("C:\\DLLTest\\sweph\\src");
		using (var swe = new SwissEph()) {
			
			// 7. Date and time conversion functions
			// 7.1 Calendar Date and Julian Day
			/*
 			* Convert calendar dates to the astronomical time scale, which measures time in Julian days.
	 		*
 			* @param year 
 			* @param month
	 		* @param day
 			* @param hour
 			*   Fractional hours in military time. Minutes need to be divided by 60 and added to the hour.
	 		*   Hours need to be converted from the local timezone to UTC, which may impact the impact the month & day
 			* @param gregflag
 			*   Gregorian Calendar flag should be set to 1
			* @return Julian Day
 			*   A Julian Day results in 2443022.711806 given an input date of 1976 September 01 05:05:00 UT
    		*/
			// STATUS: WORKING
			double tjd = swe.swe_julday(1976, 09, 01, 05.083333, 1);
			Debug.Log("swe_julday = " + tjd);
			
			// 2. swe_calc_ut()
			/**
	 		* Computes positions of planets, asteroids, lunar nodes and apogees.
 			* 
 			* @param jdnr
	 		* 	Julian Day, Universal Time
 			* @param ipl
 			* 	Body number
	 		* @param iflag
 			* 	A 32-bit integer containing bit flags that indicate what kind of computation is wanted
 			* @param xx
	 		* 	array of 6 doubles for longitude, latitude, distance, speed in long, speed in lat, and speed in distance
 			* @param serr
 			* 	character string to return error messages in case of error
			*/
			// STATUS: ERROR 
			// OLD: StackOverflowException: The requested operation caused a stack overflow. 
			// OLD: SwissEphNet.CPointer`1[System.Double]..ctor (System.Double[] baseArray)
			// NEW: SwissEphNet.CPointer`1[System.Double].op_Inequality (SwissEphNet.CPointer`1 access, System.Double[] array) (at Assets/Scripts/SwissEphNet/Tools/CPointer.cs:117)
						double[] xx = new double[6]; // This must be 6
						Debug.Log ("XX: " + xx);
						string serr = "";
						//int iflag = Constants.SEFLG_SPEED; // Calculate speed
						int iflag = 1;
						double jdnr = tjd;
						int ipl = 9;
						swe.swe_calc(jdnr, ipl, iflag, xx, ref serr);
						Debug.Log("planet longitude = " + xx[0]);
			
			
			// 2. swe_get_planet_name()()
			/**
	 		* Find the name of a planet, ficticious body, or asteroid
 			* 
 			* @param ipl
 			* 	Body number
			*/
			// STATUS: WORKING!
			//			/// TODO: Debug the opening & reading of seasnam.txt for asteroids > 10004
						int i;
//						for (i = 0; i < 23; i++) {
//							Debug.Log("swe_get_planet_name(" + i + ") = " + swe.swe_get_planet_name(i));
//						}
						// Ficticious Planets
//						for (i = 40; i < 55; i++) {
//							Debug.Log("swe_get_planet_name(" + i + ") = " + swe.swe_get_planet_name(i));
//						}
			//			// Ficticious Planets
//						for (i = 10000; i < 10005; i++) {
//							Debug.Log("swe_get_planet_name(" + i + ") = " + swe.swe_get_planet_name(i));
//						}
			//
			
			// 4. Fixed stars functions
			// 4.1 swe_fixstar()
			
			/**
	 		* If a star is found, its name is returned in this field in the following format: 
 			* traditional_name, nomenclature_name (e.g. "Aldebaran,alTau").
 			*
	 		* @param star
 			* 	The name of the fixed star to be searched, returned name of found star
 			* @param tjd_ut
	 		* 	Julian Day, Universal Time
 			* @param iflag
 			* 	A 32-bit integer containing bit flags that indicate what kind of computation is wanted
	 		* @param xx
 			* 	array of 6 doubles for longitude, latitude, distance, speed in long, speed in lat, and speed in distance
 			* @param serr
	 		* 	character string to return error messages in case of error
			*/
			// STATUS: ERROR
			// StackOverflowException: The requested operation caused a stack overflow. SwissEphNet.CPointer`1[System.Double]..ctor (System.Double[] baseArray)
			// public Int32 swe_fixstar(string star, double tjd, Int32 iflag, double[] xx, ref string serr) 
			// 		swi_check_nutation(tjd, iflag);
			// void swi_check_nutation(double tjd, Int32 iflag) 
			// 		SE.SwephLib.swi_nutation(tjd, iflag, swed.nut.nutlo);
			// swi_nutation(double J, Int32 iflag, CPointer<double> nutlo) 
			//			string star = "Spica";
			////			//double tjd = 2443022.711806;
			//			Int32 iflag = 0;
			//			double[] xx = new double[3];
			//			string serr = "";
			//			Debug.Log (swe.swe_fixstar(star, tjd, iflag, xx, ref serr));
			
			
			// 4.3 swe_fixstar_mag()
			/*
			* get fixstar magnitude
			* 
			* @param star
			* 	name of star or line number in star file (start from 1, don't count comment).
			*    		If no error occurs, the name of the star is returned in the format trad_name, nomeclat_name
			* @param mag
			* 	pointer to a double, for star magnitude
			* @param serr
			* 	error return string
			*/
			// STATUS: Not working
			// Not opening up the correct files
			// SwissEph.SE_STARFILE of "sefstars.txt"
			// SwissEph.SE_STARFILE_OLD of "fixstars.cat"
			// swed.ephepath of SwissEph.SE_EPHE_PATH = "[ephe]"
			//			string star = "Spica";
			//			double mag = 1.0;
			//			string serr = "";
			//			long magnitude = 0;
			//			magnitude = swe.swe_fixstar_mag(ref star, ref mag, ref serr);
			//			Debug.Log (magnitude);
			
			// 12. House cusp calculation
			// 12.1 swe_houses()
			
			
			
		}
		
		
		
		/*		
		// Set up array and textures of major planets
		int[] selectedPlanets = new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9};
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
*/
		/* // Relative sizes of the planets
		 * float[] planetDiameter = new float[] {
						109.167f,
						0.27256f,
						0.3829f,
						0.9496f,
						0.53320f,
						11.2212f,
						9.4597f,
						4.01177f,
						3.884790f,
						0.185214f
				};
		*/
		/*
		float[] planetDiameter = new float[] {
			0.3f,
			0.27256f,
			0.2529f,
			0.3f,
			0.33320f,
			1.0f,
			0.85f,
			2.7f,
			2.3f,
			0.7f,
			0.1f,
			0.1f, // Crashes with "IndexOutOfRangeException: Array index is out of range" error at 11
			0.1f,
			0.1f,
			0.2f
		};
*/
		
		/*
		foreach (int planetNumber in selectedPlanets) {
			planetLongitude[planetNumber] = swisseph.getLongitude (planetNumber, inputDate);
			//Debug.Log(planetNumber + " " + planetLongitude[planetNumber]);
		}
		*/
		/*
		GameObject lightGameObject = new GameObject("The Light");
		lightGameObject.AddComponent<Light>();
		lightGameObject.transform.position = new Vector3(0, 0, 0);
		// Outer planets are so far away that they are not illuminated by this light source
		lightGameObject.light.intensity = 1.0f;
		*/
		/*
		double[][] planetLongitude = new double[30][];
		foreach (int planetNumber in selectedPlanets) {
			planetLongitude[planetNumber] = new double[3];
			planetLongitude[planetNumber] = swisseph.getLongitude (planetNumber, inputDate);
			planet[planetNumber] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			planet[planetNumber].name = "Planet" + planetNumber;
			//planet[planetNumber].transform.position = new Vector3((float)planetLongitude[planetNumber][0], (float)planetLongitude[planetNumber][2], (float)planetLongitude[planetNumber][1]);
			//planet[planetNumber].transform.localScale = new Vector3(planetDiameter[planetNumber], planetDiameter[planetNumber], planetDiameter[planetNumber]);
			//Texture2D planetTexture = Resources.Load(planetTextureArray[planetNumber]) as Texture2D;
			//planet[planetNumber].renderer.material.mainTexture = planetTexture;

			for (int i = 0; i < 3; i++) { 
				Debug.Log(planetNumber + " " + planetLongitude[planetNumber][i]); 
			}

		}
		*/
		
		/*
		double[][] planetXYZ = new double[30][];
		foreach (int planetNumber in selectedPlanets) {
			planetXYZ[planetNumber] = new double[3];
			planetXYZ[planetNumber] = swisseph.getPlanetXYZ (planetNumber, inputDate);
			planet[planetNumber] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			planet[planetNumber].name = "Planet" + planetNumber;
			planet[planetNumber].transform.position = new Vector3((float)planetXYZ[planetNumber][0], (float)planetXYZ[planetNumber][2], (float)planetXYZ[planetNumber][1]);
			planet[planetNumber].transform.localScale = new Vector3(planetDiameter[planetNumber], planetDiameter[planetNumber], planetDiameter[planetNumber]);
			Texture2D planetTexture = Resources.Load(planetTextureArray[planetNumber]) as Texture2D;
			planet[planetNumber].renderer.material.mainTexture = planetTexture;

//			for (int i = 0; i < 3; i++) { 
//				Debug.Log(planetNumber + " " + planetXYZ[planetNumber][i]); 
//			}

		}
		*/
		
		/*
		double[][] planetHeliocentric = new double[20][];
		foreach (int planetNumber in selectedPlanets) {
			planetHeliocentric[planetNumber] = new double[3];
			planetHeliocentric[planetNumber] = swisseph.getPlanetHeliocentric (planetNumber, inputDate);
			for (int i = 0; i < 3; i++) { 
				Debug.Log(planetNumber + " " + planetHeliocentric[planetNumber][i]); 
			}
		}
		*/
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		/*
		int[] selectedPlanets = new int[] { 0, 2, 3, 4, 5, 6, 7, 8, 9 };
		
		if(Input.GetKey(KeyCode.RightArrow)) {
			float speed = 50.0f;
			transform.Rotate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Space.World);
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)) {
			float speed = 50.0f;
			transform.Rotate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Space.World);
		}
		*/
		
		
		// UPDATE POSITION OF THE PLANETS IN XYZ COORDINATES
		/*
		double[][] planetXYZ = new double[20][];
		foreach (int planetNumber in selectedPlanets) {
			planetXYZ[planetNumber] = new double[3];
			planetXYZ[planetNumber] = swisseph.getPlanetXYZ (planetNumber, inputDate);
			planet[planetNumber].transform.position = new Vector3((float)planetXYZ[planetNumber][0], (float)planetXYZ[planetNumber][2], (float)planetXYZ[planetNumber][1]);
		}
		inputDate = inputDate + 0.2;
		*/
		
		/*
		foreach (int planetNumber in selectedPlanets) {
			planetLongitude[planetNumber] = swisseph.getLongitude (planetNumber, inputDate);
			Debug.Log(planetNumber + " " + planetLongitude[planetNumber]);
		}
		inputDate++;
		*/
		
	}
}