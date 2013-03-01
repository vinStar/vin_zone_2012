<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="HihgCharts-pie base.aspx.cs" Inherits="HihgCharts_pie_base" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type='text/javascript'>
        //饼状图
        function optionsPieFrame() {
            var optionsPie = {
                chart: {
                    renderTo: 'containerPie',
                    type: 'pie'
                },
                title: {
                    text: 'Fruit  Test '
                },
                series: []
            };

            return optionsPie;
        }
        //线条图
        function optionsLineFrame() {
            var optionsLine = {
                chart: {
                    renderTo: 'containerLine',
                    type: 'line',
                    marginRight: 130,
                    marginBottom: 25
                },
                title: {
                    text: 'fruit weight(t)',
                    x: -20 //center
                },
                subtitle: {
                    text: 'Source: edgeTech.com',
                    x: -20
                },
                xAxis: {
                    categories: []
                },
                yAxis: {
                    title: {
                        text: 'weight(t)'
                    },
                    plotLines: [{
                        value: 0,
                        width: 1,
                        color: '#808080'
                    }]
                },
                tooltip: {
                    formatter: function () {
                        return '<b>' + this.series.name + '</b><br/>' +
                this.x + ': ' + this.y + 't';
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'top',
                    x: -10,
                    y: 100,
                    borderWidth: 0
                },
                series: []
            };
            return optionsLine;
        }

        //柱状图
        function optionsBarFrame() {
            var optionsBar = {
                chart: {
                    renderTo: 'containerBar',
                    type: 'column'
                },
                title: {
                    text: 'Historic Fruit'
                },
                subtitle: {
                    text: 'Source: edgeTech.org'
                },
                xAxis: {
                    categories: [],
                    title: {
                        text: null
                    }
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'weight (kg)',
                        align: 'high'
                    },
                    labels: {
                        overflow: 'justify'
                    }
                },
                tooltip: {
                    formatter: function () {
                        return '' +
                        this.series.name + ': ' + this.y + 'millions' + this.point.total + '总数';
                    }
                },
                plotOptions: {
                    bar: {
                        dataLabels: {
                            enabled: true
                        }
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'left',
                    verticalAlign: 'top',
                    x: -100,
                    y: 100,
                    floating: true,
                    borderWidth: 1,
                    backgroundColor: '#FFFFFF',
                    shadow: true
                },
                credits: {
                    enabled: false
                },
                series: []
            }

            return optionsBar;
        }

        var optionsFirst = {
            chart: {
                //将报表对象渲染到层上
                renderTo: 'container',
                type: 'pie'
            },
            title: {
                text: 'Fruit Consumption'
            },
            //设定报表对象的初始数据
            series: []
        };


        var chart1; //全局变量
        var isBar = false;
        $(document).ready(function () {
            optionsFirst.series.push({
                name: 'fruit',
                data:
                    [
                        ["Apples", 43.0],
                        ["Pears", 57.0]
                    ]
            });
            //声明报表对象
            chart1 = new Highcharts.Chart(optionsFirst);

        });

        //chart test 
        function showMy() {
            //pie chart
            var optionsPie = optionsPieFrame();
            var data = showMyAjax("chartPie");
            //anolog data pie
            var datatestPie = { "A": ["Apples", 20.0], "B": ["Pears", 30.0], "C": ["Bananas", 50.0] };
            var series = {
                data: []
            };
            // series.data.push( ["Apples", 20.0] );
            $.each(data, function (itemNo, item) {
                series.data.push([item['Name'], parseFloat(item['Data'])]);
            });
            optionsPie.series.push(series);
            var chart = new Highcharts.Chart(optionsPie);


            // bar chart
            var optionsBar = optionsBarFrame();
            //X轴数据
            var xAxis = ['beiJing', 'shangHai', 'chengDu'];
            $.each(xAxis, function (i, item) {
                optionsBar.xAxis.categories.push(item);
            });
            //模拟柱状数据
            var datatestBar =
                     [
                        {
                            Name: "Apples", 
                             y: 10,
                            total:3
                          
                           

                        },
                        {
                            Name: 'Pears', y: 20,
                            total: 3
                          
                        }, {
                            Name: 'Bananas', y: 30,
                            total: 3
                          
                        }
                     ]
          //  var dataBar = showMyAjax("chartBar");
            //            alert(dataBar);
//                        $.each(datatestBar, function (i, item) {
                            var series = {                   
                    data: []
                   
                };
                series.data.push(datatestBar);
//                series.name = item["Name"];
//                series.total = item["total"];
                $.each(datatestBar, function (j, item) {
                series.data.push(item);
                });
                optionsBar.series.push(series);
//            });
//            if (isBar) {
//                isBar = false;
//                optionsBar.chart.type = "bar";
//            } else {
//                isBar = true;
//                optionsBar.chart.type = "column";
//            }

            var chartBar = new Highcharts.Chart(optionsBar);

            //Line chart                     
            var optionsLine = optionsLineFrame();
            var xAxis = ['beiJing', 'shangHai', 'chengDu', 'shenZhen'];
            $.each(xAxis, function (i, item) {
                optionsLine.xAxis.categories.push(item);
            });
            var dataLine = showMyAjax("chartLine");
            $.each(dataLine, function (i, item) {
                var series = {
                    data: []
                };
                series.name = item["Name"];
                series.total = item["total"];
                $.each(item["Data"], function (j, item) {
                    series.data.push(item);
                });
                optionsLine.series.push(series);
            });
            var chartLine = new Highcharts.Chart(optionsLine);
        }

        //后台数据
        function showMyAjax(chartType) {
            var str;
            $.ajaxSettings.async = false;
            $.ajax({
                type: "get",
                url: "AjaxCharts.ashx?chartType=" + chartType,
                data: "",
                success: function (data) {
                    str = data;
                }
            });
            return str;
        }
 
    </script>
    <style type="text/css">
        .chart
        {
            width: 480px;
            height: 260px;
            margin: 10px 10px;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: left; width: 1000px;">
        <div id="container" class="chart">
        </div>
        <div id="containerBar" class="chart">
        </div>
        <div id="containerPie" class="chart">
        </div>
        <div id="containerLine" class="chart">
        </div>
    </div>
    <input style="display: block; margin: 10px auto;" type="button" id="a" value="new show"
        onclick="showMy();" />
    <asp:Literal ID="litJS" runat="server" ClientIDMode="Static"></asp:Literal>
</asp:Content>
