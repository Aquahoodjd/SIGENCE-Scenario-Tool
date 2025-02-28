﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

using SIGENCEScenarioTool.Datatypes.Geo;
using SIGENCEScenarioTool.Extensions;



namespace SIGENCEScenarioTool.Markers
{
    /// <summary>
    /// Interaktionslogik für GeoNodeMarker.xaml
    /// </summary>
    public partial class GeoNodeMarker : UserControl
    {
        /// <summary>
        /// The popup
        /// </summary>
        private readonly Popup popup = null;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="GeoNodeMarker"/> class.
        /// </summary>
        public GeoNodeMarker( GeoNode gn )
        {
            InitializeComponent();

            this.popup = new Popup
            {
                Placement = PlacementMode.Mouse,
                Child = new Label
                {
                    Background = Brushes.Yellow,
                    Foreground = Brushes.Black,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness( 2 ),
                    Padding = new Thickness( 3 ),
                    FontSize = 14,
                    FontFamily = new FontFamily( "Courier New" ),
                    Content = $"[{gn.Tag}/{gn.Value}]: {(gn.Name.IsNotEmpty() ? gn.Name : "Unknown")}"
                }
            };

            MouseEnter += MarkerControl_MouseEnter;
            MouseLeave += MarkerControl_MouseLeave;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Handles the MouseLeave event of the MarkerControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void MarkerControl_MouseLeave( object sender, MouseEventArgs e )
        {
            this.popup.IsOpen = false;

            e.Handled = true;
        }


        /// <summary>
        /// Handles the MouseEnter event of the MarkerControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void MarkerControl_MouseEnter( object sender, MouseEventArgs e )
        {
            this.popup.IsOpen = true;

            e.Handled = true;
        }

    } // end public partial class GeoNodeMarker
}
