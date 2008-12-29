#region

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using mshtml;
using SHDocVw;

#endregion

namespace twL
{
	public class IO
	{
		public static bool LoadTasks
			(string tasksFile,
			 Events e,
			 InternetExplorer ie,
			 ServerInfo si)
		{
			bool taskListIsEmpty = (e.TaskList.Count == 0) ? true : false;
			if (File.Exists(tasksFile))
			{
				using (StreamReader sr = new StreamReader(tasksFile))
				{
					while (sr.Peek() >= 0)
					{
						String line = sr.ReadLine();
						if ((!line.StartsWith("#")) && (line.Length > 5))
						{
							//villageID|buildingID|wantedLevel|NextCheck|Comment
							String[] sections = line.Split('|');
							int villageId = Int32.Parse(sections[0]);
							int buildingId = Int32.Parse(sections[1]);
							int wantedLevel = Int32.Parse(sections[2]);
							string userComment = sections[4];
							//http://s4.travian.si/build.php?newdid=0&id=1
							string upgradeBuildingUrl = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}&id={2}",
							                                          si.UpgradeBuildingPage, villageId, buildingId);
							BuildTask buildTask = new BuildTask
							                      {
							                      	VillageId = villageId,
							                      	BuildingId = buildingId,
							                      	WantedBuildingLevel = wantedLevel,
							                      	NextCheck = Browser.NextCheck(upgradeBuildingUrl, ie),
							                      	BuildTaskComment = userComment,
							                      };
							String consoleOut = String.Format(CultureInfo.InvariantCulture,
							                                  "TaskUpdated: VillageId={0}, BuildingId={1}, BuildingLevel={2}, NextCheck={3}, BuildTaskComment={4}\r\n",
							                                  buildTask.VillageId, buildTask.BuildingId, buildTask.WantedBuildingLevel,
							                                  buildTask.NextCheck.ToString("yyyy-MM-dd HH:mm:ss"), buildTask.BuildTaskComment);
							Console.WriteLine(consoleOut);
							if (taskListIsEmpty)
							{
								e.TaskList.Add(buildTask);
							}
							else
							{
								foreach (var task in e.TaskList)
								{
									BuildTask bt = task as BuildTask;
									if (bt != null)
									{
										if ((bt.VillageId != villageId) && (bt.BuildingId != buildingId))
										{
											e.TaskList.Add(buildTask);
										}
										else
										{
											bt.WantedBuildingLevel = wantedLevel;
											bt.NextCheck = buildTask.NextCheck;
										}
									}
								}
							}
						}
					}
				}
				return true;
			}
			return false;
		}



		public static bool TrainTroops
			(ServerInfo si,
			 String fileTrainTroops,
			 InternetExplorer ie)
		{
			if (File.Exists(fileTrainTroops))
			{
				using (StreamReader sr = new StreamReader(fileTrainTroops))
				{
					while (sr.Peek() >= 0)
					{
						String line = sr.ReadLine();
						if ((!line.StartsWith("#")) && (line.Length > 1))
						{
							//villageId|buildingId|trooplist
							String[] sections = line.Split('|');
							String villageID = sections[0];
							String buildingId = sections[1];
							String troopList = sections[2];
							//http://s6.travian.si/build.php?newdid=73913&gid=19
							String url = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}&gid={2}", si.UpgradeBuildingPage,
							                           villageID, buildingId);
							Browser.GetPageSource(url, ie);
							String id = Browser.ValueFromTagTypeAndName(ie, "input", "hidden", "id");
							String z = Browser.ValueFromTagTypeAndName(ie, "input", "hidden", "z");
							String a = Browser.ValueFromTagTypeAndName(ie, "input", "hidden", "a");
							Random rnd = new Random();
							String attackID =
								String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19));
							String parPost =
								String.Format(CultureInfo.InvariantCulture,
								              "id={0}&z={1}&a={2}{3}{4}",
								              id,
								              z,
								              a,
								              troopList,
								              attackID);
							Console.WriteLine("TRAIN:" + parPost);
							object flags = null;
							object headers = "Content-Type: application/x-www-form-urlencoded\n\r";
							object name = null;
							object data = Encoding.UTF8.GetBytes(parPost);
							ie.Navigate(url, ref flags, ref name, ref data, ref headers);
							Browser.WaitForComplete(ie);
						}
					}
					sr.Close();
				}
				return true;
			}
			return false;
		}

	    public static bool Attack(ServerInfo si, InternetExplorer ie, Attacks attacks)
	    {
	        if (File.Exists(attacks.FileForFinishedAttacks))
	        {
	            String tempAttacks;
	            using (StreamReader sr = new StreamReader(attacks.FileForFinishedAttacks))
	            {
	                tempAttacks = sr.ReadToEnd();
	                sr.Close();
	            }

	            bool wasFarmFound = false;
	            DateTime now = new DateTime(DateTime.Now.Ticks);
	            using (StreamReader sr = new StreamReader(attacks.FileForAttacks))
	            {
	                while (sr.Peek() >= 0)
	                {
	                    String line = sr.ReadLine();
	                    if ((!line.StartsWith("#")) && (line.Length > 5))
	                    {
	                        //destX|destY|attackType|units|unitType|villageID|comment
	                        String[] sections = line.Split('|');
	                        Int32 destinationX = Int32.Parse(sections[0].Trim());
	                        Int32 destinationY = Int32.Parse(sections[1].Trim());
	                        String attackType = sections[2].Trim();
	                        String[] unitsList = sections[3].Trim().Split(',');
	                        Int32 unitType = Int32.Parse(sections[4].Trim());
	                        Int32 villageID = Int32.Parse(sections[5].Trim());
	                        Int32 unitsCount = Int32.Parse(unitsList[unitType]);
	                        String comment = sections[6];
	                        String tempCheckLine = sections[0] + "|" + sections[1] + "|" + sections[2] + "|" + sections[3];
	                        if (tempAttacks.IndexOf(tempCheckLine) > -1)
	                        {
	                            continue;
	                        }
	                        wasFarmFound = true;
	                        String attackUnit = attacks.TroopList.Split(',')[unitType];
	                        string resourcesUrl = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}",
	                                                            si.ResourcesPage, villageID);
	                        HTMLDocument pageSource = Browser.GetPageSource(resourcesUrl, ie);
	                        Int32 availableUnits = Browser.GetTroopCountForUnit(pageSource, attackUnit);
	                        if (availableUnits >= unitsCount)
	                        {
	                            Console.WriteLine("We Have " + availableUnits + " " + attackUnit);
	                            Random rnd = new Random();
	                            Int32 parA = rnd.Next(10001, 99999);
	                            StringBuilder troops = new StringBuilder();
	                            for (int t = 0; t < 11; t++)
	                            {
	                                troops.AppendFormat("&t{0}={1}", (t + 1), unitsList[t].Trim());
	                            }
	                            String buttonId =
	                                String.Format("&s1.x={0}&s1.y={1}&s1=ok", rnd.Next(0, 79), rnd.Next(0, 19));
	                            String parPost =
	                                String.Format(CultureInfo.InvariantCulture,
	                                              "id=39&a={0}&c={1}&kid={2}{3}{4}",
	                                              parA,
	                                              attackType.Trim(),
	                                              Misc.CovertXY(destinationX, destinationY),
	                                              troops,
	                                              buttonId
	                                    );
	                            Console.WriteLine("{3} Attack with {0} {1} to {2}", unitsCount, attackUnit, comment, now.ToString("yyyy-MM-dd HH:mm:ss"));
	                            object flags = null;
	                            object headers = "Content-Type: application/x-www-form-urlencoded\n\r";
	                            object name = null;
	                            object data = Encoding.UTF8.GetBytes(parPost);
	                            string sendUnitsUrl = String.Format(CultureInfo.InvariantCulture, "{0}?newdid={1}",
	                                                                si.SendUnitsPage, villageID);
	                            ie.Navigate(sendUnitsUrl, ref flags, ref name, ref data, ref headers);
	                            Browser.WaitForComplete(ie);

	                            using (StreamWriter sw = new StreamWriter(attacks.FileForFinishedAttacks, true))
	                            {
	                                sw.WriteLine(line);
	                                sw.Close();
	                                //Console.WriteLine(line);
	                            }
	                            Thread.Sleep(1000);
	                        }
	                    }
	                }
	                sr.Close();
	            }
	            //Clear temp file
	            if (!wasFarmFound)
	            {
	                using (StreamWriter sw = new StreamWriter(attacks.FileForFinishedAttacks, false))
	                {
	                    sw.WriteLine();
	                    sw.Close();
	                }
	            }
	            return true;
	        }
	        return false;
	    }
	}
}