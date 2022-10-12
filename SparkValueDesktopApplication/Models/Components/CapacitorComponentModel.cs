﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SparkValueDesktopApplication.Models.Components
{
    public class CapacitorComponentModel : IComponentModel
    {
        public string Name { get; }
        public string Description { get; }
        public BitmapImage Image { get; }
        public double CapacitanceValue { get; }

        /// <summary>
        /// Used in making components that have a capacitance value.
        /// For example, capacitors, etc.
        /// </summary>
        /// <param name="name">Name of the component</param>
        /// <param name="description">Short description of what the component does</param>
        /// <param name="imageSource">An image source that represents the component</param>
        /// <param name="capacitanceValue">Value measured in farads (F)</param>
        public CapacitorComponentModel(string name, string description, string imageSource, double capacitanceValue)
        {
            Name = name;
            Description = description;
            Image = new BitmapImage(new Uri(imageSource, UriKind.Relative));
            CapacitanceValue = capacitanceValue;
        }

        public string DisplayValues(double inputVoltage, double inputCurrent)
        {
            throw new NotImplementedException();
        }

        public double GetOutputCurrent(double inputCurrent)
        {
            throw new NotImplementedException();
        }

        public double GetOutputVoltage(double inputVoltage)
        {
            throw new NotImplementedException();
        }
    }
}