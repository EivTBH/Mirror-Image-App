using System;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Maui;
using Microsoft.Maui.Controls;



namespace Mirror_Image_Photography;

public partial class MainPage : ContentPage
{
    private readonly List<string> _imageUrls = new List<string>
        {
            "dog.jpg",
            "bridge.jpg",
            "face.png",
            "view.jpg"
        };

    private int _currentIndex = 0;
    private System.Timers.Timer _timer;

    public MainPage()
    {
        InitializeComponent();
        
        carousel.ItemsSource = _imageUrls;

        // Create and start the timer
        _timer = new System.Timers.Timer(5000);
        _timer.Elapsed += OnTimerElapsed;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    private void ShowImage()
    {
        carousel.Position = _currentIndex;

    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        // Move to the next image
        MainThread.InvokeOnMainThreadAsync(() =>

        {
            if (_currentIndex < _imageUrls.Count - 1)
            {
                _currentIndex++;
            }
            else
            {
                _currentIndex = 0;
            }

            ShowImage();
        });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Stop the timer
        _timer.Enabled = false;
    }

    
}
