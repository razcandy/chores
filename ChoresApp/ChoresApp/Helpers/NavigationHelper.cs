using ChoresApp.Debug;
using ChoresApp.Pages;
using ChoresApp.Pages.Home;
using ChoresApp.Pages.Popups;
using ChoresApp.Pages.Popups.Alert;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChoresApp.Helpers
{
	public static class NavigationHelper
	{
		// Fields ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static NavStackEnum currentStack;

		// Properties ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static Stack<ChPageBase> homeStack = new Stack<ChPageBase>();
		private static Stack<ChPageBase> nav1Stack = new Stack<ChPageBase>();
		private static Stack<ChPageBase> nav2Stack = new Stack<ChPageBase>();
		private static Stack<ChPageBase> nav3Stack = new Stack<ChPageBase>();
		private static Stack<ChPageBase> debugStack = new Stack<ChPageBase>();
		private static ContentView homePageContainer;

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private static IPopupNavigation PopupInstance => PopupNavigation.Instance;
		
		private static Stack<ChPageBase> ResolveStack(NavStackEnum _targetEnum)
		{
			switch (_targetEnum)
			{
				case NavStackEnum.Nav1:
					return nav1Stack;
				case NavStackEnum.Nav2:
					return nav2Stack;
				case NavStackEnum.Nav3:
					return nav3Stack;
				case NavStackEnum.Debug:
					return debugStack;
				case NavStackEnum.Home:
				default:
					return homeStack;
			}
		}

		public static void InitStacks(HomePage _homePage)
		{
			homeStack.Push(_homePage.HomeContent);
			nav1Stack.Push(_homePage.Nav1Content);
			nav2Stack.Push(_homePage.Nav2Content);
			nav3Stack.Push(_homePage.Nav3Content);

#if DEBUG
			debugStack.Push(new DebugPage());
#endif

			homePageContainer = _homePage.PageContent;

			homePageContainer.Content = _homePage.HomeContent;
			_homePage.HomeContent.SendAppearing();

		}

		public static void NavToStack(NavStackEnum _targetStack)
		{
			var targetPage = ResolveStack(_targetStack).Peek();

			// do something diff if already on this stack
			if (currentStack == _targetStack)
			{
				targetPage.Refresh();
				return;
			}

			var oldPage = ResolveStack(currentStack).Peek();
			oldPage.SendDisappearing();
			targetPage.SendAppearing();
			homePageContainer.Content = targetPage;
			currentStack = _targetStack;
		}

		public static void PopFromStack(NavStackEnum _targetEnum)
		{
			var targetStack = ResolveStack(_targetEnum);

			// Should popping from a stack other than the current one be allowed?

			// first page always remains
			if (targetStack.Count == 1) return;

			targetStack.Pop().SendDestructed();
			var top = targetStack.Peek();
			top.SendAppearing();
			homePageContainer.Content = top;
		}

		public static void PopFromCurrentStack() => PopFromStack(currentStack);

		public static async void PopPopup(bool _animate = true)
		{
			await PopupInstance.PopAsync(_animate);
		}


		public static async void TryPopPage(ChPageBase _page)
		{
			var top = _page.Navigation.NavigationStack.Last();

			if (top != null && top is ChPageWrapper rawr)
			{
				if (rawr.Content == _page)
				{
					await _page.Navigation.PopAsync();
				}
			}
		}

		public static async void PushAlert(ChPopupAlertVM _popupVM)
		{
			var alert = new ChPopupAlert(_popupVM);
			await PopupInstance.PushAsync(alert);
		}

		public static async Task PushHomePage()
		{
			var top = Navigator.NavigationStack.Last();

			var home = new HomePage();
			InitStacks(home);
			await Navigator.PushAsync(home);

			Navigator.RemovePage(top);
		}

		public static void PushPage(Page _page)
		{
			Navigator.PushAsync(_page);
		}

		public static async Task PushPageAsync(Page _page)
		{
			await Navigator.PushAsync(_page);
		}

		private static INavigation Navigator => App.Current.MainPage.Navigation;

		public static async void PushPage(ChPageBase _page)
		{
			var contentPage = new ChPageWrapper
			{
				Content = _page,
			};

			await App.Current.MainPage.Navigation.PushAsync(contentPage);
		}

		public static async void PushPopup(PopupPage _popup, bool _animate = true)
		{
			await PopupInstance.PushAsync(_popup, _animate);
		}

		public static void PushSnack(string _message, double _duration = 0.5)
		{

		}

		public static void PushToCurrentStack(ChContentPage _page)
			=> PushToStack(currentStack, _page);

		public static void PushToStack(NavStackEnum _targetEnum, ChContentPage _page)
		{
			var targetStack = ResolveStack(_targetEnum);
			var oldPage = targetStack.Peek();
			targetStack.Push(_page);

			if (_targetEnum != currentStack)
			{
				NavToStack(_targetEnum);
			}
			else
			{
				oldPage.SendDisappearing();
				_page.SendAppearing();
				homePageContainer.Content = _page;
			}
		}
	}

	public enum NavStackEnum
	{
		Home,
		Nav1,
		Nav2,
		Nav3,
		Debug,
	}
}
