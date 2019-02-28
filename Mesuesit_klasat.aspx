<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Mesuesit_klasat.aspx.cs" Inherits="WebApplication2.Mesuesit_klasat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
function DeleteItem() {
    if (confirm("Mesuesi/Lenda i zgjedhur do te fshihet !  Jeni te sigurte ?")) {
                return true;
            }
            return false;
        }
 </script>

       <script type="text/javascript">
function CallPrint()
{
    var img = document.getElementById('<%= Image1.ClientID %>');
    var prtContentviti = document.getElementById('<%= vitiddl.ClientID %>');
    var prtContentklasa = document.getElementById('<%= klasaddl.ClientID %>');
   var prtContentindeksi = document.getElementById('<%= indeksiddl.ClientID %>');

    img.style.display = 'inline';

    var prtContent2 = document.getElementById('Div1');
     var grdView = '<%= GridView1.ClientID %>'
    var prtContent = document.getElementById(grdView);

    var row = prtContent.rows;
    row[row.length - 1].style.display = "none";

    for (var i = 0; i < row.length; i++) {
        row[i].cells[4].style.display = "none";
    }

            var emri = '<%= Session["emri"] %>';
           var html = "<p style=\"text-align:center;\">"+
                      prtContent2.innerHTML + "</p>" +
                     "<p style=\"text-align:center;\">" + "SHKOLLA : " + emri + "</p>"+
                      "<br><br>" +
                      "VITI SHKOLLOR : " + prtContentviti.options[prtContentviti.selectedIndex].text + "<br>" +
                      "MESUESIT KLASA " + prtContentklasa.options[prtContentklasa.selectedIndex].text + prtContentindeksi.options[prtContentindeksi.selectedIndex].text +
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
                  <td style="width: 9px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 9px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 9px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 9px">&nbsp;</td>
                  <td style="font-size: medium">
                      <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Underline="True" style="font-size: medium" Text="LENDET"></asp:Label>
                  </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 9px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 9px">
                      &nbsp;</td>
                  <td>
                      <asp:DropDownList ID="vitiddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="vitiddl_SelectedIndexChanged" style="font-size: medium">
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
                      <asp:DropDownList ID="klasaddl" runat="server" OnSelectedIndexChanged="klasaddl_SelectedIndexChanged" AutoPostBack="True" style="font-size: medium">
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
                      <asp:DropDownList ID="indeksiddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="indeksiddl_SelectedIndexChanged" style="font-size: medium">
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
                      <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="~/css/if_icon-125-printer-text_314822.png" OnClientClick ="CallPrint()" />
                      </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  
                  <td style="width: 9px">
                      &nbsp;</td>
                  
                  <td>
                      &nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      &nbsp;</td>
                  <td>
                     <link type="text/css" rel="stylesheet" href="css/style.css" />
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  GridLines="None"
        CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" ShowFooter="True" DataKeyNames="Id" ShowHeaderWhenEmpty="True" OnRowEditing="GridView1_RowEditing" OnRowDataBound="GridView1_RowDataBound" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" style="font-size: small" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25">
                         
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                           <Columns>
                                <asp:TemplateField HeaderText="Nr.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                               <asp:TemplateField HeaderText="Mesuesi">
                                   <EditItemTemplate>
                                       <asp:DropDownList ID="mes1ddl" runat="server">
                                           
                                       </asp:DropDownList>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:DropDownList ID="mesuesiinsert" runat="server">
                                           
                                       </asp:DropDownList>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label6" runat="server" Text='<%# Bind("ms1") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>

                               <asp:TemplateField HeaderText="Lenda" SortExpression="LN_EMRI">
                                   <EditItemTemplate>
                                       <asp:DropDownList ID="ledaddl" runat="server">
                                       </asp:DropDownList>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:DropDownList ID="lendainsert" runat="server">
                                       </asp:DropDownList>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("EMRI_LENDA") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Ngarkesa" SortExpression="LN_KREDITE">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="ngarkesatxt" runat="server" Text='<%# Bind("NGARKESA") %>' AutoCompleteType="Disabled" Width="60px"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ngarkesatxt" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="ngarkesatxt" ErrorMessage="*" ToolTip="Fusha e ngarkeses duhet te kete vetem vlera numerike" ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="edit"></asp:RegularExpressionValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="ngarkesainsert" runat="server" AutoCompleteType="Disabled" ViewStateMode="Disabled" Width="60px"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ngarkesainsert" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="ngarkesainsert" ErrorMessage="*" ToolTip="Fusha e ngarkeses duhet te kete vetem vlera numerike" ValidationExpression="^[1-9]\d*(\.\d+)?$"></asp:RegularExpressionValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("NGARKESA") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField ShowHeader="False">
                                   <EditItemTemplate>
                                       &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CommandName="Update" ImageUrl="~/css/if_check_925925.png" ValidationGroup="edit" />
                                       <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Cancel" ImageUrl="~/css/if_cross_925923.png" CausesValidation="False" />
                                       <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/css/if_arrow_right_925929.png" OnClientClick ="return DeleteItem()" xmlns:asp="#unknown" />
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Insert" ImageUrl="~/css/if_user_925901.png" />
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Edit" CausesValidation="False" ImageUrl="~/css/lapsi.png" />
                                   </ItemTemplate>
                               </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="idtext" runat="server" Width="55px" Text='<%# Bind("Id") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                           </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>

 

                      </asp:GridView>

                  </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
          </table>
   </div>
    </asp:Content>
