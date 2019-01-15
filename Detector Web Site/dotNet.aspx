﻿<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Detector.Master" CodeBehind="dotNet.aspx.cs" Inherits="Detector.dotNet" EnableSessionState="True" EnableViewState="false" %>

<asp:Content runat="server" ID="Body" ContentPlaceHolderID="body">
    <p>This page provides the values .NET will report for properties of the HttpBrowserCapabilities class. Many of these properties are no longer relevent but are provided here for convenience.</p>
    <p>ActiveXControls <% =Request.Browser.ActiveXControls %></p>
    <p>Adapters:</p>
    <ul>
    <% var adapters = Request.Browser.Adapters.GetEnumerator(); %>
    <% while (adapters.MoveNext()) 
       { %>
        <li><% =adapters.Key.ToString() %> = <% =adapters.Value.ToString() %></li>
    <% } %>
    </ul>
    <p>AOL <% =Request.Browser.AOL %></p>
    <p>BackgroundSounds <% =Request.Browser.BackgroundSounds %></p>
    <p>Beta <% =Request.Browser.Beta %></p>
    <p>Browser <% =Request.Browser.Browser %></p>
    <p>Browsers:</p>
    <ul>
    <% var browsers = Request.Browser.Browsers.GetEnumerator(); %>
    <% while (browsers.MoveNext())
       { %>
        <li><% =browsers.Current.ToString() %></li>
    <% } %>
    </ul>
    <p>CanCombineFormsInDeck <% =Request.Browser.CanCombineFormsInDeck %></p>
    <p>CanInitiateVoiceCall <% =Request.Browser.CanInitiateVoiceCall %></p>
    <p>CanRenderAfterInputOrSelectElement <% =Request.Browser.CanRenderAfterInputOrSelectElement %></p>
    <p>CanRenderEmptySelects <% =Request.Browser.CanRenderEmptySelects %></p>
    <p>CanRenderInputAndSelectElementsTogether <% =Request.Browser.CanRenderInputAndSelectElementsTogether %></p>
    <p>CanRenderMixedSelects <% =Request.Browser.CanRenderMixedSelects %></p>
    <p>CanRenderOneventAndPrevElementsTogether <% =Request.Browser.CanRenderOneventAndPrevElementsTogether %></p>
    <p>CanRenderPostBackCards <% =Request.Browser.CanRenderPostBackCards %></p>
    <p>CanRenderSetvarZeroWithMultiSelectionList <% =Request.Browser.CanRenderSetvarZeroWithMultiSelectionList %></p>
    <p>CanSendMail <% =Request.Browser.CanSendMail %></p>
    <p>Capabilities <% =Request.Browser.Capabilities %></p>
    <p>CDF <% =Request.Browser.CDF %></p>
    <p>ClrVersion <% =Request.Browser.ClrVersion %></p>
    <p>Cookies <% =Request.Browser.Cookies %></p>
    <p>Crawler <% =Request.Browser.Crawler %></p>
    <p>DefaultSubmitButtonLimit <% =Request.Browser.DefaultSubmitButtonLimit %></p>
    <p>EcmaScriptVersion <% =Request.Browser.EcmaScriptVersion %></p>
    <p>Frames <% =Request.Browser.Frames %></p>
    <p>GatewayMajorVersion <% =Request.Browser.GatewayMajorVersion %></p>
    <p>GatewayMinorVersion <% =Request.Browser.GatewayMinorVersion %></p>
    <p>GatewayVersion <% =Request.Browser.GatewayVersion %></p>
    <p>HasBackButton <% =Request.Browser.HasBackButton %></p>
    <p>HidesRightAlignedMultiselectScrollbars <% =Request.Browser.HidesRightAlignedMultiselectScrollbars %></p>
    <p>HtmlTextWriter <% =Request.Browser.HtmlTextWriter %></p>
    <p>Id <% =Request.Browser.Id %></p>
    <p>InputType <% =Request.Browser.InputType %></p>
    <p>IsColor <% =Request.Browser.IsColor %></p>
    <p>IsMobileDevice <% =Request.Browser.IsMobileDevice %></p>
    <p>JavaApplets <% =Request.Browser.JavaApplets %></p>
    <p>JavaScript <% =Request.Browser.JavaScript %></p>
    <p>JScriptVersion <% =Request.Browser.JScriptVersion %></p>
    <p>MajorVersion <% =Request.Browser.MajorVersion %></p>
    <p>MaximumHrefLength <% =Request.Browser.MaximumHrefLength %></p>
    <p>MaximumRenderedPageSize <% =Request.Browser.MaximumRenderedPageSize %></p>
    <p>MaximumSoftkeyLabelLength <% =Request.Browser.MaximumSoftkeyLabelLength %></p>
    <p>MinorVersion <% =Request.Browser.MinorVersion %></p>
    <p>MinorVersionString <% =Request.Browser.MinorVersionString %></p>
    <p>MobileDeviceManufacturer <% =Request.Browser.MobileDeviceManufacturer %></p>
    <p>MobileDeviceModel <% =Request.Browser.MobileDeviceModel %></p>
    <p>MSDomVersion <% =Request.Browser.MSDomVersion %></p>
    <p>NumberOfSoftkeys <% =Request.Browser.NumberOfSoftkeys %></p>
    <p>Platform <% =Request.Browser.Platform %></p>
    <p>PreferredImageMime <% =Request.Browser.PreferredImageMime %></p>
    <p>PreferredRenderingMime <% =Request.Browser.PreferredRenderingMime %></p>
    <p>PreferredRenderingType <% =Request.Browser.PreferredRenderingType %></p>
    <p>PreferredRequestEncoding <% =Request.Browser.PreferredRequestEncoding %></p>
    <p>PreferredResponseEncoding <% =Request.Browser.PreferredResponseEncoding %></p>
    <p>RendersBreakBeforeWmlSelectAndInput <% =Request.Browser.RendersBreakBeforeWmlSelectAndInput %></p>
    <p>RendersBreaksAfterHtmlLists <% =Request.Browser.RendersBreaksAfterHtmlLists %></p>
    <p>RendersBreaksAfterWmlAnchor <% =Request.Browser.RendersBreaksAfterWmlAnchor %></p>
    <p>RendersBreaksAfterWmlInput <% =Request.Browser.RendersBreaksAfterWmlInput %></p>
    <p>RendersWmlDoAcceptsInline <% =Request.Browser.RendersWmlDoAcceptsInline %></p>
    <p>RendersWmlSelectsAsMenuCards <% =Request.Browser.RendersWmlSelectsAsMenuCards %></p>
    <p>RequiredMetaTagNameValue <% =Request.Browser.RequiredMetaTagNameValue %></p>
    <p>RequiresAttributeColonSubstitution <% =Request.Browser.RequiresAttributeColonSubstitution %></p>
    <p>RequiresContentTypeMetaTag <% =Request.Browser.RequiresContentTypeMetaTag %></p>
    <p>RequiresControlStateInSession <% =Request.Browser.RequiresControlStateInSession %></p>
    <p>RequiresDBCSCharacter <% =Request.Browser.RequiresDBCSCharacter %></p>
    <p>RequiresHtmlAdaptiveErrorReporting <% =Request.Browser.RequiresHtmlAdaptiveErrorReporting %></p>
    <p>RequiresLeadingPageBreak <% =Request.Browser.RequiresLeadingPageBreak %></p>
    <p>RequiresNoBreakInFormatting <% =Request.Browser.RequiresNoBreakInFormatting %></p>
    <p>RequiresOutputOptimization <% =Request.Browser.RequiresOutputOptimization %></p>
    <p>RequiresPhoneNumbersAsPlainText <% =Request.Browser.RequiresPhoneNumbersAsPlainText %></p>
    <p>RequiresSpecialViewStateEncoding <% =Request.Browser.RequiresSpecialViewStateEncoding %></p>
    <p>RequiresUniqueFilePathSuffix <% =Request.Browser.RequiresUniqueFilePathSuffix %></p>
    <p>RequiresUniqueHtmlCheckboxNames <% =Request.Browser.RequiresUniqueHtmlCheckboxNames %></p>
    <p>RequiresUniqueHtmlInputNames <% =Request.Browser.RequiresUniqueHtmlInputNames %></p>
    <p>RequiresUrlEncodedPostfieldValues <% =Request.Browser.RequiresUrlEncodedPostfieldValues %></p>
    <p>ScreenBitDepth <% =Request.Browser.ScreenBitDepth %></p>
    <p>ScreenCharactersHeight <% =Request.Browser.ScreenCharactersHeight %></p>
    <p>ScreenCharactersWidth <% =Request.Browser.ScreenCharactersWidth %></p>
    <p>ScreenPixelsHeight <% =Request.Browser.ScreenPixelsHeight %></p>
    <p>ScreenPixelsWidth <% =Request.Browser.ScreenPixelsWidth %></p>
    <p>SupportsAccesskeyAttribute <% =Request.Browser.SupportsAccesskeyAttribute %></p>
    <p>SupportsBodyColor <% =Request.Browser.SupportsBodyColor %></p>
    <p>SupportsBold <% =Request.Browser.SupportsBold %></p>
    <p>SupportsCacheControlMetaTag <% =Request.Browser.SupportsCacheControlMetaTag %></p>
    <p>SupportsCallback <% =Request.Browser.SupportsCallback %></p>
    <p>SupportsCss <% =Request.Browser.SupportsCss %></p>
    <p>SupportsDivAlign <% =Request.Browser.SupportsDivAlign %></p>
    <p>SupportsDivNoWrap <% =Request.Browser.SupportsDivNoWrap %></p>
    <p>SupportsEmptyStringInCookieValue <% =Request.Browser.SupportsEmptyStringInCookieValue %></p>
    <p>SupportsFontColor <% =Request.Browser.SupportsFontColor %></p>
    <p>SupportsFontName <% =Request.Browser.SupportsFontName %></p>
    <p>SupportsFontSize <% =Request.Browser.SupportsFontSize %></p>
    <p>SupportsImageSubmit <% =Request.Browser.SupportsImageSubmit %></p>
    <p>SupportsIModeSymbols <% =Request.Browser.SupportsIModeSymbols %></p>
    <p>SupportsInputIStyle <% =Request.Browser.SupportsInputIStyle %></p>
    <p>SupportsInputMode <% =Request.Browser.SupportsInputMode %></p>
    <p>SupportsItalic <% =Request.Browser.SupportsItalic %></p>
    <p>SupportsJPhoneMultiMediaAttributes <% =Request.Browser.SupportsJPhoneMultiMediaAttributes %></p>
    <p>SupportsJPhoneSymbols <% =Request.Browser.SupportsJPhoneSymbols %></p>
    <p>SupportsQueryStringInFormAction <% =Request.Browser.SupportsQueryStringInFormAction %></p>
    <p>SupportsRedirectWithCookie <% =Request.Browser.SupportsRedirectWithCookie %></p>
    <p>SupportsSelectMultiple <% =Request.Browser.SupportsSelectMultiple %></p>
    <p>SupportsUncheck <% =Request.Browser.SupportsUncheck %></p>
    <p>SupportsXmlHttp <% =Request.Browser.SupportsXmlHttp %></p>
    <p>Tables <% =Request.Browser.Tables %></p>
    <p>TagWriter <% =Request.Browser.TagWriter %></p>
    <p>Type <% =Request.Browser.Type %></p>
    <p>UseOptimizedCacheKey <% =Request.Browser.UseOptimizedCacheKey %></p>
    <p>VBScript <% =Request.Browser.VBScript %></p>
    <p>Version <% =Request.Browser.Version %></p>
    <p>W3CDomVersion <% =Request.Browser.W3CDomVersion %></p>
    <p>Win16 <% =Request.Browser.Win16 %></p>
    <p>Win32 <% =Request.Browser.Win32 %></p>
</asp:Content>
