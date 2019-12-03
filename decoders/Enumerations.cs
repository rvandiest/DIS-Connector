using System;
using System.Collections.Generic;

namespace DIS.Decoders
{
    public static class Enumerations
    {
        public static Dictionary<byte, string> Platforms = new Dictionary<byte, string>(){
            {0 ,"Other"},
            {1 ,"Platform"},
            {2 ,"Munition"},
            {3 ,"Life form"},
            {4 ,"Environmental"},
            {5 ,"Cultural feature"},
            {6 ,"Supply"},
            {7 ,"Radio"},
            {8 ,"Expendable"},
            {9 ,"Sensor/Emitter"}
        };
        public static Dictionary<byte, string> Domains = new Dictionary<byte, string>(){
            {0,"Other"},
            {1,"Land"},
            {2,"Air"},
            {3,"Surface"},
            {4,"Subsurface"},
            {5,"Space"},
        };
        public static Dictionary<Tuple<byte, byte, byte>, string> Categories = new Dictionary<Tuple<byte, byte, byte>, string>(){
            {new Tuple<byte,byte, byte>(0,0,0), "Other"},
            {new Tuple<byte,byte, byte>(1,1,0), "Other"},
            {new Tuple<byte,byte, byte>(1,1,1), "Tank"},
            {new Tuple<byte,byte, byte>(1,1,2), "Armored Fighting Vehicle"},
            {new Tuple<byte,byte, byte>(1,1,3), "Armored Utility Vehicle"},
            {new Tuple<byte,byte, byte>(1,1,4), "Self-propelled Artillery"},
            {new Tuple<byte,byte, byte>(1,1,5), "Towed Artillery"},
            {new Tuple<byte,byte, byte>(1,1,6), "Small Wheeled Utility Vehicle"},
            {new Tuple<byte,byte, byte>(1,1,7), "Large Wheeled Utility Vehicle"},
            {new Tuple<byte,byte, byte>(1,1,8), "Small Tracked Utility Vehicle"},
            {new Tuple<byte,byte, byte>(1,1,9), "Large Tracked Utility Vehicle"},
            {new Tuple<byte,byte, byte>(1,1,10), "Mortar"},
            {new Tuple<byte,byte, byte>(1,1,11), "Mine Plow"},
            {new Tuple<byte,byte, byte>(1,1,12), "Mine Rake"},
            {new Tuple<byte,byte, byte>(1,1,13), "Mine Roller"},
            {new Tuple<byte,byte, byte>(1,1,14), "Cargo Trailer"},
            {new Tuple<byte,byte, byte>(1,1,15), "Fuel Trailer"},
            {new Tuple<byte,byte, byte>(1,1,16), "Generator Trailer"},
            {new Tuple<byte,byte, byte>(1,1,17), "Water Trailer"},
            {new Tuple<byte,byte, byte>(1,1,18), "Engineer Equipment"},
            {new Tuple<byte,byte, byte>(1,1,19), "Heavy Equipment Transport Trailer"},
            {new Tuple<byte,byte, byte>(1,1,20), "Mabyteenance Equipment Trailer"},
            {new Tuple<byte,byte, byte>(1,1,21), "Limber"},
            {new Tuple<byte,byte, byte>(1,1,22), "Chemical Decontamination Trailer"},
            {new Tuple<byte,byte, byte>(1,1,23), "Warning System"},
            {new Tuple<byte,byte, byte>(1,1,24), "Train - Engine"},
            {new Tuple<byte,byte, byte>(1,1,25), "Train - Car"},
            {new Tuple<byte,byte, byte>(1,1,26), "Train - Caboose"},
            {new Tuple<byte,byte, byte>(1,1,27), "Civilian Vehicle (deprecated)14"},
            {new Tuple<byte,byte, byte>(1,1,28), "Air Defense / Missile Defense Unit Equipment"},
            {new Tuple<byte,byte, byte>(1,1,29), "Command, Control, Communications, and byteelligence (C3I) System"},
            {new Tuple<byte,byte, byte>(1,1,30), "Operations Facility"},
            {new Tuple<byte,byte, byte>(1,1,31), "byteelligence Facility"},
            {new Tuple<byte,byte, byte>(1,1,32), "Surveillance Facility"},
            {new Tuple<byte,byte, byte>(1,1,33), "Communications Facility"},
            {new Tuple<byte,byte, byte>(1,1,34), "Command Facility"},
            {new Tuple<byte,byte, byte>(1,1,35), "C4I Facility"},
            {new Tuple<byte,byte, byte>(1,1,36), "Control Facility"},
            {new Tuple<byte,byte, byte>(1,1,37), "Fire Control Facility"},
            {new Tuple<byte,byte, byte>(1,1,38), "Missile Defense Facility"},
            {new Tuple<byte,byte, byte>(1,1,39), "Field Command Post"},
            {new Tuple<byte,byte, byte>(1,1,40), "Observation Post"},
            {new Tuple<byte,byte, byte>(1,1,50), "Unmanned"},
            {new Tuple<byte,byte, byte>(1,1,80), "Motorcycle"},
            {new Tuple<byte,byte, byte>(1,1,81), "Car"},
            {new Tuple<byte,byte, byte>(1,1,82), "Bus"},
            {new Tuple<byte,byte, byte>(1,1,83), "Single Unit Cargo Truck"},
            {new Tuple<byte,byte, byte>(1,1,84), "Single Unit Utility/Emergency Truck"},
            {new Tuple<byte,byte, byte>(1,1,85), "Multiple Unit Cargo Truck"},
            {new Tuple<byte,byte, byte>(1,1,86), "Multiple Unit Utility/Emergency Truck"},
            {new Tuple<byte,byte, byte>(1,1,87), "Construction Specialty Vehicle"},
            {new Tuple<byte,byte, byte>(1,1,88), "Farm Specialty Vehicle"},
            {new Tuple<byte,byte, byte>(1,1,89), "Trailer"},
            {new Tuple<byte,byte, byte>(1,1,90), "Recreational [UID 437]"},
            {new Tuple<byte,byte, byte>(1,1,91), "Non-motorized [UID 438]"},
            {new Tuple<byte,byte, byte>(1,1,92), "Trains [UID 439]"},
            {new Tuple<byte,byte, byte>(1,1,93), "Utility/Emergency Car [UID 440]"},
            {new Tuple<byte,byte, byte>(1,2,0), "Other"},
            {new Tuple<byte,byte, byte>(1,2,1), "Fighter/Air Defense"},
            {new Tuple<byte,byte, byte>(1,2,2), "Attack/Strike"},
            {new Tuple<byte,byte, byte>(1,2,3), "Bomber"},
            {new Tuple<byte,byte, byte>(1,2,4), "Cargo/Tanker"},
            {new Tuple<byte,byte, byte>(1,2,5), "ASW/Patrol/Observation"},
            {new Tuple<byte,byte, byte>(1,2,6), "Electronic Warfare (EW)"},
            {new Tuple<byte,byte, byte>(1,2,7), "Reconnaissance"},
            {new Tuple<byte,byte, byte>(1,2,8), "Surveillance/C2 (Airborne Early Warning)"},
            {new Tuple<byte,byte, byte>(1,2,9), "Air-Sea Rescue (ASR)"},
            {new Tuple<byte,byte, byte>(1,2,20), "Attack Helicopter"},
            {new Tuple<byte,byte, byte>(1,2,21), "Utility Helicopter"},
            {new Tuple<byte,byte, byte>(1,2,22), "Anti-Submarine Warfare/Patrol Helicopter"},
            {new Tuple<byte,byte, byte>(1,2,23), "Cargo Helicopter"},
            {new Tuple<byte,byte, byte>(1,2,24), "Observation Helicopter"},
            {new Tuple<byte,byte, byte>(1,2,25), "Special Operations Helicopter"},
            {new Tuple<byte,byte, byte>(1,2,40), "Trainer"},
            {new Tuple<byte,byte, byte>(1,2,50), "Unmanned"},
            {new Tuple<byte,byte, byte>(1,2,57), "Non-Combatant Commercial Aircraft (deprecated)"},
            {new Tuple<byte,byte, byte>(1,2,80), "Civilian Ultralight Aircraft, Non-rigid Wing [UID 274]"},
            {new Tuple<byte,byte, byte>(1,2,81), "Civilian Ultralight Aircraft, Rigid Wing [UID 275]"},
            {new Tuple<byte,byte, byte>(1,2,83), "Civilian Fixed Wing Aircraft, Glider [UID 276]"},
            {new Tuple<byte,byte, byte>(1,2,84), "Civilian Fixed Wing Aircraft, Light Sport (up to 1320 lbs / 600 kg) [UID 277]"},
            {new Tuple<byte,byte, byte>(1,2,85), "Civilian Fixed Wing Aircraft, Small (up to 12,500 lbs / 5,670 kg) [UID 277]"},
            {new Tuple<byte,byte, byte>(1,2,86), "Civilian Fixed Wing Aircraft, Medium (up to 41,000 lbs / 18,597 kg) [UID 277]"},
            {new Tuple<byte,byte, byte>(1,2,87), "Civilian Fixed Wing Aircraft, Large (up to 255,000 lbs / 115,666 kg) [UID 277]"},
            {new Tuple<byte,byte, byte>(1,2,88), "Civilian Fixed Wing Aircraft, Heavy (above 255,000 lbs / 115,666 kg) [UID 277]"},
            {new Tuple<byte,byte, byte>(1,2,90), "Civilian Helicopter, Small (up to 7,000 lbs / 3,175 kg) [UID 278]"},
            {new Tuple<byte,byte, byte>(1,2,91), "Civilian Helicopter, Medium (up to 20,000 lbs / 9,072 kg) [UID 278]"},
            {new Tuple<byte,byte, byte>(1,2,92), "Civilian Helicopter, Large (above 20,000 lbs / 9,072 kg) [UID 278]"},
            {new Tuple<byte,byte, byte>(1,2,93), "Civilian Autogyro"},
            {new Tuple<byte,byte, byte>(1,2,100), "Civilian Lighter than Air, Balloon [UID 279]"},
            {new Tuple<byte,byte, byte>(1,2,101), "Civilian Lighter than Air, Airship [UID 280]"},
            {new Tuple<byte,byte, byte>(1,3,0), "Other"},
            {new Tuple<byte,byte, byte>(1,3,1), "Carrier"},
            {new Tuple<byte,byte, byte>(1,3,2), "Command Ship/Cruiser"},
            {new Tuple<byte,byte, byte>(1,3,3), "Guided Missile Cruiser"},
            {new Tuple<byte,byte, byte>(1,3,4), "Guided Missile Destroyer (DDG)"},
            {new Tuple<byte,byte, byte>(1,3,5), "Destroyer (DD)"},
            {new Tuple<byte,byte, byte>(1,3,6), "Guided Missile Frigate (FFG)"},
            {new Tuple<byte,byte, byte>(1,3,7), "Light/Patrol Craft"},
            {new Tuple<byte,byte, byte>(1,3,8), "Mine Countermeasure Ship/Craft"},
            {new Tuple<byte,byte, byte>(1,3,9), "Dock Landing Ship"},
            {new Tuple<byte,byte, byte>(1,3,10), "Tank Landing Ship"},
            {new Tuple<byte,byte, byte>(1,3,11), "Landing Craft"},
            {new Tuple<byte,byte, byte>(1,3,12), "Light Carrier"},
            {new Tuple<byte,byte, byte>(1,3,13), "Cruiser/Helicopter Carrier"},
            {new Tuple<byte,byte, byte>(1,3,14), "Hydrofoil"},
            {new Tuple<byte,byte, byte>(1,3,15), "Air Cushion/Surface Effect"},
            {new Tuple<byte,byte, byte>(1,3,16), "Auxiliary"},
            {new Tuple<byte,byte, byte>(1,3,17), "Auxiliary, Merchant Marine"},
            {new Tuple<byte,byte, byte>(1,3,18), "Utility"},
            {new Tuple<byte,byte, byte>(1,3,19), "Unmanned Surface Vehicle (USV)"},
            {new Tuple<byte,byte, byte>(1,3,20), "Littoral Combat Ships (LCS)"},
            {new Tuple<byte,byte, byte>(1,3,21), "Surveillance Ship"},
            {new Tuple<byte,byte, byte>(1,3,50), "Frigate (including Corvette)"},
            {new Tuple<byte,byte, byte>(1,3,51), "Battleship"},
            {new Tuple<byte,byte, byte>(1,3,52), "Heavy Cruiser"},
            {new Tuple<byte,byte, byte>(1,3,53), "Destroyer Tender"},
            {new Tuple<byte,byte, byte>(1,3,54), "Amphibious Assault Ship"},
            {new Tuple<byte,byte, byte>(1,3,55), "Amphibious Cargo Ship"},
            {new Tuple<byte,byte, byte>(1,3,56), "Amphibious Transport Dock"},
            {new Tuple<byte,byte, byte>(1,3,57), "Ammunition Ship"},
            {new Tuple<byte,byte, byte>(1,3,58), "Combat Stores Ship"},
            {new Tuple<byte,byte, byte>(1,3,59), "Surveillance Towed Array Sonar System (SURTASS)"},
            {new Tuple<byte,byte, byte>(1,3,60), "Fast Combat Support Ship"},
            {new Tuple<byte,byte, byte>(1,3,61), "Non-Combatant Ship (deprecated)"},
            {new Tuple<byte,byte, byte>(1,3,62), "Coast Guard Cutters"},
            {new Tuple<byte,byte, byte>(1,3,63), "Coast Guard Boats"},
            {new Tuple<byte,byte, byte>(1,3,64), "Fast Attack Craft"},
            {new Tuple<byte,byte, byte>(1,3,80), "Passenger Vessel (Group 1 Merchant) [UID 441]"},
            {new Tuple<byte,byte, byte>(1,3,81), "Dry Cargo Ship (Group 2 Merchant) [UID 442]"},
            {new Tuple<byte,byte, byte>(1,3,82), "Tanker (Group 3 Merchant) [UID 443]"},
            {new Tuple<byte,byte, byte>(1,3,83), "Support Vessel [UID 444]"},
            {new Tuple<byte,byte, byte>(1,3,84), "Private Motorboat [UID 445]"},
            {new Tuple<byte,byte, byte>(1,3,85), "Private Sailboat [UID 446]"},
            {new Tuple<byte,byte, byte>(1,3,86), "Fishing Vessel [UID 447]"},
            {new Tuple<byte,byte, byte>(1,3,87), "Other Vessels [UID 448]"},
            {new Tuple<byte,byte, byte>(1,3,100), "Search and Rescue Vessels"},
            {new Tuple<byte,byte, byte>(1,3,101), "Life-Saving Equipment [UID 633]"},
            {new Tuple<byte,byte, byte>(1,4,0), "Other"},
            {new Tuple<byte,byte, byte>(1,4,1), "SSBN (Nuclear Ballistic Missile)"},
            {new Tuple<byte,byte, byte>(1,4,2), "SSGN (Nuclear Guided Missile)"},
            {new Tuple<byte,byte, byte>(1,4,3), "SSN (Nuclear Attack - Torpedo)"},
            {new Tuple<byte,byte, byte>(1,4,4), "SSG (Conventional Guided Missile)"},
            {new Tuple<byte,byte, byte>(1,4,5), "SS (Conventional Attack - Torpedo, Patrol)"},
            {new Tuple<byte,byte, byte>(1,4,6), "SSAN (Nuclear Auxiliary)"},
            {new Tuple<byte,byte, byte>(1,4,7), "SSA (Conventional Auxiliary)"},
            {new Tuple<byte,byte, byte>(1,4,8), "Unmanned Underwater Vehicle (UUV)"},
            {new Tuple<byte,byte, byte>(1,4,9), "SSB (Submarine Ballistic, Ballistic Missile Submarine)"},
            {new Tuple<byte,byte, byte>(1,4,10), "SSC (Coastal Submarine, over 150 tons)"},
            {new Tuple<byte,byte, byte>(1,4,11), "SSP (Attack Submarine - Diesel Air-Independent Propulsion)"},
            {new Tuple<byte,byte, byte>(1,4,12), "SSM (Midget Submarine, under 150 tons)"},
            {new Tuple<byte,byte, byte>(1,4,13), "SSNR (Special Attack Submarine)"},
            {new Tuple<byte,byte, byte>(1,4,14), "SST (Training Submarine)"},
            {new Tuple<byte,byte, byte>(1,4,15), "AGSS (Auxiliary Submarine)"},
            {new Tuple<byte,byte, byte>(1,4,16), "Semi-Submersible Boats"},
            {new Tuple<byte,byte, byte>(1,4,80), "Civilian Submarines"},
            {new Tuple<byte,byte, byte>(1,4,81), "Civilian Submersibles"},
            {new Tuple<byte,byte, byte>(1,4,82), "Civilian Semi-Submersible Boats"},
            {new Tuple<byte,byte, byte>(1,5,0), "Other"},
            {new Tuple<byte,byte, byte>(1,5,1), "Manned"},
            {new Tuple<byte,byte, byte>(1,5,2), "Unmanned"},
            {new Tuple<byte,byte, byte>(1,5,3), "Booster"},
            {new Tuple<byte,byte,byte>(3,1,10), "Conventional Armed Forces64"},
            {new Tuple<byte,byte,byte>(3,1,11), "Army"},
            {new Tuple<byte,byte,byte>(3,1,12), "Naval Infantry (Marines)"},
            {new Tuple<byte,byte,byte>(3,1,13), "Air Force"},
            {new Tuple<byte,byte,byte>(3,1,14), "Navy"},
            {new Tuple<byte,byte,byte>(3,1,15), "Coast Guard"},
            {new Tuple<byte,byte,byte>(3,1,16), "United Nations"},
            {new Tuple<byte,byte,byte>(3,1,30), "Special Operations Forces (SOF)65"},
            {new Tuple<byte,byte,byte>(3,1,50), "Law Enforcement66"},
            {new Tuple<byte,byte,byte>(3,1,70), "Non-Military National Government Agencies67"},
            {new Tuple<byte,byte,byte>(3,1,90), "Regional / Local Forces68"},
            {new Tuple<byte,byte,byte>(3,1,100), "Irregular Forces69"},
            {new Tuple<byte,byte,byte>(3,1,101), "Terrorist Combatant"},
            {new Tuple<byte,byte,byte>(3,1,102), "Insurgent"},
            {new Tuple<byte,byte,byte>(3,1,110), "Paramilitary Forces70"},
            {new Tuple<byte,byte,byte>(3,1,120), "Humanitarian Organizations71"},
            {new Tuple<byte,byte,byte>(3,1,130), "Civilian72"},
            {new Tuple<byte,byte,byte>(3,1,131), "Emergency Medical Technician (EMT)"},
            {new Tuple<byte,byte,byte>(3,1,132), "Firefighter"},
            {new Tuple<byte,byte,byte>(3,1,200), "Mammal [UID 100]"},
            {new Tuple<byte,byte,byte>(3,1,201), "Reptile [UID 101]"},
            {new Tuple<byte,byte,byte>(3,1,202), "Amphibian [UID 102]"},
            {new Tuple<byte,byte,byte>(3,1,203), "Insect [UID 103]"},
            {new Tuple<byte,byte,byte>(3,1,204), "Arachnid [UID 104]"},
            {new Tuple<byte,byte,byte>(3,1,205), "Mollusk [UID 105]"},
            {new Tuple<byte,byte,byte>(3,1,206), "Marsupial [UID 106]"}
        };
        public static Dictionary<ushort, string> Countries = new Dictionary<ushort, string>(){
            {0, "Other"},
            {269, "Aaland Islands (ALA)"},
            {1, "Afghanistan (AFG)"},
            {2, "Albania (ALB)"},
            {3, "Algeria (DZA)"},
            {4, "American Samoa (ASM)"},
            {5, "Andorra (AND)"},
            {6, "Angola (AGO)"},
            {7, "Anguilla (AIA)"},
            {8, "Antarctica (ATA)"},
            {9, "Antigua and Barbuda (ATG)"},
            {10, "Argentina (ARG)"},
            {244, "Armenia (ARM)"},
            {11, "Aruba (ABW)"},
            {12, "Ashmore and Cartier Islands (Australia) (deprecated)162"},
            {13, "Australia (AUS)"},
            {14, "Austria (AUT)"},
            {245, "Azerbaijan (AZE)"},
            {15, "Bahamas (BHS)"},
            {16, "Bahrain (BHR)"},
            {17, "Baker Island (United States) (deprecated)163"},
            {18, "Bangladesh (BGD)"},
            {19, "Barbados (BRB)"},
            {20, "Bassas da India (France) (deprecated)164"},
            {246, "Belarus (BLR)"},
            {21, "Belgium (BEL)"},
            {22, "Belize (BLZ)"},
            {23, "Benin (BEN)"},
            {24, "Bermuda (BMU)"},
            {25, "Bhutan (BTN)"},
            {26, "Bolivia (Plurinational State of) (BOL)"},
            {270, "Bonaire, Sint Eustatius and Saba (BES)"},
            {247, "Bosnia and Herzegovina (BIH)"},
            {27, "Botswana (BWA)"},
            {28, "Bouvet Island (BVT)"},
            {29, "Brazil (BRA)"},
            {30, "British Indian Ocean Territory (IOT)"},
            {32, "Brunei Darussalam (BRN)"},
            {33, "Bulgaria (BGR)"},
            {34, "Burkina Faso (BFA)"},
            {36, "Burundi (BDI)"},
            {40, "Cabo Verde (CPV)"},
            {37, "Cambodia (KHM)"},
            {38, "Cameroon (CMR)"},
            {39, "Canada (CAN)"},
            {41, "Cayman Islands (CYM)"},
            {42, "Central African Republic (CAF)"},
            {43, "Chad (TCD)"},
            {44, "Chile (CHL)"},
            {45, "China, People's Republic of (CHN)"},
            {46, "Christmas Island (CXR)"},
            {248, "Clipperton Island (France) (deprecated)165"},
            {47, "Cocos (Keeling) Islands (CCK)"},
            {48, "Colombia (COL)"},
            {49, "Comoros (COM)"},
            {50, "Congo (COG)166"},
            {271, "Congo (Democratic Republic of the) (COD)167"},
            {51, "Cook Islands (COK)"},
            {52, "Coral Sea Islands (Australia) (deprecated)168"},
            {53, "Costa Rica (CRI)"},
            {107, "Cote d'Ivoire (CIV)"},
            {249, "Croatia (HRV)"},
            {54, "Cuba (CUB)"},
            {272, "Curacao (CUW)"},
            {55, "Cyprus (CYP)"},
            {267, "Czech Republic (CZE)"},
            {56, "Czechoslovakia (CSK) (deprecated)169"},
            {57, "Denmark (DNK)"},
            {58, "Djibouti (DJI)"},
            {59, "Dominica (DMA)"},
            {60, "Dominican Republic (DOM)"},
            {61, "Ecuador (ECU)"},
            {62, "Egypt (EGY)"},
            {63, "El Salvador (SLV)"},
            {64, "Equatorial Guinea (GNQ)"},
            {273, "Eritrea (ERI)"},
            {250, "Estonia (EST)"},
            {65, "Ethiopia (ETH)"},
            {66, "Europa Island (France) (deprecated)170"},
            {67, "Falkland Islands (Malvinas) (FLK)"},
            {68, "Faroe Islands (FRO)"},
            {69, "Fiji (FJI)"},
            {70, "Finland (FIN)"},
            {71, "France (FRA)"},
            {72, "French Guiana (GUF)"},
            {73, "French Polynesia (PYF)"},
            {74, "French Southern Territories (ATF)"},
            {75, "Gabon (GAB)"},
            {76, "Gambia, The (GMB)"},
            {77, "Gaza Strip (Israel) (deprecated)171"},
            {251, "Georgia (GEO)"},
            {78, "Germany (DEU)"},
            {79, "Ghana (GHA)"},
            {80, "Gibraltar (GIB)"},
            {81, "Glorioso Islands (France) (deprecated)172"},
            {82, "Greece (GRC)"},
            {83, "Greenland (GRL)"},
            {84, "Grenada (GRD)"},
            {85, "Guadeloupe (GLP)"},
            {86, "Guam (GUM)"},
            {87, "Guatemala (GTM)"},
            {88, "Guernsey (GGY)"},
            {89, "Guinea (GIN)"},
            {90, "Guinea-Bissau (GNB)"},
            {91, "Guyana (GUY)"},
            {92, "Haiti (HTI)"},
            {93, "Heard Island and McDonald Islands (HMD)"},
            {228, "Holy See (VAT)"},
            {94, "Honduras (HND)"},
            {95, "Hong Kong (HKG)"},
            {96, "Howland Island (United States) (deprecated)173"},
            {97, "Hungary (HUN)"},
            {98, "Iceland (ESL)"},
            {99, "India (IND)"},
            {100, "Indonesia (IDN)"},
            {101, "Iran (Islamic Republic of) (IRN)"},
            {102, "Iraq (IRQ)"},
            {104, "Ireland (IRL)"},
            {136, "Isle of Man (IMN)"},
            {105, "Israel (ISR)"},
            {106, "Italy (ITA)"},
            {108, "Jamaica (JAM)"},
            {109, "Jan Mayen (Norway) (deprecated)174"},
            {110, "Japan (JPN)"},
            {111, "Jarvis Island (United States) (deprecated)175"},
            {112, "Jersey (JEY)"},
            {113, "Johnston Atoll (United States) (deprecated)176"},
            {114, "Jordan (JOR)"},
            {115, "Juan de Nova Island (deprecated)177"},
            {252, "Kazakhstan (KAZ)"},
            {116, "Kenya (KEN)"},
            {117, "Kingman Reef (United States) (deprecated)178"},
            {118, "Kiribati (KIR)"},
            {119, "Korea (Democratic People's Republic of) (PRK)"},
            {120, "Korea (Republic of) (KOR)"},
            {121, "Kuwait (KWT)"},
            {253, "Kyrgyzstan (KGZ)"},
            {122, "Lao People's Democratic Republic (LAO)"},
            {254, "Latvia (LVA)"},
            {123, "Lebanon (LBN)"},
            {124, "Lesotho (LSO)"},
            {125, "Liberia (LBR)"},
            {126, "Libya (LBY)"},
            {127, "Liechtenstein (LIE)"},
            {255, "Lithuania (LTU)"},
            {128, "Luxembourg (LUX)"},
            {130, "Macao (MAC)"},
            {256, "Macedonia (The Former Yugoslav Republic of) (MKD)"},
            {129, "Madagascar (MDG)"},
            {131, "Malawi (MWI)"},
            {132, "Malaysia (MYS)"},
            {133, "Maldives (MDV)"},
            {134, "Mali (MLI)"},
            {135, "Malta (MLT)"},
            {137, "Marshall Islands (MHL)"},
            {138, "Martinique (MTQ)"},
            {139, "Mauritania (MRT)"},
            {140, "Mauritius (MUS)"},
            {141, "Mayotte (MYT)"},
            {142, "Mexico (MEX)"},
            {143, "Micronesia (Federated States of) (FSM)"},
            {257, "Midway Islands (United States) (deprecated)179"},
            {258, "Moldova (Republic of) (MDA)"},
            {144, "Monaco (MCO)"},
            {145, "Mongolia (MNG)"},
            {259, "Montenegro (MNE)"},
            {146, "Montserrat (MSR)"},
            {147, "Morocco (MAR)"},
            {148, "Mozambique (MOZ)"},
            {35, "Myanmar (MMR)"},
            {149, "Namibia (NAM)"},
            {150, "Nauru (NRO)"},
            {151, "Navassa Island (United States) (deprecated)180"},
            {152, "Nepal (NPL)"},
            {153, "Netherlands (NLD)"},
            {154, "Netherlands Antilles (Curacao, Bonaire, Saba, Sint Maarten Sint Eustatius) (deprecated)181"},
            {155, "New Caledonia (NCL)"},
            {156, "New Zealand (NZL)"},
            {157, "Nicaragua (NIC)"},
            {158, "Niger (NER)"},
            {159, "Nigeria (NGA)"},
            {160, "Niue (NIU)"},
            {161, "Norfolk Island (NFK)"},
            {162, "Northern Mariana Islands (MNP)"},
            {163, "Norway (NOR)"},
            {164, "Oman (OMN)"},
            {165, "Pakistan (PAK)"},
            {216, "Palau (PLW)"},
            {282, "Palestine, State of (PSE)"},
            {166, "Palmyra Atoll (United States) (deprecated)182"},
            {168, "Panama (PAN)"},
            {169, "Papua New Guinea (PNG)"},
            {170, "Paracel Islands (International - Occupied by China, also claimed by Taiwan and Vietnam) (deprecated)"},
            {171, "Paraguay (PRY)"},
            {172, "Peru (PER)"},
            {173, "Philippines (PHL)"},
            {174, "Pitcairn (PCN)"},
            {175, "Poland (POL)"},
            {176, "Portugal (PRT)"},
            {177, "Puerto Rico (PRI)"},
            {178, "Qatar (QAT)"},
            {179, "Reunion (REU)"},
            {180, "Romania (ROY)"},
            {260, "Russia (deprecated)183"},
            {222, "Russia (RUS)184"},
            {181, "Rwanda (RWA)"},
            {274, "Saint Barthelemy (BLM)"},
            {183, "Saint Helena, Ascension and Tristan da Cunha (SHN)"},
            {182, "Saint Kitts and Nevis (KNA)"},
            {184, "Saint Lucia (LCA)"},
            {275, "Saint Martin (French Part) (MAF)"},
            {185, "Saint Pierre and Miquelon (SPM)"},
            {186, "Saint Vincent and the Grenadines (VCT)"},
            {236, "Samoa (WSM)"},
            {187, "San Marino (SMR)"},
            {188, "Sao Tome and Principe (STP)"},
            {189, "Saudi Arabia (SAU)"},
            {190, "Senegal (SEN)"},
            {276, "Serbia (SRB)"},
            {240, "Serbia and Montenegro (deprecated)"},
            {261, "Serbia and Montenegro (Montenegro to separate) (deprecated)"},
            {191, "Seychelles (SYC)"},
            {192, "Sierra Leone (SLE)"},
            {193, "Singapore (SGP)"},
            {277, "Sint Maarten (Dutch part) (SXM)"},
            {268, "Slovakia (SVK)"},
            {262, "Slovenia (SVN)"},
            {194, "Solomon Islands (SLB)"},
            {195, "Somalia (SOM)"},
            {197, "South Africa (ZAF)"},
            {196, "South Georgia and the South Sandwich Islands (SGS)"},
            {278, "South Sudan (SSD)"},
            {198, "Spain (ESP)"},
            {199, "Spratly Islands (International - parts occupied and claimed by China,Malaysia, Philippines, Taiwan, Vietnam) (deprecated)"},
            {200, "Sri Lanka (LKA)"},
            {201, "Sudan (SDN)"},
            {202, "Suriname (SUR)"},
            {203, "Svalbard (Norway) (deprecated)185"},
            {279, "Svalbard and Jan Mayen (SJM)"},
            {204, "Swaziland (SWZ)"},
            {205, "Sweden (SWE)"},
            {206, "Switzerland (CHE)"},
            {207, "Syrian Arab Republic (SYR)"},
            {208, "Taiwan, Province of China (TWN)"},
            {263, "Tajikistan (TJK)"},
            {209, "Tanzania, United Republic of (TZA)"},
            {210, "Thailand (THA)"},
            {280, "Timor-Leste (TLS)"},
            {211, "Togo (TGO)"},
            {212, "Tokelau (TKL)"},
            {213, "Tonga (TON)"},
            {214, "Trinidad and Tobago (TTO)"},
            {215, "Tromelin Island (France) (deprecated)186"},
            {217, "Tunisia (TUN)"},
            {218, "Turkey (TUR)"},
            {264, "Turkmenistan (TKM)"},
            {219, "Turks and Caicos Islands (TCA)"},
            {220, "Tuvalu (TUV)"},
            {221, "Uganda (UGA)"},
            {265, "Ukraine (UKR)"},
            {223, "United Arab Emirates (ARE)"},
            {224, "United Kingdom of Great Britain and Northern Ireland (GBR)"},
            {281, "United States Minor Outlying Islands (UMI)"},
            {225, "United States of America (USA)"},
            {226, "Uruguay (URY)"},
            {266, "Uzbekistan (UZB)"},
            {227, "Vanuatu (VUT)"},
            {229, "Venezuela (Bolivarian Republic of) (VEN)"},
            {230, "Vietnam (VNM)"},
            {31, "Virgin Islands (British) (VGB)"},
            {231, "Virgin Islands (U.S.) (VIR)"},
            {232, "Wake Island (United States) (deprecated)187"},
            {233, "Wallis and Futuna (WLF)"},
            {235, "West Bank (Israel) (deprecated)188"},
            {234, "Western Sahara (ESH)"},
            {237, "Yemen (YEM)"},
            {241, "Zaire (deprecated)189"},
            {242, "Zambia (ZMB)"},
            {243, "Zimbabwe (ZWE)"},
        };
        public static string GetPlatform(byte index)
        {
            string value = null;
            Platforms.TryGetValue(index, out value);
            return value;
        }

        public static string GetDomain(byte index)
        {
            string value = null;
            Domains.TryGetValue(index, out value);
            return value;
        }

        public static string GetCategory(byte platformindex, byte domainindex, byte categoryindex)
        {
            string value = null;
            Categories.TryGetValue(new Tuple<byte, byte, byte>(platformindex, domainindex, categoryindex), out value);
            return value;
        }

        public static string GetCountry(ushort index){
            string value = null;
            Countries.TryGetValue(index, out value);
            return value;
        }
    }
}