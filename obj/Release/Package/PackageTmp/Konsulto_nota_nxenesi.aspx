<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Konsulto_nota_nxenesi.aspx.cs" Inherits="WebApplication2.Konsulto_nota_nxenesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <div class="text-left">
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
        <script type="text/javascript">
function CallPrint()
{
    var img = document.getElementById('<%= Image1.ClientID %>');
    var prtContentviti = document.getElementById('<%= vitiddl_v.ClientID %>');
    var prtContentklasa = document.getElementById('<%= klasaddl_v.ClientID %>');
    var prtContentindeksi = document.getElementById('<%= indeksiddl_v.ClientID %>');
    var prtContentnxenesi = document.getElementById('<%= DropDownList1.ClientID %>');

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
                      "KLASA " + prtContentklasa.options[prtContentklasa.selectedIndex].text + prtContentindeksi.options[prtContentindeksi.selectedIndex].text + "     NXENESI : "+ prtContentnxenesi.options[prtContentnxenesi.selectedIndex].text +
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
                  <td style="width: 251px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 251px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 251px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>
                      <asp:Label ID="Label7" runat="server" Font-Size="Medium" Font-Underline="True" style="font-size: medium" Text="NOTAT NXENESI"></asp:Label>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 251px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      </span>
                              </td>
                  <td style="width: 251px">
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
                      <asp:ImageButton ID="ImageButton7" runat="server" ImageAlign="AbsBottom" ImageUrl="~/css/if_icon-125-printer-text_314822.png" OnClientClick ="CallPrint()" CausesValidation="False" />
                              </td>
                  <td dir="ltr">
                      <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BorderStyle="None" GridLines="None" OnRowCancelingEdit="GridView4_RowCancelingEdit" OnRowEditing="GridView4_RowEditing" OnRowUpdating="GridView4_RowUpdating" HorizontalAlign="Left" style="font-size: small; margin-left: 49px;">
                          <Columns>
                              <asp:TemplateField HeaderText="T">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox1" runat="server" Height="16px" Text='<%# Bind("k1") %>' Width="31px"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label5" runat="server" Text='<%# Bind("k1") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Font-Size="Smaller" />
                              </asp:TemplateField>
                              <asp:TemplateField></asp:TemplateField>
                              <asp:TemplateField HeaderText="P">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox2" runat="server" Height="16px" Text='<%# Bind("k2") %>' Width="31px"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("k2") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Font-Size="Smaller" />
                              </asp:TemplateField>
                              <asp:TemplateField></asp:TemplateField>
                              <asp:TemplateField HeaderText="V">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox3" runat="server" Height="16px" Text='<%# Bind("k3") %>' Width="31px"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label4" runat="server" Text='<%# Bind("k3") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Font-Size="Smaller" />
                              </asp:TemplateField>
                              <asp:TemplateField></asp:TemplateField>
                              <asp:TemplateField>
                                  <EditItemTemplate>
                                      <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Update" ImageUrl="~/css/if_check_925925.png" ValidationGroup="edit" />
                                      <asp:ImageButton ID="ImageButton5" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/css/if_cross_925923.png" />
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit" ImageUrl="~/css/lapsi.png" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                      </asp:GridView>
                  </td>
                  <td><span style="font-size: medium">
                      <asp:GridView ID="GridView2" runat="server" Visible="False" style="font-size: medium">
                      </asp:GridView>
                      <asp:GridView ID="GridView3" runat="server" Visible="False" style="font-size: medium">
                      </asp:GridView>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      </span>
                  </td>
                  <td style="width: 251px">
                      <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" style="font-size: medium">
                      </asp:DropDownList>
                  </td>
                  <td><span style="font-size: medium"></td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 22px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>





                  <td style="width: 10px; height: 25px;" dir="ltr">


                      </td>





                  <td style="width: 251px; height: 25px;" dir="auto">


                      <link type="text/css" rel="stylesheet" href="css/style.css" />
                      </span>
                      <asp:GridView ID="GridView1" runat="server" ShowHeader ="false"  RowStyle-Wrap ="false"  GridLines="None"
        CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" OnRowDataBound="GridView1_RowDataBound" OnDataBound="GridView1_DataBound" style="font-size: medium" PageSize="20">
                    
                           <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                          <PagerStyle CssClass="pgr"></PagerStyle>
                          
                      </asp:GridView>
                  </td>
                  <td style="height: 25px">
                  </td>
                  <td style="height: 25px"><span style="font-size: medium"></td>
                  <td style="height: 25px"></td>
              </tr>
              <tr>
                  <td style="width: 10px; height: 22px;" dir="ltr">
                      &nbsp;</td>
                 
                  <td style="width: 251px; height: 22px;" dir="ltr">
                      &nbsp;</td>
                 
                  <td style="height: 22px">&nbsp;</td>
                  <td style="height: 22px">&nbsp;</td>
                  <td style="height: 22px">&nbsp;</td>

              </tr>
              <tr>
                  <td style="width: 10px; height: 22px;" dir="rtl"></td>
                 
                  <td style="width: 251px; height: 22px;" dir="ltr">
                      <asp:Label ID="Label2" runat="server" Text="Label" style="font-size: medium"></asp:Label>
                  </td>
                 
                  <td style="height: 22px"></td>
                  <td style="height: 22px"></td>
                  <td style="height: 22px"></td>

              </tr>
              <tr>
                  <td style="width: 10px" dir="rtl">&nbsp;</td>
                 
                  <td style="width: 251px" dir="ltr">
                      <asp:Label ID="Label6" runat="server" style="font-size: medium" Text="Label"></asp:Label>
                  </td>
                 
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>

              </tr>
              <tr>
                  <td style="width: 10px">
                      &nbsp;</td>
                  <td style="width: 251px">
                      </span></td>
                  <td>
                      </table>
          </div>
</asp:Content>
