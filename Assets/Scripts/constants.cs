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

namespace animamundi {
	/// TODO: Look up all of the other constants via the Swiss Ephemeris documentation
	/**
	* Constants for the Swiss Ephemeris 
	*
	*/
	public static class Constants {
		/* values for gregflag in swe_julday() and swe_revjul() */
		public const int SE_JUL_CAL = 0;					// Julian calendar
		public const int SE_GREG_CAL = 1;					// Gregorian Calendar

		/*
 		* planet numbers for the ipl parameter in swe_calc()
 		*/
		public const int SE_ECL_NUT = -1;					// Special body number to compute obliquity and nutation.
		public const int SE_SUN = 0;						// Index for Sun
		public const int SE_MOON = 1;						// Index for Moon
		public const int SE_MERCURY = 2;					// Index for Mercury
		public const int SE_VENUS = 3;						// Index for Venus
		public const int SE_MARS = 4;						// Index for Mars
		public const int SE_JUPITER = 5;					// Index for Jupiter
		public const int SE_SATURN = 6;						// Index for Saturn
		public const int SE_URANUS = 7;						// Index for Uranus
		public const int SE_NEPTUNE = 8;					// Index for Neptune
		public const int SE_PLUTO = 9;						// Index for Pluto
		public const int SE_MEAN_NODE = 10;					// Index for standard node (mean)
		public const int SE_TRUE_NODE = 11;					// Index for oscillating node (true)
		public const int SE_MEAN_APOG = 12;      
		public const int SE_OSCU_APOG = 13;    
		public const int SE_EARTH = 14;      
		public const int SE_CHIRON = 15;					// Index for Chiron
		public const int SE_PHOLUS = 16;      
		public const int SE_CERES = 17;      
		public const int SE_PALLAS = 18;      
		public const int SE_JUNO = 19;     
		public const int SE_VESTA = 20;      
		public const int SE_INTP_APOG = 21;      
		public const int SE_INTP_PERG = 22;    
		public const int SE_NPLANETS = 23;      				
		public const int SE_AST_OFFSET = 10000;
		public const int SE_VARUNA = (SE_AST_OFFSET + 20000);
		public const int SE_FICT_OFFSET = 40;
		public const int SE_FICT_OFFSET_1 = 39;
		public const int SE_FICT_MAX = 999; 
		public const int SE_NFICT_ELEM = 15;
		public const int SE_COMET_OFFSET = 1000;
		public const int SE_NALL_NAT_POINTS = (SE_NPLANETS + SE_NFICT_ELEM);
				
		/* Hamburger or Uranian "planets" */
		public const int SE_CUPIDO = 40;
		public const int SE_HADES = 41;
		public const int SE_ZEUS = 42;
		public const int SE_KRONOS = 43;
		public const int SE_APOLLON = 44;
		public const int SE_ADMETOS = 45;
		public const int SE_VULKANUS = 46;
		public const int SE_POSEIDON = 47;

		/* other fictitious bodies */
		public const int SE_ISIS = 48;
		public const int SE_NIBIRU = 49;
		public const int SE_HARRINGTON = 50;
		public const int SE_NEPTUNE_LEVERRIER = 51;
		public const int SE_NEPTUNE_ADAMS = 52;
		public const int SE_PLUTO_LOWELL = 53;
		public const int SE_PLUTO_PICKERING = 54;
		public const int SE_VULCAN = 55;
		public const int SE_WHITE_MOON = 56;
		public const int SE_PROSERPINA = 57;
		public const int SE_WALDEMATH = 58;
				
		public const int SE_FIXSTAR = -10;
				
		public const int SE_ASC = 0;
		public const int SE_MC = 1;
		public const int SE_ARMC = 2;
		public const int SE_VERTEX = 3;
		public const int SE_EQUASC = 4;							/* "equatorial ascendant" */
		public const int SE_COASC1 = 5;							/* "co-ascendant" (W. Koch) */
		public const int SE_COASC2 = 6;							/* "co-ascendant" (M. Munkasey) */
		public const int SE_POLASC = 7;							/* "polar ascendant" (M. Munkasey) */
		public const int SE_NASCMC = 8;
				
