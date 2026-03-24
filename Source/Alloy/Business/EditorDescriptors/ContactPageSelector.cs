using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Application.Business.EditorDescriptors;

/// <summary>
/// Registers an editor to select a ContactPage for a PageReference property using a dropdown
/// </summary>
[EditorDescriptorRegistration(
	TargetType = typeof(ContentReference),
	UIHint = Globals.SiteUIHints.Contact)]
public class ContactPageSelector : EditorDescriptor
{
	#region Methods

	public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
	{
		this.SelectionFactoryType = typeof(ContactPageSelectionFactory);

		this.ClientEditingClass = "epi-cms/contentediting/editors/SelectionEditor";

		base.ModifyMetadata(metadata, attributes);
	}

	#endregion
}