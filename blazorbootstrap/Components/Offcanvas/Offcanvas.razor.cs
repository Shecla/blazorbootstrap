﻿using BlazorBootstrap.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorBootstrap
{
    public partial class Offcanvas : BaseComponent
    {
        #region Members

        private DotNetObjectReference<Offcanvas> objRef;

        #endregion Members

        #region Methods

        protected override void BuildClasses(ClassBuilder builder)
        {
            builder.Append(BootstrapClassProvider.Offcanvas());
            builder.Append(BootstrapClassProvider.Offcanvas(Placement));
            builder.Append(BootstrapClassProvider.ToOffcanvasSize(Size));

            base.BuildClasses(builder);
        }

        protected override async Task OnInitializedAsync()
        {
            objRef ??= DotNetObjectReference.Create(this);
            await base.OnInitializedAsync();

            ExecuteAfterRender(async () => { await JS.InvokeVoidAsync("window.blazorBootstrap.offcanvas.initialize", ElementId, UseBackdrop, CloseOnEscape, IsScrollable, objRef); });
        }

        /// <summary>
        /// Shows an offcanvas.
        /// </summary>
        public async Task ShowAsync()
        {
            await JS.InvokeVoidAsync("window.blazorBootstrap.offcanvas.show", ElementId);
        }

        /// <summary>
        /// Hides an offcanvas.
        /// </summary>
        public async Task HideAsync()
        {
            await JS.InvokeVoidAsync("window.blazorBootstrap.offcanvas.hide", ElementId);
        }

        /// <inheritdoc />
        protected override async ValueTask DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await JS.InvokeVoidAsync("window.blazorBootstrap.offcanvas.dispose", ElementId);
                objRef?.Dispose();
            }

            await base.DisposeAsync(disposing);
        }

        [JSInvokable] public async Task bsShowOffcanvas() => await OnShowing.InvokeAsync();
        [JSInvokable] public async Task bsShownOffcanvas() => await OnShown.InvokeAsync();
        [JSInvokable] public async Task bsHideOffcanvas() => await OnHiding.InvokeAsync();
        [JSInvokable] public async Task bsHiddenOffcanvas() => await OnHidden.InvokeAsync();

        #endregion Methods

        #region Properties

        /// <inheritdoc/>
        protected override bool ShouldAutoGenerateId => true;

        /// <summary>
        /// Text for the title in header.
        /// </summary>
        [Parameter] public string Title { get; set; }

        /// <summary>
        /// Content for the header.
        /// </summary>
        [Parameter] public RenderFragment HeaderTemplate { get; set; }

        /// <summary>
        /// Body content.
        /// </summary>
        [Parameter] public RenderFragment BodyTemplate { get; set; }

        /// <summary>
        /// Footer content.
        /// </summary>
        [Parameter] public RenderFragment FooterTemplate { get; set; }

        /// <summary>
        /// Specifies the placement.
        /// By default, offcanvas is placed on the right of the viewport.
        /// </summary>
        [Parameter] public Placement Placement { get; set; } = Placement.End;

        /// <summary>
        /// Size of the offcanvas. Default is <see cref="OffcanvasSize.Regular"/>.
        /// </summary>
        [Parameter] public OffcanvasSize Size { get; set; } = OffcanvasSize.Regular;

        /// <summary>
        /// Indicates whether the modal shows close button in header.
        /// Default value is true.
        /// Use <see cref="CloseButtonIcon"/> to change shape of the button.
        /// </summary>
        [Parameter] public bool ShowCloseButton { get; set; } = true;

        /// <summary>
        /// Indicates whether the offcanvas closes when escape key is pressed.
        /// Default value is true.
        /// </summary>
        [Parameter] public bool CloseOnEscape { get; set; } = true;

        /// <summary>
        /// Indicates whether to apply a backdrop on body while offcanvas is open.
        /// Default value is true.
        /// </summary>
        [Parameter] public bool UseBackdrop { get; set; } = true;

        /// <summary>
        /// Indicates whether body (page) scrolling is allowed while offcanvas is open.
        /// Default value is false.
        /// </summary>
        [Parameter] public bool IsScrollable { get; set; }

        /// <summary>
        /// Additional header CSS class.
        /// </summary>
        [Parameter] public string HeaderCssClass { get; set; }

        /// <summary>
        /// Additional body CSS class.
        /// </summary>
        [Parameter] public string BodyCssClass { get; set; }

        /// <summary>
        /// Additional footer CSS class.
        /// </summary>
        [Parameter] public string FooterCssClass { get; set; }

        /// <summary>
        /// This event fires immediately when the show instance method is called.
        /// </summary>
        [Parameter] public EventCallback OnShowing { get; set; }

        /// <summary>
        /// This event is fired when an offcanvas element has been made visible to the user (will wait for CSS transitions to complete).
        /// </summary>
        [Parameter] public EventCallback OnShown { get; set; }

        /// <summary>
        /// This event is fired immediately when the hide method has been called.
        /// </summary>
        [Parameter] public EventCallback OnHiding { get; set; }

        /// <summary>
        /// This event is fired when an offcanvas element has been hidden from the user (will wait for CSS transitions to complete).
        /// </summary>
        [Parameter] public EventCallback OnHidden { get; set; }

        #endregion Properties
    }
}
