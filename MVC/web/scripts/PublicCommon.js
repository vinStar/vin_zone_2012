function MM_swapImgRestore() { //v3.0
    var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
}
function MM_preloadImages() { //v3.0
    var d = document; if (d.images) {
        if (!d.MM_p) d.MM_p = new Array();
        var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
            if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
    }
}

function MM_findObj(n, d) { //v4.01
    var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
        d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
    }
    if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
    for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
    if (!x && d.getElementById) x = d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
    var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
        if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
}

function KeyWordOnFocus(obj) {
    if (obj.value == HTrackingLang.InputCompanyNameOrPositionName) obj.value = '';
}
function KeyWordOnBlur(obj) {
    if (obj.value == '') obj.value = HTrackingLang.InputCompanyNameOrPositionName;
}
//弹出对话框
function PubShowPopWin(url, wdith, height, title) {
    showPopWin(url, wdith, height, null, null, title);
}

function checkAllRow(ctrl, tableid) {
    //debugger;
    var table = document.getElementById(tableid);
    var chkchilds = table.getElementsByTagName('input');
    if (chkchilds.length > 0) {
        for (var i = 1; i < chkchilds.length; i = i + 2) {
            chkchilds[i].checked = ctrl.checked;
        }
    }
}
function GetRadioValue(RadioName) {
    var obj;
    obj = document.getElementsByName(RadioName);
    if (obj != null) {
        var i;
        for (i = 0; i < obj.length; i++) {
            if (obj[i].checked) {
                return obj[i];
            }
        }
    }
    return null;
}
//检查textbox文字个数
function setMaxLength(object, length) {
    var result = true;
    var controlid = document.selection.createRange().parentElement().id;
    var controlValue = document.selection.createRange().text;
    if (controlid == object.id && controlValue != "") {
        result = true;
    }
    else if (object.value.length >= length) {
        result = false;
    }
    if (window.event) {
        window.event.returnValue = result;
        return result;
    }
}
//控制并计算字数
function countfonts(object, length) {
    var result = true;
    var controlid = document.selection.createRange().parentElement().id;
    var FontCount = document.getElementById("fontcount");
    var TxtContent = document.getElementById("TxtContent").value;
    var sum = 500 - TxtContent.length;
    if (controlid == object.id) {
        result = true;
        FontCount.innerHTML = sum;
    }
    if (object.value.length >= length) {
        result = false;
    }
    if (window.event) {
        window.event.returnValue = result;
        return result;
    }
}

//Check maxlength for multiline TextBox when paste 
function limitPaste(object, length) {
    var tempLength = 0;
    if (document.selection) {
        if (document.selection.createRange().parentElement().id == object.id) {
            tempLength = document.selection.createRange().text.length;
        }
    }
    var tempValue = window.clipboardData.getData("Text");
    tempLength = object.value.length + tempValue.length - tempLength;
    if (tempLength > length) {
        tempLength -= length;
        tempValue = tempValue.substr(0, tempValue.length - tempLength);
        window.clipboardData.setData("Text", tempValue);
    }

    window.event.returnValue = true;
}

//判断checkbox是否选中
function GetSelectedCount(tableid) {
    var count = false;
    var table = document.getElementById(tableid);
    var chkchilds = table.getElementsByTagName('input');
    if (chkchilds.length > 0) {
        for (var i = 1; i < chkchilds.length; i++) {
            if (chkchilds[i].checked) {
                count = true;
                break;
            }
        }
    }
    return count;
}

function GetComSelectedCount(tableid) {
    var count = false;
    var table = document.getElementById(tableid);
    var chkchilds = table.getElementsByTagName('input');
    if (chkchilds.length > 0) {
        for (var i = 0; i < chkchilds.length; i++) {
            if (chkchilds[i].checked) {
                count = true;
                break;
            }
        }
    }
    return count;
}

// 删除提示
function PubDelete() {
    if (!confirm("" + HTrackingLang.OperateDelete + "")) {
        return false;
    }
    return true;
}



//Success、Warning、Error弹出框
function openSuccessMsg(oTitle, msg, width, height, url) {
    $("body").append('<div id="SuccessDialog" class="msg-dialog" style="display:none"></div>');
    $("#SuccessDialog").dialog({
        bgiframe: true,
        width: width,
        height: height,
        buttons: {
            确定: function () {
                $(this).dialog('close');
                if (url != '') {
                    window.location.href(url);
                }
            }
        }
    });
    var oMsg = '<p class="success">' + msg + '</p>'
    $("#SuccessDialog").html(oMsg);
    $(".ui-dialog-title").html(oTitle);
}