		/*
 		* flag bits for parameter iflag in function swe_calc()
 		* The flag bits are defined in such a way that iflag = 0 delivers what one
 		* usually wants:
 		*    - the default ephemeris (SWISS EPHEMERIS) is used,
 		*    - apparent geocentric positions referring to the true equinox of date
 		*      are returned.
 		* If not only coordinates, but also speed values are required, use 
 		* flag = SEFLG_SPEED.
 		*
 		* The 'L' behind the number indicates that 32-bit integers (Long) are used.
 		*/
		public const int SEFLG_JPLEPH = 1;       				/* use JPL ephemeris */
		public const int SEFLG_SWIEPH = 2;       				/* use SWISSEPH ephemeris */
		public const int SEFLG_MOSEPH = 4;        				/* use Moshier ephemeris */
				
		public const int SEFLG_HELCTR = 8;       				/* return heliocentric position */
		public const int SEFLG_TRUEPOS = 16;      				/* return true positions, not apparent */
		public const int SEFLG_J2000 = 32;      				/* no precession, i.e. give J2000 equinox */
		public const int SEFLG_NONUT = 64;      				/* no nutation, i.e. mean equinox of date */
		public const int SEFLG_SPEED3 = 128;      				/* speed from 3 positions (do not use it,
                                  				 				SEFLG_SPEED is faster and more precise.) */
		public const int SEFLG_SPEED = 256;      				/* high precision speed  */
		public const int SEFLG_NOGDEFL = 512;      				/* turn off gravitational deflection */
		public const int SEFLG_NOABERR = 1024;     				/* turn off 'annual' aberration of light */
		public const int SEFLG_EQUATORIAL = (2 * 1024);    		/* equatorial positions are wanted */
		public const int SEFLG_XYZ = (4 * 1024);     			/* cartesian, not polar, coordinates */
		public const int SEFLG_RADIANS = (8 * 1024);     		/* coordinates in radians, not degrees */
		public const int SEFLG_BARYCTR = (16 * 1024);   		/* barycentric positions */
		public const int SEFLG_TOPOCTR = (32 * 1024);   		/* topocentric positions */
		public const int SEFLG_SIDEREAL = (64 * 1024);   		/* sidereal positions */
		public const int SEFLG_ICRS = (128 * 1024);   			/* ICRS (DE406 reference frame) */
				
		public const int SE_SIDBITS = 256;
		/* for projection onto ecliptic of t0 */
		public const int SE_SIDBIT_ECL_T0 = 256;
		/* for projection onto solar system plane */
		public const int SE_SIDBIT_SSY_PLANE = 512;
				
		/* sidereal modes (ayanamsas) */
		public const int SE_SIDM_FAGAN_BRADLEY = 0;
		public const int SE_SIDM_LAHIRI = 1;
		public const int SE_SIDM_DELUCE = 2;
		public const int SE_SIDM_RAMAN = 3;
		public const int SE_SIDM_USHASHASHI = 4;
		public const int SE_SIDM_KRISHNAMURTI = 5;
		public const int SE_SIDM_DJWHAL_KHUL = 6;
		public const int SE_SIDM_YUKTESHWAR = 7;
		public const int SE_SIDM_JN_BHASIN = 8;
		public const int SE_SIDM_BABYL_KUGLER1 = 9;
		public const int SE_SIDM_BABYL_KUGLER2 = 10;
		public const int SE_SIDM_BABYL_KUGLER3 = 11;
		public const int SE_SIDM_BABYL_HUBER = 12;
		public const int SE_SIDM_BABYL_ETPSC = 13;
		public const int SE_SIDM_ALDEBARAN_15TAU = 14;
		public const int SE_SIDM_HIPPARCHOS = 15;
		public const int SE_SIDM_SASSANIAN = 16;
		public const int SE_SIDM_GALCENT_0SAG = 17;
		public const int SE_SIDM_J2000 = 18;
		public const int SE_SIDM_J1900 = 19;
		public const int SE_SIDM_B1950 = 20;
		public const int SE_SIDM_SURYASIDDHANTA = 21;
		public const int SE_SIDM_SURYASIDDHANTA_MSUN = 22;
		public const int SE_SIDM_ARYABHATA = 23;
		public const int SE_SIDM_ARYABHATA_MSUN = 24;
		public const int SE_SIDM_SS_REVATI = 25;
		public const int SE_SIDM_SS_CITRA = 26;
		public const int SE_SIDM_USER = 255;
		public const int SE_NSIDM_PREDEF = 27;
				
