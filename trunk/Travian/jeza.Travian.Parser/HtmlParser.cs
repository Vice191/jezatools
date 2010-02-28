﻿#region

using System;
using System.Collections.Generic;
using System.Globalization;
using HtmlAgilityPack;
using jeza.Travian.Framework;

#endregion

namespace jeza.Travian.Parser
{
    public class HtmlParser
    {
        public HtmlParser(HtmlDocument htmlDocument)
        {
            this.htmlDocument = htmlDocument;
        }

        /// <summary>
        /// Gets the village details.
        /// </summary>
        /// <returns><see cref="Neighborhood"/></returns>
        public Neighborhood GetVillageDetails()
        {
            Neighborhood neighborhood = new Neighborhood();
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//table[@id='village_info']");
            if (nodes != null)
            {
                HtmlNode head = nodes[0].SelectSingleNode("./thead/tr/th");
                HtmlNode nodeVillageName = head.SelectSingleNode("./div");
                string villageName = nodeVillageName.InnerText;
                HtmlNode nodeVillageCoords = head.SelectSingleNode(".");
                string coordinates = nodeVillageCoords.InnerText.Substring(nodeVillageCoords.InnerText.LastIndexOf('(')).Trim();
                string[] strings = coordinates.Split('|', '(', ')');
                int coordinateX = Misc.String2Number(strings[1]);
                int coordinateY = Misc.String2Number(strings[2]);
                HtmlNode alliance = nodes[0].SelectSingleNode("./tbody/tr[2]/td/a");
                string allianceUrl = alliance.Attributes["href"].Value;
                string allianceName = alliance.InnerText.Trim();
                HtmlNode player = nodes[0].SelectSingleNode("./tbody/tr[3]/td/a");
                string playerUrl = player.Attributes["href"].Value;
                string playerName = player.InnerText.Trim();
                HtmlNode population = nodes[0].SelectSingleNode("./tbody/tr[4]/td");
                int villagePopulation = Misc.String2Number(population.InnerText.Trim());
                neighborhood
                    .AddName(villageName)
                    .AddCoordinates(coordinateX, coordinateY)
                    .AddAlliance(allianceName, allianceUrl)
                    .AddPlayer(playerName, playerUrl)
                    .AddPopulation(villagePopulation);
            }
            return neighborhood;
        }

        /// <summary>
        /// Parse villages from map field.
        /// </summary>
        public List<Neighborhood> GetVillagesFromMap()
        {
            List<Neighborhood> neighborhood = new List<Neighborhood>();
            List<string> villages = new List<string>();
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//div[@id='map_content']");
            if (nodes != null)
            {
                foreach (HtmlNode mapContentNode in nodes)
                {
                    foreach (HtmlNode htmlNode in mapContentNode.SelectNodes(".//div[starts-with(@class, 'b')]"))
                    {
                        villages.Add("a" + htmlNode.Attributes["id"].Value.Substring(1));
                    }
                }
            }
            foreach (string list in villages)
            {
                //<area id="a_0_0" shape="poly" coords="53, 137, 90, 157, 53, 177, 16, 157" title="Nezasedena pokrajina" href="karte.php?d=273457&c=e4" />
                HtmlNodeCollection areaNode =
                    htmlDocument.DocumentNode.SelectNodes(String.Format(CultureInfo.InvariantCulture,
                                                                        "//area[@id='{0}']", list));
                Neighborhood village = new Neighborhood();
                village.AddName(areaNode[0].Attributes["title"].Value).AddUrl(areaNode[0].Attributes["href"].Value);
                neighborhood.Add(village);
            }
            return neighborhood;
        }

        /// <summary>
        /// Gets troop movements from rally point.
        /// </summary>
        /// <returns><see cref="List{T}"/></returns>
        public List<TroopMovement> TroopMovements()
        {
            List<TroopMovement> troopMovement = new List<TroopMovement>();
            DateTime dt = new DateTime(DateTime.Now.Ticks);
            HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//table[@class='troop_details']");
            if (nodes != null)
            {
                foreach (HtmlNode tableNode in nodes)
                {
                    TroopMovement movement = new TroopMovement();
                    //source and destination
                    //<thead><tr><td class="role"><a href="karte.php?d=271057&c=cf">02</a></td><td colspan="10"><a href="karte.php?d=260630&c=88">Vrnitev iz lčolipops lol</a></td></tr></thead>
                    HtmlNodeCollection htmlNodeCollection = tableNode.SelectNodes(".//thead/tr/td//a");
                    if (htmlNodeCollection != null)
                    {
                        HtmlNode nodeSource = htmlNodeCollection[0];
                        movement.SetSource(nodeSource.InnerText,
                                           nodeSource.Attributes["href"].Value);
                        HtmlNode nodeDestination = htmlNodeCollection[1];
                        movement.SetDestination(nodeDestination.InnerText,
                                                nodeDestination.Attributes["href"].Value);
                        //foreach (HtmlNode theadNode in htmlNodeCollection)
                        //{
                        //    HtmlNode htmlNode = theadNode.SelectSingleNode("./a");
                        //    Console.WriteLine("Name:{1}, href={0}", htmlNode.Attributes["href"].Value,
                        //                      htmlNode.InnerText);
                        //}
                    }
                    //units
                    HtmlNodeCollection nodeCollection = tableNode.SelectNodes(".//tbody[@class='units']//td");
                    if (nodeCollection != null)
                    {
                        Troops troops = new Troops();
                        int totalUnits = nodeCollection.Count/2;
                        //<td><img src="img/x.gif" class="unit u21" title="Falanga" alt="Falanga" /></td>
                        for (int i = 0; i < totalUnits; i++)
                        {
                            string classAttribute = nodeCollection[i].Element("img").Attributes["class"].Value;
                            string titleAttribute = nodeCollection[i].Element("img").Attributes["title"].Value;
                            int unitCount = Misc.String2Number(nodeCollection[i + totalUnits].InnerText);
                            troops.AddTroopUnit(new TroopUnit(titleAttribute, unitCount).AddHtmlClassName(classAttribute));
                            //Console.Write(classAttribute + " " + titleAttribute + unitCount + ", ");
                        }
                        movement.AddTroops(troops);
                        //Console.WriteLine();
                    }
                    //resoures
                    //<div class="res" style="width: auto;"><img class="r1" src="img/x.gif" alt="les" title="les" />27 | <img class="r2" src="img/x.gif" alt="glina" title="glina" />27 | <img class="r3" src="img/x.gif" alt="železo" title="železo" />27 | <img class="r4" src="img/x.gif" alt="žito" title="žito" />8</div>
                    //carry
                    //<div class="carry" style="float: right; width: auto;"><img class="car" src="img/x.gif" alt="nosilnost" title="nosilnost" />89/225</div>
                    //infos
                    //<tbody class="infos"><tr><th>Prihod</th><td colspan="10"><div class="in">v <span id=timer1>0:07:30</span> h</div><div class="at">ob 18:51:03</span><span> uri</div></td></tr></tbody>
                    HtmlNodeCollection arrivalSpan =
                        tableNode.SelectNodes(".//tbody[@class='infos']//span[starts-with(@id, 'timer')]");
                    if (arrivalSpan != null)
                    {
                        TimeSpan timeSpan = Misc.String2TimeSpan(arrivalSpan[0].InnerText);
                        movement.SetDate(dt + timeSpan);
                    }
                    troopMovement.Add(movement);
                }
            }
            return troopMovement;
        }

        private readonly HtmlDocument htmlDocument;
    }
}