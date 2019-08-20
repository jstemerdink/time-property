<%@ Import Namespace="AdvancedCms.TimeProperty" %>
<%@ Import Namespace="EPiServer.Web.Mvc.Html" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TimeSpan?>" %>
<% Html.RenderTimeSpan(Model); %>