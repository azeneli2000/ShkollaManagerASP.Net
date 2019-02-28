<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Hidh_notat.aspx.cs" Inherits="WebApplication2.Hidh_notat" %>
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
                  <td class="modal-lg" style="width: 1196px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td class="modal-lg" style="width: 1196px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td class="modal-lg" style="width: 1196px">
                      &nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td>&nbsp;</td>
                  <td>
                      <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Underline="True" style="font-size: medium" Text="HEDHJE NOTA"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td class="modal-lg" style="width: 1196px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      &nbsp;</td>
                  <td class="modal-lg" style="width: 1196px">
                      <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="11px" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="NT_MOMENTALE">E vazhduar</asp:ListItem>
                          <asp:ListItem Value="NT_DETYREKONTROLLI">Test</asp:ListItem>
                          <asp:ListItem Value="NT_PROJEKT">Portofol</asp:ListItem>
                          <asp:ListItem Value="NT_MUNGESE_PA">Mungese</asp:ListItem>
                      </asp:RadioButtonList>
                  </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td class="modal-lg" style="width: 1196px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="height: 4px; width: 10px;">
                      &nbsp;</td>
                  <td style="height: 4px; width: 1196px;">
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
                      <asp:DropDownList ID="lendaddl" runat="server" OnSelectedIndexChanged="lendaddl_SelectedIndexChanged" AutoPostBack="True" style="font-size: medium">
                      </asp:DropDownList>
                      <asp:DropDownList ID="mesuesiddl" runat="server" style="font-size: medium">
                      </asp:DropDownList>
                      <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsBottom" ImageUrl="~/css/document-edit.png" OnClick="ImageButton1_Click" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lendaddl" ErrorMessage="Nuk jane konfiguruar lendet"></asp:RequiredFieldValidator>
                      </td>
                  <td style="height: 4px"></td>
                  <td style="height: 4px"></td>
              </tr>
              <tr>
                  <td style="width: 10px">&nbsp;</td>
                  <td class="modal-lg" style="width: 1196px">&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      &nbsp;</td>
                  <td class="modal-lg" style="width: 1196px">
                      <asp:Repeater ID="Repeater1" runat="server">
                      <HeaderTemplate>
        <table  border="1">
            <tr>
                <th scope="col" style="width: 0px">
                
                </th>
                 <th scope="col" style="width: 25px">
                    Nr
                </th>
                <th scope="col" style="width: 175px">
                    Emri
                </th>
                <th scope="col" style="width: 35px">
                   Nota
                </th>
            </tr>
    </HeaderTemplate>

                           <ItemTemplate>
        <tr>
            
            <td>
                <asp:Label ID="lblAmza" runat="server" Text='<%# Eval("KL_NR_AMZA") %>' Visible =" false" />
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text=  <%# Container.ItemIndex+1 %>   Width =" 35px" Font-Size ="Medium" />
            </td>
            <td>
                <asp:Label ID="lblEmri" runat="server" Text='<%# Eval("Emri") %>'  Font-Size ="Medium" />
            </td>
            <td>
                <asp:textbox ID="txtlenda" runat="server" Text='' Width =" 35px" AutoCompleteType = "Disabled"  Font-Size ="Medium" />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
                      </asp:Repeater>
                  </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      &nbsp;</td>
                  <td class="modal-lg" style="width: 1196px">
                      &nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      &nbsp;</td>
                  <td class="modal-lg" style="width: 1196px">
                      &nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
              </tr>
              <tr>
                  <td style="width: 10px">
                      &nbsp;<td class="modal-lg" style="width: 1196px">
                      &nbsp;<tr>
                  <td style="width: 10px">
                      &nbsp;<td class="modal-lg" style="width: 1196px">
                              &nbsp;</table>
          </div>




</asp:Content>
