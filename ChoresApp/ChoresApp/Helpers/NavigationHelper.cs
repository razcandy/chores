using ChoresApp.Debug;
using ChoresApp.Pages;
using System;
using System.Collections.Generic;
using System.Text;
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
		private static ContentView mainPageContainer;

		// Events & Handlers ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

		// Methods ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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

		public static void InitStacks(MainPage _mainPage)
		{
			homeStack.Push(_mainPage.HomeContent);
			nav1Stack.Push(_mainPage.Nav1Content);
			nav2Stack.Push(_mainPage.Nav2Content);
			nav3Stack.Push(_mainPage.Nav3Content);

#if DEBUG
			debugStack.Push(new DebugPage());
#endif

			mainPageContainer = _mainPage.PageContent;

			mainPageContainer.Content = _mainPage.HomeContent;
			_mainPage.HomeContent.SendAppearing();

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
			mainPageContainer.Content = targetPage;
			currentStack = _targetStack;
		}

		public static void Pop()
		{

		}

		public static void Pop(Page _page)
		{

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
			mainPageContainer.Content = top;
		}

		public static void PopFromCurrentStack() => PopFromStack(currentStack);

		public static void PushAlert(string _message, double _duration = 0.5)
		{

		}

		public static void PushPage(Page _page)
		{
			_page.Navigation.PushAsync(_page);
		}

		public static async void PushPage(ChPageBase _page)
		{
			var contentPage = new ContentPage
			{
				Content = _page,
			};

			//if (MainThread.IsMainThread)
			//{
			//	contentPage.Navigation.PushAsync(contentPage);
			//}
			//else
			//{
			//	MainThread.BeginInvokeOnMainThread(() =>
			//	{
			//		contentPage.Navigation.PushAsync(contentPage);
			//	});
			//}

			await App.Current.MainPage.Navigation.PushAsync(contentPage);
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
				mainPageContainer.Content = _page;
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
