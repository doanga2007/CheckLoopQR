<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheckLoopQR.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.6.4.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script type="text/javascript">

    $(window).load(function(){
      
    $("#checkAll").change(function () {
    $("input:checkbox").prop('checked', $(this).prop("checked"));
    });

    });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>QR Code Generator</h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Please Input Data</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtQRCode" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="input-group-prepend">
                                <asp:Button ID="btnGenerate" runat="server" CssClass="btn btn-secondary" Text="Generate" OnClick="btnGenerate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Button ID="btnSelect" runat="server" CssClass="btn btn-secondary" Text="Display Text" OnClick="btnSelect_Click" /><br /><br />

            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder><br /><br />

            <p><label><input type="checkbox" id="checkAll"/> Check all</label></p>

            <asp:CheckBoxList 
            ID="CheckBox1"
            runat="server"
            Border="1"
            BorderColor="LightGray"
            Font-Size="Large"></asp:CheckBoxList>  

        </div>
    </form>
</body>
</html>