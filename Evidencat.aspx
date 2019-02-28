<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Evidencat.aspx.cs" Inherits="WebApplication2.Evidencat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
function CallPrint()
{
    var img = document.getElementById('<%= Image1.ClientID %>');
    var prtContentviti = document.getElementById('<%= vitiddl_v.ClientID %>');
    var prtContentklasa = document.getElementById('<%= klasaddl_v.ClientID %>');
    var prtContentindeksi = document.getElementById('<%= indeksiddl_v.ClientID %>');

    img.style.display = 'inline';

    var prtContent2 = document.getElementById('Div1');
     var grdView = '<%= GridView1.ClientID %>'
           var prtContent = document.getElementById(grdView);
            var emri = '<%= Session["emri"] %>';
           var html = "<p style=\"text-align:center;\">"+
                      prtContent2.innerHTML + "</p>" +
                     "<p style=\"text-align:center;\">" + "SHKOLLA : " + emri + "</p>"+
                      "<br><br>" +
                      "VITI SHKOLLOR : " + prtContentviti.options[prtContentviti.selectedIndex].text + "<br>" +
                      "EVIDENCA KLASA " + prtContentklasa.options[prtContentklasa.selectedIndex].text + prtContentindeksi.options[prtContentindeksi.selectedIndex].text +
                     "<table cellspacing=0 border width=100%>" +
                     "</td></tr>"  +                                         
                      "<thead>" +
                      //"<tr><td colspan=4 bgcolor=lightblue>" +                     
                      "</td></tr>" +
                      "</thead>" +
                      prtContent.innerHTML + 
                      "</table>"  ; 
           console.log(html);
           var WinPrint = window.open('', '', 'letf=0,top=0,width=1000px,height=600px,toolbar=0,scrollbars=0,status=0');
           WinPrint.document.write(html);
           WinPrint.document.close();
           WinPrint.focus();
           WinPrint.print();
           WinPrint.close();
   <%-- var prtContent2 = document.getElementById('<%=GridView1.ClientID %>')--%>
 //var WinPrint = window.open('','','letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
// WinPrint.document.write(prtContent.innerHTML);
 ////WinPrint.document.write(prtContent2.outerHTML);
 //WinPrint.document.close();
 //WinPrint.focus();
 //WinPrint.print();
 //WinPrint.close();
 //prtContent.innerHTML=strOldOne;
}
</script>
  
     <div id = "Div1">
         <asp:Image ID="Image1"   runat="server" Height="100px" Width="100px" style="display: none;" />
   </div>

     <div>
   </div>

      <div>
   </div>

      <div>
          <table style="width:100%;">
              <tr>
                  <td style="width: 10px"><span style="font-size: medium"></td>
                  <td style="width: 667px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 667px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 667px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 667px; font-size: medium;">
                      <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Underline="True" style="font-size: medium" Text="EVIDENCA"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px; height: 20px;"></td>
                  <td style="width: 667px; height: 20px;"></td>
                  <td style="height: 20px"></td>
                  <td style="height: 20px"></td>
                  <td style="height: 20px"></td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 667px">
                      <asp:DropDownList ID="vitiddl_v" runat="server" AutoPostBack="True" OnSelectedIndexChanged="vitiddl_v_SelectedIndexChanged" style="font-size: medium">
                          <asp:ListItem>2016-2017</asp:ListItem>
                          <asp:ListItem>2017-2018</asp:ListItem>
                          <asp:ListItem>2018-2019</asp:ListItem>
                          <asp:ListItem>2019-2020</asp:ListItem>
                          <asp:ListItem>2020-2021</asp:ListItem>
                          <asp:ListItem>2021-2022</asp:ListItem>
                          <asp:ListItem>2022-2023</asp:ListItem>
                          <asp:ListItem>2023-2024</asp:ListItem>
                          <asp:ListItem>2024-2025</asp:ListItem>
                          <asp:ListItem>2025-2026</asp:ListItem>
                          <asp:ListItem>2026-2027</asp:ListItem>
                          <asp:ListItem>2027-2028</asp:ListItem>
                          <asp:ListItem>2028-2029</asp:ListItem>
                          <asp:ListItem>2029-2030</asp:ListItem>
                          <asp:ListItem>2030-2031</asp:ListItem>
                          <asp:ListItem>2031-2032</asp:ListItem>
                          <asp:ListItem>2032-2033</asp:ListItem>
                      </asp:DropDownList>
                      <asp:DropDownList ID="klasaddl_v" runat="server" OnSelectedIndexChanged="klasaddl_v_SelectedIndexChanged" AutoPostBack="True" style="font-size: medium">
                          <asp:ListItem>1</asp:ListItem>
                          <asp:ListItem>2</asp:ListItem>
                          <asp:ListItem>3</asp:ListItem>
                          <asp:ListItem>4</asp:ListItem>
                          <asp:ListItem>5</asp:ListItem>
                          <asp:ListItem>6</asp:ListItem>
                          <asp:ListItem>7</asp:ListItem>
                          <asp:ListItem>8</asp:ListItem>
                          <asp:ListItem>9</asp:ListItem>
                          <asp:ListItem>10</asp:ListItem>
                          <asp:ListItem>11</asp:ListItem>
                          <asp:ListItem>12</asp:ListItem>
                      </asp:DropDownList>
                      <asp:DropDownList ID="indeksiddl_v" runat="server" AutoPostBack="True" OnSelectedIndexChanged="indeksiddl_v_SelectedIndexChanged" style="font-size: medium">
                          <asp:ListItem>A</asp:ListItem>
                          <asp:ListItem>B</asp:ListItem>
                          <asp:ListItem>C</asp:ListItem>
                          <asp:ListItem>D</asp:ListItem>
                          <asp:ListItem>E</asp:ListItem>
                          <asp:ListItem>F</asp:ListItem>
                          <asp:ListItem>G</asp:ListItem>
                          <asp:ListItem>H</asp:ListItem>
                          <asp:ListItem>I</asp:ListItem>
                      </asp:DropDownList>
                              &nbsp;
                      <asp:ImageButton ID="ImageButton7" runat="server" ImageAlign="AbsBottom" ImageUrl="~/css/if_icon-125-printer-text_314822.png" OnClientClick ="CallPrint()" CausesValidation="False" />&nbsp&nbsp&nbsp
                      INTERVALI : <asp:TextBox ID="datepicker" runat="server" Width="90px"></asp:TextBox>&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="datepicker" ErrorMessage="*" ValidationGroup="data"></asp:RequiredFieldValidator>
