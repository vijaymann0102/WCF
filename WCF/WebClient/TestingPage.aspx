<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master"  AutoEventWireup="true" Debug="false"
    CodeBehind="TestingPage.aspx.cs"  Inherits="WebClient.TestingPage" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td>
               <span style=" color:Red;"> <strong>No Validations on this page yet</strong></span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Service1 (Get All Movies)
            </td>
            <td>
                <asp:Button ID="BtnTest" runat="server" Text="Call Service1" 
                    onclick="BtnTest_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Service2 (Insert Movie)
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            Cast
                        </td>
                        <td>
                            <asp:TextBox ID="txtCast" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Classification
                        </td>
                        <td>
                            <asp:TextBox ID="txtClassification" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Genre
                        </td>
                        <td>
                            <asp:TextBox ID="txtGenre" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Rating
                        </td>
                        <td>
                            <asp:TextBox ID="txtRating" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ReleaseDate
                        </td>
                        <td>
                            <asp:TextBox ID="txtReleaseDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Title
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnInsert" runat="server" Text="Call Service2" 
                    onclick="btnInsert_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Service3 (update Movies)
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            MoveID
                        </td>
                        <td>
                            <asp:TextBox ID="txtMovieId" runat="server"></asp:TextBox>
                        </td>
                        <tr>
                            <td>
                                Cast
                            </td>
                            <td>
                                <asp:TextBox ID="txtCastU" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Classification
                            </td>
                            <td>
                                <asp:TextBox ID="txtClassificationU" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Genre
                            </td>
                            <td>
                                <asp:TextBox ID="txtGenreU" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rating
                            </td>
                            <td>
                                <asp:TextBox ID="txtRatingU" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ReleaseDate
                            </td>
                            <td>
                                <asp:TextBox ID="txtReleaseDateU" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Title
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitleU" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                </table>
                <asp:Button ID="btnUpdate" runat="server" Text="Call Service3" 
                    onclick="btnUpdate_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Service4 (Search By Field)
            </td>
            <td>
                <tr>
                    <td>
                        Column Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtColumnName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Text To Search
                    </td>
                    <td>
                        <asp:TextBox ID="txtToSearch" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <asp:Button ID="btnSearch" runat="server" Text="Call Service4" />
            </td>
        </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                <asp:Button ID="btnSearch1" runat="server" Text="Call Service4" onclick="btnSearch1_Click" 
                          />
                    </td>
                </tr>
        <tr>
            <td>
                Service4 (Sort By Field)
            </td>
            <td>
                <tr>
                    <td>
                        Column Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtSort" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
            </td>
        </tr>

                <tr>
                    <td>
                        &nbsp;</td>
                    <td><asp:Button ID="btnSort" runat="server" Text="Call Service5" 
                            onclick="btnSort_Click" />
                        &nbsp;</td>
                </tr>

        <tr><td colspan="2">
        
            <asp:GridView ID="gvData" runat="server" Width="359px">
            </asp:GridView>
        
        </td></tr>
    </table>
</asp:Content>