function openWarningMsg(oTitle, msg, width, height, url) {
    $("body").append('<div id="msg-dialog" style="display:none"></div>')
    $("#msg-dialog").html("");
    $("#msg-dialog").dialog({
        bgiframe: true,
        width: width,
        height: height,
        buttons: {
            确定: function () {
                $(this).dialog('close');
                if (url != '') {
                    window.location.href(url);
                }
            }
        }
    });
    var oMsg = '<p class="warning">' + msg + '</p>'
    $("#msg-dialog").html(oMsg);
    $(".ui-dialog-title").html(oTitle);
}

function openErrorMsg(oTitle, msg, width, height, url) {
    $("body").append('<div id="ErrorDialog" class="msg-dialog" style="display:none"></div>');
    $("#ErrorDialog").dialog({
        bgiframe: true,
        width: width,
        height: height,
        buttons: {
            确定: function () {
                $(this).dialog('close');
                if (url != '') {
                    window.location.href(url);
                }
            }
        }
    });
    var oMsg = '<p class="error">' + msg + '</p>'
    $("#ErrorDialog").html(oMsg);
    $(".ui-dialog-title").html(oTitle);
}

function SaveSuccess() {
    openSuccessMsg(HTrackingLang.SuccessTitle, HTrackingLang.SaveMessage, 300, 150, '')
}

function SaveSuccessBack(url) {
    openSuccessMsg(HTrackingLang.SuccessTitle, HTrackingLang.SaveMessage, 300, 150, url)
}

function RedirectSuccess(content, url) {
    openSuccessMsg(HTrackingLang.SuccessTitle, content, 300, 150, url)
}
function RedirectWarning(content, url) {
    openWarningMsg(HTrackingLang.WarningTitle, content, 300, 150, url)
}

function RedirectError(content, url) {
    openErrorMsg(HTrackingLang.FailTitle, content, 300, 150, url)
}

function SaveFail() {
    openErrorMsg(HTrackingLang.FailTitle, HTrackingLang.SaveFail, 300, 150, '')
}
function formatalert() {
    openErrorMsg(HTrackingLang.FailTitle, HTrackingLang.AlertFormat, 300, 150, '')
}
//大小
function logosizealert() {
    openErrorMsg(HTrackingLang.FailTitle, HTrackingLang.AlertSize, 300, 150, '')
}
//上传出错
function logouploaderroralert() {
    openErrorMsg(HTrackingLang.FailTitle, HTrackingLang.AlertUploadError, 300, 150, '')
}

function FileUploadNot() {
    openErrorMsg(HTrackingLang.FailTitle, HTrackingLang.OperateFileUploadNot, 300, 150, '')
}

