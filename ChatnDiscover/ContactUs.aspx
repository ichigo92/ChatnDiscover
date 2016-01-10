<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="ChatnDiscover.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .contact {
	        font-family: "Palatino Linotype", "Book Antiqua", Palatino, serif;
	        margin-top: 50px;
        }
        .font1 {
	        font-family: "Palatino Linotype", "Book Antiqua", Palatino, serif;
        }
        .input1
        {
	        background:#996666;
	        width:300px;
	        color:#f0f0f0;
	        }

        body
            {
                background: #666;
            }
        #form_contact{
          margin-top: 350px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="form_contact">
        <h1 class="contact" style="color:black"> Contact </h1>
        <p><span class="font1">First Name</span><br/>
         <asp:TextBox ID="txtfirstname" runat="server" CssClass="input1"></asp:TextBox>
          <asp:RequiredFieldValidator ID="requiredfieldfirtsname" runat="server" ErrorMessage="field required" ControlToValidate="txtfirstname" Visible="true"></asp:RequiredFieldValidator>
          <br/>
  
          <span class="font1">Last Name</span><br>
         <asp:TextBox ID="txtlastname" runat="server" CssClass="input1"></asp:TextBox>
          <asp:RequiredFieldValidator ID="requiredfieldlastname" runat="server" ErrorMessage="fireldrequired" ControlToValidate="txtlastname"></asp:RequiredFieldValidator> 
          <br />
  
          <span class="font1">Email</span><br/>
         <asp:TextBox ID="txtemail" runat="server" CssClass="input1"></asp:TextBox>
          <asp:RequiredFieldValidator ID="requiredfieldemail" runat="server" ErrorMessage="fireldrequired" ControlToValidate="txtemail"></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="wrong email format" ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
             <br/>
          <span class="font1"> Subject </span><br>
          <asp:TextBox ID="txtsubject" runat="server" CssClass="input1"></asp:TextBox>
          <asp:RequiredFieldValidator ID="requiredfieldsubject" runat="server" ErrorMessage="fireldrequired" ControlToValidate="txtsubject"></asp:RequiredFieldValidator> 
          <br>
          <span class="font1">Message</span><br>
         <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine" CssClass="input1" Rows="7" Columns="5"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldmessage" runat="server" ErrorMessage="fireldrequired" ControlToValidate="txtmessage"></asp:RequiredFieldValidator> 
         <br />
          <asp:Button runat="server" ID="sumit" Text="Submit" OnClick="sumit_Click" />
        </p>
        </div>
</asp:Content>
