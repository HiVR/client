﻿// <copyright file="MarginConverter.cs" company="HiVR">
// Copyright (c) 2016 HiVR All Rights Reserved
// </copyright>
namespace HiVRClient.Converter
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Converts a multibinding to apply margin offset with a zoom factor.
    /// </summary>
    [ValueConversion(typeof(double[]), typeof(Thickness))]
    public class MarginConverter : IMultiValueConverter
    {
        #region Methods

        /// <summary>
        /// Converts a array of doubles to a thickness object with a multiplication factor.
        /// </summary>
        /// <param name="values">the double array to convert</param>
        /// <param name="targetType">The parameter is not used.</param>
        /// <param name="parameter">The parameter is not used.</param>
        /// <param name="culture">The parameter is not used.</param>
        /// <returns>the thickness object</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new Thickness(
                System.Convert.ToDouble(values[0]) * ZoomConverter.Zoom,
                System.Convert.ToDouble(values[1]) * ZoomConverter.Zoom,
                System.Convert.ToDouble(values[2]) * ZoomConverter.Zoom,
                System.Convert.ToDouble(values[3]) * ZoomConverter.Zoom);
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="value">The parameter is not used.</param>
        /// <param name="targetTypes">The parameter is not used.</param>
        /// <param name="parameter">The parameter is not used.</param>
        /// <param name="culture">Thee parameter is not used.</param>
        /// <returns>just null</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion Methods
    }
}