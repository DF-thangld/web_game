﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace beans
{
    public class Map
    {

        public static double RangeCalculator(int sourceX, int sourceY, int desX, int desY)
        {
            return Math.Sqrt(Math.Pow(sourceX - desX, 2) + Math.Pow(sourceY - desY, 2));
        }
        public static DateTime LandingTime(TroopType troop, int sourceX, int sourceY, int desX, int desY, DateTime start)
        {
            return LandingTime(troop, sourceX, sourceY, desX, desY, start, 0);
        }
        public static DateTime LandingTime (TroopType troop, int sourceX, int sourceY, int desX, int desY, DateTime start, double speedIncrease)
        {
            string type = "Map.merchant_speed";
            switch (troop)
            {
                case TroopType.Axe:
                    type = "Map.axe_speed";
                    break;
                case TroopType.Spear:
                    type = "Map.spear_speed";
                    break;
                case TroopType.Sword:
                    type = "Map.sword_speed";
                    break;
                case TroopType.Heavy:
                    type = "Map.heavy_cavalry_speed";
                    break;
                case TroopType.Light:
                    type = "Map.light_cavalry_speed";
                    break;
                case TroopType.Scout:
                    type = "Map.scout_speed";
                    break;
                case TroopType.Nobleman:
                    type = "Map.noble_speed";
                    break;
                case TroopType.Ram:
                    type = "Map.ram_speed";
                    break;
                case TroopType.Catapult:
                    type = "Map.catapult_speed";
                    break;
                default:
                    type = "Map.merchant_speed";
                    break;
            }

            Configuration config = Configuration.TribalWarsConfiguration;
            NumericConfiguration troopSpeedConfiguration = config.GetNumericConfigurationItem(type);

            return start.AddMilliseconds(RangeCalculator(sourceX, sourceY, desX, desY) * (troopSpeedConfiguration.Value - troopSpeedConfiguration.Value * speedIncrease));
        }

        public static double MovingTime(int sourceX, int sourceY, int desX, int desY, TroopType troop)
        {
            string type = "Map.merchant_speed";
            switch (troop)
            {
                case TroopType.Axe:
                    type = "Map.axe_speed";
                    break;
                case TroopType.Spear:
                    type = "Map.spear_speed";
                    break;
                case TroopType.Sword:
                    type = "Map.sword_speed";
                    break;
                case TroopType.Heavy:
                    type = "Map.heavy_cavalry_speed";
                    break;
                case TroopType.Light:
                    type = "Map.light_cavalry_speed";
                    break;
                case TroopType.Scout:
                    type = "Map.scout_speed";
                    break;
                case TroopType.Nobleman:
                    type = "Map.noble_speed";
                    break;
                case TroopType.Ram:
                    type = "Map.ram_speed";
                    break;
                case TroopType.Catapult:
                    type = "Map.catapult_speed";
                    break;
                default:
                    type = "Map.merchant_speed";
                    break;
            }

            Configuration config = Configuration.TribalWarsConfiguration;
            NumericConfiguration troopSpeedConfiguration = config.GetNumericConfigurationItem(type);
            return RangeCalculator(sourceX, sourceY, desX, desY) * troopSpeedConfiguration.Value;
        }
        public static double MovingTime(Village fromVillage, Village toVillage, TroopType troop)
        {
            return MovingTime(fromVillage.X, fromVillage.Y, toVillage.X, toVillage.Y, troop);
        }

        public static DateTime LandingTime(TroopType troop, Village from, Village to, DateTime start)
        {
            return Map.LandingTime(troop, from.X, from.Y, to.X, to.Y, start, 0);
        }
        public static DateTime LandingTime(TroopType troop, Village from, Village to, DateTime start, double speedIncrease)
        {
            return Map.LandingTime(troop, from.X, from.Y, to.X, to.Y, start, speedIncrease);
        }
        public static DateTime LandingTime(int speed, Village from, Village to, DateTime start, double speedIncrease)
        {
            return start.AddMilliseconds(RangeCalculator(from.X, from.Y, to.X, to.Y) * (speed + speed * speedIncrease));
        }
        public static DateTime LandingTime(int speed, Village from, Village to, DateTime start)
        {
            return start.AddMilliseconds(RangeCalculator(from.X, from.Y, to.X, to.Y) * speed);
        }
        
        public static IList<Village> GetMap(Village center, ISession session)
        {
            Configuration config = Configuration.TribalWarsConfiguration;
            NumericConfiguration mapSizeConfiguration = config.GetNumericConfigurationItem("Map.map_size");
            int mapSize = (int)mapSizeConfiguration.Value;

            return (from village in session.Linq<Village>()
                    where village.X >= center.X - mapSize && village.X <= center.X + mapSize
                    && village.Y >= center.Y - mapSize && village.Y <= center.Y + mapSize
                    orderby village.X descending
                    orderby village.Y descending
                    select village).ToList<Village>();
        }

        public static IList<Village> GetMap(int x, int y, ISession session)
        {
            Configuration config = Configuration.TribalWarsConfiguration;
            NumericConfiguration mapSizeConfiguration = config.GetNumericConfigurationItem("Map.map_size");
            int mapSize = (int)mapSizeConfiguration.Value;

            return (from village in session.Linq<Village>()
                    where village.X >= x - mapSize && village.X <= x + mapSize
                    && village.Y >= y - mapSize && village.Y <= y + mapSize
                    orderby village.X descending
                    orderby village.Y descending
                    select village).ToList<Village>();
        }

        public static bool HasVillage(int x, int y, ISession session)
        {
            int villageCount = (from village in session.Linq<Village>()
                                where village.X == x && village.Y == y
                                select village).Count<Village>();
            return (villageCount > 0);
        }

        public static int SlowestSpeed(int spear,
                                        int sword,
                                        int axe,
                                        int scout,
                                        int lightCavalry,
                                        int heavyCavalry,
                                        int ram,
                                        int catapult,
                                        int noble)
        {
            Configuration config = Configuration.TribalWarsConfiguration;
            List<double> speeds = new List<double>();
            if (spear > 0)
                speeds.Add(config.GetNumericConfigurationItem("Map.spear_speed").Value);
            if (sword > 0)
                speeds.Add(config.GetNumericConfigurationItem("Map.sword_speed").Value);
            if (axe > 0)
                speeds.Add(config.GetNumericConfigurationItem("Map.axe_speed").Value);
            if (scout > 0)
                speeds.Add(config.GetNumericConfigurationItem("Map.scout_speed").Value);
            if (lightCavalry > 0)
                speeds.Add(config.GetNumericConfigurationItem("Map.light_cavalry_speed").Value);
            if (heavyCavalry > 0)
                speeds.Add(config.GetNumericConfigurationItem("Map.heavy_cavalry_speed").Value);
            if (ram > 0)
                speeds.Add(config.GetNumericConfigurationItem("Map.ram_speed").Value);
            if (catapult > 0)
                speeds.Add(config.GetNumericConfigurationItem("Map.catapult_speed").Value);
            if (noble > 0)
                speeds.Add(config.GetNumericConfigurationItem("Map.noble_speed").Value);

            return (int)speeds.Max();
        }
    }
}
