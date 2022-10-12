﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SparkValueDesktopApplication.Models.Components
{
    public class BasicComponentModel : IComponentModel
    {
        public string Name { get; }
        public string Description { get; }
        public BitmapImage Image { get; }

        /// <summary>
        /// Used in making basic components that have nothing special associated with them.
        /// For example, LEDs, diodes, etc.
        /// </summary>
        /// <param name="name">Name of the component</param>
        /// <param name="description">Short description of what the component does</param>
        /// <param name="imageSource">An image source that represents the component</param>
        public BasicComponentModel(string name, string description, string imageSource)
        {
            Name = name;
            Description = description;
            Image = new BitmapImage(new Uri(imageSource, UriKind.Relative));
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