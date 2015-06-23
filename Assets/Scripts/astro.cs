/***************************************************************************
 Copyright (C) 2014 Immersive Astrology/Kent Bye (http://immersiveastrology.com).	  
                                                                        
 This program is free software; you can redistribute it and/or          
 modify it under the terms of both the GNU General Public License (GPL).
 You should also adhere to the terms of the Swiss Ephemerice            
 License (SEPL).                                                        
 The GPL is published by the Free Software Foundation; either version 3 
 of the License, or (at your option) any later version is effective. 	  
 The SEPL (Swiss Ephemeris License) is published by AstroDienst; either 
 version 0.2 of the License, or (at your option) any later version is   
 effective.                                                             
 This program is distributed in the hope that it will be useful, but	  
 WITHOUT ANY WARRANTY; without even the implied warranty of	          
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU 	  
 General Public License for more details.                               
                                                                        
 You should have received a copy of the GPL along with this program; 	  
 if not, download a copy from http://www.gnu.org/copyleft/gpl.html      
 You also should have received a copy of the SEPL along with this program; 
 if not, download a copy from http://www.astro.com/swisseph/sepl.htm                                 
 ***************************************************************************/

using System;
using System.Runtime.InteropServices;
using UnityEngine; // Set to using if using Debug.Log() to the Unity Console
using SwissEphNet;

namespace animamundi {
	/**
	* All of the API commands that interface with the Swiss Ephemeris 
	*/

	public class astro {
//		SwissEph swe = new SwissEph();
		// 2. swe_calc_ut()
		// Calculate the positions of the planets
//		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_calc_ut")]
//		private extern static long extern_swe_calc_ut(double jdnr, int ipl, int iflag, double[] xx, String serr);
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
		// Ecliptic position returns Longitude, Latitude, Distance in AU, 
		// Speed in longitude (deg/day), Speed in latitude (deg/day), Speed in distance (AU/day)
		public static double getLongitude(int ipl, double jdnr) {
			Debug.Log("TEST01");
			SwissEph swe = new SwissEph();
			Debug.Log("TEST02");
			double[] xx = new double[6];

			string serr = "";
			int iflag = Constants.SEFLG_SPEED; // Calculate speed
			//			int iflag = 0;
			swe.swe_calc_ut(jdnr, ipl, iflag, xx, ref serr);
			return xx[0];
		}

		// Rectangular coordinates returns x, y, z, dx, dy, dz in AU.
		public static double[] getPlanetXYZ(int ipl, double jdnr) {
			SwissEph swe = new SwissEph();
			double[] xx = new double[6];
			String serr = "";
			int iflag = Constants.SEFLG_SWIEPH | Constants.SEFLG_SPEED | Constants.SEFLG_XYZ; // Calculate speed
			//int iflag = Constants.SEFLG_XYZ;
			swe.swe_calc_ut(jdnr, ipl, iflag, xx, ref serr);
			return xx;
		}

		// Equatorial position returns Rectascension, Declination, Distance in AU, 
		// Speed in rectascension (deg/day), Speed in declination (deg/day), Speed in distance (AU/day)
//		public static double[] getPlanetEquatorial(int ipl, double jdnr) {
//			double[] xx = new double[3];
//			String serr = "";
//			// int iflag = Constants.SEFLG_SWIEPH | Constants.SEFLG_SPEED | Constants.SEFLG_EQUATORIAL; // Calculate speed
//			int iflag = Constants.SEFLG_EQUATORIAL;
//			SwissEph.swe_calc_ut(jdnr, ipl, iflag, xx, serr);
//			return xx;
//		}

		// Equatorial position returns Rectascension, Declination, Distance in AU, 
		// Speed in rectascension (deg/day), Speed in declination (deg/day), Speed in distance (AU/day)
//		public static double[] getPlanetHeliocentric(int ipl, double jdnr) {
//			double[] xx = new double[3];
//			String serr = "";
//			// int iflag = Constants.SEFLG_SWIEPH | Constants.SEFLG_SPEED | Constants.SEFLG_HELCTR; // Calculate speed
//			int iflag = Constants.SEFLG_HELCTR;
//			SwissEph.swe_calc_ut(jdnr, ipl, iflag, xx, serr);
//			return xx;
//		}

