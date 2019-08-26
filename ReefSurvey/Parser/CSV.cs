﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Data.Common;
using Model;

namespace Parser
{
    public class CSV
    {
        public void ReadCSV()
        {
            //using (var reader = new StreamReader(@"C:\Users\dilsh\source\repos\Reef_Survey\external\survey\1-data\FGBS-0800-1100\Fish Dump.csv"))
            //{
            //    List<string> listA = new List<string>();
            //    List<string> listB = new List<string>();
            //    while (!reader.EndOfStream)
            //    {
            //        var line = reader.ReadLine();
            //        var values = line.Split(',');


            //        listA.Add(values[0]);
            //        Console.WriteLine(values[0]);
            //       // Console.ReadLine();
            //    }
            //}
            List<DailyValues> values = File.ReadAllLines(@"C:\Users\dilsh\source\repos\Reef_Survey\external\survey\1-data\FGBS-0800-1100\Fish Dump.csv")
                                           .Skip(1)
                                           .Select(v => DailyValues.FromCsv(v))
                                           .ToList();
            //foreach (var item in values)
            //{
            //    Console.WriteLine($"{item.Region}{item.SubRegion}{item.StudyArea}{item.SurveyYear}{item.BatchCode}{item.SurveyIndex}{item.SurveyDate}" +
            //        $"{item.Latitude}{item.Longitude}{item.Management}{item.StructureType}{item.Family}{item.ScientificName}{item.CommonName}{item.Trophic}" +
            //        $"{item.FishLength}{item.FishCount}");
            //}


            using (var db = new FishDump())
            {

                foreach (var item in values.Select(m => new { m.Region, m.SubRegion }).Distinct().ToList())//Region
                {
                    db.Regions.Add(new Region { RegionName = item.Region, SubRegion = item.SubRegion });
                }
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                foreach (var item in values.Select(m => new { m.Trophic }).Distinct().ToList())//Trophic
                {
                    db.Trophics.Add(new Trophic { TrophicName = item.Trophic });
                }
                count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                foreach (var item in values.Select(m => new { m.BatchCode }).Distinct().ToList())//BatchCode
                {
                    db.BatchCodes.Add(new BatchCode { BatchCodeNumber = item.BatchCode });
                }
                count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                foreach (var item in values.Select(m => new { m.SurveyDate, m.SurveyIndex }).Distinct().ToList())//Survay
                {
                    db.Surveys.Add(new Survey { SurveyDate = item.SurveyDate, SurveyIndex = item.SurveyIndex });
                }
                count = db.SaveChanges();

                foreach (var item in values.Select(m => new { m.Management }).Distinct().ToList())//Managment
                {
                    db.Managments.Add(new Managment { ManagmentName = item.Management });
                }
                count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                foreach (var item in values.Select(m => new { m.Family }).Distinct().ToList())//Family
                {
                    db.Families.Add(new Family { FamilyName = item.Family });
                }
                count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                //foreach (var item in values.Select(m => new { m.StructureType }).Distinct().ToList())//StructureType
                //{
                //    db.StructTypes.Add(new StructType { StructureType = item.StructureType });
                //}
                //var count = db.SaveChanges();
                //Console.WriteLine("{0} records saved to database", count);

                foreach (var item in values.Select(m => new { m.StudyArea }).Distinct().ToList())//StudyArea
                {
                    db.StudyAreas.Add(new StudyArea { StudyAreaName = item.StudyArea });
                }
                count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                foreach (var item in values.Select(m => new { m.Latitude, m.Longitude }).Distinct().ToList())//location
                {
                    db.Locations.Add(new Location { Longitude = item.Longitude, Latitude=item.Latitude });
                }
                count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                foreach (var item in values)//fish
                {
                    db.Fishes.Add(new Fish { ScientificName = item.ScientificName, CommonName=item.CommonName, FishCount=item.FishCount, FishLength=item.FishLength});
                }
                count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var region in db.Regions)
                {
                    Console.WriteLine(" - {0}", region.RegionName);
                }
            }


        }


    }


    class DailyValues
    {
        public string Region;
        public string SubRegion;
        public string StudyArea;
        public string SurveyYear;
        public string BatchCode;
        public string SurveyIndex;
        public string SurveyDate;
        public string Latitude;
        public string Longitude;
        public string Management;
        public string StructureType;
        public string Family;
        public string ScientificName;
        public string CommonName;
        public string Trophic;
        public double FishLength;
        public int FishCount;

        //decimal Low;
        //decimal Close;
        //decimal Volume;
        //decimal AdjClose;

        public static DailyValues FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            DailyValues dailyValues = new DailyValues();
            dailyValues.Region = values[0];
            dailyValues.SubRegion = values[1];
            dailyValues.StudyArea = values[2];
            dailyValues.SurveyYear = values[3];
            dailyValues.BatchCode = values[4];
            dailyValues.SurveyIndex = values[5];
            dailyValues.SurveyDate = values[6];
            dailyValues.Latitude = values[7];
            dailyValues.Longitude = values[8];
            dailyValues.Management = values[9];
            dailyValues.StructureType = values[10];
            dailyValues.Family = values[11];
            dailyValues.ScientificName = values[12];
            dailyValues.CommonName = values[13];
            dailyValues.Trophic = values[14];
            dailyValues.FishLength = Convert.ToDouble(values[15]);
            dailyValues.FishCount = Convert.ToInt32(values[16]);
            return dailyValues;
        }
    }



}