		/* used for swe_nod_aps(): */
		public const int SE_NODBIT_MEAN = 1;    				/* mean nodes/apsides */
		public const int SE_NODBIT_OSCU = 2;   					/* osculating nodes/apsides */
		public const int SE_NODBIT_OSCU_BAR = 4;   				/* same, but motion about solar system barycenter is considered */
		public const int SE_NODBIT_FOPOINT = 256;   			/* focal point of orbit instead of aphelion */
				
		/* default ephemeris used when no ephemeris flagbit is set */
		public const int SEFLG_DEFAULTEPH = SEFLG_SWIEPH;
				
		public const int SE_MAX_STNAME = 256;					/* maximum size of fixstar name;
                                         						* the parameter star in swe_fixstar
					 											* must allow twice this space for
				         										* the returned star name.
					 											*/
				
		/* defines for eclipse computations */
		public const int SE_ECL_CENTRAL = 1;
		public const int SE_ECL_NONCENTRAL = 2;
		public const int SE_ECL_TOTAL = 4;
		public const int SE_ECL_ANNULAR = 8;
		public const int SE_ECL_PARTIAL = 16;
		public const int SE_ECL_ANNULAR_TOTAL = 32;
		public const int SE_ECL_PENUMBRAL = 64;
		public const int SE_ECL_ALLTYPES_SOLAR = (SE_ECL_CENTRAL | SE_ECL_NONCENTRAL | SE_ECL_TOTAL | SE_ECL_ANNULAR | SE_ECL_PARTIAL | SE_ECL_ANNULAR_TOTAL);
		public const int SE_ECL_ALLTYPES_LUNAR = (SE_ECL_TOTAL | SE_ECL_PARTIAL | SE_ECL_PENUMBRAL);
		public const int SE_ECL_VISIBLE = 128;
		public const int SE_ECL_MAX_VISIBLE = 256;
		public const int SE_ECL_1ST_VISIBLE = 512;				/* begin of partial eclipse */
		public const int SE_ECL_PARTBEG_VISIBLE = 512;			/* begin of partial eclipse */
		public const int SE_ECL_2ND_VISIBLE = 1024;				/* begin of total eclipse */
		public const int SE_ECL_TOTBEG_VISIBLE = 1024;			/* begin of total eclipse */
		public const int SE_ECL_3RD_VISIBLE = 2048;    			/* end of total eclipse */
		public const int SE_ECL_TOTEND_VISIBLE = 2048;    		/* end of total eclipse */
		public const int SE_ECL_4TH_VISIBLE = 4096;    			/* end of partial eclipse */
		public const int SE_ECL_PARTEND_VISIBLE = 4096;    		/* end of partial eclipse */
		public const int SE_ECL_PENUMBBEG_VISIBLE = 8192;    	/* begin of penumbral eclipse */
		public const int SE_ECL_PENUMBEND_VISIBLE = 16384;   	/* end of penumbral eclipse */
		public const int SE_ECL_ONE_TRY = (32 * 1024);