		// 2. swe_calc()
		/// TODO: Find a use case for using the ephemeris time rather than UT. 
		// Otherwise leave commented out.
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_calc")]
		private extern static long extern_swe_calc(double tjd_et, int index, int y, double[] x, String serr);
		*/
		/**
 		* Computes positions of planets, asteroids, lunar nodes and apogees.
 		* 
 		* @param tjd_et
 		* 	Julian day, Ephemeris time, where tjd_et = tjd_ut + swe_deltat(tjd_ut)
		* @param ipl
 		* 	Body number
 		* @param iflag
 		* 	A 32-bit integer containing bit flags that indicate what kind of computation is wanted
 		* @param xx
 		* 	array of 6 doubles for longitude, latitude, distance, speed in long, speed in lat, and speed in distance
 		* @param serr
 		* 	character string to return error messages in case of error
		*/
		/*
		public static double[] swe_calc(int ipl, double tjd_et) {
			// Copied from the getPlanet() function
			double[] xx2 = new double[8];
			double[] xx = new double[6];
			String serr = "";
			int iflag = Constants.SEFLG_SPEED;
			extern_swe_calc_ut(tjd_et, ipl, iflag, xx, serr);
			for (int i = 0; i < 6; i++) { 
				xx2[i] = xx[i]; 
			}
			iflag = Constants.SEFLG_SWIEPH | Constants.SEFLG_SPEED | Constants.SEFLG_EQUATORIAL;
			extern_swe_calc_ut(tjd_et, ipl, iflag, xx, serr);
			xx2[6] = xx[0];
			xx2[7] = xx[1];
			
			return xx2;
		}
		*/
		
		// 3. Find a planetary or asteroid name -- swe_get_planet_name()
		/// TODO: Fix this from crashing out. 
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_get_planet_name")]
		private extern static char extern_swe_get_planet_name(int ipl, char spname);
		
		public static char swe_get_planet_name(int ipl, char spname) {
			extern_swe_get_planet_name(ipl, spname);
			return spname;
		}
		*/

		// 4. Fixed stars functions
		// 4.1 swe_fixstar_ut()
		/// TODO: Fix this from crashing out.
		/// Function has asteriks in it, but they throw an error
		/// swe_fixstar_ut(char* star, double tjd_ut, long iflag, double* xx, char* serr)
		/// ERROR: Pointers and fixed size buffers may only be used in an unsafe context
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_fixstar_ut")]
		private extern static long extern_swe_fixstar_ut(char[] star, double tjd_ut, long iflag, 
															 double[] xx, char[] serr);
		*/
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
		/*
		public static long swe_fixstar_ut(char[] star, double tjd_ut, long iflag, double[] xx, char[] serr) {
			return extern_swe_fixstar_ut(star, tjd_ut, iflag, xx, serr);
		}
		*/

		// 4.2 swe_fixstar()
		/// TODO: Stop swe_fixstar_ut() from crashing before implementing this function
		/*
 		* If a star is found, its name is returned in this field in the following format: 
 		* traditional_name, nomenclature_name (e.g. "Aldebaran,alTau").
 		*
 		* @param star
 		* 	The name of the fixed star to be searched, returned name of found star
 		* @param tjd_et
 		* 	Julian day, Ephemeris time, where tjd_et = tjd_ut + swe_deltat(tjd_ut)
 		* @param iflag
 		* 	A 32-bit integer containing bit flags that indicate what kind of computation is wanted
 		* @param xx
 		* 	array of 6 doubles for longitude, latitude, distance, speed in long, speed in lat, and speed in distance
 		* @param serr
 		* 	character string to return error messages in case of error
		*/
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_fixstar")]
		private extern static double[] extern_swe_fixstar(char star, double tjd_et, long iflag, double[] xyz, char serr);
		public static double[] swe_fixstar(char star, double tjd_et, long iflag, double[] x, char serr) {
			return extern_swe_fixstar(star, tjd_et, iflag, x, serr);
		}
		*/

