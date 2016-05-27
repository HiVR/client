﻿// <copyright file="ConnectControlViewModel.cs" company="HiVR">
// Copyright (c) 2016 HiVR All Rights Reserved
// </copyright>
namespace HiVRClient.ViewModel
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// This class implements the view model of the ConnectControl.
    /// </summary>
    public class ConnectControlViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Private instance of property below.
        /// </summary>
        private ICommand connectCommand;

        /// <summary>
        /// Is called when a connection is attempted.
        /// </summary>
        public event EventHandler ConnectionAttempted;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets command interface that connects to the button in the view.
        /// </summary>
        public ICommand ConnectCommand
        {
            get { return this.connectCommand ?? (this.connectCommand = new RelayCommand(param => this.Connect())); }
        }

        /// <summary>
        /// Gets or sets the host to connect to.
        /// </summary>
        public string Host { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the port to connect to.
        /// </summary>
        public int Port { get; set; } = 25565;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Is called after a connection is attempted. It invokes the event handler.
        /// </summary>
        protected virtual void OnConnectionAttempted()
        {
            this.ConnectionAttempted?.Invoke(this, null);
        }

        /// <summary>
        /// Attempts a connection and calls the OnConnectionAttempted method with the results.
        /// </summary>
        private void Connect()
        {
            // Create a connection to the specified address.
            Model.Network.NetworkManager.CreateConnection(this.Host, this.Port);

            // Actual connection logic here. The OnConnectionAttempted method should provide parameters to provide whether the connection was successful or not.
            this.OnConnectionAttempted();
        }

        #endregion Methods
    }
}