		/* check if the next conjunction of the moon with
		 * a planet is an occultation; don't search further */
		/* for swe_rise_transit() */
		public const int SE_CALC_RISE = 1;
		public const int SE_CALC_SET = 2;
		public const int SE_CALC_MTRANSIT = 4;
		public const int SE_CALC_ITRANSIT = 8;
		public const int SE_BIT_DISC_CENTER = 256; 				/* to be or'ed to SE_CALC_RISE/SET,
				     											* if rise or set of disc center is 
				     											* required */
		public const int SE_BIT_DISC_BOTTOM = 8192; 			/* to be or'ed to SE_CALC_RISE/SET,
                                      							* if rise or set of lower limb of 
				      											* disc is requried */
		public const int SE_BIT_NO_REFRACTION = 512; 			/* to be or'ed to SE_CALC_RISE/SET, 
				     											* if refraction is to be ignored */
		public const int SE_BIT_CIVIL_TWILIGHT = 1024; 			/* to be or'ed to SE_CALC_RISE/SET */
		public const int SE_BIT_NAUTIC_TWILIGHT = 2048; 		/* to be or'ed to SE_CALC_RISE/SET */
		public const int SE_BIT_ASTRO_TWILIGHT = 4096; 				/* to be or'ed to SE_CALC_RISE/SET */
		public const int SE_BIT_FIXED_DISC_SIZE = (16 * 1024); /* or'ed to SE_CALC_RISE/SET:
                                     							* neglect the effect of distance on
				     											* disc size */
				
		/* for swe_azalt() and swe_azalt_rev() */
		public const int SE_ECL2HOR = 0;
		public const int SE_EQU2HOR = 1;
		public const int SE_HOR2ECL = 0;
		public const int SE_HOR2EQU = 1;
				
		/* for swe_refrac() */
		public const int SE_TRUE_TO_APP = 0;
		public const int SE_APP_TO_TRUE = 1;

		public const int SE_ASC_AS_BODY = 200;				// Index for ascendant to be used during analysis
		public const int SE_MC_AS_BODY = 201;				// Index for MC to be used during analysis
		public const char C_HOUSES_PLACIDUS = 'P';			// Housesystem: Placidus
		public const char C_HOUSES_KOCH = 'K';				// Housesystem: Koch GOH
		public const char C_HOUSES_PORPHYRIUS = 'O';		// Housesystem: Porphyrius
		public const char C_HOUSES_REGIOMONTANUS = 'R';		// Housesystem: Regiomontanus
		public const char C_HOUSES_CAMPANUS = 'C';			// Housesystem: Campanus
		public const char C_HOUSES_EQUAL_ASC = 'A';			// Housesystem: Equal, starting with asc.
		public static char C_HOUSES_EQUAL_VEHLOW = 'V';		// Housesystem: Equal, asc centre of I (Vehlow)
		public static char C_HOUSES_AXIAL_ROTATION = 'X';	// Housesystem: Axial Rotation
		public static char C_HOUSES_HORIZONTAL = 'H';		// Housesystem: Azimuthal or horizontal system
		public static char C_HOUSES_TOPOCENTRIC = 'T';		// Housesystem: Topocentric (Polich and Page)
		public static char C_HOUSES_ALCABITIUS = 'B';		// Housesystem: Alcabitus
		public static char C_HOUSES_GAUQUELIN = 'G';		// Housesystem: Gauquelin sectors
		public static char C_HOUSES_MORINUS = 'M';			// Housesystem: Morinus
		public static char C_HOUSES_KRUSINSKI = 'U';		// Housesystem: Krusinski

