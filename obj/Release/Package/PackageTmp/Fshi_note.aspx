<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Fshi_note.aspx.cs" Inherits="WebApplication2.Fshi_note" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
function DeleteItem() {
    if (confirm("Nota e zgjedhur do te fshihet !  Jeni te sigurte ?")) {
                return true;
            }
            return false;
        }
 </script>
    <div>

   </div>

     <div>
   </div>

      <div>
   </div>

      <div>
          <table style="width:100%;">
              <tr>
                  <td style="width: 10px"><span style="font-size: medium"></td>
                  <td style="width: 597px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 597px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 597px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 597px">
                      <asp:Label ID="Label4" runat="server" Font-Size="Medium" Font-Underline="True" style="font-size: medium" Text="MODIFIKIMI NOTA"></asp:Label>
                  </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 597px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 597px">

                      <asp:DropDownList ID="vitiddl_v" runat="server" AutoPostBack="True" style="font-size: medium" OnSelectedIndexChanged="vitiddl_v_SelectedIndexChanged">
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
                      <asp:DropDownList ID="klasaddl_v" runat="server" AutoPostBack="True" style="font-size: medium" OnSelectedIndexChanged="klasaddl_v_SelectedIndexChanged">
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
                      <asp:DropDownList ID="indeksiddl_v" runat="server" AutoPostBack="True" style="font-size: medium" OnSelectedIndexChanged="indeksiddl_v_SelectedIndexChanged">
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
                       
 
&nbsp;<asp:DropDownList ID="lendaddl" runat="server" OnSelectedIndexChanged="lendaddl_SelectedIndexChanged" AutoPostBack="True" style="font-size: medium">
                      </asp:DropDownList>
                      <asp:DropDownList ID="DropDownList1" runat="server" style="font-size: medium" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                      </asp:DropDownList>
                   
                       </td>
                
 
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      </span>
                              </td>
                  <td style="width: 597px">
                      &nbsp;</td>

              <tr>
                  <td style="width: 10px">
                      &nbsp;</td>
                  <td style="width: 597px">
                      <link type="text/css" rel="stylesheet" href="css/style.css" />
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  GridLines="None"
        CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="NT_ID" OnRowCommand="GridView1_RowCommand" ShowHeaderWhenEmpty="True" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" style="font-size: small" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25">
                         
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                          <Columns>
                              <asp:TemplateField HeaderText="Data">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Text='<%# Bind("NT_DATA") %>'></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("NT_DATA") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="ID" Visible="False">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label2" runat="server" Text='<%# Bind("NT_ID") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Vleresimi">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NT_VLERESIMI") %>' Width="46px" AutoCompleteType="Disabled"></asp:TextBox>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("NT_VLERESIMI") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="E vazhduar">
                                  <EditItemTemplate>
                                      <asp:CheckBox ID="CheckBox_goje" runat="server" Checked='<%# Bind("NT_MOMENTALE") %>' />
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("NT_MOMENTALE") %>' Enabled="False" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Test">
                                  <EditItemTemplate>
                                      <asp:CheckBox ID="CheckBox_shkrim" runat="server" Checked='<%# Bind("NT_DETYREKONTROLLI") %>' />
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("NT_DETYREKONTROLLI") %>' Enabled="False" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Portofol">
                                  <EditItemTemplate>
                                      <asp:CheckBox ID="CheckBox_projekt" runat="server" Checked='<%# Bind("NT_PROJEKT") %>' />
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:CheckBox ID="CheckBox3" runat="server" Checked='<%# Bind("NT_PROJEKT") %>' Enabled="False" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField ShowHeader="False">
                                  <EditItemTemplate>
                                      <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Update" ImageUrl="~/css/if_check_925925.png" ValidationGroup="edit" />
                                      <asp:ImageButton ID="ImageButton5" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/css/if_cross_925923.png" />
                                      <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/css/if_arrow_right_925929.png" OnClientClick ="return DeleteItem()" xmlns:asp="#unknown" />
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Edit" ImageUrl="~/css/lapsi.png" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                      </asp:GridView>
                  </td>

              <tr>
                  <td style="width: 10px">
                      &nbsp;</td>
                  <td style="width: 597px">
                      &nbsp;</td>

</asp:Content>
