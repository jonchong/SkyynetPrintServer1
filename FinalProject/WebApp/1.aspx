<%@ Page Language="C#" AutoEventWireup="true" CodeFile="1.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 158%;
            height: 97px;
        }
        .auto-style3 {
            height: 139px;
        }
        .auto-style4 {
            width: 69%;
            height: 264px;
        }
        .auto-style6 {
            height: 30px;
        }
        .auto-style9 {
            width: 308px;
            text-align: left;
        }
        .auto-style17 {
            width: 331px;
            height: 73px;
        }
        .auto-style18 {
            width: 592px;
            height: 73px;
        }
        .auto-style19 {
            height: 73px;
        }
        .auto-style20 {
            width: 331px;
            height: 84px;
        }
        .auto-style21 {
            width: 512px;
            text-align: left;
        }
        .auto-style22 {
            height: 84px;
        }
        .auto-style24 {
            height: 30px;
            width: 252px;
        }
        .auto-style26 {
            width: 851px;
        }
        .auto-style28 {
            height: 139px;
            width: 851px;
        }
        .auto-style29 {
            height: 30px;
            width: 331px;
            text-align: right;
        }
        .auto-style30 {
            height: 84px;
            width: 252px;
        }
        .auto-style32 {
            height: 72px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-image: url('Awesome-Gun-.jpg'); background-color: #FFFFFF; color: #FFFFFF;">
        <table class="auto-style1">
            <tr>
                <td class="auto-style26">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style17" style="background-color: #C0C0C0">
                                <asp:Image ID="Image1" runat="server" Height="90px" ImageUrl="~/subcategory_watch_hello_kitty.gif" Width="188px" />
                            </td>
                            <td class="auto-style18" colspan="2" style="vertical-align: top">
                                &nbsp;&nbsp;
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                <asp:Label ID="Label13" runat="server"></asp:Label>
                            </td>
                            <td class="auto-style19" style="vertical-align: top"><
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style20" style="border-top-style: outset; border-width: thick; border-color: #FF00FF">
                                <asp:Label ID="Label7" runat="server" Text="STEP 1" Font-Bold="True" Font-Size="Larger"></asp:Label>
                            &nbsp; Choose a file to send to the print server.&nbsp; It cannot be larger than 15 MB.&nbsp;
                            </td>
                            <td class="auto-style30" style="border-right: thick none #FF00FF; border-top: thick outset #FF00FF; text-align: left; border-left-style: none; border-bottom-style: none;">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:FileUpload ID="FileUpload1" runat="server" Font-Bold="True" style="text-align: justify" />
                            </td>
                            <td class="auto-style21" rowspan="4" style="border-width: thick; border-color: #FF00FF; clip: rect(auto, auto, auto, auto); vertical-align: top; border-top-style: outset;">
                                <br />
                                <asp:Label ID="Label11" runat="server" Text="Server Queue" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                <br />
                                Shows all the jobs currently in the queue in order.<br />
                                <asp:GridView ID="GridView2" runat="server" BackColor="Black" BorderColor="Lime" BorderStyle="Outset" Font-Bold="True" ForeColor="#FF33CC" Width="510px"  >
                                </asp:GridView>
                            </td>
                            <td class="auto-style22">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style29" style="border-style: outset none none none; border-width: thick; border-color: #FF00FF; text-align: left;">
                                <asp:Label ID="Label8" runat="server" Text="STEP 2" Font-Bold="True" Font-Size="Larger"></asp:Label>
                            &nbsp; Click this button to send it to the print server.&nbsp; If everything went well you should see an acknoldgement.</td>
                            <td class="auto-style24" style="border-style: outset none none none; border-right-width: thick; border-right-color: #FF00FF; border-top-width: thick; border-top-color: #FF00FF;">
                                &nbsp;
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <br />
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Send to Print" Font-Bold="True" />
                &nbsp;</td>
                            <td class="auto-style6">
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style29" style="border-left: thick none #FF00FF; border-right: thick none #FF00FF; border-top: thick outset #FF00FF; border-bottom: thick none #FF00FF; text-align: right;">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="REFRESH " Font-Bold="True" Height="35px" style="text-align: right" />
                            </td>
                            <td class="auto-style24" style="border-style: outset none none none; border-right-width: thick; border-right-color: #FF00FF; border-top-width: thick; border-top-color: #FF00FF;">
                                &nbsp;
                            </td>
                            <td class="auto-style6">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style29" style="text-align: right">
                                <asp:Image ID="Image2" runat="server" Height="73px" ImageUrl="~/o.png" style="text-align: right" Width="102px" />
                            </td>
                        </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style28">
                    <table class="auto-style4">
                        <tr>
                            <td class="auto-style32" style="border-width: thick; border-color: #FF00FF; vertical-align: top; border-top-style: none; border-right-style: none;">
                                <asp:Label ID="Label9" runat="server" Text="My Jobs " Font-Bold="True" Font-Size="Larger"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label12" runat="server" Text="Kill Your Job/s" Font-Bold="True" Font-Size="Larger"></asp:Label>
                                <br />
                                This will display all the jobs you send to the server.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Delete all your current jobs.&nbsp; Deletes everything.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Kill My Jobs" Font-Bold="True" OnClientClick="return confirm('Are you sure you want to kill\nall your jobs?');" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9" style="border-right-style: none; border-right-width: thick; border-right-color: #FF00FF">
                                <asp:GridView ID="GridView1" runat="server" BackColor="Black" BorderColor="Lime" BorderStyle="Outset" Font-Bold="True" ForeColor="#FF33CC" style="margin-top: 0px" Width="587px"  >
                                </asp:GridView>
                            </td>
                        </tr>
                        </table>
                </td>
                <td class="auto-style3"></td>
            </tr>
        </table>
    </form>
</body>
</html>