		/*
		/// <summary>
		/// Configuration status: Configuration file read, ok, not changed 
		/// </summary>
		public const int RP_CONFIG_OK = 0;
		/// <summary>
		/// Configuration status: Configuration file contains errors, reset to default
		/// </summary>
		public const int RP_CONFIG_CORRECTED = 1;
		/// <summary>
		/// Configuration status: Configuration file not found, default recreated
		/// </summary>
		public const int RP_CONFIG_RENEWED = 2;
		/// <summary>
		/// Configuration status: Configuration changed by user
		/// </summary>
		public const int RP_CONFIG_ALTERED = 3;
		/// <summary>
		/// Configuration status: Configuration contains unresolved errors
		/// </summary>
		public const int RP_CONFIG_ERROR = -1;
		
		/// <summary>
		/// Maximum index for timezones
		/// </summary>
		public const int RP_MAX_TIMEZONES = 35;

		/// <summary>        
		/// Progression: an error occured
		/// </summary>
		public static int C_PROGSTATUS_ERROR = -1;
		/// <summary>
		/// Progression: started but not completed
		/// </summary>
		public static int C_PROGSTATUS_UNFINISHED = 0;
		/// <summary>
		/// Progression: calculated
		/// </summary>
		public static int C_PROGSTATUS_CALCULATED = 1;
		
		///// TODO check if following constants can be rempoed
		/// <summary>
		/// Radix: an error occured
		/// </summary>
		public static int C_RADIXSTATUS_ERROR = -1;
		/// <summary>
		/// Radix: started but not completed
		/// </summary>
		public static int C_RADIXSTATUS_UNFINISHED = 0;
		/// <summary>
		/// Radix: calculated but not saved
		/// </summary>
		public static int C_RADIXSTATUS_CALCULATED = 1;
		/// <summary>
		/// Radix: has been saved
		/// </summary>
		public static int C_RADIXSTATUS_SAVED = 2;
		/// <summary>
		/// Radix: changes that might differ from saved version
		/// </summary>
		public static int C_RADIXSTATUS_UNSAVEDCHANGES = 2;
		
		///// end TODO
		
		
		/// <summary>
		/// Status: initial, no data available
		/// </summary>
		public static int C_RP_STATUS_INIT = 0;
		
		/// <summary>
		/// Status: chart calculated but no events
		/// </summary>
		public static int C_RP_STATUS_POP = 1;
		
		/// <summary>
		/// Status: chart calculated, no unsaved changes
		/// </summary>
		public static int C_RP_STATUS_POP_NC = 2;
		
		/// <summary>
		/// Status: chart and event(s) calculated
		/// </summary>
		public static int C_RP_STATUS_EVENTS = 3;
		
		/// <summary>
		/// Status: chart and event(s) calculated and no unsaved changes
		/// </summary>
		public static int C_RP_STATUS_EVENTS_POP_NC = 4;
		
		
		/// <summary>
		/// Number of predefined timezones
		/// </summary>
		public static int C_RP_TOTAL_TIMEZONES = 35;
		
		/// <summary>
		/// Number of charttypes
		/// </summary>
		public static int C_RP_TOTAL_CHARTTYPES = 4;
		
		/// <summary>
		/// Number of sourcetypes
		/// </summary>
		public static int C_RP_TOTAL_SOURCETYPES = 7;
		
		/// <summary>
		/// Number of housesystems
		/// </summary>
		public static int C_RP_TOTAL_HOUSESYSTEMS = 14;

		
		// ******************** aspects *************************************** 
		
		
		/// <summary>
		/// Index for conjunction
		/// </summary>
		public const int C_RP_ASPECT_CONJUNCTION = 1;
		
		/// <summary>
		/// Index for opposition
		/// </summary>
		public const int C_RP_ASPECT_OPPOSITION = 2;
		
		/// <summary>
		/// Index for trine
		/// </summary>
		public const int C_RP_ASPECT_TRINE = 3;
		
		/// <summary>
		/// Index for square
		/// </summary>
		public const int C_RP_ASPECT_SQUARE = 4;
		
		/// <summary>
		/// Index for quintile
		/// </summary>
		public const int C_RP_ASPECT_QUINTILE = 5;
		
		/// <summary>
		/// Index for sextile
		/// </summary>
		public const int C_RP_ASPECT_SEXTILE = 6;
		
		/// <summary>
		/// Index for septile
		/// </summary>
		public const int C_RP_ASPECT_SEPTILE = 7;
		
		/// <summary>
		/// Index for semisquare
		/// </summary>
		public const int C_RP_ASPECT_SEMISQUARE = 8;
		
		/// <summary>
		/// Index for sesquiquadrate
		/// </summary>
		public const int C_RP_ASPECT_SESQUIQUADRATE = 9;
		
		/// <summary>
		/// Index for semisextile
		/// </summary>
		public const int C_RP_ASPECT_SEMISEXTILE = 10;
		
		/// <summary>
		/// Index for inconjunct
		/// </summary>
		public const int C_RP_ASPECT_INCONJUNCT = 11;
		
		/// <summary>
		/// Index for biquintile
		/// </summary>
		public const int C_RP_ASPECT_BIQUINTILE = 12;
		*/

	}		
}
