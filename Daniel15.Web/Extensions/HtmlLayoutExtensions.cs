﻿using System;
using System.Collections.Generic;
using Daniel15.Web.Controllers;
using Daniel15.Web.Models.Shared;
using Daniel15.Web.ViewModels;
using Microsoft.AspNet.Mvc.Rendering;

namespace Daniel15.Web.Extensions
{
	/// <summary>
	/// <see cref="HtmlHelper"/> extensions for rendering of the page
	/// </summary>
	public static class HtmlLayoutExtensions
	{
		/// <summary>
		/// Gets the value to use for the id attribute on the body tag
		/// </summary>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <returns>The ID</returns>
		public static string BodyId(this IHtmlHelper htmlHelper)
		{
			var routeData = htmlHelper.ViewContext.RouteData;
			var controller = ((string)routeData.Values["controller"]).ToLower();
			var action = ((string)routeData.Values["action"]).ToLower();
			object areaObj;
			routeData.DataTokens.TryGetValue("area", out areaObj);
			var area = (string)areaObj;

			if (!string.IsNullOrEmpty(area))
				return area.ToLower() + "-" + controller + "-" + action;
			else
				return controller + "-" + action;
		}

		/// <summary>
		/// Gets the value to use for the class attribute on the body tag
		/// </summary>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <returns>The class</returns>
		public static string BodyClass(this IHtmlHelper<ViewModelBase> htmlHelper)
		{
			var classes = new List<string>
			{
				((string)htmlHelper.ViewContext.RouteData.Values["controller"]).ToLower(),
				"col-" + htmlHelper.ViewData.Model.SidebarType.ToString().ToLower()
			};
			return string.Join(" ", classes);
		}

		/// <summary>
		/// Renders the top menu
		/// </summary>
		/// <param name="htmlHelper">The HTML helper.</param>
		/// <returns>Text for the top menu</returns>
		public static HtmlString Menu(this IHtmlHelper htmlHelper)
		{
			return new HtmlString("TODO");
			/*var controller = htmlHelper.ViewContext.Controller;
			var action = htmlHelper.ViewContext.RouteData.GetRequiredString("action").ToLower();

			// TODO: Where should these actually be? Probably in a model.
			// TODO: Should these be using UrlHelper?
			var menuItems = new List<MenuItemModel>
			{
				new MenuItemModel
				{
					Url = "", 
					Title = "Home", 
					Active = controller is SiteController && action == "index"
				},
				new MenuItemModel
				{
					Url = "projects", 
					Title = "Projects", 
					Active = controller is ProjectController
				},
				new MenuItemModel
				{
					Url = "blog", 
					Title = "Blog", 
					Active = controller is BlogController
				},
				new MenuItemModel
				{
					Url = "http://daaniel.com/", 
					Title = "Thoughts", 
					Active = false
				},
			};

			return htmlHelper.Partial(MVC.Shared.Views._Menu, menuItems);*/
		}

		/// <summary>
		/// Retrieves the content of the blog sidebar
		/// </summary>
		/// <param name="htmlHelper">HTML helper</param>
		/// <returns>HTML for the blog sidebar</returns>
		public static HtmlString BlogSidebar(this IHtmlHelper htmlHelper)
		{
			return new HtmlString("TODO");
			/*return htmlHelper.ViewContext.HttpContext.Cache.GetOrInsert("BlogSidebar", DateTime.UtcNow.AddDays(1), null,
			                                                            () => htmlHelper.Action(MVC.BlogPartials.Sidebar()));*/
		}
	}
}