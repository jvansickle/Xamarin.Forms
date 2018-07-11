using Xamarin.Forms.Internals;
using Xamarin.Forms.CustomAttributes;

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 3277, "[macOS] Grid Row Height zero does not hide contents", PlatformAffected.macOS)]
	public class GitHub3277 : TestContentPage
	{
		protected override void Init()
		{
			// Instantiate elements
			var grid = new Grid
			{
				RowDefinitions = new RowDefinitionCollection
				{
					new RowDefinition{
						Height = new GridLength(1, GridUnitType.Auto)
					},
					new RowDefinition{
						Height = new GridLength(1, GridUnitType.Auto)
					},
					new RowDefinition{
						Height = new GridLength(1, GridUnitType.Auto)
					},
					new RowDefinition{
						Height = new GridLength(1, GridUnitType.Auto)
					}
				},
				RowSpacing = 0
			};

			var rowZeroLabel = new Label
			{
				Text = "I'm row 0"
			};

			var rowOneButton = new Button
			{
				Text = "I'm row 1"
			};

			var rowTwoLabel = new Label
			{
				Text = "I'm row 2"
			};

			var rowThreeLabel = new Label
			{
				Text = "I'm row 3"
			};

			var toggleRowOneButton = new Button
			{
				Text = "Toggle row one height",
				Command = new Command(() =>
				{
					if (grid.RowDefinitions[1].ActualHeight > 0)
					{
						grid.RowDefinitions[1].Height = new GridLength(0);
					}
					else
					{
						grid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Auto);
					}
				})
			};

			var toggleRowTwoButton = new Button
			{
				Text = "Toggle row two height",
				Command = new Command(() =>
				{
					if (grid.RowDefinitions[2].ActualHeight > 0)
					{
						grid.RowDefinitions[2].Height = new GridLength(0);
					}
					else
					{
						grid.RowDefinitions[2].Height = new GridLength(1, GridUnitType.Auto);
					}
				})
			};

			// add elements to grid
			grid.Children.Add(rowZeroLabel, 0, 0);
			grid.Children.Add(rowOneButton, 0, 1);
			grid.Children.Add(rowTwoLabel, 0, 2);
			grid.Children.Add(rowThreeLabel, 0, 3);
			grid.Children.Add(toggleRowOneButton, 0, 4);
			grid.Children.Add(toggleRowTwoButton, 0, 5);

			Content = grid;
		}
	}
}
