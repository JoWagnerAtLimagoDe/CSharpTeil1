using RicisBatch.Job;
using RicisBatch.Step.ChunkStep;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace JobLauncherProjekt
{
    public class SimpleReader: AbstractReader<FxRateItem>
    {

       


        public override  IEnumerable<FxRateItem> GetEnumerator()
        {
           
           
            using (var reader = new StreamReader((string)Parameters["filename"]))
            {
               
                
                while (!reader.EndOfStream)
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    string format = "dd.mm.yyyy";

                    var line = reader.ReadLine();
                    var values = line.Split(",");

                   
                    yield return CreateFxRateItem(values, format, provider); 
                }
            }
        }

        private static FxRateItem CreateFxRateItem(string[] values, string format, CultureInfo provider)
        {
            
            return new FxRateItem(
                values[0],
                values[1],
                DateTime.ParseExact(values[2], format, provider),
                double.TryParse(values[3], NumberStyles.Float, new CultureInfo("en-US"), out double x) ? x : 0); ;
        }
    }
}