function mailSendAlert() {
    openSuccessMsg(HTrackingLang.SuccessTitle, HTrackingLang.mailSendAlert, 300, 150, '')
}
function CandidateEmail() {
    openSuccessMsg(HTrackingLang.FailTitle, HTrackingLang.OperateCandidateEmail, 300, 150, '')
}
function IsValidDate(dateValue) {
    try {
        var checkDate = new Date(dateValue);

        var day = dateValue.substr(3, 2);
        var month = dateValue.substr(0, 2);
        var year = dateValue.substr(6, 4);

        if (month != "12" && month != "11" && month != "10") {
            month = month.substr(1, 1);
        }

        if (day == "01" || day == "02" || day == "03" || day == "04" || day == "05" ||
        day == "06" || day == "07" || day == "08" || day == "09") {
            day = day.substr(1, 1);
        }

        if (checkDate.getDate().toString() != day) {
            return false;
        }

        if ((checkDate.getMonth() + 1).toString() != month) {
            return false;
        }

        if (checkDate.getFullYear().toString() != year) {
            return false;
        }

        return true;
    }
    catch (E) { return false; }

}
function Pub_ShowDiv(obj, state, location, param, status) {
    var divname = "pub_mdiv";
    if (state.toLowerCase() == "show") {
        Pub_CreateDiv(divname, param, status);
    }
    Pub_showmenu(obj, divname, state, location, param);
}
//创建弹出层.并绑定用户信息
function Pub_CreateDiv(obj, param, status) {
    var btn = document.getElementById(obj);
    if (btn == null) {
        var str = document.createElement("div");
        str.id = obj;
        str.style.position = "absolute";
        str.style.left = "0px";
        str.style.top = "0px";
        str.style.background = "#ffffff";
        //str.style.visibility = "hidden";
        str.style.padding = "5px";
        str.style.filter = "Alpha(Opacity=80)";   //ie下的透明度设置
        str.style.opacity = "0.8";                //firefox 的透明度设置  
        document.body.appendChild(str);
        var temp = "<div id=\"" + obj + "_message\" >" + HTrackingLang.DataLoading + "</div> ";

        $("#" + obj).empty();
        $("#" + obj).append(temp);
    }
    $("#" + obj + "_message").empty();
    var OptDiv;
    OptDiv = "       <div class=\"popupmenu_popup\"> ";
    OptDiv += "           <ul>";

    switch (status) {
        case "0": // 删除
            OptDiv += "               <li><a href=\"JobActivityLog.aspx?JobID=" + param + "\">" + HTrackingLang.SystemLog + "</a></li>";
            OptDiv += "               <li><a href=\"JobCost.aspx?JobID=" + param + "\">" + HTrackingLang.JobCost + "</a></li>";
            OptDiv += "               <li><a href=\"JobTrace.aspx?JobID=" + param + "\">" + HTrackingLang.ActivityLog + "</a></li>";
            OptDiv += "               <li><a href=\"Job.aspx?JobID=" + param + "\">" + HTrackingLang.JobStatus + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"CopyJob('" + param + "');\">" + HTrackingLang.CopyJob + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"showModalDialog('EmailDeliver.aspx?JobID=" + param + "','" + HTrackingLang.EmailDeliver + "','dialogWidth:600px;dialogHeight:450px;status:0;help:0');\">" + HTrackingLang.EmailDeliver + "</a></li>";
            OptDiv += "               <li><a href=\"JobStatusLog.aspx?JobID=" + param + "\">" + HTrackingLang.ChangeJobStatus + "</a></li>";
            //OptDiv += "               <li><a href=\"JobPrint.aspx?JobID=" + param + "\">" + HTrackingLang.PrintPosition + "</a></li>";
            //OptDiv += "               <li><a href=\"#\"  onclick=\"PubShowPopWin('PrintChoose.aspx?JobID=" + param + "',210,220,'" + HTrackingLang.PrintPosition + "');\" >" + HTrackingLang.PrintPosition + "</a></li>";

            OptDiv += "               <li><a href=\"#\"  onclick=\"showModalDialog('PrintChoose.aspx?JobID=" + param + "','" + HTrackingLang.PrintPosition + "','dialogWidth:200px;dialogHeight:200px;status:0;help:0');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            // showModalDialog( "SelectOperater.aspx ",   " ",   "dialogWidth:330px;   dialogHeight:420px;   status:0;   help:0 "); 

            break;
        case "1": // 草稿
            OptDiv += "               <li><a href=\"JobStatusLog.aspx?JobID=" + param + "\">" + HTrackingLang.ChangeJobStatus + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"CopyJob('" + param + "');\">" + HTrackingLang.CopyJob + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"DelJob('" + param + "');\">" + HTrackingLang.DeletePosition + "</a></li>";
            OptDiv += "               <li><a href=\"#\">" + HTrackingLang.PrintPosition + "</a></li>";
            break;
        case "2": // 待批准
            OptDiv += "               <li><a href=\"JobActivityLog.aspx?JobID=" + param + "\">" + HTrackingLang.SystemLog + "</a></li>";
            OptDiv += "               <li><a href=\"JobCost.aspx?JobID=" + param + "\">" + HTrackingLang.JobCost + "</a></li>";
            OptDiv += "               <li><a href=\"JobTrace.aspx?JobID=" + param + "\">" + HTrackingLang.ActivityLog + "</a></li>";
            OptDiv += "               <li><a href=\"FulfillTeam.aspx?type=JobSetLeft&JobID=" + param + "\">" + HTrackingLang.DistributionRecruitment + "</a></li>";
            OptDiv += "               <li><a href=\"JobStatusLog.aspx?JobID=" + param + "\">" + HTrackingLang.ChangeJobStatus + "</a></li>";
            OptDiv += "               <li><a href=\"Job.aspx?JobID=" + param + "\">" + HTrackingLang.JobStatus + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"CopyJob('" + param + "');\">" + HTrackingLang.CopyJob + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"showModalDialog('EmailDeliver.aspx?JobID=" + param + "','" + HTrackingLang.EmailDeliver + "','dialogWidth:600px;dialogHeight:450px;status:0;help:0');\">" + HTrackingLang.EmailDeliver + "</a></li>";
            //OptDiv += "               <li><a href=\"JobPrint.aspx?JobID=" + param + "\">" + HTrackingLang.PrintPosition + "</a></li>";
            //OptDiv += "               <li><a href=\"#\"  onclick=\"PubShowPopWin('PrintChoose.aspx?JobID=" + param + "',210,220,'" + HTrackingLang.PrintPosition + "');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            OptDiv += "               <li><a href=\"#\"  onclick=\"showModalDialog('PrintChoose.aspx?JobID=" + param + "','" + HTrackingLang.PrintPosition + "','dialogWidth:200px;dialogHeight:200px;status:0;help:0');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            break;
        case "3": // 开放
            OptDiv += "               <li><a href=\"JobActivityLog.aspx?JobID=" + param + "\">" + HTrackingLang.SystemLog + "</a></li>";
            OptDiv += "               <li><a href=\"JobCost.aspx?JobID=" + param + "\">" + HTrackingLang.JobCost + "</a></li>";
            OptDiv += "               <li><a href=\"JobTrace.aspx?JobID=" + param + "\">" + HTrackingLang.ActivityLog + "</a></li>";
            OptDiv += "               <li><a href=\"FulfillTeam.aspx?type=JobSetLeft&JobID=" + param + "\">" + HTrackingLang.DistributionRecruitment + "</a></li>";
            OptDiv += "               <li><a href=\"JobStatusLog.aspx?JobID=" + param + "\">" + HTrackingLang.ChangeJobStatus + "</a></li>";
            OptDiv += "               <li><a href=\"Job.aspx?JobID=" + param + "\">" + HTrackingLang.JobStatus + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"CopyJob('" + param + "');\">" + HTrackingLang.CopyJob + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"showModalDialog('EmailDeliver.aspx?JobID=" + param + "','" + HTrackingLang.EmailDeliver + "','dialogWidth:600px;dialogHeight:450px;status:0;help:0');\">" + HTrackingLang.EmailDeliver + "</a></li>";
            //OptDiv += "               <li><a href=\"JobPrint.aspx?JobID=" + param + "\">" + HTrackingLang.PrintPosition + "</a></li>";
            //OptDiv += "               <li><a href=\"#\"  onclick=\"PubShowPopWin('PrintChoose.aspx?JobID=" + param + "',210,220,'" + HTrackingLang.PrintPosition + "');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            OptDiv += "               <li><a href=\"#\"  onclick=\"showModalDialog('PrintChoose.aspx?JobID=" + param + "','" + HTrackingLang.PrintPosition + "','dialogWidth:200px;dialogHeight:200px;status:0;help:0');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            break;
        case "4": // 冻结
            OptDiv += "               <li><a href=\"JobActivityLog.aspx?JobID=" + param + "\">" + HTrackingLang.SystemLog + "</a></li>";
            OptDiv += "               <li><a href=\"JobTrace.aspx?JobID=" + param + "\">" + HTrackingLang.ActivityLog + "</a></li>";
            OptDiv += "               <li><a href=\"Job.aspx?JobID=" + param + "\">" + HTrackingLang.JobStatus + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"CopyJob('" + param + "');\">" + HTrackingLang.CopyJob + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"showModalDialog('EmailDeliver.aspx?JobID=" + param + "','" + HTrackingLang.EmailDeliver + "','dialogWidth:600px;dialogHeight:450px;status:0;help:0');\">" + HTrackingLang.EmailDeliver + "</a></li>";
            OptDiv += "               <li><a href=\"JobStatusLog.aspx?JobID=" + param + "\">" + HTrackingLang.ChangeJobStatus + "</a></li>";
            //OptDiv += "               <li><a href=\"JobPrint.aspx?JobID=" + param + "\">" + HTrackingLang.PrintPosition + "</a></li>";
            //OptDiv += "               <li><a href=\"#\"  onclick=\"PubShowPopWin('PrintChoose.aspx?JobID=" + param + "',210,220,'" + HTrackingLang.PrintPosition + "');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            OptDiv += "               <li><a href=\"#\"  onclick=\"showModalDialog('PrintChoose.aspx?JobID=" + param + "','" + HTrackingLang.PrintPosition + "','dialogWidth:200px;dialogHeight:200px;status:0;help:0');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            break;
        case "5": // 暂停
            OptDiv += "               <li><a href=\"JobActivityLog.aspx?JobID=" + param + "\">" + HTrackingLang.SystemLog + "</a></li>";
            OptDiv += "               <li><a href=\"JobCost.aspx?JobID=" + param + "\">" + HTrackingLang.JobCost + "</a></li>";
            OptDiv += "               <li><a href=\"JobTrace.aspx?JobID=" + param + "\">" + HTrackingLang.ActivityLog + "</a></li>";
            OptDiv += "               <li><a href=\"FulfillTeam.aspx?type=JobSetLeft&JobID=" + param + "\">" + HTrackingLang.DistributionRecruitment + "</a></li>";
            OptDiv += "               <li><a href=\"JobStatusLog.aspx?JobID=" + param + "\">" + HTrackingLang.ChangeJobStatus + "</a></li>";
            OptDiv += "               <li><a href=\"Job.aspx?JobID=" + param + "\">" + HTrackingLang.JobStatus + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"CopyJob('" + param + "');\">" + HTrackingLang.CopyJob + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"showModalDialog('EmailDeliver.aspx?JobID=" + param + "','" + HTrackingLang.EmailDeliver + "','dialogWidth:600px;dialogHeight:450px;status:0;help:0');\">" + HTrackingLang.EmailDeliver + "</a></li>";
            //OptDiv += "               <li><a href=\"JobPrint.aspx?JobID=" + param + "\">" + HTrackingLang.PrintPosition + "</a></li>";
            //OptDiv += "               <li><a href=\"#\"  onclick=\"PubShowPopWin('PrintChoose.aspx?JobID=" + param + "',210,220,'" + HTrackingLang.PrintPosition + "');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            OptDiv += "               <li><a href=\"#\"  onclick=\"showModalDialog('PrintChoose.aspx?JobID=" + param + "','" + HTrackingLang.PrintPosition + "','dialogWidth:200px;dialogHeight:200px;status:0;help:0');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            break;
        case "6": // 关闭
            OptDiv += "               <li><a href=\"JobActivityLog.aspx?JobID=" + param + "\">" + HTrackingLang.SystemLog + "</a></li>";
            OptDiv += "               <li><a href=\"JobCost.aspx?JobID=" + param + "\">" + HTrackingLang.JobCost + "</a></li>";
            OptDiv += "               <li><a href=\"JobTrace.aspx?JobID=" + param + "\">" + HTrackingLang.ActivityLog + "</a></li>";
            OptDiv += "               <li><a href=\"Job.aspx?JobID=" + param + "\">" + HTrackingLang.JobStatus + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"CopyJob('" + param + "');\">" + HTrackingLang.CopyJob + "</a></li>";
            OptDiv += "               <li><a href=\"#\" onclick=\"showModalDialog('EmailDeliver.aspx?JobID=" + param + "','" + HTrackingLang.EmailDeliver + "','dialogWidth:600px;dialogHeight:450px;status:0;help:0');\">" + HTrackingLang.EmailDeliver + "</a></li>";
            //OptDiv += "               <li><a href=\"JobPrint.aspx?JobID=" + param + "\">" + HTrackingLang.PrintPosition + "</a></li>";
            //OptDiv += "               <li><a href=\"#\"  onclick=\"PubShowPopWin('PrintChoose.aspx?JobID=" + param + "',210,220,'" + HTrackingLang.PrintPosition + "');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            OptDiv += "               <li><a href=\"#\"  onclick=\"showModalDialog('PrintChoose.aspx?JobID=" + param + "','" + HTrackingLang.PrintPosition + "','dialogWidth:200px;dialogHeight:200px;status:0;help:0');\" >" + HTrackingLang.PrintPosition + "</a></li>";
            break;
        default:
            break;
    }
    OptDiv += "           </ul>";
    OptDiv += "       </div>";


    $("#" + obj + "_message").append(OptDiv);
}

