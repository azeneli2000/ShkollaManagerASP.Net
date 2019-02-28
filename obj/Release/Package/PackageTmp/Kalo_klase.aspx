<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Kalo_klase.aspx.cs" Inherits="WebApplication2.Kalo_klase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>

   </div>

     <div>
   </div>

      <div>
   </div>

      <div>
          <table style="width:100%;">
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 196px">&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 196px">&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 196px">&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 196px; font-size: medium;">
                      <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Underline="True" style="font-size: medium" Text="KALO KLASE"></asp:Label>
                  </td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td style="width: 196px">&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      &nbsp;</td>
                  <td style="width: 196px">
                      <table style="width: 100%;">
                          <tr>
                              <td style="width: 184px">
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
                              </td>
                          </tr>
                          <tr>
                              <td style="width: 184px">&nbsp;</td>
                          </tr>
                          <tr>
                              <td style="width: 184px">
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
                              </td>
                          </tr>
                          <tr>
                              <td style="width: 184px">&nbsp;</td>
                          </tr>
                          <tr>
                              <td style="width: 184px">
                                  <asp:ListBox ID="ListBox1" runat="server" Height="400px" SelectionMode="Multiple" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" style="font-size: medium"></asp:ListBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width: 184px">&nbsp;</td>
                          </tr>
                          <tr>
                              <td style="width: 184px">
                                  &nbsp;</td>
                          </tr>
                      </table>
                  </td>
                  <td>
                      <table style="width: 100%;">
                          <tr>
                              <td style="height: 20px; width: 41px">&nbsp;</td>
                              <td style="height: 20px">
                      <asp:DropDownList ID="vitiddl_re" runat="server" AutoPostBack="True" OnSelectedIndexChanged="vitiddl_re_SelectedIndexChanged" style="font-size: medium">
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
                              </td>
                          </tr>
                          <tr>
                              <td style="height: 20px; width: 41px">&nbsp;</td>
                              <td style="height: 20px">&nbsp;</td>
                          </tr>
                          <tr>
                              <td style="height: 20px; width: 41px">&nbsp;</td>
                              <td style="height: 20px">
                      <asp:DropDownList ID="klasaddl_re" runat="server" OnSelectedIndexChanged="klasaddl_re_SelectedIndexChanged" AutoPostBack="True" style="font-size: medium">
                      </asp:DropDownList>
                      <asp:DropDownList ID="indeksiddl_re" runat="server" AutoPostBack="True" OnSelectedIndexChanged="indeksiddl_re_SelectedIndexChanged" style="font-size: medium">
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
                              </td>
                          </tr>
                          <tr>
                              <td style="height: 20px; width: 41px">&nbsp;</td>
                              <td style="height: 20px"></td>
                          </tr>
                          <tr>
                              <td style="width: 41px">
                                  <table style="width: 100%;">
                                      <tr>
                                          <td style="height: 49px; width: 85px">
                                              <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/css/if_next_3_926650_50x50.png" Width="49px" OnClick="ImageButton1_Click" />
                                          </td>
                                      </tr>
                                      <tr>
                                          <td style="width: 85px">
                                              <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/css/if_check_925925_50x50.png" Width="49px" OnClick="ImageButton2_Click" />
                                          </td>
                                      </tr>
                                  </table>
                              </td>
                              <td>
                                  <asp:ListBox ID="ListBox2" runat="server" Height="400px" SelectionMode="Multiple" Width="200px" style="font-size: medium"></asp:ListBox>
                                  <asp:ListBox ID="ListBoxAMZA1" runat="server" Visible="False"></asp:ListBox>
                                  <asp:ListBox ID="ListBoxAMZA2" runat="server" Visible="False"></asp:ListBox>
                              </td>
                          </tr>
                          <tr>
                              <td style="width: 41px">&nbsp;</td>
                              <td>
                                  &nbsp;</td>
                          </tr>
                          <tr>
                              <td style="width: 41px">&nbsp;</td>
                              <td>&nbsp;</td>
                          </tr>
                      </table>
                  </td>
              </tr>
          </table>
   </div>

</asp:Content>
