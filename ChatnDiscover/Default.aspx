﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChatnDiscover.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="row" id="home">
            <div class="col-md-6 col-md-offset-4 div_intro custom_font">
                <img src="images/chatting_icon2.png" class="img-responsive" style=" margin-left:10%;"/>
                <h3 style=" margin-left:25%;">Welcome!!</h3>
                <p>Cn'D is a way for you to chat with friends and discover new ones</p>
            </div>
        </section><!--end-home-->

        <section class="row" id="features">
            <div class="col-md-6 col-md-offset-4 div_features custom_font">
                <h2 style="margin-left:25%;">Features!!</h2>
            </div>

            <div class="row">
                <div class="media col-md-6 custom_font">
                  <a class="media-left" href="#">
                    <img class="img-responsive" src="images/blends.png" alt="...">
                  </a>
                  <div class="media-body">
                    <h4 class="media-heading" style="margin-top:10%">Blends into any site</h4>
                    <p>Fit the look and feel of your site. Available in different form factors: Box, or compact Ticker and Tab formats. Customizable color scheme, borders, transparency, corner radius, size, user images size and much more</p>
                  </div>
                </div>

                <div class="media col-md-6 custom_font">
                  <a class="media-left" href="#">
                    <img class="img-responsive" src="images/devices.png" alt="...">
                  </a>
                  <div class="media-body">
                    <h4 class="media-heading" style="margin-top:10%">Works on all devices</h4>
                    <p>Optimized to work on mobile, tablets and desktop</p>
                  </div>
                </div>
             </div><!--end-row--1-->

            <div class="row">
                <div class="media col-md-6 custom_font">
                  <a class="media-left" href="#">
                    <img class="img-responsive" src="images/fast.png" alt="...">
                  </a>
                  <div class="media-body">
                    <h4 class="media-heading" style="margin-top:10%">Fast</h4>
                    <p>Handles traffic spikes for breaking live events. Administrators can set a message rate limit per user, to keep large groups readable</p>
                  </div>
                </div>

                <div class="media col-md-6 custom_font">
                  <a class="media-left" href="#">
                    <img class="img-responsive" src="images/family.png" alt="...">
                  </a>
                  <div class="media-body">
                    <h4 class="media-heading" style="margin-top:10%">Family Friendly</h4>
                    <p>Meaningless posts are automatically stopped using machine text analysis. Intelligently matched banned words resilient to misspellings. Administrators control posting images, links or videos. Optional anonymity: administrators decide whether anonymous participants are allowed. Moderator bans are hard to evade</p>
                  </div>
                </div>
             </div><!--end-row--2-->
        </section><!--end-features-->

        <section class="row custom_font" id="who_are_we">
            <div class="col-md-6 col-md-offset-4 div_who_are_we custom_font">
                <h2 style="margin-left:25%;">Who are we??</h2>
            </div>
            
            <div class="row">
                <div class="col-lg-6">
                    <img src="images/ichigo-insanity.png" class="img-responsive" style="margin-left:40.5%;" />
                    <h3 style="margin-left:50%;">Abdul Fatir</h3>
                </div><!--end-col-md-6-first-->

                <div class="col-lg-6">
                    <img src="images/donquixote-doflamingo.png" class="img-responsive" style="margin-left:40.5%;" />
                    <h3 style="margin-left:50%;">Faheem Sultan</h3>
                </div><!--end-col-md-6-second-->

            </div><!--end-row-->
        </section><!--end-who_are_we-->


</asp:Content>
