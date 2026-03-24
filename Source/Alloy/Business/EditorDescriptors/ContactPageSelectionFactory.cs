using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;

namespace Application.Business.EditorDescriptors;

/// <summary>
/// Provides a list of options corresponding to ContactPage pages on the site
/// </summary>
/// <seealso cref="ContactPageSelector"/>
[ServiceConfiguration]
public class ContactPageSelectionFactory : ISelectionFactory
{
	#region Fields

	private readonly ContentLocator _contentLocator;

	#endregion

	#region Constructors

	public ContactPageSelectionFactory(ContentLocator contentLocator)
	{
		this._contentLocator = contentLocator;
	}

	#endregion

	#region Methods

	public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
	{
		var contactPages = this._contentLocator.GetContactPages();

		return new List<SelectItem>(contactPages.Select(c => new SelectItem { Value = c.ContentLink, Text = c.Name }));
	}

	#endregion
}