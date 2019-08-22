using System;
using Microsoft.EntityFrameworkCore;

namespace Model
{

    public class FishDump : DbContext
    {
        public DbSet<Fish> Fishes { get; set; }
        public DbSet<Trophic> Trophics { get; set; }
        public DbSet<BatchCode> BatchCodes { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Managment> Managments { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<StructType> StructTypes { get; set; }
        public DbSet<StudyArea> StudyAreas { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = Blogging; Trusted_Connection = True;");
        }
    }


    public class Fish
    {
        public int ID { get; set; }
        public string scientificName { get; set; }
        public string commonName { get; set; }
        public int fishCount { get; set; }
        public double fishLength { get; set; }
        public int trophicID { get; set; }
        public int managmentID { get; set; }
        public int familyID { get; set; }
        public int secTypeID { get; set; }
        public int batchCodeID { get; set; }
        public int surveyID { get; set; }
        public int regionID { get; set; }
        public int studyAreaID { get; set; }
        public int locationID { get; set; }

    }

    public class Trophic
    {
        public int ID { get; set; }
        public int trophic { get; set; }
      

    }

    public class BatchCode
    {
        public int ID { get; set; }
        public int batchCode { get; set; }


    }

    public class Survey
    {
        public int ID { get; set; }
        public string surveyDate { get; set; }
        public string surveyIndex { get; set; }

    }

    public class Region
    {
        public int ID { get; set; }
        public string regionName { get; set; }
        public string subRegion { get; set; }

    }


    public class Managment
    {
        public int ID { get; set; }
        public string managment  { get; set; }
      

    }

    public class Family
    {
        public int ID { get; set; }
        public string name { get; set; }

    }


    public class StructType
    {
        public int ID { get; set; }
        public string structureType { get; set; }

    }


    public class StudyArea
    {
        public int ID { get; set; }
        public string studyAr { get; set; }

    }


    public class Location
    {
        public int ID { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

    }








}

