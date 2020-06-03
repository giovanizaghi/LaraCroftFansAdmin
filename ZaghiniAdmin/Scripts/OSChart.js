$(document).ready(function(){
    var myChart = echarts.init(document.getElementById('os'));    

    option = {
        title : {
            text: 'Operational System',
            subtext: 'Number of visits',
            x:'center'
        },
        tooltip : {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },        
        series : [
            {
                name: 'Visits',
                type: 'pie',
                radius : '55%',
                center: ['50%', '60%'],
                data:[
                    {value:1335, name:'Android'},
                    {value:310, name:'iOS'},
                    {value:800, name:'Windows'},
                    {value:19, name:'Linux'},
                    {value:200, name:'MacOS'}
                ],
                itemStyle: {
                    emphasis: {
                        shadowBlur: 10,
                        shadowOffsetX: 0,
                        shadowColor: 'rgba(0, 0, 0, 0.5)'
                    }
                }
            }
        ]
    };

    myChart.setOption(option);
})