﻿using Microsoft.AspNetCore.Components;

namespace BlazorBootstrap.Demo;

public partial class MetaTags : ComponentBase
{
    #region Members

    private string siteName => "Blazor.Bootstrap";

    private string title => $"{Title} - {siteName}";

    private string url => $"https://demos.getblazorbootstrap.com{PageUrl}";

    #endregion

    #region Methods

    #endregion

    #region Properties

    /// <summary>
    /// Meta Url.
    /// Example: /alerts, /modal
    /// </summary>
    [Parameter] public string PageUrl { get; set; }

    /// <summary>
    /// Page Title / Meta Title.
    /// </summary>
    [Parameter] public string Title { get; set; }

    /// <summary>
    /// Meta Description.
    /// </summary>
    [Parameter] public string Description { get; set; }

    /// <summary>
    /// Meta Image Url.
    /// </summary>
    [Parameter] public string ImageUrl { get; set; }

    #endregion
}