		// 4.3 swe_fixstar_mag()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_fixstar_mag")]
		private extern static long extern_swe_fixstar_mag(char star, double mag, char serr);
		*/
		/*
 		* Calculates the magnitude of a fixed star
 		*
 		* @param star
 		* 	The name of the fixed star to be searched, returned name of found star
 		* @param mag	
 		* 	array of 6 doubles for longitude, latitude, distance, speed in long, speed in lat, and speed in distance
 		* @param serr
 		* 	character string to return error messages in case of error
		*/
		/*
		public static long swe_fixstar_mag(char star, double mag, char serr) {
			return extern_swe_fixstar_mag (star, mag, serr);
		}
		*/
			
		// 5. Apsides functions
		// 5.1 swe_nod_aps_ut()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_nod_aps_ut")]
		private extern static
		public static {
			return extern_swe_nod_aps_ut
		}
		*/

		// 5.2 swe_nod_aps()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_nod_aps")]
		private extern static
		public static {
			return extern_swe_nod_aps
		}
		*/

		// 6. Eclipse and planetary phenomena functions
		// 6.1. swe_sol_eclipse_when_loc() and swe_lun_occult_when_loc()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.1. swe_sol_eclipse_when_loc() and swe_lun_occult_when_loc()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.2. swe_sol_eclipse_when_glob()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.3. swe_sol_eclipse_how()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.4. swe_sol_eclipse_where()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.5. swe_lun_occult_when_loc()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.6. swe_lun_occult_when_glob()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.7. swe_lun_occult_where()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.8. swe_lun_eclipse_when()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.9. swe_lun_eclipse_how()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.10. swe_rise_trans() and swe_rise_trans_true_hor() (risings, settings, meridian transits)
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.10. swe_rise_trans() and swe_rise_trans_true_hor() (risings, settings, meridian transits)
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.11. swe_pheno_ut() and swe_pheno(), planetary phenomena 
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.11. swe_pheno_ut() and swe_pheno(), planetary phenomena
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.12. swe_azalt(), horizontal coordinates, azimuth, altitude
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.13. swe_azalt_rev()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.14. swe_refrac(), swe_refract_extended(), refraction
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.14. swe_refrac(), swe_refract_extended(), refraction
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.15. Heliacal risings etc.: swe_heliacal_ut()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 6.16. Magnitude limit for visibility: swe_vis_limit_mag()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 7. Date and time conversion functions
		// 7.1 Calendar Date and Julian Day: swe_julday(), swe_date_conversion(), swe_revjul()
		//[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_julday")]
//		private extern static double extern_swe_julday(int year, int month, int day, double hour, int gregflag);
		/**
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
//		public static double swe_julday(int year, int month, int day, double hour, int cal) {
//			return extern_swe_julday(year, month, day, hour, cal);
//		}

		// 7.1 Calendar Date and Julian Day: swe_julday(), swe_date_conversion(), swe_revjul()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/
		
		// 7.1 Calendar Date and Julian Day: swe_julday(), swe_date_conversion(), swe_revjul()
		//[DllImport("swedll32", CharSet = CharSet.Ansi, EntryPoint = "swe_revjul")]
//		private extern static double extern_swe_revjul(double tjd, int gregflag, ref int year, ref int month, ref int day, ref double hour);
//		
//		private static double swe_revjul(double tjd, int gregflag, ref int year, ref int month, ref int day, ref double hour) {
//			return extern_swe_revjul(tjd, gregflag, ref year, ref month, ref day, ref hour);
//		}
		/// <summary>
		/// Returns the daynumber for a given Julian day number
		/// </summary>
		/// <param name="jdnr">The Julian Day</param>
		/// <param name="cal">Calendar used</param>
		/// <returns>The day number</returns>
//		public static int getDayFromJd(double jdnr, int cal) {
//			int day = 0, month = 0, year = 0;
//			double hour = 0;
//			swe_revjul(jdnr, cal, ref year, ref month, ref day, ref hour);
//			return day;
//		}

		// 7.2. UTC and Julian day: swe_utc_time_zone(), swe_utc_to_jd(), swe_jdet_to_utc(), swe_jdut1_to_utc()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 7.2. UTC and Julian day: swe_utc_time_zone(), swe_utc_to_jd(), swe_jdet_to_utc(), swe_jdut1_to_utc()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 7.2. UTC and Julian day: swe_utc_time_zone(), swe_utc_to_jd(), swe_jdet_to_utc(), swe_jdut1_to_utc()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 7.2. UTC and Julian day: swe_utc_time_zone(), swe_utc_to_jd(), swe_jdet_to_utc(), swe_jdut1_to_utc()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 7.4. Mean solar time versus True solar time: swe_time_equ()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 8. Delta T-related functions
		// 8.1 swe_deltat()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 8.2 swe_set_tid_acc(), swe_get_tid_acc()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 8.2 swe_set_tid_acc(), swe_get_tid_acc()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 9. The function swe_set_topo() for topocentric planet positions
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 10. Sidereal mode functions
		// 10.1. swe_set_sid_mode()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 10.2. swe_get_ayanamsa_ut() and swe_get_ayanamsa()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 10.2. swe_get_ayanamsa_ut() and swe_get_ayanamsa()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 11. The Ephemeris file related functions
		// 11.1 swe_set_ephe_path()
		//[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_set_ephe_path")]
//		private extern static void extern_swe_set_ephe_path(String path);
		/**
 		* Sets the path for ephemeris files.
 		*
 		* @param path 
 		*   The argument can be a single directory name or a list of directories, which are then 
 		*   searched in sequence. The argument of this call is ignored if the environment variable 
 		*   SE_EPHE_Path exists and is not empty.
    	*/
//		public static void swe_set_ephe_path(String path) {
//			extern_swe_set_ephe_path(path);
//		}

