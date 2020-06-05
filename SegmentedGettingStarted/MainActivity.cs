using Android.App;
using Android.Widget;
using Android.OS;
using Syncfusion.Android.Buttons;
using Android.Views;
using Android.Graphics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace SegmentedGettingStarted
{
    [Activity(Label = "SegmentedGettingStarted", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LinearLayout mainLayout = new LinearLayout(this);
            mainLayout.Orientation = Orientation.Vertical;
            mainLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);

            mainLayout.SetBackgroundColor(Color.WhiteSmoke);
            mainLayout.SetPadding(50, 50, 50, 50);


            //Adding textview as the header part of the application.
            TextView headerLabel = new TextView(this);
            headerLabel.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 100);
            headerLabel.Text = "Bus Ticket Booking";
            headerLabel.SetTextColor(Color.Black);
            headerLabel.TextSize = 25;
            headerLabel.TextAlignment = TextAlignment.Center;
            headerLabel.TextAlignment = TextAlignment.Gravity;

            //Adding the editor to enter the origin location.
            EditText fromEditor = new EditText(this);
            fromEditor.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 130);
            fromEditor.Hint = "From";
            fromEditor.SetTextColor(Color.Black);
            fromEditor.SetHintTextColor(Color.Gray);

            //Adding editor to enter the destination locaiton.
            EditText toEditor = new EditText(this);
            toEditor.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 170);
            toEditor.Hint = "To";
            toEditor.SetTextColor(Color.Black);
            toEditor.SetHintTextColor(Color.Gray);

            //segmented control to add item as string data.
            SfSegmentedControl segmentedControl = new SfSegmentedControl(this)
            {
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 200),
                SelectionTextColor = Color.White,
                BackColor = Color.Transparent,
                SegmentHeight = 50,
                BorderColor = Color.ParseColor("#929292"),
                FontColor = Color.ParseColor("#929292"),
                SegmentBackgroundColor = Color.Transparent,
                VisibleSegmentsCount = 6,
                DisplayMode = SegmentDisplayMode.Text,
                ItemsSource = new List<string>
                {
                    "1","2","3","4","5","6"
                }
            };
           
            //segmented control to add item as SfSegmentItem.
            SfSegmentedControl segment = new SfSegmentedControl(this)
            {
                SelectionTextColor = Color.White,
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 200),
                BorderColor = Color.ParseColor("#007CEE"),
                FontColor = Color.Black,
                SelectedIndex = 2,
                FontSize = 15,
                SegmentHeight = 50,
                SegmentBackgroundColor = Color.Transparent,
                VisibleSegmentsCount = 5,
                DisplayMode = SegmentDisplayMode.Text,
                ItemsSource = new ObservableCollection<SfSegmentItem>
                {
                    new SfSegmentItem(){Text="Sleepers"},
                    new SfSegmentItem(){Text="Seaters"},
                },

                SelectionIndicatorSettings = new SelectionIndicatorSettings()
                {
                    Color = Color.Transparent
                }

            };

            AlertDialog.Builder resultsDialog = new AlertDialog.Builder(this);
            resultsDialog.SetTitle("Status");

            Button resetButtonView = new Button(this) { Text = "Reset", TextAlignment = TextAlignment.Center };
            resetButtonView.SetHeight(50);
            resetButtonView.SetBackgroundColor(Color.White);
            resetButtonView.SetTextColor(Color.Gray);

            Button goButtonView = new Button(this) { Text = "Go", TextAlignment = TextAlignment.Center };
            goButtonView.SetHeight(50);
            goButtonView.SetTextColor(Color.Gray);
            goButtonView.SetBackgroundColor(Color.White);

            resetButtonView.Click += (object sender, EventArgs e) =>
            {
                resultsDialog.SetMessage("Fields has been reset.");
                resultsDialog.Create().Show();
                resultsDialog.SetCancelable(true);
            };
            goButtonView.Click += (object sender, EventArgs e) =>
            {
                resultsDialog.SetMessage("Your ticket has been booked.");
                resultsDialog.Create().Show();
                resultsDialog.SetCancelable(true);
            };

            //segmented control to add item as View.
            SfSegmentedControl segmentView = new SfSegmentedControl(this)
            {
                LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 200),
                BorderColor = Color.Transparent,
                SegmentHeight = 50,
                VisibleSegmentsCount = 2,
                SegmentPadding = 30,
                ItemsSource = new ObservableCollection<View>
                {
                    resetButtonView,
                    goButtonView
                },

            };
           

            mainLayout.AddView(headerLabel);
            mainLayout.AddView(fromEditor);
            mainLayout.AddView(toEditor);
            mainLayout.AddView(segment);
            mainLayout.AddView(segmentedControl);
            mainLayout.AddView(segmentView);

            // Set our view from the "main" layout resource
            SetContentView(mainLayout);
        }
    }
}