var Pub_menuTimer = null;
//控制弹出显示或隐藏
function Pub_showmenu(obj1, obj2, state, location, param) {

    var btn = document.getElementById(obj1);
    var obj = document.getElementById(obj2);
    var h = btn.offsetHeight;
    var w = btn.offsetWidth;
    var x = btn.offsetLeft;
    var y = btn.offsetTop;

    obj.onmouseover = function () {
        Pub_showmenu(obj1, obj2, 'show', location, param);
    }
    obj.onmouseout = function () {
        Pub_showmenu(obj1, obj2, 'hide', location, param);
    }

    while (btn = btn.offsetParent) { y += btn.offsetTop; x += btn.offsetLeft; }

    var hh = obj.offsetHeight;
    var ww = obj.offsetWidth;
    var xx = obj.offsetLeft; //style.left;
    var yy = obj.offsetTop; //style.top;
    var obj2state = state.toLowerCase();
    var obj2location = location.toLowerCase();

    var showx, showy;

    if (obj2location == "left" || obj2location == "l" || obj2location == "top" || obj2location == "t" || obj2location == "u" || obj2location == "b" || obj2location == "r" || obj2location == "up" || obj2location == "right" || obj2location == "bottom") {
        if (obj2location == "left" || obj2location == "l") { showx = x - ww; showy = y; }
        if (obj2location == "top" || obj2location == "t" || obj2location == "u") { showx = x; showy = y - hh; }
        if (obj2location == "right" || obj2location == "r") { showx = x + w; showy = y; }
        if (obj2location == "bottom" || obj2location == "b") { showx = x; showy = y + h; }
    } else {
        showx = xx; showy = yy;
    }
    obj.style.left = showx + "px";
    obj.style.top = showy + "px";
    if (state == "hide") {
        Pub_menuTimer = setTimeout("Pub_hiddenmenu('" + obj2 + "')", 100);

    } else {
        clearTimeout(Pub_menuTimer);
        obj.style.visibility = "visible";


    }
}
function OpenWin(page, height, width) {
    window.open(page, "", "height=" + height + ", width=" + width + ", toolbar =no, menubar=no, scrollbars=no, resizable=no, location=no, status=no");

}


