// using System;
// using System.Collections.Generic;
//
// namespace PlanetCodeSmell
// {
//     public class Planet
//     {
//         private ILogger _logger;
//         public int NanoMetre { get; set; }
//         public string Name { get; set; }
//
//         public Planet(int nanoMetre, string name, ILogger<Planet> logger)
//         {
//             NanoMetre = nanoMetre;
//             Name = name;
//             _logger = logger;
//         }
//
//         public List<Planet> FindPlanetsWithLessMoons(List<Planet> planets)
//         {
//             Boolean planetWasRemoved = false;
//             
//
//             try
//             {   
//                 //I recon(according to method name) that we don't need to remove all planet that smaller then Moon, 
//                 //Perhaps we could simply return planets that fit our condition? => List<Planet> result = planets.Where(planet => planet.NanoMetre >= NanoMetre).ToList();
//                 //If I wrong please rename particular method. 
//                 
//                 planets.ForEach(planet =>
//                 {
//                     if (planet.NanoMetre >= NanoMetre)
//                     {
//                         planets.Remove(planet);
//                     }
//                 });
//             }
//             catch (Exception e)
//             {
//                 _logger.LogError();
//             }
//
//             switch (planetWasRemoved.ToString())
//             {
//                 case "true":
//                     Console.WriteLine(new String("planets were removed"));
//                     break;
//                 case "false":
//                     Console.WriteLine("no planets were removed");
//                     break;
//                 default:
//                     Console.WriteLine("shouldn't happen");
//
//                     break;
//             }
//
//             return result;
//         }
//     }
// }
//

 