<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication2.login" %>
<%@ MasterType virtualpath="~/Site1.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    
    
      <style>
          #bb {
              /*background-image: url("~/css/background1.jpg");*/
             background-color : whitesmoke;
            
          }  
    </style>   
            <div   style="text-align: center";  >
           <div  style="width: 300px; margin-left: auto; margin-right:auto;">
            <br /><br /><br /><br /><br /><br />
               <asp:Panel ID="Panel2" runat="server" BorderStyle="Double" BackColor="#6D6E71"> <br />
               <asp:Label ID="Label1" runat="server" Text="PERDORUESI" Font-Size="Large" Font-Bold="False" ForeColor="White"></asp:Label>   <br />
                 <asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium"></asp:TextBox>
               
                 <br />
                   <asp:Label ID="Label4" runat="server" Text="FJALEKALIMI" Font-Size="Large" Font-Bold="False" ForeColor="White"></asp:Label>
                 <br />
                 <asp:TextBox ID="TextBox2" runat="server" Font-Size="Medium" TextMode="Password"></asp:TextBox> <br /><br />
                 <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="HYR" Width="127px" Font-Bold="True" Font-Size="Medium" BackColor="#5895B6" />
                   <br /><br />
               </asp:Panel>
             
               
    </div>
               <div>
                   <asp:Image ID="Image1" runat="server" ImageUrl="~/css/logo_origjinaleCopy.png" /> 
               </div>
    </div>
        
</asp:Content>