		// 11.2 swe_close()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 11.3 swe_set_jpl_file()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 11.4 swe_version()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 12. House cusp calculation
		// 12.1 swe_houses()
		//[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "swe_houses")]
//		private extern static int extern_swe_houses(double jdnr, double lat, double lon, int system, 
//		                                         double[] xx, double[] yy);
		/// <summary>
		/// Calculate houses
		/// </summary>
		/// <param name="jdnr">Julian day number</param>
		/// <param name="lat">Geographical latitude</param>
		/// <param name="lon">Geographical longitude</param>
		/// <param name="system">Index to define housesystem</param>
		/// <returns>Array of doubles with with the following values:
		///  0: not used, 1..12 cusps 1..12, 13: asc., 14: MC, 15: ARMC, 16: Vertex,
		///  17: Equatorial asc., 18: co-ascendant (Koch), 19: co-ascendant(Munkasey),
		///  20: polar ascendant 
		///</returns>
//		public static double[] getHouses(double jdnr, double lat, double lon, char system) {
//			double[] xx = new double[13];
//			double[] yy = new double[10];
//			double[] zz = new double[23];
//			extern_swe_houses(jdnr, lat, lon, (int)(system), xx, yy);
//			
//			for (int i = 0; i < 13; i++) {
//				zz[i] = xx[i];
//			}
//			for (int i = 0; i < 10; i++) {
//				zz[i + 13] = yy[i];
//			}
//			return zz;
//		}

		// 12.2 swe_houses_armc()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 12.3 swe_houses_ex()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 12.4 swe_house_name()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 14 Getting the house position of a planet with swe_house_pos()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 14.1 swe_gauquelin_sector()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 15. Sidereal time with swe_sidtime() and swe_sidtime0()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/
		// 15. Sidereal time with swe_sidtime() and swe_sidtime0()

		// 16.6. Auxiliary functions
		// Coordinate transformation, from ecliptic to equator or vice-versa -- swe_cotrans
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 16.6 Coordinate transformation of position and speed, from ecliptic to equator or vice-versa swe_cotrans_sp
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 16.6 Get the name of a planet swe_get_planet_name()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

		// 16.6 Normalization of any degree number from 0 to 360 swe_degnorm()
		/*
		[DllImport("swedll32.dll", CharSet = CharSet.Ansi, EntryPoint = "")]
		private extern static
		public static {
			return extern_
		}
		*/

	}
}
