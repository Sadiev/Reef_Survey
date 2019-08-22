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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FishDump;Trusted_Connection=True;");
        }
    }


    public class Fish
    {
        public int FishId { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public int FishCount { get; set; }
        public double FishLength { get; set; }
        public int TrophicID { get; set; }
        public int ManagmentID { get; set; }
        public int FamilyID { get; set; }
        public int SecTypeID { get; set; }
        public int BatchCodeID { get; set; }
        public int SurveyID { get; set; }
        public int RegionID { get; set; }
        public int StudyAreaID { get; set; }
        public int LocationID { get; set; }

    }

    public class Trophic
    {
        public int ID { get; set; }
        public string TrophicName { get; set; }


        public int FishId { get; set; }
        public Fish Fish { get; set; }


    }

    public class BatchCode
    {
        public int ID { get; set; }
        public string BatchCodeNumber { get; set; }


        public int FishId { get; set; }
        public Fish Fish { get; set; }

    }

    public class Survey
    {
        public int ID { get; set; }
        public string SurveyDate { get; set; }
        public string SurveyIndex { get; set; }


        public int FishId { get; set; }
        public Fish Fish { get; set; }
    }

    public class Region
    {
        public int ID { get; set; }
        public string RegionName { get; set; }
        public string SubRegion { get; set; }


        public int FishId { get; set; }
        public Fish Fish { get; set; }

    }


    public class Managment 
    {
        public int ID { get; set; }
        public string ManagmentName  { get; set; }


        public int FishId { get; set; }
        public Fish Fish { get; set; }


    }

    public class Family
    {
        public int ID { get; set; }
        public string FamilyName { get; set; }

        public int FishId { get; set; }
        public Fish Fish { get; set; }

    }


    public class StructType
    {
        public int ID { get; set; }
        public string StructureType { get; set; }

        public int FishId { get; set; }
        public Fish Fish { get; set; }

    }


    public class StudyArea
    {
        public int ID { get; set; }
        public string StudyAreaName { get; set; }

        public int FishId { get; set; }
        public Fish Fish { get; set; }

    }

    public class Location
    {
        public int ID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public int FishId { get; set; }
        public Fish Fish { get; set; }

    }
}

