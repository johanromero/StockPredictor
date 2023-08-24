using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;

namespace SPTrainer.Models
{
    public class StockDataInput {
        // Date,Close,Volume,Open,High,Low
        [LoadColumn(0)]
        [ColumnName("Date")]
        public string Date { get; set; }

        [LoadColumn(1)]
        public float Close { get; set; }

        [LoadColumn(2)]
        public float Volume { get; set; }

        [LoadColumn(3)]
        public float Open { get; set; }

        [LoadColumn(4)]
        public float High { get; set; }

        [LoadColumn(5)]
        public float Low { get; set; }

     

    }

    public class StockData
    {
        // Date,Close,Volume,Open,High,Low
        public string Date { get; set; }
        public float DateFloat { get; set; }
        public float Close { get; set; }
        public float Volume { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public string Ticker { get; set; }
        public float Score { get; set; }

    }


    [CustomMappingFactoryAttribute("DateToFloat")]
    public  class DateToFloatCustomAction : CustomMappingFactory<StockDataInput,
    StockData>
    {
        // We define the custom mapping between input and output rows that will
        // be applied by the transformation.
        public static void CustomAction(StockDataInput input, StockData
            output)
        {  
            
                const string DATETIME_FORMAT = "MM/dd/yyyy";
                output.Close = input.Close;
                output.High = input.High;
                output.Low = input.Low;
                output.Open = input.Open;
                output.Volume = input.Volume;
                output.Date = input.Date;

            if (DateTime.TryParseExact(input.Date,
                                            DATETIME_FORMAT,
                                            CultureInfo.InvariantCulture,
                                            DateTimeStyles.None, out var result))              
                output.DateFloat = (float) result.ToFileTime();
    }

        public override Action<StockDataInput, StockData> GetMapping()
            => CustomAction;
    }
}
