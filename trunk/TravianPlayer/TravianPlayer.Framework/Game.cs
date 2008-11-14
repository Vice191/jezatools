﻿using System;
using System.Collections.Generic;

namespace TravianPlayer.Framework
{
    public class Game
    {
        public int UserId { get; set; }

        public void AddVillage(Village village)
        {
            villages.Add(village.Id, village);
        }

        public int GetVillagesCount
        {
            get { return villages.Count; }
        }

        public string GetVillageName(int villageId)
        {
            foreach (KeyValuePair<int, Village> village in villages)
            {
                if (village.Key == villageId)
                {
                    return village.Value.Name;
                }
            }
            return String.Empty;
        }

        public Dictionary<int, Village> Villages
        {
            get { return villages; }
        }

        private Dictionary<int, Village> villages = new Dictionary<int, Village>();
    }
}