&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/css/if_arrow_right_925929.png" />&nbsp
                      <asp:TextBox ID="datepicker0" runat="server" Width="90px"></asp:TextBox>&nbsp<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="datepicker0" ErrorMessage="*" ValidationGroup="data"></asp:RequiredFieldValidator>
&nbsp;<asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/css/if_search_925911.png" ImageAlign="Bottom" OnClick="ImageButton8_Click" style="width: 22px" ValidationGroup="data" />
                              </td>
                  <td>
                      &nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 667px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 667px">
                                         <link type="text/css" rel="stylesheet" href="css/style.css" />
                    
                      <asp:GridView ID="GridView1" runat="server" ShowHeader ="true"  RowStyle-Wrap ="false"  GridLines="None"
        CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" HorizontalAlign="Left" Width="174px" style="font-size: small" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25" AllowPrintPaging="true">
                    
                           <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                          <Columns>
                           <asp:TemplateField HeaderText="Nr.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                              </Columns>

<RowStyle Wrap="False"></RowStyle>
                          
                      </asp:GridView>
                      
                  </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 667px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      </span>
                              </td>
                  <td style="width: 667px">
                      &nbsp;</td>
                  </table>
          </div>
     <%-- kalendari--%>
      <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=datepicker]").datepicker({
                //showOn: 'button',
                //buttonImageOnly: true,
                ////buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });

           

        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id$=datepicker0]").datepicker({
                //showOn: 'button',
                //buttonImageOnly: true,
                ////buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
            });
        });
        </script>

     <%-- kalendari--%>
</asp:Content>
