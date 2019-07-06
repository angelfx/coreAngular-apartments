using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Entities;
using RealEstates.Abstract;
using RealEstates.Abstract.Logic;
using System.IO;
using System.Linq;
//using Microsoft.EntityFrameworkCore;
using RealEstates.BLL.Helpers;

namespace RealEstates.BLL.Logic
{
    public class ApartmentsFileImport : BaseLogicCtx, IApartmentsImport
    {
        public ApartmentsFileImport(IDALContext ctx) : base(ctx)
        { }

        public string Import(string path, char separator = ',')
        {
            StringBuilder res = new StringBuilder();
            if (!File.Exists(path))
            {
                res.AppendLine("File not found");
                return res.ToString();
            }

            bool error = false;
            int cnt = 0;
            using (var inputStream = new StreamReader(path))
            {
                string line;
                while ((line = inputStream.ReadLine()) != null)
                {
                    try
                    {
                        cnt++;
                        string[] arr = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (arr.Length != 14)
                        {
                            error = true;
                            res.AppendLine($"В строке не совпадает количество столбцов. Необходимо 14, обнаружено {arr.Length}. Строка: 'line'");
                        }

                        EntityParser.array = arr;
                        var apartment = EntityParser.ParseApartment();
                        var building = EntityParser.ParseBuilding();
                        var district = EntityParser.ParseDistrict();
                        var region = EntityParser.ParseRegion();

                        //var item = db.Regions.FirstOrDefault(x => x.IdRegion == 444);

                        if (db.Regions.Any(x => x.IdRegion == region.IdRegion))
                            region = db.Regions.First(x => x.IdRegion == region.IdRegion);
                        else
                        {
                            region = db.Regions.Add(region).Entity;
                            db.SaveChanges();
                        }

                        if (db.Districts.Any(x => x.IdDistrict == district.IdDistrict))
                            district = db.Districts.First(x => x.IdDistrict == district.IdDistrict);
                        else
                        {
                            district.Region = region;
                            district = db.Districts.Add(district).Entity;
                            db.SaveChanges();
                        }

                        if (db.Buildings.Any(x => x.IdBuilding == building.IdBuilding))
                            building = db.Buildings.First(x => x.IdBuilding == building.IdBuilding);
                        else
                        {
                            building.District = district;
                            building = db.Buildings.Add(building).Entity;
                            db.SaveChanges();
                        }

                        if (!db.Apartments.Any(x => x.IdApartment == apartment.IdApartment))
                        {
                            apartment.Building = building;
                            db.Apartments.Add(apartment);
                            db.SaveChanges();
                        }
                    }
                    catch { }
                }
            }
            if (!error)
            {
                res.Clear();
                res.AppendLine("Import finished");
                res.AppendLine($"Added {cnt} items");
            }

            return res.ToString();
        }


    }
}
