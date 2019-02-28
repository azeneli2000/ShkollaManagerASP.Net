<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Mesuesit.aspx.cs" Inherits="WebApplication2.Mesuesit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <script type="text/javascript">
function CallPrint()
{
    var img = document.getElementById('<%= Image1.ClientID %>');
  
  

    img.style.display = 'inline';

    var prtContent2 = document.getElementById('Div1');
     var grdView = '<%= GridView1.ClientID %>'
    var prtContent = document.getElementById(grdView);

    var row = prtContent.rows;
    row[row.length - 1].style.display = "none";

    for (var i = 0; i < row.length; i++) {
        row[i].cells[6].style.display = "none";
    }

            var emri = '<%= Session["emri"] %>';
           var html = "<p style=\"text-align:center;\">"+
                      prtContent2.innerHTML + "</p>" +
                     "<p style=\"text-align:center;\">" + "SHKOLLA : " + emri + "</p>"+
                      "<br><br>" +
                     
                      "MESUESIT" + 
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
                  <td style="width: 11px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 11px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 11px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 11px">
                      &nbsp;</td>
                  <td style="font-size: medium">
                      <asp:Label ID="Label7" runat="server" Font-Size="Medium" Font-Underline="True" style="font-size: medium" Text="MESUESIT"></asp:Label>
                  </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 11px">&nbsp;</td>
                  <td>
                      <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="~/css/if_icon-125-printer-text_314822.png" OnClientClick ="CallPrint()" />
                  </td>
                  <td>&nbsp;</td>
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
            AlternatingRowStyle-CssClass="alt" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ShowFooter="True" DataKeyNames="MS_ID_MESUESI" OnRowCommand="GridView1_RowCommand" ShowHeaderWhenEmpty="True" OnRowDeleting="GridView1_RowDeleting" style="font-size: small" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25">
                         
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                           <Columns>
                                <asp:TemplateField HeaderText="Nr.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                               <asp:TemplateField HeaderText="Id_mesuesi" SortExpression="MS_ID_MESUESI" Visible="False">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MS_ID_MESUESI") %>' Enabled="False" AutoCompleteType="Disabled"></asp:TextBox>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertamza" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("MS_ID_MESUESI") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Emri" SortExpression="MS_EMRI">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MS_EMRI") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertemri" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="insertemri" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("MS_EMRI") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Mbiemri" SortExpression="MS_MBIEMRI">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("MS_MBIEMRI") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertmbiemri" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="insertmbiemri" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("MS_MBIEMRI") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Emri Perdoruesit">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("MS_USERNAME1") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertp" runat="server" AutoCompleteType="Disabled" ViewStateMode="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="insertp" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("MS_USERNAME1") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Fjalekalimi">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("MS_PASSWORD1") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox5" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertfjalekalimi" runat="server" AutoCompleteType="Disabled" ValidateRequestMode="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="insertfjalekalimi" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label5" runat="server" Text='<%# Bind("MS_PASSWORD1") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Statusi">
                                   <EditItemTemplate>
                                       <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("MS_GJENDJA") %>'>
                                           <asp:ListItem>Aktiv</asp:ListItem>
                                           <asp:ListItem>Pasiv</asp:ListItem>
                                       </asp:DropDownList>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:DropDownList ID="DropDownList2" runat="server">
                                           <asp:ListItem>Aktiv</asp:ListItem>
                                       </asp:DropDownList>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label6" runat="server" Text='<%# Bind("MS_GJENDJA") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField ShowHeader="False">
                                   <EditItemTemplate>
                                       &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CommandName="Update" ImageUrl="~/css/if_check_925925.png" ValidationGroup="edit" />
                                       <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Cancel" ImageUrl="~/css/if_cross_925923.png" CausesValidation="False" />
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Insert" ImageUrl="~/css/if_user_925901.png" />
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Edit" CausesValidation="False" ImageUrl="~/css/lapsi.png" />
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