using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_6._1
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }

        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);

            set => SetValue(TemperatureProperty, value);

        }

        public enum Precipitation
        {
            sunny = 0,
            cloudy = 1,
            rain = 2,
            snow = 3
        }
        public WeatherControl(int temperature, string windDirection, int windSpeed)
        {
            this.Temperature = temperature;
            this.WindDirection = windDirection;
            this.WindSpeed = windSpeed;
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)));
        }
               

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t>=-50 && t<=50)            
                return t;
            
            else
                return 0;
        }
        
        public string Print(Precipitation precipitation)
        {
            switch (precipitation)
            {
                case Precipitation.sunny:
                    Console.WriteLine("солнечно");
                    break;
                case Precipitation.cloudy:
                    Console.WriteLine("облачно");
                    break;
                case Precipitation.rain:
                    Console.WriteLine("дождь");
                    break;
                case Precipitation.snow:
                    Console.WriteLine("снег");
                    break;
            }
           
            return $"{Temperature} {WindDirection} {WindSpeed} {precipitation}";
        }
    }
}