//隐藏弹出层
function Pub_hiddenmenu(psObjId) {
    document.getElementById(psObjId).style.visibility = "hidden";
}
// 公用删除
function Delete() {
    if (PubDelete()) {
        return true;
    }
    else {
        return false;
    }
}
// 通用
function CommonDelete(tabid) {
    if (GetComSelectedCount(tabid) > 0) {
        if (PubDelete()) {
            return true;
        }
        else {
            return false;
        }
    } else {
        return false;
    }
}

//打开等待窗口函数
function OpenLoadingWin() {
    $("body").append('<div id="loadingMask"></div>');
    $("body").append('<div id="loadingDialog"><p><img src="/HireTracking/Images/Default/loading.gif" />' + HTrackingLang.LoadWaiting + '</p></div>');
    resizeLoadingWin();
}
//关闭等待窗口函数
function CloseLoadingWin() {
    $("#loadingMask").remove();
    $("#loadingDialog").remove();
}

function resizeLoadingWin() {
    var brsW = $(window).width();
    var brsH = $(window).height();
    var sclL = $(window).scrollLeft();
    var sclT = $(window).scrollTop();
    var docH = $(document).height();
    var objW = $("#loadingDialog").width();
    var objH = $("#loadingDialog").height();
    var left = sclL + (brsW - objW) / 2;
    var top = sclT + (brsH - objH) / 2;
    $("#loadingMask").css("height", docH);
    $("#loadingDialog").css({ "left": left, "top": top });
}

