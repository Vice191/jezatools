#region

using System;
using System.Text.RegularExpressions;
using log4net;

#endregion

namespace Library
{
	public class Parser
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof (Parser));

		private const string resourcesPattern =
			@"<area href=""build.php.id=([0-9]{1,3})"" coords=""([0-9]{1,3}.)*"" shape=""circle"" title=""((\w|\d|\s)*)"">";



		/// <summary>
		/// Parses values from login page.
		/// </summary>
		/// <param name="sd"><see cref="ServerData"/></param>
		/// <param name="pageSource">page source</param>
		/// 
		public void LoginData
			(ServerData sd,
			 string pageSource)
		{
			Regex regHiddenLoginValue = new Regex("<input type=\"hidden\" name=\"login\" value=\"(.*)\">");
			if (regHiddenLoginValue.IsMatch(pageSource))
			{
				Match Mc = regHiddenLoginValue.Matches(pageSource)[0];
				sd.HiddenLoginValue = Mc.Groups[1].Value;
			}

			Regex regLoginName = new Regex("<input class=\"fm fm110\" type=\"text\" name=\"(.*)\" value=");
			if (regLoginName.IsMatch(pageSource))
			{
				Match Mc = regLoginName.Matches(pageSource)[0];
				sd.TextboxLoginName = Mc.Groups[1].Value;
			}

			Regex regPasswordName = new Regex("<input class=\"fm fm110\" type=\"password\" name=\"(.*)\" value=");
			if (regPasswordName.IsMatch(pageSource))
			{
				Match Mc = regPasswordName.Matches(pageSource)[0];
				sd.TextboxPasswordName = Mc.Groups[1].Value;
			}

			Regex regHiddenName = new Regex("<p align=\"center\"><input type=\"hidden\" name=\"(.*)\" value=\"(.*)\">");
			if (regHiddenName.IsMatch(pageSource))
			{
				Match Mc = regHiddenName.Matches(pageSource)[0];
				sd.HiddenName = Mc.Groups[1].Value;
				sd.HiddenValue = Mc.Groups[2].Value;
			}
		}



		/// <summary>
		/// Gets production of the village adn adds it to production list.
		/// </summary>
		/// <param name="sd"><see cref="ServerData"/></param>
		/// <param name="v"><see cref="Village"/></param>
		/// <param name="pageSource">Page source</param>
		/// 
		public void Production
			(ServerData sd,
			 Village v,
			 String pageSource)
		{
			/*
<table align="center" cellspacing="0" cellpadding="0"><tr valign="top">
<td><img class="res" src="img/un/r/1.gif" title="Les"></td>
<td id=l4 title=132>3766/7800</td>

<td class="s7"> <img class="res" src="img/un/r/2.gif" title="Glina"></td>
<td id=l3 title=127>3541/7800</td>
<td class="s7"> <img class="res" src="img/un/r/3.gif" title="�elezo"></td>
<td id=l2 title=121>4032/7800</td><td class="s7"> <img class="res" src="img/un/r/4.gif" title="�ito"></td>
<td id=l1 title=93>2095/2300</td>
<td class="s7"> &nbsp;<img class="res" src="img/un/r/5.gif" title="Poraba �ita">&nbsp;122/215</td></tr></table>
 */

			Production p = GetProductionForVillage(pageSource);
			p.VillageId = v.VillageId;
			p.VillageName = v.VillageName;
			sd.ProductionList.Add(p);
		}



		public static Production GetProductionForVillage(string pageSource)
		{
			Production p = new Production();
			//wood
			Regex wood = new Regex(@"id=l4 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (wood.IsMatch(pageSource))
			{
				Match Mc = wood.Matches(pageSource)[0];
				p.Wood = Int32.Parse(Mc.Groups[2].Value.Trim());
				p.WoodPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				p.WarehouseKapacity = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			//clay
			Regex clay = new Regex(@"id=l3 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (clay.IsMatch(pageSource))
			{
				Match Mc = clay.Matches(pageSource)[0];
				p.Clay = Int32.Parse(Mc.Groups[2].Value.Trim());
				p.ClayPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				p.WarehouseKapacity = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			//iron
			Regex iron = new Regex(@"id=l2 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (iron.IsMatch(pageSource))
			{
				Match Mc = iron.Matches(pageSource)[0];
				p.Iron = Int32.Parse(Mc.Groups[2].Value.Trim());
				p.IronPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				p.WarehouseKapacity = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			//crop
			Regex crop = new Regex(@"id=l1 title=(.*)>([0-9]{1,7})/([0-9]{1,7})<");
			if (crop.IsMatch(pageSource))
			{
				Match Mc = crop.Matches(pageSource)[0];
				p.Crop = Int32.Parse(Mc.Groups[2].Value.Trim());
				p.CropPerHour = Int32.Parse(Mc.Groups[1].Value.Trim());
				p.GranaryKapacity = Int32.Parse(Mc.Groups[3].Value.Trim());
			}
			return p;
		}



		/// <summary>
		/// Gets player UID
		/// </summary>
		/// <param name="sd"><see cref="ServerData"/></param>
		/// <param name="pageSource">Page source</param>
		/// 
		public void PlayerUid
			(ServerData sd,
			 String pageSource)
		{
			sd.PlayerUID = -1;
			Regex regPlayerID = new Regex(@"<a href=""spieler.php.uid=([0-9]{0,6})"">");
			if (regPlayerID.IsMatch(pageSource))
			{
				Match Mc = regPlayerID.Matches(pageSource)[0];
				sd.PlayerUID = Int32.Parse(Mc.Groups[1].Value.Trim());
			}
		}



		/// <summary>
		/// Gets village IDs and names
		/// </summary>
		/// <param name="sd"><see cref="ServerData"/></param>
		/// <param name="pageSource">Page source</param>
		/// 
		public void VillageIDs
			(ServerData sd,
			 String pageSource)
		{
			//<div class="dname"><h1>Muta01</h1></div> - one village!!! ?newdid=0
			MatchCollection myMatchCollection =
				Regex.Matches(pageSource, @"<a href="".newdid=(.*)\"">(.*)<.a>");
			int villageCount = myMatchCollection.Count;
			//Console.WriteLine("villageCount={0}", villageCount);
			for (int i = 0; i < villageCount; i++)
			{
				//102706" class="active_vl
				Village v = new Village();
				string regEx = myMatchCollection[i].Groups[1].Value;
				v.VillageId = Int32.Parse(tbLibrary.GetOnlyNumbers(regEx));
				v.VillageName = myMatchCollection[i].Groups[2].Value.Trim();
				sd.VillagesList.Add(v);
				//Console.WriteLine("Village={0}", v.ToString());
			}
			if (villageCount < 2)
			{
				const string regVillageName = @"<div class=""dname""><h1>(.*)</h1></div>";
				myMatchCollection =
					Regex.Matches(pageSource, regVillageName);
				Village v = new Village();
				v.VillageId = 0;
				v.VillageName = myMatchCollection[0].Groups[1].Value.Trim();
				sd.VillagesList.Add(v);
			}
		}



		/// <summary>
		/// Gets resource levels and list for village.
		/// </summary>
		/// <param name="sd"><see cref="ServerData"/></param>
		/// <param name="v"><see cref="Village"/></param>
		/// <param name="pageSource">Page source</param>
		/// 
		public void Resources
			(ServerData sd,
			 Village v,
			 String pageSource)
		{
			MatchCollection resourcesCollection =
				Regex.Matches(pageSource, resourcesPattern);
			for (int i = 0; i < resourcesCollection.Count; i++)
			{
				Resource r = GetResourcesForVillage(i, resourcesCollection);
				r.VillageId = v.VillageId;
				r.VillageName = v.VillageName;
				VillageData vd = new VillageData();
				vd.ResourcesForVillage.Add(r);
				sd.ResourcesList.Add(vd);
			}
		}



		public static Resource GetResourcesForVillage
			(int i,
			 MatchCollection resourcesCollection)
		{
			Resource r = new Resource();
			string name = resourcesCollection[i].Groups[3].Value.Trim();
			string[] nameLevel = name.Split(' ');
			int nameLevelLength = nameLevel.Length;
			r.ResourceFullName = name;
			r.ResourceId = Int32.Parse(resourcesCollection[i].Groups[1].Value.Trim());
			r.ResourceLevel = Int32.Parse(nameLevel[nameLevelLength - 1]);
			for (int n = 0; n < nameLevelLength - 2; n++)
			{
				r.ResourceName += nameLevel[n] + " ";
			}
			return r;
		}



		/// <summary>
		/// Gets buildings levels and list for village.
		/// </summary>
		/// <param name="sd"><see cref="ServerData"/></param>
		/// <param name="v"><see cref="Village"/></param>
		/// <param name="pageSource">Page source</param>
		/// 
		public void Buildings
			(ServerData sd,
			 Village v,
			 String pageSource)
		{
			//<area href="build.php?id=19" title="zazidljiva parcela" coords="53,91,91,71,127,91,91,112" shape="poly">
			const string reg =
				@"<area href=""build.php.id=([0-9]{1,3})"" title=""((\w|\d|\s)*)"" coords=""([0-9]{1,3}.)*"" shape=""poly"">";
			MatchCollection buildingsCollection = Regex.Matches(pageSource, reg);
			for (int i = 0; i < buildingsCollection.Count; i++)
			{
				Log.DebugFormat("Match_{1}:{0}", buildingsCollection[i].Groups[0].Value.Trim(), i);
				//Console.WriteLine("Match_{1}:{0}", buildingsCollection[i].Groups[0].Value.Trim(), i);
				//zazidljiva parcela
				string name = buildingsCollection[i].Groups[2].Value.Trim();
				Log.DebugFormat("BuildingFullName={0}", name);
				Building b = new Building();
				b.BuildingFullName = name;
				b.BuildingId = Int32.Parse(buildingsCollection[i].Groups[1].Value.Trim());
				if ((name.Equals(sd.EmptyLandName, StringComparison.InvariantCultureIgnoreCase)) ||
				    (name.Equals(sd.EmptyCityWall, StringComparison.InvariantCultureIgnoreCase)) ||
				    (name.Equals(sd.EmptyRallyPoint, StringComparison.InvariantCultureIgnoreCase))
					)
				{
					b.BuildingLevel = 0;
					b.BuildingName += name;
				}
				else
				{
					string[] nameLevel = name.Split(' ');
					int nameLevelLength = nameLevel.Length;
					b.BuildingLevel = Int32.Parse(nameLevel[nameLevelLength - 1]);
					for (int n = 0; n < nameLevelLength - 2; n++)
					{
						b.BuildingName += nameLevel[n] + " ";
					}
				}
				b.VillageId = v.VillageId;
				b.VillageName = v.VillageName;
				VillageData vd = new VillageData();
				vd.BuildingsForVillage.Add(b);
				sd.BuildingsList.Add(vd);
			}
		}



		public static int GetBuildingIdLevel(String pageSource)
		{
			Regex pageTitle = new Regex(@"<h1><b>(.*)<\/b><\/h1>");
			if (pageTitle.IsMatch(pageSource))
			{
				Match Mc = pageTitle.Matches(pageSource)[0];
				string titleName = Mc.Groups[1].Value.Trim();
				if (titleName.Equals("Postavi nov objekt", StringComparison.InvariantCultureIgnoreCase))
				{
					return -1;
				}
				String[] titleMatch = titleName.Split(' ');
				return Int32.Parse(titleMatch[titleMatch.Length - 1]);
			}
			return -1;
		}



		public void UpgradeLink
			(Upgrade u,
			 String pageSource)
		{
			u.UpgradeAvailable = false;
			Regex upgradeRegEx = new Regex(@"<a href=""(dorf[12].php\?(.*))"">((\w|\d|\s)*) [0-9]{1,3}<\/a>");
			if (upgradeRegEx.IsMatch(pageSource))
			{
				Match Mc = upgradeRegEx.Matches(pageSource)[0];
				u.UpgradeUrl = Mc.Groups[1].Value;
				u.UpgradeAvailable = true;
			}
			Regex pageTitle = new Regex(@"<h1><b>(.*)<\/b><\/h1>");
			if (pageTitle.IsMatch(pageSource))
			{
				Match Mc = pageTitle.Matches(pageSource)[0];
				u.UpgradeFullName = Mc.Groups[1].Value;
				if (!u.UpgradeFullName.Trim().Equals("Postavi nov objekt", StringComparison.InvariantCultureIgnoreCase))
				{
					String[] titleMatch = Mc.Groups[1].Value.Split(' ');
					u.UpgradeLevel = Int32.Parse(titleMatch[titleMatch.Length - 1]);
					for (int n = 0; n < titleMatch.Length - 2; n++)
					{
						u.UpgradeName += titleMatch[n] + " ";
					}
				}
				else
				{
					u.UpgradeName = u.UpgradeFullName;
					u.UpgradeLevel = 0;
				}
			}
		}



		/// <summary>
		/// Returns time until building is complete.
		/// </summary>
		/// <param name="pageSource">Page source</param>
		/// <returns>time when building is complete ni format h:MM:SS</returns>
		/// 
		public string TimeToCompleteBuilding(String pageSource)
		{
			string endTime = "0:00:00";
			MatchCollection buildTimeCollection =
				Regex.Matches(pageSource, @"<span id=timer[12]>([0-9]{0,3}.[0-9]{0,3}.[0-9]{0,3})<\/span>");
			for (int i = 0; i < buildTimeCollection.Count; i++)
			{
				endTime = buildTimeCollection[i].Groups[1].Value.Trim();
			}
			return endTime;
		}



		/// <summary>
		/// Returns building time.
		/// </summary>
		/// <param name="pageSource">Page source</param>
		/// <returns>time when building is complete ni format h:MM:SS</returns>
		/// 
		public string BuildTime(String pageSource)
		{
			string endTime = "0:00:00";
			Regex buildTime = new Regex(@"<img class=""clock"" src=""(.*)"" width=""[0-9]{0,3}"" height=""[0-9]{0,3}"">(.*)</td>");
			if (buildTime.IsMatch(pageSource))
			{
				Match Mc = buildTime.Matches(pageSource)[0];
				endTime = Mc.Groups[2].Value.Trim();
			}
			return endTime;
		}



		public BuildCost BuildCost(String pageSource)
		{
			BuildCost bc = NeededResources(pageSource);
			Production p = GetProductionForVillage(pageSource);
			bc.AvailableWood = p.Wood;
			bc.AvailableClay = p.Clay;
			bc.AvailableIron = p.Iron;
			bc.AvailableCrop = p.Crop;
			bc.WoodPerHour = p.WoodPerHour;
			bc.ClayPerHour = p.ClayPerHour;
			bc.IronPerHour = p.IronPerHour;
			bc.CropPerHour = p.CropPerHour;
			return bc;
		}



		private static BuildCost NeededResources(String pageSource)
		{
			//<img class="res" src="img/un/r/1.gif">6050
			BuildCost bc = new BuildCost();
			const string reg = @"class=""res"" src=""img\/un\/r\/[1234].gif"">([0-9]{0,6})";
			MatchCollection neededResourcesCollection = Regex.Matches(pageSource, reg);
			bc.NeededWood = Int32.Parse(neededResourcesCollection[0].Groups[1].Value.Trim());
			bc.NeededClay = Int32.Parse(neededResourcesCollection[1].Groups[1].Value.Trim());
			bc.NeededIron = Int32.Parse(neededResourcesCollection[2].Groups[1].Value.Trim());
			bc.NeededCrop = Int32.Parse(neededResourcesCollection[3].Groups[1].Value.Trim());
			return bc;
		}



		public static Upgrade GetLowestResource
			(string pageSource,
			 tbLibrary.ProductionForVillage production,
			 ServerData sd)
		{
			string landName = sd.CroplandName;
			switch (production)
			{
				case tbLibrary.ProductionForVillage.Wood:
				{
					landName = sd.WoodlandName;
					break;
				}
				case tbLibrary.ProductionForVillage.Clay:
				{
					landName = sd.ClaypitName;
					break;
				}
				case tbLibrary.ProductionForVillage.Iron:
				{
					landName = sd.IronmineName;
					break;
				}
				default:
				{
					break;
				}
			}

			int minLevelForUpgrade = 101;
			Upgrade upgrade = new Upgrade();
			MatchCollection resourcesCollection =
				Regex.Matches(pageSource,
				              resourcesPattern);
			for (int i = 0; i < resourcesCollection.Count; i++)
			{
				Resource r = GetResourcesForVillage(i, resourcesCollection);
				if (landName.Equals(r.ResourceName.Trim()))
				{
					if (minLevelForUpgrade > r.ResourceLevel)
					{
						minLevelForUpgrade = r.ResourceLevel;
						upgrade.UpgradeFullName = r.ResourceFullName;
						upgrade.UpgradeName = r.ResourceName.Trim();
						upgrade.UpgradeId = r.ResourceId;
					}
				}
			}
			return upgrade;
		}
	}
}