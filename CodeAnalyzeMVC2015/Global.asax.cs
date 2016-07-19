﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CodeAnalyzeMVC2015
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls;
           // System.Threading.Timer ChatRoomsCleanerTimer = new System.Threading.Timer(new TimerCallback(ChatEngine.CleanChatRooms), null, 1200000, 1200000);

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 45;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            try
            {
                if (Request.Url.ToString().ToLower().Contains("soln.aspx?qid=") ||
                    Request.Url.ToString().ToLower().Contains("xcode.aspx?qid=") ||
                    Request.Url.ToString().ToLower().Contains("android.aspx?qid=") ||
                    Request.Url.ToString().ToLower().Contains("angularjs.aspx?qid=") ||

                    Request.Url.ToString().ToLower().Contains("csharp.aspx?qid=") ||
                   Request.Url.ToString().ToLower().Contains("dotnet.aspx?qid=") ||
                    Request.Url.ToString().ToLower().Contains("jquery.aspx?qid=") ||

                    Request.Url.ToString().ToLower().Contains("mvc.aspx?qid=") ||
                    Request.Url.ToString().ToLower().Contains("aspnet.aspx?qid=") ||
                    Request.Url.ToString().ToLower().Contains("sql.aspx?qid=") ||
                    Request.Url.ToString().ToLower().Contains("java.aspx?qid=")
                    )
                {
                    string strId = Request.QueryString["QId"];
                    string strTitle = Request.QueryString["QT"];

                    System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 -]");
                    strTitle = rgx.Replace(strTitle, "");

                    Response.Redirect("/Que/Ans/" + strId + "/" + strTitle);
                }
                //else if (Request.Url.ToString().ToLower().Contains("/va.aspx?qid="))
                //{
                //string strId = Request.QueryString["QId"];
                //string strTitle = Request.QueryString["QT"];

                //strTitle = strTitle.Replace(" ", "-");

                //System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9 -]");
                //strTitle = rgx.Replace(strTitle, "");

                //Response.Redirect("/Articles/Details/" + strId + "/" + strTitle);
                //}
                //if (Request.Url.ToString().ToLower().Contains("/questions/soln/"))
                //{
                //    string strURL = Request.Url.ToString().ToLower().Replace("/questions/soln/", "/que/ans/");
                //    Response.Redirect(strURL);
                //}
                //else if (Request.Url.ToString().ToLower().Contains("/questions/unans"))
                //{
                //    string strURL = Request.Url.ToString().ToLower().Replace("/questions/unans", "/que/unans");
                //    Response.Redirect(strURL);
                //}
                //else if (Request.Url.ToString().ToLower().Contains("/unanswered.aspx"))
                //{
                //    Response.Redirect("/Que/Unans");
                //}
                //else if (Request.Url.ToString().ToLower().Contains("/articles.aspx"))
                //{
                //    Response.Redirect("/Articles/Index");
                //}
                //else if (Request.Url.ToString().ToLower().Contains("/mvc.aspx"))
                //{
                //    Response.Redirect("/Que/Unans");
                //}
                else if (Request.Url.ToString().ToLower().Contains("/postingguidelines.aspx"))
                {
                    Response.Redirect("/Home/Postingguidelines");
                }
                else if (Request.Url.ToString().ToLower().Contains("eval(chr(100).chr(105).chr(101).chr(40).chr(39).chr(49).chr(55).chr(73).chr(53).chr(51).chr(48).chr(86).chr(65).chr(117).chr(52).chr(39).chr(41).chr(59)"))
                {
                    Response.Redirect("/Que/Unans");
                }
                //else if (Request.Url.ToString().ToLower().Contains("/questions/upvote") ||
                //    Request.Url.ToString().ToLower().Contains("/questions/downvote"))
                //{
                //    if (Request.Url.ToString().Contains("localhost"))
                //       HttpContext.Current.Response.Redirect("/CodeAnalyzeMVC2015/Home/NotFound");
                //   else
                //        HttpContext.Current.Response.Redirect("/Home/NotFound");
                //}
                //else if (Request.Url.ToString().ToLower().Contains("/credits.aspx"))
                //{
                //    Response.Redirect("/Home/Rewards");
                //}
                //else if (Request.Url.ToString().ToLower().Contains("/topics.aspx"))
                //{
                //    Response.Redirect("/Tutorials/Basics");
                //}
                //else if (Request.Url.ToString().ToLower().Contains("/info.aspx"))
                //{
                //    Response.Redirect("/Home/About");
                //}
                //else if (Request.Url.ToString().ToLower().Contains("/userprofile.aspx"))
                //{
                //    Response.Redirect("/Account/Users");
                //}
                //else if (Request.Url.ToString().ToLower().Contains("/suggestions.aspx"))
                //{
                //    Response.Redirect("/Home/Contact");
                //}
                //if (Request.Url.ToString().ToLower().Contains("/questions/post") ||
                //    Request.Url.ToString().ToLower().Contains("/account/register") ||
                //    Request.Url.ToString().ToLower().Contains("va.aspx") ||
                //    Request.Url.ToString().ToLower().Contains("soln.aspx")||
                //    Request.Url.ToString().ToLower().Contains("/artilces/details/home/rewards")||
                //    Request.Url.ToString().ToLower().Contains("codeanalyze.com/wp")||
                //    Request.Url.ToString().ToLower().Contains("codeanalyze.com/blog")||
                //    Request.Url.ToString().ToLower().Contains("codeanalyze.com/webresource.axd?"))
                //{
                //    if (Request.Url.ToString().Contains("localhost"))
                //        HttpContext.Current.Response.Redirect("/CodeAnalyzeMVC2015/Home/NotFound");
                //    else
                //       HttpContext.Current.Response.Redirect("/Home/NotFound");
                //}
            }
            catch
            {

            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                Exception ex = new Exception();
                ex = Server.GetLastError();
    
                // Code that runs when an unhandled error occurs
                Mail mail = new Mail();
                string strBody = "";
                
                if (HttpContext.Current != null)
                {
                    var varURL = HttpContext.Current.Request.Url;
                    strBody += "URL -- " + varURL + "<br /><br />";
                    try
                    {
                    string strReferer = Request.UrlReferrer.ToString();
                    strBody += "Previous URL -- " + strReferer + "<br /><br />";
                    }
                    catch
                    {
                        
                    }
                }

                if (!string.IsNullOrEmpty(ex.Message))
                    strBody += "Message -- " + ex.Message + "<br /><br />";
                if (!string.IsNullOrEmpty(ex.Source))
                    strBody += "Source -- " + ex.Source + "<br /><br />";
                if (ex.TargetSite != null)
                    strBody += "TargetSite -- " + ex.TargetSite + "<br /><br />";
                if (ex.Data != null)
                    strBody += "Data -- " + ex.Data + "<br /><br />";
                if (ex.InnerException != null)
                    strBody += "InnerException -- " + ex.InnerException + "<br /><br />";
                if (!string.IsNullOrEmpty(ex.Source))
                    strBody += "Source -- " + ex.Source + "<br /><br />";

                try
                {
                    strBody += "IP - " + Utilities.GetUserIP() + "<br /><br />";
                }
                catch
                {

                }

                try
                {
                    if (ex.GetType().ToString() != null)
                        strBody += "Type -- " + ex.GetType().ToString() + "<br />";
                    //if (ex.GetType().ToString() == "System.Web.HttpException")
                        //Response.Redirect("/Home/Error");
                }
                catch
                {

                }
                
                if (ex.StackTrace != null)
                strBody += " Stack Trace -- " + ex.StackTrace + " <br /><br />";
                
                mail.Body = strBody;
                mail.FromAdd = "admin@codeanalyze.com";
                mail.Subject = "Error";
                mail.ToAdd = "admin@codeanalyze.com";
                mail.IsBodyHtml = true;
                mail.SendMail();

                if (ex.Message.ToLower().Contains("the controller for path")
                    && ex.Message.ToLower().Contains("was not found or does not implement icontroller"))
                {
                     if (Request.Url.ToString().Contains("localhost"))
                        HttpContext.Current.Response.Redirect("/CodeAnalyzeMVC2015/Home/NotFound");
                    else
                        HttpContext.Current.Response.Redirect("/Home/NotFound");
                }
                else if (ex.Message.ToLower().Contains("a public action method")
                    && ex.Message.ToLower().Contains("was not found on controller"))
                {
                     if (Request.Url.ToString().Contains("localhost"))
                        HttpContext.Current.Response.Redirect("/CodeAnalyzeMVC2015/Home/NotFound");
                    else
                        HttpContext.Current.Response.Redirect("/Home/NotFound");
                }
                else if (ex.Message.ToLower().Contains("this is an invalid webresource request")
                    || ex.Message.ToLower().Contains("this is an invalid script resource request"))
                {
                    if (Request.Url.ToString().Contains("localhost"))
                        HttpContext.Current.Response.Redirect("/CodeAnalyzeMVC2015/Home/NotFound");
                    else
                        HttpContext.Current.Response.Redirect("/Home/NotFound");
                }
                //else if (Request.Url.ToString().ToLower().Contains("/questions/upvote") ||
                //    Request.Url.ToString().ToLower().Contains("/questions/downvote"))
                //{
                //    if (Request.Url.ToString().Contains("localhost"))
                //       HttpContext.Current.Response.Redirect("/CodeAnalyzeMVC2015/Home/NotFound");
                //   else
                //        HttpContext.Current.Response.Redirect("/Home/NotFound");
                //}
                else
                {
                    if (Request.Url.ToString().Contains("localhost"))
                        HttpContext.Current.Response.Redirect("/CodeAnalyzeMVC2015/Home/Error");
                    else
                        HttpContext.Current.Response.Redirect("/Home/Error");
                }
            }
            catch
            {
                HttpContext.Current.Response.Redirect("/Home/Error");
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
