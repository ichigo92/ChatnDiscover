﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="ChatnDiscover.Chat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/jquery.signalR-2.1.2.js"></script>
    <div class="custom_font" id="header">
        Chat Room
    </div>
    <br />
    <br />
    <br />

    <div id="divContainer">
        <%--<div id="divLogin" class="login">
            <div>
                Your Name:<br />
            <input id="txtNickName" runat="server" type="hidden" class="textBox" />
            </div>
            <div id="divButton">
                <%--<asp:Button runat="server" CssClass="submitButton" value="Start Chat" OnClick="click_me" />
                <input id="btnStartChat" type="button" class="submitButton" value="Start Chat" />

            </div>
        </div>--%>

        <div id="divChat" class="chatRoom">
            <div class="title">
                Welcome to Chat Room [<span id='spanUser'><asp:LoginName ID="LoginName1"  runat="server" /></span>]

            </div>
            <div class="content">
                <div id="divChatWindow" class="chatWindow">
                </div>
                <div id="divusers" class="users">
                </div>
            </div>
            <div class="messageBar">
                <input class="textbox" type="text" id="txtMessage" />
                <input id="btnSendMsg" type="button" value="Send" class="submitButton" />
            </div>
        </div>
        <input id="hidUsername" type="hidden" runat="server" />
        <input id="hdId" type="hidden"/>
        <input id="hdUserName" type="hidden" />
    </div>

    <script type="text/javascript">

        $(function () {

            //setScreen(true);

            // Declare a proxy to reference the hub. 

            var chatHub = $.connection.chatHub;

            registerClientMethods(chatHub);
            $.connection.hub.logging = true;
            // Start Hub
            $.connection.hub.start().done(function () {

                registerEvents(chatHub);
                    var name = $("#ContentPlaceHolder1_hidUsername").val();
                    if (name.length > 0) {
                        chatHub.server.connect(name);
                    }
                    else {
                        alert("Please enter name");
                    }


            });

        });

        //function setScreen(isLogin) {

        //    if (!isLogin) {

        //        $("#divChat").hide();
        //        $("#divLogin").show();
        //    }
        //    else {

        //        $("#divChat").show();
        //        $("#divLogin").hide();
        //    }

        //}

        //Funtions that Client is Calling
        function registerEvents(chatHub) {
           // When Start Chat is Clicked
            //$("#btnStartChat").click(function () {
            //    var name = $("#ContentPlaceHolder1_txtNickName").val(); //$("#ContentPlaceHolder1_hidUsername").val(); //
            //    if (name.length > 0) {
            //        chatHub.server.connect(name);
            //    }
            //    else {
            //        alert("Please enter name");
            //    }

            //});


            $('#btnSendMsg').click(function () {

                var msg = $("#txtMessage").val();
                if (msg.length > 0) {

                    var userName = $('#hdUserName').val();
                    chatHub.server.sendMessageToAll(userName, msg);
                    $("#txtMessage").val('');
                }
            });


            $("#txtNickName").keypress(function (e) {
                if (e.which == 13) {
                    $("#btnStartChat").click();
                }
            });

            $("#txtMessage").keypress(function (e) {
                if (e.which == 13) {
                    $('#btnSendMsg').click();
                }
            });


        }
        //Functions that server can call
        function registerClientMethods(chatHub) {

            // Calls when user successfully logged in
            chatHub.client.onConnected = function (id, userName, allUsers, messages) {

               // setScreen(true);

                $('#hdId').val(id);
                $('#hdUserName').val(userName);
                //$('#spanUser').html(userName);

                // Add All Users
                for (i = 0; i < allUsers.length; i++) {

                    AddUser(chatHub, allUsers[i].ConnectionId, allUsers[i].UserName);
                }

                // Add Existing Messages
                for (i = 0; i < messages.length; i++) {

                    AddMessage(messages[i].UserName, messages[i].Message);
                }


            }

            // On New User Connected
            chatHub.client.onNewUserConnected = function (id, name) {

                AddUser(chatHub, id, name);
            }


            // On User Disconnected
            chatHub.client.onUserDisconnected = function (id, userName) {

                $('#' + id).remove();

                var ctrId = 'private_' + id;
                $('#' + ctrId).remove();


                var disc = $('<div class="disconnect">"' + userName + '" logged off.</div>');

                $(disc).hide();
                $('#divusers').prepend(disc);
                $(disc).fadeIn(200).delay(2000).fadeOut(200);

            }

            chatHub.client.messageReceived = function (userName, message) {

                AddMessage(userName, message);
            }


            chatHub.client.sendPrivateMessage = function (windowId, fromUserName, message) {

                var ctrId = 'private_' + windowId;


                if ($('#' + ctrId).length == 0) {

                    createPrivateChatWindow(chatHub, windowId, ctrId, fromUserName);

                }

                $('#' + ctrId).find('#divMessage').append('<div class="message"><span class="userName">' + fromUserName + '</span>: ' + message + '</div>');

                // set scrollbar
                var height = $('#' + ctrId).find('#divMessage')[0].scrollHeight;
                $('#' + ctrId).find('#divMessage').scrollTop(height);

            }

        }

        function AddUser(chatHub, id, name) {

            var userId = $('#hdId').val();

            var code = "";

            if (userId == id) {

                code = $('<div class="loginUser">' + name + "</div>");

            }
            else {

                if (chatHub.server.checkStatus(name)) {
                    code = $('<a id="' + id + '" class="user" >' + name + '<a>');
                }
                else {
                    code = $('<a id="' + id + '" class="user" >' + name + '</a>'+'<input id="friend_plus" type="button" value="Friend +" class="submitButton" />');
                }
                $(code).dblclick(function () {

                    var id = $(this).attr('id');

                    if (userId != id)
                        OpenPrivateChatWindow(chatHub, id, name);

                });
            }

            $("#divusers").append(code);

        }

        function AddMessage(userName, message) {
            $('#divChatWindow').append('<div class="message"><span class="userName">' + userName + '</span>: ' + message + '</div>');

            var height = $('#divChatWindow')[0].scrollHeight;
            $('#divChatWindow').scrollTop(height);
        }

        function OpenPrivateChatWindow(chatHub, id, userName) {

            var ctrId = 'private_' + id;

            if ($('#' + ctrId).length > 0) return;

            createPrivateChatWindow(chatHub, id, ctrId, userName);

        }

        function createPrivateChatWindow(chatHub, userId, ctrId, userName) {

            var div = '<div id="' + ctrId + '" class="ui-widget-content draggable" rel="0">' +
                       '<div class="header">' +
                          '<div  style="float:right;">' +
                              '<img id="imgDelete"  style="cursor:pointer;" src="/Images/delete.png"/>' +
                           '</div>' +

                           '<span class="selText" rel="0">' + userName + '</span>' +
                       '</div>' +
                       '<div id="divMessage" class="messageArea">' +

                       '</div>' +
                       '<div class="buttonBar">' +
                          '<input id="txtPrivateMessage" class="msgText" type="text"   />' +
                          '<input id="btnSendMessage" class="submitButton button" type="button" value="Send"   />' +
                       '</div>' +
                    '</div>';

            var $div = $(div);

            // DELETE BUTTON IMAGE
            $div.find('#imgDelete').click(function () {
                $('#' + ctrId).remove();
            });

            // Send Button event
            $div.find("#btnSendMessage").click(function () {

                $textBox = $div.find("#txtPrivateMessage");
                var msg = $textBox.val();
                if (msg.length > 0) {

                    chatHub.server.sendPrivateMessage(userId, msg);
                    $textBox.val('');
                }
            });

            // Text Box event
            $div.find("#txtPrivateMessage").keypress(function (e) {
                if (e.which == 13) {
                    $div.find("#btnSendMessage").click();
                }
            });

            AddDivToContainer($div);

        }

        function AddDivToContainer($div) {
            $('#divContainer').prepend($div);

            $div.draggable({

                handle: ".header",
                stop: function () {

                }
            });

            ////$div.resizable({
            ////    stop: function () {

            ////    }
            ////});

        }

    </script>


    
</asp:Content>