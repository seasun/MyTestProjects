<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>
    <link href="/Scripts/uploadify-v3.1/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery-1.7.min.js" type="text/javascript"></script>
    <script src="/Scripts/uploadify-v3.1/jquery.uploadify-3.1.min.js" type="text/javascript"></script>
    <style type="text/css">
        .uploadify-button
        {
            background-color: transparent;
            border: 0;
            padding: 0;
            background-position: 0 0;
        }
        .uploadify:hover .uploadify-button
        {
            background-color: transparent;
            background-position: 0 -30px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#file_upload_1").uploadify({
                swf: '/Scripts/uploadify-v3.1/uploadify.swf',
                uploader: '/File/Upload',
                fileTypeExts: '*.mp4;*.mov;*.mp3;*.aac',
                fileTypeDesc: 'mp4,mov,mp3,aac', //打開文件框時顯示的文字(下拉列表)
                fileSizeLimit: '150MB',
                uploadLimit: '5', //允許同時進行上傳的文件數
                buttonImage: '/Scripts/uploadify-v3.1/img/browse-btn.png',
                buttonText: '上傳大文件',
                debug: true,
                height: 20,
                width: 78,
                onUploadComplete: function (file, data, response) {
                    alert('The file ' + file.name + ' was successfully uploaded with a response of ' + response + ':' + data);
                },
                onUploadError: function (file, errorCode, errorMsg, errorString) {
                    alert('The file ' + file.name + ' could not be uploaded: ' + errorString);
                }
            });
        });
    </script>
</head>
<body>
    <div id="file_upload_1">
    </div>
</body>
</html>
