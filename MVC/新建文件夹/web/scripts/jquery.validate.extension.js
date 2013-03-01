//远程验证抽象方法
function GetRemoteInfo(postUrl, data) {
    var remote = {
        type: "POST",
        async: false,
        url: postUrl,
        dataType: "xml",
        data: data,
        dataFilter: function(dataXML) {
            var result = new Object();
            result.Result = jQuery(dataXML).find("Result").text();
            result.Msg = jQuery(dataXML).find("Msg").text();
            if (result.Result == "-1") {
                result.Result = false;
                return result;
            }
            else {
                result.Result = result.Result == "1" ? true : false;
                return result;
            }
        }
    };
    return remote;
}