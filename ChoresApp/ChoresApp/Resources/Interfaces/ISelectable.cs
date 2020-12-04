using System;

namespace ChoresApp.Resources.Interfaces
{
	public interface ISelectable
	{
		bool IsSelectable { get; set; }
		bool IsSelected { get; set; }

		event EventHandler<bool> IsSelectedChanged;
	}
}
