<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="HihgCharts-pie base.aspx.cs" Inherits="HihgCharts_pie_base" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type='text/javascript'>
	
        $(document).ready(function () {
            //声明报表对象
            var options = new Highcharts.Chart({
                chart: {
                    //将报表对象渲染到层上
                    renderTo: 'container'
                },
                title: {
                    text: 'fruit'
                },
                //设定报表对象的初始数据
                series: [{
                    type: 'pie',
                    name: 'fruit',
                    data:
                            [
                                 ["Apples", 43.0],
                                 ["Pears", 57.0]
                            ]
                }]
            });
        });

        function showMy() {
            $.ajax({
                type: "POST",
                url: "AjaxCharts.ashx",
                data: "",
                success: function (data) {
                    alert(data);
                    document.write(data);
                  //  $('#litJS').html(data);
                }
            });
        }

        //            $(document).ready(function () {
        //                //每隔3秒自动调用方法，实现图表的实时更新
        //                window.setInterval(getForm, 3000);

        //            });

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="container" style="width: 800px; height: 400px; margin: 0 auto">
    </div>        <input type="button" id="a" value="new show" onclick="showMy();" />
        <asp:Literal ID="litJS" runat="server" ClientIDMode="Static"></asp:Literal>

</asp:Content>
