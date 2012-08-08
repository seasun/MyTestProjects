<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>利用Google Jar壓縮JS</title>
    <link href="../../Content/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.7.min.js" type="text/javascript"></script>
</head>
<body>
    <input type="button" id="action" value="開始壓縮" />
    <input type="radio" name="compressWay" id="normal" value="0" checked="checked" /><label
        for="normal">最佳压缩</label>
    <input type="radio" name="compressWay" id="whitespace_only" value="1" /><label for="whitespace_only">只去掉空格</label>
    <div style="color: #009900" id="mes">
    </div>
    <textarea style="color: #c2c2c2; font-size: 12px; width: 1000px; height: 50px;" id="error">
        壓縮JS一些error或waring信息將會在這裏顯示
    </textarea>
    <div class="bodyleft">
        <h5>
            原始JS</h5>
        <textarea class="ori_js"></textarea>
    </div>
    <div class="bodyright">
        <h5>
            壓縮後的JS</h5>
        <textarea class="comp_js"></textarea>
    </div>
    <script type="text/javascript">
        $("#action").on("click", function () {
            $("#mes").css("color", "#009900").html("正在壓縮中...");
            $("#error").val("");
            $(".comp_js").val("");
            var params = { jsContent: encodeURIComponent($(".ori_js").val()), compressWay: $("input[name=compressWay]:checked").val() };
            var jqxhr = $.post("/home/compress", params, function (data) {
                if (data.status === 1) {
                    $("#mes").css("color", "#009900");
                    $("#mes").html("Congratulation！压缩后文件大小：" + Math.round(data.compressedFileSize * 10) / 10 + "KB  压缩比例达到:" + (100 - Math.round((data.compressedFileSize / data.unCompressFileSize) * 10000) / 100) + "%");
                    console.log("压缩前：" + data.unCompressFileSize);
                    console.log("压缩后：" + data.compressedFileSize);
                    console.log(data.compressedFileSize / data.compressedFileSize);
                    console.log(Math.round((data.compressedFileSize / data.unCompressFileSize) * 10000));
                    $(".comp_js").val(decodeURIComponent(data.msg));
                    $("#error").val(data.error ? decodeURIComponent(data.error) : "");
                }
                else {
                    $("#mes").css("color", "#f00");
                    $("#mes").html(data.msg);
                    $("#error").val(data.excetion ? decodeURIComponent(data.excetion) : "");
                }
            }, "json");
        });
    </script>
</body>
</html>
