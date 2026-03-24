using EPiServer.ServiceLocation;

namespace Application.Business.Extensions;

/// <summary>
/// Provides extension methods for types intended to be used when working with page types
/// </summary>
public static class TypeExtension
{
	#region Nested types

	extension(Type type)
	{
		#region Methods

		public ContentType GetContentType()
		{
			var contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();

			return contentTypeRepository.Load(type);
		}

		/// <summary>
		/// Returns the definition for a specific page type
		/// </summary>
		/// <returns></returns>
		public PageType GetPageType()
		{
			return type.GetContentType() as PageType;
		}

		#endregion
	}

	#endregion
}