using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatePattern
{
    public class Weather
    {
        public int Temperature { get; set; }
        private TemperatureState _temperatureState;
        public TemperatureState temperatureState
        {
            get
            {
                return _temperatureState;
            }
            set
            {
                _temperatureState = value;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("當前類型是：{0}", _temperatureState.GetType().Name);
               
            }
        }
        public Weather(TemperatureState state)
        {
            temperatureState = state;
        }

        public void Up()
        {
            temperatureState.Up(this);
        }
    }
}
