using Application.Models.Pages;
using Application.Models.ViewModels;
using EPiServer.Data;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Application.Business;

[ServiceConfiguration]
public class PageViewContextFactory
{
	#region Fields

	private readonly IContentLoader _contentLoader;
	private readonly CookieAuthenticationOptions _cookieAuthenticationOptions;
	private readonly IDatabaseMode _databaseMode;
	private readonly UrlResolver _urlResolver;

	#endregion

	#region Constructors

	public PageViewContextFactory(
		IContentLoader contentLoader,
		UrlResolver urlResolver,
		IDatabaseMode databaseMode,
		IOptionsMonitor<CookieAuthenticationOptions> optionMonitor)
	{
		this._contentLoader = contentLoader;
		this._urlResolver = urlResolver;
		this._databaseMode = databaseMode;
		this._cookieAuthenticationOptions = optionMonitor.Get(IdentityConstants.ApplicationScheme);
	}

	#endregion

	#region Methods

	public virtual LayoutModel CreateLayoutModel(ContentReference currentContentLink, HttpContext httpContext)
	{
		var startPageContentLink = ContentReference.StartPage;

		// Use the content link with version information when editing the startpage,
		// otherwise the published version will be used when rendering the props below.
		if(currentContentLink.CompareToIgnoreWorkID(startPageContentLink))
		{
			startPageContentLink = currentContentLink;
		}

		var startPage = this._contentLoader.Get<StartPage>(startPageContentLink);

		return new LayoutModel
		{
			Logotype = startPage.SiteLogotype,
			LogotypeLinkUrl = new HtmlString(this._urlResolver.GetUrl(ContentReference.StartPage)),
			ProductPages = startPage.ProductPageLinks,
			CompanyInformationPages = startPage.CompanyInformationPageLinks,
			NewsPages = startPage.NewsPageLinks,
			CustomerZonePages = startPage.CustomerZonePageLinks,
			LoggedIn = httpContext.User.Identity.IsAuthenticated,
			LoginUrl = new HtmlString(this.GetLoginUrl(currentContentLink)),
			SearchActionUrl = new HtmlString(UrlResolver.Current.GetUrl(startPage.SearchPageLink)),
			IsInReadonlyMode = this._databaseMode.DatabaseMode == DatabaseMode.ReadOnly
		};
	}

	private string GetLoginUrl(ContentReference returnToContentLink)
	{
		return $"{this._cookieAuthenticationOptions?.LoginPath.Value ?? Globals.LoginPath}?ReturnUrl={this._urlResolver.GetUrl(returnToContentLink)}";
	}

	public virtual IContent GetSection(ContentReference contentLink)
	{
		var currentContent = this._contentLoader.Get<IContent>(contentLink);

		static bool isSectionRoot(ContentReference contentReference) =>
			ContentReference.IsNullOrEmpty(contentReference) ||
			contentReference.Equals(ContentReference.StartPage) ||
			contentReference.Equals(ContentReference.RootPage);

		if(isSectionRoot(currentContent.ParentLink))
		{
			return currentContent;
		}

		return this._contentLoader.GetAncestors(contentLink)
			.OfType<PageData>()
			.SkipWhile(x => !isSectionRoot(x.ParentLink))
			.FirstOrDefault();
	}

	#endregion
}