function switchSkin(skinName) {
    $("#" + skinName).addClass("selected").siblings().removeClass("selected");
    $("#ctl00_cssfile").attr("href", "../../Style/SkinHeader/" + skinName + ".css");
    $.cookie("MyCssSkin", skinName, { path: '/', expires: 10 });
}

$(function () {
    //换肤
    $("#skin li").click(function () {
        switchSkin(this.id);
    });
    var cookie_skin = $.cookie("MyCssSkin");
    if (cookie_skin) {
        switchSkin(cookie_skin);
    }

    //表格无内容时IE7下显示不了边框
    $(".hxr-gzjy td").each(function () {
        var tdText = $(this).text();
        if (tdText == "") {
            $(this).append("&nbsp;");
        }
    });



    $(window).resize(function () {
        if (!$("#loadingDialog").is(":visible")) {
            return;
        }
        resizeLoadingWin();
    });

    //
    var _move = false; //移动标记
    var _x, _y; //鼠标离控件左上角的相对位置
    $(".WindowsDialog").mousedown(function (e) {
       // _move = true;
        _x = e.pageX - parseInt($(".WindowsDialog").css("left"));
        _y = e.pageY - parseInt($(".WindowsDialog").css("top"));
    });
    $(document).mousemove(function (e) {
        if (_move) {
            var x = e.pageX - _x; //移动时根据鼠标位置计算控件左上角的绝对位置
            var y = e.pageY - _y;
            $(".WindowsDialog").css({ top: y, left: x }); //控件新位置
        }
    }).mouseup(function () {
        _move = false;
    });

});