<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script type="text/javascript">
function DeleteItem() {
    if (confirm("Nxenesi i zgjedhur do te largohet !  Jeni te sigurte ?")) {
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
    //hide footer row
    var row = prtContent.rows;
    row[row.length - 1].style.display = "none";
    //hide kolonen e fundit
    for (var i = 0; i < row.length; i++) {
        row[i].cells[12].style.display = "none";
    }

            var emri = '<%= Session["emri"] %>';
           var html = "<p style=\"text-align:center;\">"+
                      prtContent2.innerHTML + "</p>" +
                     "<p style=\"text-align:center;\">" + "SHKOLLA : " + emri + "</p>"+
                      "<br><br>" +
                      "VITI SHKOLLOR : " + prtContentviti.options[prtContentviti.selectedIndex].text + "<br>" +
                      "NXENESIT KLASA " + prtContentklasa.options[prtContentklasa.selectedIndex].text + prtContentindeksi.options[prtContentindeksi.selectedIndex].text +
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
                  <td style="width: 10px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td style="width: 10px">&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td style="width: 10px">&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td style="width: 10px">&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>
                      <asp:Label ID="Label13" runat="server" Font-Size="Medium" Font-Underline="True" style="font-size: medium" Text="GJENERALITETE"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td style="width: 10px">&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
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
                      <asp:ImageButton ID="ImageButton7" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="~/css/if_icon-125-printer-text_314822.png" OnClientClick ="CallPrint()" ToolTip="Printo" />
                  </td>
                  <td style="width: 10px">&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px; height: 22px;"></td>
                  <td style="height: 22px">
                      &nbsp;</td>
                  <td style="height: 22px; width: 10px;"></td>
                  <td style="height: 22px"></td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      &nbsp;</td>
                  <td>
                     <link type="text/css" rel="stylesheet" href="css/style.css" />
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  GridLines="None"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ShowFooter="True" DataKeyNames="AMZA_NR_AMZA" OnRowCommand="GridView1_RowCommand" ShowHeaderWhenEmpty="True" OnRowDeleting="GridView1_RowDeleting"  OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25" Width ="100%" style="font-size: small" CssClass="mGrid">
                         
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                           <Columns>
                               <asp:TemplateField HeaderText="Nr.Amza" SortExpression="AMZA_NR_AMZA">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AMZA_NR_AMZA") %>' Enabled="False" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ToolTip="Kjo fushe eshte e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="*" ToolTip="Numri i Amzes duhet te kete vetem numra" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertamza" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="insertamza" ErrorMessage="*" ToolTip="Kjo fushe eshte e detyrueshme"></asp:RequiredFieldValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="insertamza" ErrorMessage="*" ToolTip="Numri i Amzes duhet te kete vetem numra" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("AMZA_NR_AMZA") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Emri" SortExpression="AMZA_EMRI">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AMZA_EMRI") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertemri" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="insertemri" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("AMZA_EMRI") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Mbiemri" SortExpression="AMZA_MBIEMRI">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("AMZA_MBIEMRI") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertmbiemri" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="insertmbiemri" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label3" runat="server" Text='<%# Bind("AMZA_MBIEMRI") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Atesia" SortExpression="AMZA_ATESIA">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("AMZA_ATESIA") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertatesia" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="insertatesia" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label4" runat="server" Text='<%# Bind("AMZA_ATESIA") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Memesia" SortExpression="AMZA_MEMSIA">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("AMZA_MEMESIA") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox5" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertmemesia" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="insertmemesia" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label5" runat="server" Text='<%# Bind("AMZA_MEMESIA") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Seksi" SortExpression="AMZA_SEKSI">
                                   <EditItemTemplate>
                                       <asp:DropDownList ID="DropDownList1" runat="server">
                                           <asp:ListItem>Mashkull</asp:ListItem>
                                           <asp:ListItem>Femer</asp:ListItem>
                                       </asp:DropDownList>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:DropDownList ID="DropDownList1" runat="server">
                                           <asp:ListItem>Mashkull</asp:ListItem>
                                           <asp:ListItem>Femer</asp:ListItem>
                                       </asp:DropDownList>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label6" runat="server" Text='<%# Bind("AMZA_SEKSI") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Vendlindja" SortExpression="AMZA_VENDLINDJA">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("AMZA_VENDLINDJA") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox7" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertvendlindja" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="insertvendlindja" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label7" runat="server" Text='<%# Bind("AMZA_VENDLINDJA") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Datelindja" SortExpression="AMZA_DATELINDJA">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("AMZA_DATELINDJA") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox13" ErrorMessage="*" ToolTip="Fushe e detyrueshme" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertdatelindja" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="insertdatelindja" ErrorMessage="*" ToolTip="Fushe e detyrueshme"></asp:RequiredFieldValidator>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label8" runat="server" Text='<%# Bind("AMZA_DATELINDJA") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Vrejtje" SortExpression="AMZA_VREJTJE">
                                   <EditItemTemplate>
                                       <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("AMZA_VREJTJE") %>' AutoCompleteType="Disabled"></asp:TextBox>
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:TextBox ID="insertvrejtje" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label9" runat="server" Text='<%# Bind("AMZA_VREJTJE") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Viti Shkollor" SortExpression="AMZA_VITI_SHKOLLOR">
                                   <EditItemTemplate>
                                       <asp:DropDownList ID="DropDownList2" runat="server" Enabled="False">
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
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:DropDownList ID="DropDownList2" runat="server" Enabled="False">
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
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label10" runat="server" Text='<%# Bind("AMZA_VITI_SHKOLLOR") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Klasa" SortExpression="AMZA_KLASA">
                                   <EditItemTemplate>
                                       <asp:DropDownList ID="DropDownList3" runat="server" Enabled="False">
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
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:DropDownList ID="DropDownList3" runat="server" Enabled="False">
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
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label11" runat="server" Text='<%# Bind("AMZA_KLASA") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Indeksi" SortExpression="AMZA_INDEKSI">
                                   <EditItemTemplate>
                                       <asp:DropDownList ID="DropDownList4" runat="server" Enabled="False">
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
                                   </EditItemTemplate>
                                   <FooterTemplate>
                                       <asp:DropDownList ID="DropDownList4" runat="server" Enabled="False">
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
                                   </FooterTemplate>
                                   <ItemTemplate>
                                       <asp:Label ID="Label12" runat="server" Text='<%# Bind("AMZA_INDEKSI") %>'></asp:Label>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField ShowHeader="False">
                                   <EditItemTemplate>
                                       &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" CommandName="Update" ImageUrl="~/css/if_check_925925.png" ValidationGroup="edit" />
                                       <asp:ImageButton ID="ImageButton5" runat="server" CommandName="Cancel" ImageUrl="~/css/if_cross_925923.png" CausesValidation="False" />
                                       <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Delete" ImageUrl="~/css/if_arrow_right_925929.png" CausesValidation="False" OnClientClick ="return DeleteItem()" xmlns:asp="#unknown" />
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
                          <RowStyle Wrap="False" />

 

                      </asp:GridView>

                  </td>
                  <td style="width: 10px">&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
          </table>
   </div>
    </asp:Content>


